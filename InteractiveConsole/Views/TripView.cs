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
    public class TripView :BaseView
    {
        //private DbContext context = null;
        public TripView(DbContext context) :base(context)
        {
            this.context = context;
        }
        public override void UpdateMenu(string path)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(path);
                Trip entity = null;
                Console.WriteLine("1 - Редактировать по ID -->");
                Console.WriteLine("2 - Редактировать № -->");
                Console.WriteLine("3 - Выход -->");
                var consoleCommand = ReadIntValueFromConsole();
                if (consoleCommand == 1)
                {
                    Console.WriteLine("Введите Id --> ");
                    var id = ReadIntValueFromConsole();
                    entity = context.Set<Trip>().FirstOrDefault(m => m.Id == id);
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
                    entity = context.Set<Trip>().ToList()[pos];
                }
                else if (consoleCommand == 3) { break; }
                if (entity == null)
                {
                    break;
                }
                Console.WriteLine(entity.ToString());
                Console.WriteLine();
                Console.WriteLine("Введите номер порта отправки");
                entity.PortFromId = ReadIntValueFromConsole();
                Console.WriteLine("Введите номер порта прибытия");
                entity.PortToId = ReadIntValueFromConsole();
                Console.WriteLine("Введите номер корабля");
                entity.ShipId = ReadIntValueFromConsole();
                Console.WriteLine("Введите дату отправки");
                entity.StartDate = ReadDateTimeFromConsole();
                Console.WriteLine("Введите дату прибытия");
                entity.EndDate = ReadDateTimeFromConsole();
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
