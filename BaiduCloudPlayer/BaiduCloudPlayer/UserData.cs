using System.Collections.Generic;
using System.ComponentModel;
using Windows.Storage;

namespace BaiduCloudPlayer
{
    public class UserDataStorge
    {
        private ApplicationDataContainer LocalSettings
        {
            get
            {
                return ApplicationData.Current.LocalSettings;
            }
        }

        private UserDataStorge()
        {
           
        }

        public readonly static UserDataStorge Instance = new UserDataStorge();

        public string Access_Token
        {
            get
            {
                return LocalSettings.Values["Access_Token"].ToString();
            }
            set
            {
                LocalSettings.Values["Access_Token"] = value;
            }
        }

        public string UserId
        {
            get
            {
                return LocalSettings.Values["UserId"].ToString();
            }
            set
            {
                LocalSettings.Values["UserId"] = value;
            }
        }

        public string UserName
        {
            get
            {
                return LocalSettings.Values["UserName"].ToString();
            }
            set
            {
                LocalSettings.Values["UserName"] = value;
            }
        }
    }
}
