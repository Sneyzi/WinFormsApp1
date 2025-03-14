using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        // Пункт 2: Делегат
        public delegate void ParcelEventHandler(string message);

        public Form1()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);

            var sendButton = new MaterialButton { Text = "Send Parcel", Location = new Point(150, 150) };
            var displayListButton = new MaterialButton { Text = "Display Parcel List", Location = new Point(150, 200) };
            var calcCostButton = new MaterialButton { Text = "Calculate Cost", Location = new Point(150, 250) };
            Controls.Add(sendButton);
            Controls.Add(displayListButton);
            Controls.Add(calcCostButton);

            sendButton.Click += SendButton_Click;
            displayListButton.Click += DisplayListButton_Click;
            calcCostButton.Click += CalcCostButton_Click;

            var objects = new object[]
            {
                new City("Kyiv"),
                new PostOffice("Main St"),
                new Parcel(1.5, DateTime.Now, DateTime.Now.AddDays(2), 50m),
                new Client("John")
            };
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var client = new Client("Alice");
            var parcel = new Parcel(2.0, DateTime.Now, DateTime.Now.AddDays(3), 75m);

            // Пункт 5: Анонімний метод
            ParcelEventHandler handler = delegate(string msg) { MessageBox.Show(msg); };
            handler("Parcel sent anonymously!");

            // Пункт 5: Лямбда-вираз
            var sendLambda = (Action<Parcel>)(parcel =>
            {
                client.SendParcel(parcel);
                Console.WriteLine("Lambda: Parcel sent");
            });
            sendLambda(parcel);

            // Пункт 3: Різні типи параметрів
            ProcessParcel(ref parcel, out decimal cost, new Parcel[] { parcel }, sendNotification: true);
            parcel.SaveToFile("parcel.txt");
            MessageBox.Show($"Parcel sent, cost: {cost}");
        }

        // Пункт 3: Метод з різними типами параметрів
        private void ProcessParcel(ref Parcel parcel, out decimal cost, Parcel[] parcels, bool sendNotification = true)
        {
            cost = parcel.CalculateCost();
            if (sendNotification)
                Console.WriteLine("Notification sent.");
        }

        private void DisplayListButton_Click(object sender, EventArgs e)
        {
            Parcel.DisplayParcelList();
            MessageBox.Show("Check console for parcel list.");
        }

        private void CalcCostButton_Click(object sender, EventArgs e)
        {
            var parcel = new Parcel(2.0, DateTime.Now, DateTime.Now.AddDays(3), 75m);
            MessageBox.Show($"Cost: {parcel.CalculateCost()}");
        }
    }
}