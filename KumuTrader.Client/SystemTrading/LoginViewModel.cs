using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XAPI;

namespace KumuTraderClient.SystemTrading
{
    public class LoginViewModel : ViewModelBase
    {
        string _LoginUser;
        public string LoginUser
        {
            get
            {
                return _LoginUser;
            }
            set
            {
                if (_LoginUser != value)
                {
                    _LoginUser = value;
                    OnPropertyChanged();
                }
            }
        }
        string _LoginPwd;
        public string LoginPwd
        {
            get
            {
                return _LoginPwd;
            }
            set
            {
                if (_LoginPwd != value)
                {
                    _LoginPwd = value;
                    OnPropertyChanged();
                }
            }
        }

        ICommand _LoginCmd;
        public ICommand LoginCmd
        {
            get
            {
                return _LoginCmd ?? (_LoginCmd = new RelayCommand(
                    () => OnLoginChanged(),
                    () => CanExecute()
                ));
            }

        }
        public ICommand CannelCmd { get; set; }

        void OnLoginChanged()
        {
            //与服务端通讯登录完成后，加载一系列数据
            throw new Exception();

            //加载权限

            //加载码表

            //行情接口初始化
            XAPI.
            //登录行情

            //订阅行情
        }
        bool CanExecute()
        {
            return true;
        }
    }
}
