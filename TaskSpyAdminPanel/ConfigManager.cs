using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace TaskSpyAdminPanel.Config
{
    [Serializable]
    public class StateConfig
    {
        public bool showSystemProcesses = false;
        public bool highlightUnwhitelisted = false;
        public int sortBy = 0;
        public int machine = 0;
        public StateConfig()
        {
        }
        public StateConfig(bool showSystemProcesses, bool highlightUnwhitelisted, int sortBy, int machine)
        {
            this.showSystemProcesses = showSystemProcesses;
            this.highlightUnwhitelisted = highlightUnwhitelisted;
            this.sortBy = sortBy;
            this.machine = machine;
        }
    }
    class ConfigManager
    {
        static StateConfig config = new StateConfig();
        static public StateConfig Config
        {
            get
            {
                return config;
            }
            set
            {
                config = value;
            }
        }
        static public void Save()
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(StateConfig));
                using (FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"
                        ), FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, config);
                }
            } catch (Exception e)
            {
                MessageBox.Show("По какой-то причине не удалось записать конфиг файл, мне вас очень жаль."+e.ToString());
            }
      
        }
        static public void Load()
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(StateConfig));
                using (FileStream fs =
                    new FileStream(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"
                        ), FileMode.Open)
                    )
                {
                    config = (StateConfig)formatter.Deserialize(fs);
                }

            }
            catch (Exception e)
            {
                config = new StateConfig();
                MessageBox.Show(e.ToString());
            }
        }
    }
}
