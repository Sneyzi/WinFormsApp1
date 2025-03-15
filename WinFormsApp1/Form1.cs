using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private readonly AppDbContext dbContext = new AppDbContext();

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
            var updateButton = new MaterialButton { Text = "Update Parcel", Location = new Point(150, 200) };
            var deleteButton = new MaterialButton { Text = "Delete Parcel", Location = new Point(150, 250) };
            Controls.Add(sendButton);
            Controls.Add(updateButton);
            Controls.Add(deleteButton);

            sendButton.Click += SendButton_Click;
            updateButton.Click += UpdateButton_Click;
            deleteButton.Click += DeleteButton_Click;

            dbContext.Database.EnsureCreated(); // Створюємо БД
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var parcel = new Parcel(2.0, DateTime.Now, DateTime.Now.AddDays(3), 75m);
            var postOffice = new PostOffice("Main St");
            parcel.PostOffice = postOffice;

            // Пункт 2: Create
            dbContext.Parcels.Add(parcel);
            dbContext.PostOffices.Add(postOffice);
            dbContext.SaveChanges();
            MessageBox.Show("Parcel added to DB!");
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var parcel = dbContext.Parcels.FirstOrDefault();
            if (parcel != null)
            {
                parcel.Price = 100m; // Пункт 2: Update
                dbContext.SaveChanges();
                MessageBox.Show("Parcel updated!");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var parcel = dbContext.Parcels.FirstOrDefault();
            if (parcel != null)
            {
                dbContext.Parcels.Remove(parcel); // Пункт 2: Delete
                dbContext.SaveChanges();
                MessageBox.Show("Parcel deleted!");
            }
        }

        private void ProcessParcel(ref Parcel parcel, out decimal cost, Parcel[] parcels, bool sendNotification = true)
        {
            cost = parcel.CalculateCost();
            if (sendNotification)
                Console.WriteLine("Notification sent.");
        }
    }
}