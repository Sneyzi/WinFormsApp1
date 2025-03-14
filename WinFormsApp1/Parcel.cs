using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1
{
    public class Parcel : ISendable // Пункт 1: Реалізація інтерфейсу
    {
        public double Weight { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }
        public static LinkedList<Parcel> ParcelList = new LinkedList<Parcel>();

        public Parcel()
        {
        }

        public Parcel(double weight, DateTime sendDate, DateTime deliveryDate, decimal price)
        {
            Weight = weight;
            SendDate = sendDate;
            DeliveryDate = deliveryDate;
            Price = price;
            ParcelList.AddLast(this);
        }

        public virtual void Send()
        {
            Console.WriteLine($"Parcel sent: {Weight}kg, Price: {Price}");
        }

        public void SaveToFile(string path)
        {
            File.WriteAllText(path, $"{Weight},{SendDate},{DeliveryDate},{Price}");
        }

        public static Parcel LoadFromFile(string path)
        {
            var data = File.ReadAllText(path).Split(',');
            return new Parcel(
                double.Parse(data[0]),
                DateTime.Parse(data[1]),
                DateTime.Parse(data[2]),
                decimal.Parse(data[3])
            );
        }

        public static void DisplayParcelList()
        {
            foreach (var parcel in ParcelList)
            {
                Console.WriteLine($"Parcel: {parcel.Weight}kg, {parcel.Price}");
            }
        }

        // Пункт 1: Реалізація методу інтерфейсу
        public decimal CalculateCost()
        {
            return Price + (decimal)Weight * 10m;
        }

        // Пункт 4: Індексатор
        public int this[int index]
        {
            get => index == 0 ? (int)Weight : (int)Price;
            set
            {
                if (index == 0) Weight = value;
                else if (index == 1) Price = value;
            }
        }
    }
}