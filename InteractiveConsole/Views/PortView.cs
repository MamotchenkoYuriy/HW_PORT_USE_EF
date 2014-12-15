using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace InteractiveConsole.Views
{
    public class PortView : BaseView
    {
        //private DbContext context = null;
        public PortView(DbContext context) : base(context)
        {
            this.context = context;
        }
        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Port entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = context.Set<Port>().FirstOrDefault(m => m.Id == id);
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
                    if (pos >= context.Set<Port>().Count())
                    {
                        Console.WriteLine("Вы ввели не корректный номер!!!");
                        Console.ReadKey(); break;
                    }
                    entity = context.Set<Port>().ToList()[pos];
                }
                else if (consoleCommand == 3) { break; }
                if (entity == null)
                {
                    break;
                }
                Console.WriteLine(entity.ToString());
                Console.WriteLine();
                Console.WriteLine("Введите название порта");
                entity.Name = Console.ReadLine();
                Console.WriteLine("Введите ID города");
                entity.CityId = ReadIntValueFromConsole();
                context.SaveChanges();
                Console.WriteLine("Изменения внесены!!!");
                Console.ReadKey();
            }
        }
    }
}
