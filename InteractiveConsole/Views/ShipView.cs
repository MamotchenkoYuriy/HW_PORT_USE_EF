using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Tables;

namespace InteractiveConsole.Views
{
    public class ShipView : BaseView
    {
        //private DbContext context = null;
        public ShipView(DbContext context) : base(context)
        {
            this.context = context;
        }
        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Ship entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = context.Set<Ship>().FirstOrDefault(m => m.Id == id);
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
                    entity = context.Set<Ship>().ToList()[pos];
                }
                else if (consoleCommand == 3) { break; }
                if (entity == null)
                {
                    break;
                }
                Console.WriteLine("Введите номер");
                entity.Number = Console.ReadLine();
                Console.WriteLine("Введите номер порта");
                entity.PortId = ReadIntValueFromConsole();
                Console.WriteLine("Введите номер капитана");
                entity.CaptainId = ReadIntValueFromConsole();
                Console.WriteLine("Введите грузоподемность");
                entity.Capacity = ReadIntValueFromConsole();
                Console.WriteLine("Введите максимальную дистанцию");
                entity.MaxDistance = ReadIntValueFromConsole();
                Console.WriteLine("Введите количество человек в команде");
                entity.TeamCount = ReadIntValueFromConsole();
                try
                {
                    context.SaveChanges();
                    Console.WriteLine("Изменения внесены!!!");
                }
                catch (Exception err)
                {
                    Console.WriteLine("Ошибка при сохранении изменений");
                }
                Console.ReadKey();
            }
        }
    }
}
