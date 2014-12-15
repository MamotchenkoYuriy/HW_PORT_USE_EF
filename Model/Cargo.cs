using System;

namespace Model
{
    public class Cargo : BaseEntity
    {
        public int Number { get; set; }
        public int CargoTypeId { get; set; }
        public virtual CargoType CargoType { get; set; }
        public int Weight { get; set; }
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public double Price { get; set; }
        public double InsurancePrice { get; set; }

        public Cargo() { }

        public Cargo(int Id, int Number, int CargoTypeId, int Weight, int TripId, double Price, double InsurancePrice)
        {
            this.Id = Id;
            this.Number = Number;
            this.CargoTypeId = CargoTypeId;
            this.Weight = Weight;
            //this.TripId = TripId;
            this.Price = Price;
            this.InsurancePrice = InsurancePrice;
        }
        public override string ToString()
        {
            return String.Format("Id --> {1}{0}Number --> {2}{0}CargoTypeId --> {3}{0}Weight --> {4}{0}TripId --> {5}{0}Price --> {6}{0}InsurancePrice --> {7}{0}",
                Environment.NewLine, Id, Number, CargoTypeId, Weight, Weight /*TripId*/, Price, InsurancePrice);
        }
    }
}