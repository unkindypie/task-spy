using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TaskSpyAdminPanel.Models;
using TaskSpyAdminPanel.Config;

namespace TaskSpyAdminPanel.DB
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
            builder.MultipleActiveResultSets = true;
            connection.ConnectionString = builder.ConnectionString;

        }
        public List<User> fetchUsers()
        {
            List<User> users = new List<User>();
            SqlCommand cmd = new SqlCommand($"select local_username, pseudonym, id from users where is_real = 1", connection);
            var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            
            foreach(DataRow row in table.Rows)
            {
                users.Add(new User(row["local_username"].ToString(), row["pseudonym"].ToString(), int.Parse(row["id"].ToString()), true));
            }

            return users;
        }
        public DataTable fetchProcesses(long userId, long machineId)
        {
            string commandText = $"execute last_user_report {userId}, {(ConfigManager.Config.showEveryUser ? 1 : 0)}, {machineId}";
            
            SqlCommand cmd = new SqlCommand(commandText, connection);
            //MessageBox.Show(commandText);
            var reader = cmd.ExecuteReader();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }
        public async Task<DataTable> fetchProcessesAsync(long userId, long machineId, bool showEveryUser)
        {
            string commandText = $"execute last_user_report {userId}, {(showEveryUser? 1 : 0)}, {machineId}";

            SqlCommand cmd = new SqlCommand(commandText, connection);
            //MessageBox.Show(commandText);
            var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        public async Task<List<Machine>> fetchUserMachines(long userId)
        {
            string commandText = $"execute get_user_machines {userId}";
            SqlCommand cmd = new SqlCommand(commandText, connection);
            var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            var machines = new List<Machine>();
            
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                machines.Add(new Machine() {
                    Name = row["name"].ToString(),
                    Id = long.Parse(row["machine_id"].ToString()),
                    LastReport = DateTime.Parse(row["created"].ToString())
                });
            }
            //сортирую по времени отчета, чтобы сверху были машины
            //со свежими отчетами
            machines = machines.OrderByDescending(m => m.LastReport).ToList();

            return machines;

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

