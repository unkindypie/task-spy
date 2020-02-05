using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpyAdminPanel.DBWorker
{
    class DBWorker
    {
        SqlConnection connection = new SqlConnection();
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        static string server = "";
        static string serverIp = "";
        static string userId = "";
        static string password = "";
        static DBWorker self = null;
        public static void SetCredentials(string server, string serverIp, string userId, string password)
        {
            DBWorker.server = server;
            DBWorker.userId = userId;
            DBWorker.password = password;
            DBWorker.serverIp = serverIp;
        }
        protected DBWorker()
        {
            if (serverIp != "")
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
        //public long createReport(long totalMemoryLoad, float totalCpuLoad, string machineName, string localIP)
        //{
        //    SqlCommand cmd = new SqlCommand($"insert into reports_mutator values ({totalMemoryLoad}, @totalCPULoad, '{machineName}','{localIP}')", connection);
        //    cmd.Parameters.AddWithValue("@totalCPULoad", SqlDbType.Float).Value = totalCpuLoad;
        //    return int.Parse(cmd.ExecuteScalar().ToString());
        //}
        //public void sendProcess(long reportId, ProcessModel processModel)
        //{
        //    SqlCommand cmd = new SqlCommand($"insert into processes_mutator values ({reportId}, @cpuLoad, {processModel.memoryUsage}, " +
        //        $"{processModel.pid}, {processModel.parentPID}, '{processModel.name}', '{processModel.path}',"
        //        + $" {(processModel.isSystem ? 1 : 0)}, '{processModel.owner}', {(processModel.isOwnerReal ? 1 : 0)})", connection);
        //    cmd.Parameters.AddWithValue("@cpuLoad", SqlDbType.Float).Value = processModel.cpuUsage;
        //    cmd.ExecuteNonQuery();
        //}

        public static DBWorker Self
        {
            get
            {
                if (self == null)
                {
                    self = new DBWorker();
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

