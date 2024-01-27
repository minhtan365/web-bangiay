    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Redstore.Models
{
    public class GioHang
    {
        public string idUser { get; set; }
        public string UserName { get; set; }
        public DateTime NgayDat { get; set; }
        public string Adress { get; set; }
        public SortedList<string, detailOrders> SPchon { get; set; }
        public GioHang()
        {
            this.idUser = "";
            this.UserName = "";
            this.NgayDat = DateTime.Now;
            this.Adress = "";
            this.SPchon = new SortedList<string, detailOrders>();
        }

        public bool ghRong()
        {
            return (SPchon.Keys.Count == 0);
        }

        public void themItem(string idSP)
        {
            
                if (SPchon.Keys.Contains(idSP))
                {
                    detailOrders detail = SPchon.Values[SPchon.IndexOfKey(idSP)];
                    detail.quanTity++;
                    capnhatItem(detail);
                }
                else
                {
                    detailOrders detail = new detailOrders();
                    detail.idSP = idSP;
                    detail.quanTity = 1;
                    Products products = dungchung.getProductsID(idSP);
                    detail.priceSP = products.priceSP;
                    SPchon.Add(idSP, detail);
                }
            
            
        }
        public void capnhatItem(detailOrders detail)
        {
            this.SPchon.Remove(detail.idSP);
            this.SPchon.Add(detail.idSP, detail);
        }
        public void xoaItem(string idSP)
        {
                if (SPchon.Keys.Contains(idSP))
                {
                    SPchon.Remove(idSP);
                }
            
           
        }
        public void giamSP(string idSP)
        {
            if (SPchon.Keys.Contains(idSP))
            {
                detailOrders detail = SPchon.Values[SPchon.IndexOfKey(idSP)];
                if (detail.quanTity > 1)
                {
                    detail.quanTity--;
                    capnhatItem(detail);
                }
                else
                    xoaItem(idSP);
            }
        }
        public int giatien1SP(detailOrders detail)
        {
            return (int)detail.priceSP * detail.quanTity;
        }

        public int tongslSP()
        {
            int tong = 0;
            foreach(detailOrders detail in SPchon.Values)
            {
                tong += detail.quanTity;
            }
            return tong;
        }
        public int tongslSPtronggio()
        {
            int tong = 0;
            foreach(detailOrders detail in SPchon.Values)
            {
                tong += giatien1SP(detail);
            }
            return tong;
        }
    }
}