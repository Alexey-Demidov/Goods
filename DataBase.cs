using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Goods
{
    internal static class DataBase
    {
        internal static ApplicationContext Context { get; private set; }
        internal static List<Goods> goods { get; private set; }

        // если новый товар не был добавлен, новый список товаров не формируется
        // изначально true для инициализации списка товаров при запуске
        private static bool IsNewProductAdded { get; set; } = true;
        public static void InitializeDataBase()
        {
            Context = new ApplicationContext();
            FormGoodsList();
        }
        public static Task AddGoods(Goods goods)
        {
            return Task.Run(() =>
            {
                Context.Goods.Add(goods);
                Context.SaveChanges();
                IsNewProductAdded = true;
            });
        }

        public async static void FormGoodsList()
        {
            if (IsNewProductAdded)
            {
                var temp = await Context.Goods.ToListAsync();
                goods = temp;
                IsNewProductAdded = false;
            }
            else
            {
                return;
            }    
        }
    }

    internal class ApplicationContext : DbContext
    {
        internal DbSet<Goods> Goods => Set<Goods>();
        internal ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Goods.db");
        }
    }
}
