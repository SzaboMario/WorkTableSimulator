using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTableSimulator
{
    internal class Motor : ChangeNotifier
    {
        private int _Speed;
        public int Speed
        {
            get { return _Speed; }
            set { _Speed = value; OnPropertyChanged(nameof(Speed)); }
        }

        public Motor() { }
    }
}
