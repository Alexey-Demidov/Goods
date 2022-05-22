using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    internal class Validation
    {
        public NameValidator name { get; set; }
        public PriceValidator price { get; set; }
        public AmountValidator amount { get; set; }

        public Validation()
        {
            name = new NameValidator();
            price = new PriceValidator();
            amount = new AmountValidator();
        }
    }
    
    internal class NameValidator
    {
        uint minLen = 3;
        uint maxLen = 30; 

        public NameValidator IsProductExist(string name)
        {
            DataBase.FormGoodsList();
            foreach (var a in DataBase.goods)
            {
                if (a.Name == name)
                    throw new Exception("Товар с таким названием уже существует");
            }
            return this;
        }
        public NameValidator IsContainLetters(string name)
        {
            var a = (from temp in name
                    where Char.IsLetter(temp)
                    select temp).Count();
            if (a > 0)
                return this;
            else
                throw new Exception("Название должно содержать хотя бы один символ");
        }

        public NameValidator IsCorrectLength(string name)
        {
            if (name.Length >= minLen && name.Length <= maxLen)
                return this;
            else
                throw new Exception("Некорректная длинна названия");
        }
    }

    internal class PriceValidator
    {
        decimal minPrice = 1;
        decimal maxPrice = 100000;
        decimal temp = 0;
        public PriceValidator IsNumber(string price)
        {
            if (Decimal.TryParse(price, out temp))
                return this;
            else
                throw new Exception("Некорректно введена цена");
        }

        public PriceValidator IsCorrectPrice(string price)
        {
            if (Decimal.TryParse(price, out temp))
            {
                if(temp >= minPrice && temp <= maxPrice)
                    return this;
                else
                    throw new Exception("Некорректно введена цена");
            }
            throw new Exception("Некорректно введена цена");
        }
    }

    internal class AmountValidator
    {
        int minAmount = 0;
        int temp = 0;

        public AmountValidator IsNumber(string amount)
        {
            if (Int32.TryParse(amount, out temp))
                return this;
            else
                throw new Exception("Некорректно введено количество товара");
        }

        public AmountValidator IsCorrectAmount(string amount)
        {
            if (Int32.TryParse(amount, out temp))
            {
                if (temp >= minAmount)
                    return this;
                else
                    throw new Exception("Количество товара не может быть отрицательынм");
            }
            throw new Exception("Некорректно введено количество товара");

        }
    }
}
