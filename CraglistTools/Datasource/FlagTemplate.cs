using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraigslistTools.Datasource
{
    public class FlagTemplate : INotifyPropertyChanged
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
        private Core.Core.TemplateType _temType;
        public Core.Core.TemplateType TemType
        {
            get { return _temType; }
            set { _temType = value; OnPropertyChanged("TemType"); }
        }
        private object _parameter;
        public object Parameter
        {
            get { return _parameter; }
            set { _parameter = value; OnPropertyChanged("Parameter"); }
        }
        public FlagTemplate(Core.Core.TemplateType temType, object parameter = null)
        {
            TemType = temType;
            Parameter = parameter;
        }

    }
}
