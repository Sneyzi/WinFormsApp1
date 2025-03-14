using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class PostOffice
    {
        // Пункт 3: Властивості get, set
        public string Address { get; set; }
        public List<Parcel> Parcels { get; set; } = new List<Parcel>();

        // Пункт 4: Конструктор без параметрів
        public PostOffice() { }

        // Пункт 4: Конструктор з параметрами
        public PostOffice(string address)
        {
            Address = address;
        }

        // Пункт 9: Віртуальна функція
        public virtual void AcceptParcel(Parcel p)
        {
            Parcels.Add(p);
            Console.WriteLine($"Parcel accepted at {Address}");
        }
    }
}