using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopApp.DataAccess.Concrete.EfCore
{
	//Test Datas
	public static class SeedDatabase
	{
		public static void Seed()
		{
			var context = new ShopContext();
			if(context.Database.GetPendingMigrations().Count() == 0)
			{
				if(context.Categories.Count() == 0)
				{
					context.Categories.AddRange(Categories);
				}

				if(context.Products.Count() == 0 )
				{
					context.Products.AddRange(Products);
				}
				context.SaveChanges();
			}
		}

		private static Category[] Categories =
		{
			new Category() { Name="Phones" },
			new Category() { Name="Computers"}
		};
		private static Product[] Products =
		{
			new Product() { Name = "Huawei Mate 20", Price = 2000,ImageUrl = "1.jpg"},
			new Product() { Name = "Macbook Air 2019", Price = 13000,ImageUrl = "2.jpg"},
			new Product() { Name = "iPhone 11 Max", Price = 12000,ImageUrl = "3.jpg"},
			new Product() { Name = "Monster Abra A5", Price = 7000,ImageUrl = "4.jpg"},
			new Product() { Name = "Xiaomi Redmi Note 8", Price = 5000,ImageUrl = "5.jpg"},
			new Product() { Name = "Samsung A70", Price = 5500,ImageUrl = "6.jpg"},
		};
	}


}
