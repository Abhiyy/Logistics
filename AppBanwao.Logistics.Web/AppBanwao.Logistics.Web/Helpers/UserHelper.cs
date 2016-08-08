
using AppBanwao.Logistics.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;


namespace AppBanwao.Logistics.Web.Helpers
{
    public class UserHelper
    {
        string _user;
        string _password;
        LogisticsEntities _context;
        public UserHelper(){
            _context = null;
        }

        public UserHelper(string user, string password)
        {
            _user=user;
            _password=password;
        }

        public UserName GetUser()
        {
            _context = new LogisticsEntities();

            var user = _context.UserNames.Where(x => x.EmailAddress == _user && x.Password == _password).FirstOrDefault();
            _context = null;

            return user;
        }
        
        
    }

}