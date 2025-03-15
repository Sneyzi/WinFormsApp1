using System;

namespace WinFormsApp1
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Client()
        {
        }

        public Client(string name)
        {
            Name = name;
        }

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

        public override void SendParcel(Parcel p)
        {
            Console.WriteLine($"{Name} (Phone: {Phone}) sending sealed parcel.");
            p.Send();
        }
    }
}