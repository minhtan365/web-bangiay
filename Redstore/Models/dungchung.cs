using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Redstore.Models
{
    public class dungchung
    {
        static DbContext database = new RedStore1Entities5();
        public static List<Products> getProdutcsQC()
        {
            var QCproc = database.Set<Products>().Where(a => a.typeSP == 1).ToList();
            return QCproc;
        }

        public static List<Products> GetProductsNB()
        {
            var NBproc = database.Set<Products>().Where(a => a.typeSP == 2).ToList();
            return NBproc; 
        }

        public static List<Products> GetProductsNew()
        {
            var Newproc = database.Set<Products>().Where(a => a.typeSP == 3).ToList();
            return Newproc;
        }

        public static List<Products> GetProducts()
        {
            var products = database.Set<Products>().Where(a => a.typeSP >= 4).ToList();
            return products;
        }
        public static Products getProductsID(string idSP)
        {
            return database.Set<Products>().Find(idSP);
        }
        public static string getimgofProducts(string idSP)
        {
            return database.Set<Products>().Find(idSP).imgSP;
        }
        public static string getNameofProducts(string idSP)
        {
            return database.Set<Products>().Find(idSP).nameSP;
        }
        public static List<tkNguoiDung> GetNguoiDungs()
        {
            return database.Set<tkNguoiDung>().ToList();
        }
    }
}