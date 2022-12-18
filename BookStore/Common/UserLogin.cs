using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string GroupID { set; get; }
    }
}