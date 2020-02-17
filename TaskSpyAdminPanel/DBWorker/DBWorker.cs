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
    class ProcessHistoryItem
    {
        public DateTime Created
        {
            get; set;
        }
        public float CPU
        {
            get; set;
        }
        //public long Memory
        //{
        //    get; set;
        //}
    }
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
            builder.ConnectTimeout = 5 * 60;
            connection.ConnectionString = builder.ConnectionString;

        }
        public async Task<List<User>> fetchUsers(string searchString)
        {
            List<User> users = new List<User>();
            SqlCommand cmd;
            try
            {
                if (searchString == "")
                {
                    cmd = new SqlCommand($"select local_username, pseudonym, id from users " +
                  $"where is_real = 1", connection);
                }
                else
                {
                    cmd = new SqlCommand($"select local_username, pseudonym, id from users " +
                    $"where is_real = 1 and local_username like '%' + @search + '%'", connection);
                    var param = new SqlParameter("@search", SqlDbType.VarChar);
                    param.Value = searchString;
                    cmd.Parameters.Add(param);
                }
                var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                foreach (DataRow row in table.Rows)
                {
                    users.Add(new User(row["local_username"].ToString(), row["pseudonym"].ToString(), int.Parse(row["id"].ToString()), true));
                }
                return users;
            } catch
            {
                MessageBox.Show("Ошибка поиска.");
                return new List<User>();
            }
     
        }

      

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


        public async Task<DataTable> getReport(long userId, long reportId, long machineId, bool showEveryUser)
        {
            string commandText = $"execute get_report {userId}, {machineId}, {(showEveryUser ? 1 : 0)}, {reportId}";

            SqlCommand cmd = new SqlCommand(commandText, connection);

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

        public async Task<DateTime> lastReport(long userId)
        {
            SqlCommand cmd = new SqlCommand($"select max(created) as created " +
                $"from reports join processes on report_id = reports.id" +
                $" where user_id = {userId}", connection);
            var result = await cmd.ExecuteScalarAsync();
            return DateTime.Parse(result.ToString());
        }
        public async Task<DateTime> firstReport(long userId)
        {
            SqlCommand cmd = new SqlCommand($"select min(created) as created " +
                $"from reports join processes on report_id = reports.id" +
                $" where user_id = {userId}", connection);
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
        public async void whitelistProcess(long processId, bool value) {
            if (self.Connect())
            {
                SqlCommand cmd = new SqlCommand($"execute set_proc_whitelist {processId}, {(value ? 1 : 0)}", connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async void whitelistAllUserProcesses(long userId, bool mode)
        {
            if (self.Connect())
            {
                var commandText = $"update processEntries " +
                    $"set in_whitelist = {(mode ? 1 : 0)} from processEntries " +
                    $"join processes on entry_id = processEntries.id" +
                    $" where user_id = {userId}";
                SqlCommand cmd = new SqlCommand(commandText, connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<List<ProcessHistoryItem>> getProcessHistory(long userId, long procId, long machineId)
        {
            if (self.Connect())
            {
                var commandText = $"execute get_process_history {userId}, {procId}, {machineId}";
                SqlCommand cmd = new SqlCommand(commandText, connection);

                var reader = await cmd.ExecuteReaderAsync();
                var table = new DataTable();
                table.Load(reader);

                List<ProcessHistoryItem> history = new List<ProcessHistoryItem>();
                foreach (DataRow r in table.Rows)
                {
                    history.Add(new ProcessHistoryItem()
                    {
                        Created = DateTime.Parse(r["created"].ToString()),
                        CPU = float.Parse(r["cpu_load"].ToString()),
                        //Memory = long.Parse(r["mem_load"].ToString())
                    });
                }
                return history;
            }
            return null;
        }

        public async Task<bool> hasUnwhitelistedProcesses(long userId)
        {
            var commandText = $"select top 1 processEntries.id" +
                            $" from processEntries, processes " +
                            $"where entry_id = processEntries.id " +
                             $"and user_id = {userId} and in_whitelist = 0";

            SqlCommand cmd = new SqlCommand(commandText, connection);
            var reader = await cmd.ExecuteReaderAsync();
            var table = new DataTable();
            table.Load(reader);

            return table.Rows.Count > 0;
        }

        public async void setPseudonym(long userId, string pseudonym)
        {
            if (self.Connect())
            {
                try
                {
                    string commandText =
                    $" update users set pseudonym = @pdm where id = {userId}";
                    SqlCommand cmd = new SqlCommand(commandText, connection);
                    var param = new SqlParameter("@pdm", SqlDbType.VarChar);
                    param.Value = pseudonym;
                    cmd.Parameters.Add(param);
                    await cmd.ExecuteNonQueryAsync();
                } catch
                {
                    MessageBox.Show("Не удалось изменить всевдоним, вы пытались поломать бд, да?");
                }
              
            }
        }

        public async Task<List<Report>> getReportList(DateTime from, long userId, int length, bool includeFrom = false, DateTime to = new DateTime(), bool showOnlyUnwhutelisted = false)
        {
            bool isToNull = to == new DateTime();
            string commandText =
                     $"execute get_report_list @from, {userId}," +
                     $" {length}, {(includeFrom ? 1 : 0)}, {(isToNull? "null" : $"@to")}, {(showOnlyUnwhutelisted ? 1: 0)}";
            SqlCommand cmd = new SqlCommand(commandText, connection);
            cmd.Parameters.Add("@from", SqlDbType.DateTime);
            cmd.Parameters["@from"].Value = from;
            if (!isToNull)
            {
                cmd.Parameters.Add("@to", SqlDbType.DateTime);
                cmd.Parameters["@to"].Value = to;
            }
            SqlDataReader reader;
            try
            {
                reader = await cmd.ExecuteReaderAsync();
            } catch
            {
                MessageBox.Show("Отчетов не найдено.");
                return null;
            }
           
            var reports = new List<Report>();
            var table = new DataTable();
            table.Load(reader);

            foreach (DataRow row in table.Rows)
            {
                reports.Add(new Report()
                {
                    MachineName = row["machine"].ToString(),
                    Id = long.Parse(row["id"].ToString()),
                    Created = DateTime.Parse(row["created"].ToString()),
                    CPU = int.Parse(row["total_cpu_load"].ToString()),
                    Mem = long.Parse(row["total_memory_load"].ToString()),
                    IP = row["ip"].ToString(),
                    HasUnwhitelisted = bool.Parse(row["has_unwhitelisted"].ToString()),
                    ProcessCount = int.Parse(row["process_count"].ToString()),
                });
            }
            return reports;
        }
        public async void setWhitelistReport(long reportId, bool value)
        {
            if (self.Connect())
            {
                var commandText = $"execute whitelist_report {reportId}, {(value ? 1 : 0)}";
                SqlCommand cmd = new SqlCommand(commandText, connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        
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
        public async Task<bool> ConnectAsync(bool showConnectionAlert = true)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                await connection.OpenAsync();
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

