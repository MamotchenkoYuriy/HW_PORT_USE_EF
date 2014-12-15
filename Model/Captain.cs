using System;
using System.Collections.Generic;
using Model.Tables;

namespace Model
{
    public class Captain : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Ship> Ships { get; set; }

        public Captain() { Ships = new List<Ship>(); }

        public Captain(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.LastName = LastName;
            this.FirstName = FirstName;
            Ships = new List<Ship>();
        }


        public override string ToString()
        {
            return String.Format("Id --> {1}{0} FirstName --> {2}{0}LastName --> {3}{0}", Environment.NewLine, Id, FirstName, LastName);
        }
    }
}