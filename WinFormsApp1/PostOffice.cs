using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class PostOffice
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Parcel> Parcels { get; set; } = new List<Parcel>();

        public PostOffice() { }

        public PostOffice(string address)
        {
            Address = address;
        }

        public virtual void AcceptParcel(Parcel p)
        {
            Parcels.Add(p);
            Console.WriteLine($"Parcel accepted at {Address}");
        }
    }
}