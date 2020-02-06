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
        public bool showEveryUser = false;
        public string ip = "";
        public string server = "";
        public string username = "";
        public string password = "";

        public StateConfig()
        {
        }
        public StateConfig(bool showSystemProcesses, bool highlightUnwhitelisted, bool showEveryUser)
        {
            this.showSystemProcesses = showSystemProcesses;
            this.highlightUnwhitelisted = highlightUnwhitelisted;
            this.showEveryUser = showEveryUser;
        }
    }
    class ConfigManager
    {
        static StateConfig config = new StateConfig();
        static bool isLoaded = false;
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
                        ), FileMode.Create))
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
            if (isLoaded) return;
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
                    isLoaded = true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                config = new StateConfig();
                isLoaded = true;
            }
        }
    }
}
