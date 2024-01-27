using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Redstore.Models
{
    public class TaiKhoan
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public TaiKhoan()
        {
            this.Account = "";
            this.Password = "";
        }
        public tkNguoiDung ttNguoiDung()
        {
            tkNguoiDung result = null;
            result = dungchung.GetNguoiDungs().Where(get => get.taiKhoan.ToLower().Equals(this.Account.ToLower()) && get.passWords.Equals(this.Password)).FirstOrDefault();
            return result;
        }
    }
}