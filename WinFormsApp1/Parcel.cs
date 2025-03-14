using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1
{
    public class Parcel
    {
        // Пункт 3: Властивості get, set
        public double Weight { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }

        // Пункт 12: Статичний зв’язний список
        public static LinkedList<Parcel> ParcelList = new LinkedList<Parcel>();

        // Пункт 4: Конструктор без параметрів
        public Parcel() { }

        // Пункт 4: Конструктор з параметрами
        public Parcel(double weight, DateTime sendDate, DateTime deliveryDate, decimal price)
        {
            Weight = weight;
            SendDate = sendDate;
            DeliveryDate = deliveryDate;
            Price = price;
            ParcelList.AddLast(this); // Додаємо до статичного списку
        }

        // Пункт 9: Віртуальна функція
        public virtual void Send()
        {
            Console.WriteLine($"Parcel sent: {Weight}kg, Price: {Price}");
        }

        // Пункт 11: Запис у файл
        public void SaveToFile(string path)
        {
            File.WriteAllText(path, $"{Weight},{SendDate},{DeliveryDate},{Price}");
        }

        // Пункт 11: Читання з файлу
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

        // Пункт 12: Статичний метод перегляду списку
        public static void DisplayParcelList()
        {
            foreach (var parcel in ParcelList)
            {
                Console.WriteLine($"Parcel: {parcel.Weight}kg, {parcel.Price}");
            }
        }
    }
}