using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    internal class Goods
    {
        public int GoodsId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public uint Amount { get; set; }

        public Goods(string name, decimal price = 0, uint amount = 0)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}
