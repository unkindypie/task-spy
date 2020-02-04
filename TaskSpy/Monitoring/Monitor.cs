using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Management;

namespace TaskSpy.Monitoring
{
    //класс для мониторинга процессов
    public partial class Monitor
    {
        private static Dictionary<int, ProcessModel> models = new Dictionary<int, ProcessModel>();
        static TimeSpan curTotoalProcTime;
        static List<int> deadProcesses = new List<int>();
        static private long totalMemoryUsage = 0;
        static private float totalCpuUsage = 0;
        static private long scanCounter = 0;

        public static Dictionary<int, ProcessModel> Models
        {
            get
            {
                return models;
            }
        }
        public static long TotalMemoryUsage
        {
            get
            {
                return totalMemoryUsage;
            }
        }
        public static float TotalCpuUsage
        {
            get
            {
                return totalCpuUsage;
            }
        }
        public static long ScanCounter
        {
            get
            {
                return scanCounter;
            }
        }

        static public List<ProcessModel> ScanProcesses()
        {
            totalCpuUsage = totalMemoryUsage = 0;

            var processes = Process.GetProcesses();
            //ищу процессы, закончившие свою работу
            foreach (int pid in models.Keys)
            {
                bool exists = false;
                foreach (Process p in processes)
                {
                    if (pid == p.Id)
                    {
                        exists = true;
                    }
                }
                if (!exists)
                {
                    deadProcesses.Add(pid);
                }
            }
            //удаляю процессы, закончившие свою работу
            foreach (int pid in deadProcesses)
            {
                models.Remove(pid);
            }
            deadProcesses.Clear();
            //обновление данных о процессах
            foreach (Process p in processes)
            {
                ProcessModel processModel;
                //если процесс уже запущен, то cтоит обновить его данные
                if (models.ContainsKey(p.Id))
                {
                    processModel = models[p.Id];
                    models[p.Id].memoryUsage = p.WorkingSet64 / 1000;
                }
                else
                {
                    processModel = new ProcessModel(p.ProcessName, p.WorkingSet64 / 1000, p.Id);

                    try
                    {
                        using (ManagementObject mo = new ManagementObject($"win32_process.handle='{p.Id}'"))
                        {
                            mo.Get();
                            //получаю id родительского процесса
                            processModel.parentPID = Convert.ToInt32(mo["ParentProcessId"]);
                            //узнаю системный ли процесс
                            string[] argList = new string[] { string.Empty, string.Empty };
                            int returnVal = Convert.ToInt32(mo.InvokeMethod("GetOwner", argList));
                            if (returnVal == 0)
                            {
                                processModel.isSystem = (argList[0].ToLower() == "система"
                                    || argList[0].ToLower() == "system"
                                    || argList[0].ToLower() == "network service"
                                    || argList[0].ToLower() == "local service");

                                //пользователь процесса
                                processModel.owner = argList[0];
                                //определяю, является ли пользователь пользователем какой-то службы или это настоящий пользователь
                                processModel.isOwnerReal = IsActualUser(Environment.MachineName, processModel.owner);
                            }
                            else processModel.isSystem = true;
                        }

                    }
                    catch
                    {
                        processModel.parentPID = -1;
                        processModel.isSystem = true;
                    }

                    models.Add(p.Id, processModel);
                }

                curTotoalProcTime = new TimeSpan();
                try
                {
                    processModel.path = p.MainModule.FileName;
                    curTotoalProcTime = p.TotalProcessorTime;
                }
                catch (Exception e)
                {
                    //Console.WriteLine("  Exception on {0}", p.ProcessName);
                    //Console.WriteLine(e.Message);
                }

                //вычисление процента нагрузки на процессор
                if (curTotoalProcTime != new TimeSpan())
                {
                    if (processModel.lastTime == null || processModel.lastTime == new DateTime())
                    {
                        processModel.lastTime = DateTime.Now;
                        processModel.lastTotalProcessorTime = curTotoalProcTime;
                    }
                    else
                    {
                        DateTime curTime = DateTime.Now;

                        double CPUUsage = (curTotoalProcTime.TotalMilliseconds - processModel.lastTotalProcessorTime.TotalMilliseconds)
                            / curTime.Subtract(processModel.lastTime).TotalMilliseconds / Convert.ToDouble(Environment.ProcessorCount);

                        processModel.cpuUsage = (float)CPUUsage * 100;

                        processModel.lastTime = curTime;
                        processModel.lastTotalProcessorTime = curTotoalProcTime;
                    }
                }

                totalCpuUsage += processModel.cpuUsage;
                totalMemoryUsage += processModel.memoryUsage;

            }
            scanCounter++;
            return models.Values.ToList();
        }

    }
}
