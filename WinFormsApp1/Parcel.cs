using System;

namespace WinFormsApp1
{
    public class Parcel : ISendable
    {
        public int Id { get; set; } // Додано для EF
        public double Weight { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public int PostOfficeId { get; set; } // Пункт 5: Зв’язок один до багатьох
        public PostOffice PostOffice { get; set; } // Пункт 3: Навігаційна властивість
        public int? ClientId { get; set; } // Пункт 4: Зв’язок один до одного
        public Client Client { get; set; } // Пункт 3: Навігаційна властивість

        public Parcel() { }
        public Parcel(double weight, DateTime sendDate, DateTime deliveryDate, decimal price)
        {
            Weight = weight;
            SendDate = sendDate;
            DeliveryDate = deliveryDate;
            Price = price;
        }

        public virtual void Send() { }
        public decimal CalculateCost() => Price + (decimal)Weight * 10m;
        public int this[int index]
        {
            get => index == 0 ? (int)Weight : (int)Price;
            set { if (index == 0) Weight = value; else if (index == 1) Price = value; }
        }
    }
}