using System;

namespace WinFormsApp1
{
    public class Client
    {
        // Пункт 3: Властивості get, set
        public string Name { get; set; }

        // Пункт 4: Конструктор без параметрів
        public Client()
        {
        }

        // Пункт 4: Конструктор з параметрами
        public Client(string name)
        {
            Name = name;
        }

        // Пункт 9: Віртуальна функція
        public virtual void SendParcel(Parcel p)
        {
            Console.WriteLine($"{Name} sending parcel.");
            p.Send();
        }

        // Додатковий метод
        public void Pay(decimal amount)
        {
            Console.WriteLine($"{Name} paid {amount}");
        }
    }

    // Пункт 7: Sealed клас
    public sealed class SealedClient : Client
    {
        public string Phone { get; set; }

        public SealedClient()
        {
        }

        public SealedClient(string name, string phone) : base(name)
        {
            Phone = phone;
        }

        // Пункт 8: Перевизначення методу
        public override void SendParcel(Parcel p)
        {
            Console.WriteLine($"{Name} (Phone: {Phone}) sending sealed parcel.");
            p.Send();
        }
    }
}