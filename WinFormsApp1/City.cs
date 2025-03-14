using System;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public class City
    {
        // Пункт 3: Властивості get, set
        public string Name { get; set; }
        public List<PostOffice> PostOffices { get; set; } = new List<PostOffice>();

        // Пункт 5: Приховування успадкованого члена
        public new string ToString => $"City: {Name}";

        // Пункт 4: Конструктор без параметрів
        public City()
        {
        }

        // Пункт 4: Конструктор з параметрами
        public City(string name)
        {
            Name = name;
        }

        // Пункт 9: Віртуальна функція
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