using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class City
    {
        public string Name { get; set; }
        public List<PostOffice> PostOffices { get; set; } = new List<PostOffice>();

        public new string ToString => $"City: {Name}";

        public City()
        {
        }

        public City(string name)
        {
            Name = name;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"City: {Name}, Post Offices: {PostOffices.Count}");
        }

        public void AddPostOffice(PostOffice po)
        {
            PostOffices.Add(po);
        }
    }
}