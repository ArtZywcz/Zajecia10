using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia10
{
    class Files : INotifyPropertyChanged
    {

        private string contentPriv;

        public string path { get; set; }

        public string Content
        {
            get { return contentPriv; }
            set
            {
                if (contentPriv != value)
                {
                    contentPriv = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
