using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Tables;

namespace InteractiveConsole.Views
{
    public class CityView : BaseView
    {
        //private DbContext context = null;
        public CityView(DbContext context) : base(context)
        {
            this.context = context;
        }

        public override void UpdateMenu(string path) //where T :BaseEntity
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                City entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = context.Set<City>().FirstOrDefault(m => m.Id == id);
                    if (entity == null)
                    {
                        Console.Write("Сущьность с Id = " + id + " не найденна!!!");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (consoleCommand == 2)
                {
                    Console.WriteLine("Введите номер записи --> ");
                    var pos = ReadIntValueFromConsole();
                    if (pos >= context.Set<City>().Count())
                    {
                        Console.WriteLine("Вы ввели не корректный номер!!!");
                        Console.ReadKey(); break;
                    }
                    entity = context.Set<City>().ToList()[pos];
                }
                else if (consoleCommand == 3) { break; }
                Console.WriteLine(entity.ToString());
                Console.WriteLine();
                Console.WriteLine("Введите название города");
                if (entity != null) entity.Name = Console.ReadLine();
                context.SaveChanges();
                Console.WriteLine("Изменения внесены!!!");
                Console.ReadKey();
            }
        }
    }
}
