using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zajecia10
{
    public class User : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        private int pointsPriv;

        public User(int id, string login, string password, int points)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.points = points;
        }

        public int points { get { return pointsPriv; }
            set
            {
                if (pointsPriv != value)
                {
                    pointsPriv = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Points"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
