using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackerEntities;

namespace BugTrackerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var  c = new BugTrackerContext())
            {
                c.Database.Delete();
                c.Database.Create();
            }
            using (var c =  new BugTrackerContext())
            {
                var user = c.Users.Create();
                user.Login = "GiovanniSolinas";
                user.FirstName = "Giovanni";
                user.LastName = "Solinas";
                user.Password = "kbsajbsakjaksbcscscvwcw";
                user.BirthDate = new DateTime(1998, 9,11);
                user.Address = new Address() {ZipCode = 16100};
                c.Users.Add(user);
                c.SaveChanges();
            }
            using (var c = new BugTrackerContext())
            {
                var product = c.Products.Create();
                product.Code = 42;
                product.CommercialName = "Motore";
                product.InternalName = "Motore 1.5 95 cv";
                product.Description = "abajdcowjdbcjdbcwjbcw";
                c.Products.Add(product);
                c.SaveChanges();
            }
            using (var c = new BugTrackerContext())
            {
                var product = c.Products.Create();
                product.Code = 27;
                product.CommercialName = "Matita";
                product.InternalName = "Matita bianca";
                product.Description = "oojosjcbdwjcoswcojbwe";
                c.Products.Add(product);
                c.SaveChanges();
            }
            using (var c = new BugTrackerContext())
            {
                var product1 = c.Products.FirstOrDefault(p => p.Code == 1);
                var product2 = c.Products.FirstOrDefault(p => p.Code == 2);
                product1.DependsOn.Add(product2);
                c.SaveChanges();
            }
        }
    }
}
