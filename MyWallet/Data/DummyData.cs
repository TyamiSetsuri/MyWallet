using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWallet.Data
{
    public class DummyData
    {


        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (context.Items.Any()
                    && context.Costs.Any())
                {
                    return;   // DB has already been seeded
                }

                var items = DummyData.GetProvinces().ToArray();
                context.Items.AddRange(items);
                context.SaveChanges();

                var costs = DummyData.GetCosts(context).ToArray();
                context.Costs.AddRange(costs);
                context.SaveChanges();
            }
        }

        public static List<Item> GetProvinces()
        {
            List<Item> provinces = new List<Item>() {
            new Item() {
                ItemName="Ball",
            },
            new Item() {
                ItemName="Chicken",
            },
            new Item() {
                ItemName="Chip",
            },
        };

            return provinces;
        }

        public static List<Cost> GetCosts(ApplicationDbContext context)
        {
            List<Cost> costs = new List<Cost>() {
            new Cost {
                ItemName = "Ball",
                ItemId = 1,
                Costs="70yuan",
            },
            new Cost {
                ItemName = "Chicken",
                ItemId = 2,
                Costs="20yuan",
            },
            new Cost {
                ItemName = "Chip",
                ItemId = 3,
                Costs="10yuan",
            },

        };
            return costs;
        }
    }


}
