using System;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using lesson5.Domain;
using lesson5.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace lesson5
{
    class Program
    {
        static ContextDB context = new ContextDB();
        static void Main(string[] args)
        {
            //context.Database.EnsureCreated();
            context.Database.Migrate();
            SeedCategory();
            SeedProduct();

            //foreach (var item in context.Categories)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //var query = context.Products.Select(x =>
            //    new { x.Id, x.Name, CategoryName = x.Category.Name })
            //    .AsQueryable();

            //string name = "";

            //if (!string.IsNullOrEmpty(name))
            //{
            //    query = query.Where(x => x.Name.Contains(name));
            //}

            //string ggwp = "Tasty";
            //query = query.Where(x => x.Name.Contains(ggwp));

            //string cat = "Game";
            //query = query.Where(x => x.CategoryName.Contains(cat));

            //foreach (var item in query.ToList())
            //{
            //    Console.WriteLine($"Id: {item.Id}\n" +
            //        $"Name: {item.Name}\n" +
            //        $"Category: {item.CategoryName}\n");
            //}
            //foreach (var item in context.Products)
            //{
            //    Console.WriteLine($"Id: {item.Id}\n" +
            //        $"Name: {item.Name}\n" +
            //        $"Category: {item.Category.Name}\n");
            //}


            SeedUsers();
            SeedRoles();
            SeedUserRoles();

            var query = context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .AsQueryable();

            foreach (var user in query)
            {
                Console.WriteLine($"UserId: {user.Id}\t UserNmae: {user.Name}");
                Console.WriteLine("Roles:");
                foreach (var roleUser in user.UserRoles)
                {
                    Console.Write($" {roleUser.RoleId} ");
                }
                Console.WriteLine();
            }
            
        }

        static void SeedCategory()
        {
            if (!context.Categories.Any())
            {
                var testCategories = new Faker<Category>("en")
                                .RuleFor(x => x.Name, f => f.Commerce.Categories(1)[0]);

                for (int i = 0; i < 100; i++)
                {
                    var data = testCategories.Generate();
                    var category = context.Categories
                        .SingleOrDefault(x => x.Name == data.Name);

                    if (category == null)
                    {
                        context.Categories.Add(data);
                        context.SaveChanges();
                    }
                }
            }
            
            
        }

        static void SeedProduct()
        {
            if (!context.Products.Any())
            {
                long[] catIds = context.Categories
                    .Select(x => x.Id).ToArray();

                var faker = new Faker<Product>()
                    .RuleFor(x => x.CatedoryId, f => f.PickRandom(catIds))
                    .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                    .RuleFor(x => x.Price, f => f.Finance.Amount(1M, 100M));

            
                for (int i = 0; i < 1000; i++)
                {
                    var data = faker.Generate();
                    context.Products.Add(data);
                    
                }
                context.SaveChanges();
            }
        }
        static void SeedUsers()
        {
            if (!context.Users.Any())
            {
                context.Users
                    .Add(new AppUser
                    {
                        Name = "Boris",
                        Phone = "981280817",
                    });
                context.Users
                    .Add(new AppUser
                    {
                        Name = "Johnathan",
                        Phone = "128081798",
                    });
                context.SaveChanges();
            }
        }
        static void SeedRoles()
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new AppRole { Name = ConstantRoles.Admin });
                context.Roles.Add(new AppRole { Name = ConstantRoles.Chel });
                context.Roles.Add(new AppRole { Name = ConstantRoles.Sasa });
                context.SaveChanges();
            }
        }

        static void SeedUserRoles()
        {
            if (!context.AppUserRoles.Any())
            {
                var role = context.Roles.SingleOrDefault(x => x.Name == ConstantRoles.Chel);
                string phone = "981280817";
                var user = context.Users.SingleOrDefault(x => x.Phone == phone);

                //AppUserRole userRole = new AppUserRole();
                //userRole.UserId = user.Id;
                //userRole.RoleId = role.Id;
                //context.AppUserRoles.Add(userRole);

                context.AppUserRoles.Add(
                    new AppUserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                    });
                context.SaveChanges();

                role = context.Roles.SingleOrDefault(x => x.Name == ConstantRoles.Sasa);
                
                context.AppUserRoles.Add(
                    new AppUserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id,
                    });
                context.SaveChanges();

                phone = "128081798";;
                user = context.Users.SingleOrDefault(x => x.Phone == phone);
                role = context.Roles.SingleOrDefault(x => x.Name == ConstantRoles.Admin);
                context.AppUserRoles.Add(
                    new AppUserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    });
                context.SaveChanges();

            }
        }
    }
}
