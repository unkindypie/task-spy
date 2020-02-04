using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSpy
{
    public class ProcessModel
    {
        public string name = "<unacessable>";
        public string path = "<unacessable>";
        public long memoryUsage; //kb's
        public float cpuUsage = 0; //percentage
        public DateTime lastTime = new DateTime();
        public TimeSpan lastTotalProcessorTime = new TimeSpan();
        public int parentPID;
        public int pid;
        public bool isSystem = false;
        public string owner = "";
        public bool isOwnerReal;
        public ProcessModel(string name, long memoryUsage, int pid)
        {
            this.name = name;
            this.memoryUsage = memoryUsage;
            this.pid = pid;
        }
        public override string ToString()
        {
            //return $"{pid}n:{name}; p:{path}; m:{memoryUsage}; c:{cpuUsage}";
            return $"cpu:{cpuUsage}; name:{name}";
        }
    }
}
