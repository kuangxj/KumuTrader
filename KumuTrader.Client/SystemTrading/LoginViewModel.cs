using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using XAPI;
using XAPI.Callback;

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
            Debugger.Log(0, null, "CTP:Login");

            //加载权限

            //加载码表

            //行情接口初始化
            var type = Type.GetType("XAPI.Callback.XApi,XAPI_CSharp");
            var api = (IXApi)Activator.CreateInstance(type, AppDomain.CurrentDomain.BaseDirectory + @"XAPI\x86\CTP\CTP_Quote_x86.dll");

            api.Server.BrokerID = "9999";
            api.Server.Address = "tcp://180.168.146.187:10010";
            api.Server.PrivateTopicResumeType = ResumeType.Undefined;

            api.User.UserID = "037505";
            api.User.Password = "123456";

            api.OnConnectionStatus = OnConnectionStatus;
            api.OnRtnDepthMarketData = OnRtnDepthMarketData;
            api.OnRspQryInstrument = OnRspQryInstrument;
            api.OnRspQrySettlementInfo = OnRspQrySettlementInfo;
            api.Connect();
            Thread.Sleep(3 * 1000);
            api.Subscribe("IF000;IF_WI;IF_IH_1803;IF888", "");
            //登录行情

            //订阅行情
        }
        bool CanExecute()
        {
            return true;
        }
        void OnConnectionStatus(object sender, ConnectionStatus status, ref RspUserLoginField userLogin, int size1)
        {
            if (size1 > 0)
            {
                Console.WriteLine("333333" + status);
                Console.WriteLine("333333" + userLogin.ToFormattedStringLong());
            }
            else
            {
                Console.WriteLine("333333" + status);
            }
        }
        void OnRtnDepthMarketData(object sender, ref DepthMarketDataNClass marketData)
        {
            Debugger.Log(0, null, "CTP:C#");
            Console.WriteLine(marketData.InstrumentID);
            //Console.WriteLine(marketData.Exchange);
            Console.WriteLine(marketData.LastPrice);
            //Console.WriteLine(marketData.OpenInterest);
            if (marketData.Bids.Count() > 0)
            {
                Console.WriteLine(marketData.Bids[0].Price);
            }
            if (marketData.Asks.Count() > 0)
            {
                Console.WriteLine(marketData.Asks[0].Price);
            }
        }
        void OnRspQryInstrument(object sender, ref InstrumentField instrument, int size1, bool bIsLast)
        {
            Console.WriteLine(instrument.InstrumentName);
        }
        void OnRspQrySettlementInfo(object sender, ref SettlementInfoClass settlementInfo, int size1, bool bIsLast)
        {
            Console.WriteLine(settlementInfo.Content);
        }
    }
}
