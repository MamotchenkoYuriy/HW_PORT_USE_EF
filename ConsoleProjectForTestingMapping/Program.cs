using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleProjectForTestingMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext.DataContext())
            {
                /*context.Cities.Add(new City() { Name = "Test" });
                context.Cities.Add(new City() { Name = "Test" });
                context.Cities.Add(new City() { Name = "Test" });*/
                var city = new City() {Name = "Test"};
                city.Ports.Add(new Port() { Name = "Test", CityId = city.Id });
                city.Ports.Add(new Port() { Name = "Test", CityId = city.Id });
                city.Ports.Add(new Port() { Name = "Test", CityId = city.Id });
                context.Cities.Add(city);

                context.SaveChanges();
                //context.Set<City>()

                context.Ports.Add(new Port() {Name = "Test", CityId = context.Cities.FirstOrDefault().Id});
                context.Ports.Add(new Port() { Name = "Test", CityId = context.Cities.FirstOrDefault().Id });
                context.Ports.Add(new Port() { Name = "Test", CityId = context.Cities.FirstOrDefault().Id });
                context.Ports.Add(new Port() { Name = "Test", CityId = context.Cities.FirstOrDefault().Id });
                context.SaveChanges();
            }
            using (var context = new DataContext.DataContext())
            {
                foreach (var item in context.Set<City>())
                {
                    Console.WriteLine(item.ToString());
                }
                foreach (var item in context.Ports)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadKey();

        }
    }
}
