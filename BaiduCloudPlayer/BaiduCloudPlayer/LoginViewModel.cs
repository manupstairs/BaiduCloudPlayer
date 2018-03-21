using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace BaiduCloudPlayer
{
    public class LoginViewModel : ViewModelBase
    {
        private string BaiduClientId { get; set; } = "CuOLkaVfoz1zGsqFKDgfvI0h";
        private string RedirectUri { get; set; } = "oob";
        private string Scope { get; set; } = "netdisk";

        public string LoginUri
        {
            get
            {
                return string.Format("https://openapi.baidu.com/oauth/2.0/authorize?response_type=token&client_id={0}&redirect_uri={1}&scope={2}",
                    BaiduClientId, RedirectUri, Scope);
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            this.LoginCommand = new RelayCommand<NavigationEventArgs>(LoginAction);
        }

        private void LoginAction(NavigationEventArgs e)
        {
            if (e.Uri.AbsolutePath.Contains("login_success"))
            {
                string[] parm = e.Uri.Fragment.Split('#')[1].Split('&');
                foreach (string p in parm)
                {
                    string[] sub = p.Split('=');
                    // Get each parameter
                    switch (sub[0])
                    {
                        case "access_token":
                            UserDataStorge.Instance.Access_Token = sub[1];
                            break;
                    }
                }
            }
        }
    }
}
