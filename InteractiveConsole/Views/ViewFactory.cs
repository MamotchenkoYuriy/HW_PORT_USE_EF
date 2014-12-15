using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Tables;

namespace InteractiveConsole.Views
{
    public class ViewFactory
    {
        private static ViewFactory _viewFactory = null;
        private IDictionary<string, BaseView> dictionary = null;
        private DataContext.DataContext context = null;

        private ViewFactory()
        {
            //_viewFactory = new ViewFactory(); 
            context = new DataContext.DataContext();
            dictionary = new ConcurrentDictionary<string, BaseView>();
            dictionary.Add(typeof(City).Name, new CityView(context));
            dictionary.Add(typeof(Port).Name, new PortView(context));
            dictionary.Add(typeof(Captain).Name, new CaptainView(context));
            dictionary.Add(typeof(Cargo).Name, new CargoView(context));
            dictionary.Add(typeof(CargoType).Name, new CargoTypeView(context));
            dictionary.Add(typeof(Ship).Name, new ShipView(context));
            dictionary.Add(typeof(Trip).Name, new TripView(context));
        }

        public static ViewFactory GetInstance()
        {
            if (_viewFactory != null)
            {
                return _viewFactory;
            }
            else
            {
                _viewFactory = new ViewFactory();
                return _viewFactory;
            }
        }

        public BaseView GetView<T>()
        {
            return dictionary[typeof(T).Name];
        }
    }
}
