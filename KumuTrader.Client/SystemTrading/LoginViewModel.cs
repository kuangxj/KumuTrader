using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KumuTraderClient.SystemTrading
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string name)
        {
            if (PropertyChanged == null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }
        private string _LoginName = "";

        public string LoginName
        {
            get { return _LoginName; }
            set
            {
                _LoginName = value;
                Notify("Name");
            }
        }

        private string _PasswordInfo = "";

        public string PasswordInfo
        {
            get { return _LoginName; }
            set
            {
                _PasswordInfo = value;
                Notify("Name");
            }
        }
        void UpdateArtistNameExecute()
        {
            this._LoginName = "中孝介";
        }

        bool CanUpdateArtistNameExecute()
        {
            return true;
        }
        public ICommand UserLoginCommand { get { return new RelayCommand(UpdateArtistNameExecute, CanUpdateArtistNameExecute); } }
        public ICommand NameChanaged { get { return new RelayCommand(NameChanagedMethod); } }

        public ICommand PasswordChanged { get { return new RelayCommand(PasswordChangedMethod); } }

        private void NameChanagedMethod()
        {
            string na = _LoginName;
        }
        private void PasswordChangedMethod()
        {
            string na = _PasswordInfo;
        }
    }
}
