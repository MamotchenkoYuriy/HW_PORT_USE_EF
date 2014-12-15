using System;
using System.Collections.Generic;
using Model.Tables;

namespace Model
{
    public class Port : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }
        public virtual ICollection<Trip> TripsFrom { get; set; }
        public virtual ICollection<Trip> TripsTo { get; set; }

        public Port()
        {
            TripsTo = new List<Trip>(); 
            TripsFrom = new List<Trip>();
            Ships = new List<Ship>();
        }
        public Port(int Id, string Name, int CityId)
        {
            this.Id = Id;
            this.CityId = CityId;
            this.Name = Name;
            TripsTo = new List<Trip>();
            TripsFrom = new List<Trip>();
            Ships = new List<Ship>();
        }

        public override string ToString()
        {
            return String.Format("Id --> {1}{0}Name --> {2}{0} CityId --> {3}{0}", Environment.NewLine, Id, Name, CityId);
        }
    }
}