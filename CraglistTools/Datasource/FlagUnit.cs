using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraigslistTools.Datasource
{
    public class FlagUnit : INotifyPropertyChanged
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
        private string _proxy;
        public string Proxy
        {
            get { return _proxy; }
            set { _proxy = value; OnPropertyChanged("Proxy"); }
        }
        private string _agent;
        public string Agent
        {
            get { return _agent; }
            set { _agent = value; OnPropertyChanged("Agent"); }
        }
        private int _agentId;
        public int AgentId
        {
            get { return _agentId; }
            set { _agentId = value; OnPropertyChanged("AgentId"); }
        }
        private string _pid;
        public string PID
        {
            get { return _pid; }
            set { _pid = value; OnPropertyChanged("PID"); }
        }
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; OnPropertyChanged("Url"); }
        }
        private bool _exe;
        public bool Exe
        {
            get { return _exe; }
            set { _exe = value; OnPropertyChanged("Exe"); }
        }
        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged("Status"); }
        }
        public FlagUnit(string proxy, int agentId, string agent, string pid)
        {
            Proxy = proxy;
            Agent = agent;
            _pid = pid;
            AgentId = agentId;
            Exe = true;
            Url = string.Format(@"https://post.craigslist.org/flag?flagCode=28&postingID=" + pid);

        }

    }
}
