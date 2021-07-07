using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Models
{
    public class Stock
    {
        public Stock()
        {
            ReserveStocks = new HashSet<ReserveStock>();
        }
        public Stock(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            ReserveStocks = new HashSet<ReserveStock>();
        }


        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ICollection<ReserveStock> ReserveStocks { get; set; }

        public int GetAvailableQuantity()
        {
            if (ReserveStocks.Count == 0)
                return Quantity;

            var reservedCount = ReserveStocks
                                    .Where(x => !x.Expired)
                                    .Select(x => x.Quantity)
                                    .Sum();
            return Quantity - reservedCount;
        }

    }
}
