using System;
using System.Collections.Generic;

namespace Model
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Port> Ports { get; set; }

        public City(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            Ports = new List<Port>();
        }
        public City() { Ports = new List<Port>();  }
        public override string ToString()
        {
            return String.Format("Id --> {1}{0} Name -->{2}{0}", Environment.NewLine, Id, Name);
        }
    }
}