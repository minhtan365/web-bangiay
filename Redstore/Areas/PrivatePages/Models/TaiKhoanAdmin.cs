using Redstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstore.Areas.PrivatePages.Models
{
    public class TaiKhoanAdmin
    {
        private static RedStore1Entities5 enity = new RedStore1Entities5();
       public  string taiKhoanAdmin { get; set; }
        public  string matKhauAdmin { get; set; }
        public TaiKhoanAdmin() 
        {
            this.taiKhoanAdmin = "";
            this.matKhauAdmin = "";
        }
        public AdminAccounts ttAdmin()
        {
            AdminAccounts accounts = null;
            var getAdmin = enity.Set<AdminAccounts>().ToList();
            accounts = getAdmin.Where(get=>get.taiKhoanAdmin.ToLower().Equals(this.taiKhoanAdmin.ToLower())&& get.matKhauAdmin.Equals(this.matKhauAdmin)).FirstOrDefault();
            return accounts;
        }
    }
}
