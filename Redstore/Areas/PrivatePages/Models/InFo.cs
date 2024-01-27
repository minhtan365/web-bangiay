using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Redstore.Models;
namespace Redstore.Areas.PrivatePages.Models
{
    public class InFo
    {
         static DbContext dbcontext = new RedStore1Entities5();
        public static List<Products> getProducts()
        {
            var proc = dbcontext.Set<Products>().Where(a => a.typeSP >= 4).ToList();
            return proc;
        }
        public static Dictionary<string, decimal> CalculateTotalPriceByOrder()
        {
            RedStore1Entities5 db = new RedStore1Entities5();
            var ListDetailOrder = db.Set<detailOrders>().ToList();
            Dictionary<string, decimal> sumBySoDH = new Dictionary<string, decimal>();

            foreach (var orderDetail in ListDetailOrder)
            {
                var sodh = orderDetail.soDH;

                // Check if the order ID is already in the dictionary
                if (sumBySoDH.ContainsKey(sodh))
                {
                    // If yes, add the product price to the existing total
                    sumBySoDH[sodh] += orderDetail.priceSP;
                }
                else
                {
                    // If no, add the order ID to the dictionary with the initial product price
                    sumBySoDH.Add(sodh, orderDetail.priceSP);
                }
            }

            // Now sumBySoDH contains the total price for each order
            return sumBySoDH;
        }
    }
}