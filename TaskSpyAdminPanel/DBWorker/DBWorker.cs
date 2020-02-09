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

        //public async Task<List<Process>> fetchProcessesAsync(long userId, long machineId, bool showEveryUser)
        //{
        //    string commandText = $"execute last_user_report {userId}, {(showEveryUser ? 1 : 0)}, {machineId}";

        //    SqlCommand cmd = new SqlCommand(commandText, connection);
        //    //MessageBox.Show(commandText);
        //    var reader = await cmd.ExecuteReaderAsync();
        //    var table = new DataTable();
        //    var processes = new List<Process>();
        //    table.Load(reader);
        //    foreach (DataRow r in table.Rows)
        //    {
        //        processes.Add(new Process(long.Parse(r["id"].ToString()), bool.Parse(r["is_system"].ToString())) {
        //            CPU = float.Parse(r["cpu_load"].ToString()),
        //            Mem = long.Parse(r["mem_load"].ToString()),
        //            ProcessName = r["procname"].ToString(),
        //            PID = int.Parse(r["pid"].ToString()),
        //            ParentPID = int.Parse(r["parent_pid"].ToString()),
        //        });
        //    }
            
        //    return processes;
        //}

        public async Task<DataTable> fetchProcessesTableAsync(long userId, long machineId, bool showEveryUser)
        {
            string commandText = $"execute last_user_report {userId}, {(showEveryUser ? 1 : 0)}, {machineId}";


            SqlCommand cmd = new SqlCommand(commandText, connection);
            //MessageBox.Show(commandText);
            var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            var processes = new List<Process>();
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
        public async Task<DateTime> lastReport(long userId, long machineId)
        {
            SqlCommand cmd = new SqlCommand($"select max(created) as created " +
                $"from reports join processes on report_id = reports.id" +
                $" where user_id = {userId} and machine_id = {machineId}", connection);
            var result = await cmd.ExecuteScalarAsync();
            return DateTime.Parse(result.ToString());
        }
        public async Task<Process> fetchProcessAsync(int pid, long machineId)
        {
            SqlCommand cmd = new SqlCommand($"execute get_process {pid}, {machineId}", connection);
            var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            table.Load(reader);
            var row = table.Rows[0];
            return new Process()
            {
                ProcessName = row["name"].ToString(),
                BinPath = row["bin_path"].ToString(),
                CPU = float.Parse(row["cpu_load"].ToString()),
                Mem = long.Parse(row["mem_load"].ToString()),
                PID  = int.Parse(row["pid"].ToString()),
                ParentPID = int.Parse(row["parent_pid"].ToString()),
                IsSystem = bool.Parse(row["is_system"].ToString()),
                InWhitelist = bool.Parse(row["in_whitelist"].ToString()),
                Report = new Report { Created = (DateTime)row["created"] },
                User = new User { Name = row["local_username"].ToString() },
                Id = long.Parse(row["id"].ToString()),
            };
        }
        public void whitelistProcess(long processId, bool value) {
            if (self.Connect())
            {
                SqlCommand cmd = new SqlCommand($"execute set_proc_whitelist {processId}, {(value ? 1 : 0)}", connection);
                cmd.ExecuteNonQuery();
            }

        }
        public void setPseudonym(long userId, string pseudonym)
        {
            if (self.Connect())
            {
                string commandText =
                      $" update users set pseudonym = '{pseudonym}' where id = {userId}";
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.ExecuteNonQuery();
            }
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

        public bool Connect(bool showConnectionAlert = true)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            if (connection.State != System.Data.ConnectionState.Open)
            {
                if (showConnectionAlert)
                {
                    MessageBox.Show("Не удается соедениться с сервером. ");
                }
            
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

