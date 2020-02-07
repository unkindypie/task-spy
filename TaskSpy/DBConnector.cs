using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace TaskSpy
{
    class DBConnector
    {
        SqlConnection connection = new SqlConnection();
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        static string server = "";
        static string serverIp = "";
        static string userId = "";
        static string password = "";
        static DBConnector self = null;
        public static void SetCredentials(string server, string serverIp, string userId, string password)
        {
            DBConnector.server = server;
            DBConnector.userId = userId;
            DBConnector.password = password;
            DBConnector.serverIp = serverIp;
        }
        protected DBConnector()
        {
            if(serverIp != "")
            {
                builder.DataSource = serverIp + "\\" + server;
            }
            else
            {
                builder.DataSource = server;
            }
         
            builder.InitialCatalog = @"task-spy";
            builder.UserID = userId;
            builder.Password = password;
            connection.ConnectionString = builder.ConnectionString;
        }
        public long createReport(long totalMemoryLoad, float totalCpuLoad, string machineName, string localIP)
        {
            SqlCommand cmd = new SqlCommand($"insert into reports_mutator values ({totalMemoryLoad}, @totalCPULoad, '{machineName}','{localIP}')", connection);
            cmd.Parameters.AddWithValue("@totalCPULoad", SqlDbType.Float).Value = totalCpuLoad;
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        public void sendProcess(long reportId, ProcessModel processModel)
        {
            SqlCommand cmd = new SqlCommand($"insert into processes_mutator values ({reportId}, @cpuLoad, {processModel.memoryUsage}, "+
                $"{processModel.pid}, {processModel.parentPID}, '{processModel.name}', '{processModel.path}'," 
                + $" {(processModel.isSystem? 1 : 0)}, '{processModel.owner}', {(processModel.isOwnerReal ? 1 : 0)})", connection);
            cmd.Parameters.AddWithValue("@cpuLoad", SqlDbType.Float).Value = processModel.cpuUsage;
            cmd.ExecuteNonQuery();
        }

        public void sendProcesses(long reportId, List<ProcessModel> processes)
        {
            string commandText = "insert into processes_mutator values";
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            //динамически генерирую один большой insert для всех процессов
            foreach (ProcessModel p in processes)
            {
                commandText += $"({reportId}, @cpuLoad{i}, {p.memoryUsage}, " +
                $"{p.pid}, {p.parentPID}, '{p.name}', '{p.path}',"
                + $" {(p.isSystem ? 1 : 0)}, '{p.owner}', {(p.isOwnerReal ? 1 : 0)})";
                cmd.Parameters.AddWithValue("@cpuLoad" + i, SqlDbType.Float).Value = p.cpuUsage;
                i++;
                if(i < processes.Count)
                {
                    commandText += ", ";
                }
            }
            cmd.CommandText = commandText;
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }
        public void approveReport(long reportId)
        {
            SqlCommand cmd = new SqlCommand($"update reports set created = GETDATE() where id = {reportId}", connection);
            cmd.ExecuteNonQuery();
        }

        public static DBConnector Self
        {
            get
            {
                if (self == null)
                {
                    self = new DBConnector();
                }
                return self;
            }
        }

        public bool Connect()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            if (connection.State != System.Data.ConnectionState.Open)
            {
                return false;
            }
            return true;
        }

        public bool Disconect()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}

