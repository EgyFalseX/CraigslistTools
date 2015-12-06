using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CraigslistTools.Datasource
{
    public class Act_Item: INotifyPropertyChanged
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
        private Core.Core.FlagType _flgType;
        public Core.Core.FlagType FlgType
        {
            get { return _flgType; }
            set { _flgType = value; OnPropertyChanged("FlgType"); }
        }
        private string _link;
        public string Link
        {
            get { return _link; }
            set { _link = value; OnPropertyChanged("Link"); }
        }
        public Act_Item(Core.Core.FlagType flgType, string link)
        {
            FlgType = flgType;
            Link = link;
        }
    }

}
