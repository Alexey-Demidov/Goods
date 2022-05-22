using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    internal static class Save
    {
        public static List<Goods> goods = new List<Goods>();
        public static void SaveProduct(string name, string price, string amount)
        {
            Validation validator = new Validation();

            validator.name.IsProductExist(name).IsCorrectLength(name).IsContainLetters(name);
            validator.price.IsNumber(price).IsCorrectPrice(price);
            validator.amount.IsNumber(amount).IsCorrectAmount(amount);

            AddToDataBase(name, price, amount);
        }

        private async static void AddToDataBase(string name, string price, string amount)
        {
            Goods good = new Goods(name, Decimal.Parse(price), UInt32.Parse(amount));
            await DataBase.AddGoods(good);
        }
    }
}
