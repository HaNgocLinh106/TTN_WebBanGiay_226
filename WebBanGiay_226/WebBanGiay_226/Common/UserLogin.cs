using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanGiay_226.Common
{
    [Serializable]
    public class UserLogin
    {
        public long MaNguoiDung { set; get; }
        public string UserName { set; get; }
    }
}