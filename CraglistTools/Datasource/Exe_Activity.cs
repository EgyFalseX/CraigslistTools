using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraigslistTools.Datasource
{
    public class Exe_Activity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(name));
                //handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public readonly string Cl_URL = "https://craigslist.org/";
        //public readonly string Cl_URL = "http://whatismyipaddress.com/";
        public readonly string Cl_lOGIN = "https://accounts.craigslist.org/login";
        public readonly int WAITSEC = 4 * 1000;

        private Core.Core.TemplateType _temType;
        public Core.Core.TemplateType TemType
        {
            get { return _temType; }
            set { _temType = value; OnPropertyChanged("TemType"); }
        }
        
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }

        private string _agent;
        public string Agent
        {
            get { return _agent; }
            set { _agent = value; OnPropertyChanged("Agent"); }
        }

        private string _link;
        public string Link
        {
            get { return _link; }
            set { _link = value; OnPropertyChanged("Link"); }
        }

        private int _wait;
        public int Wait
        {
            get { return _wait; }
            set { _wait = value; OnPropertyChanged("Wait"); }
        }

        private string _activityCategory;
        public string ActivityCategory
        {
            get { return _activityCategory; }
            set { _activityCategory = "https://craigslist.org/search/" + value; OnPropertyChanged("ActivityCategory"); }
        }

        private string _opCode_Status;
        public string OpCode_Status
        {
            get { return _opCode_Status; }
            set { _opCode_Status = value; OnPropertyChanged("OpCode_Status"); }
        }

        public Exe_Activity(Core.Core.TemplateType temType)
        {
            TemType = temType;
        }
        public Exe_Activity()
        {
            
        }

    }
}
