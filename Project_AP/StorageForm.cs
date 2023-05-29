using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_AP
{
    public partial class StorageForm : Form
    {
        public int LocWidth;
        public int LocHeight;

        public StorageForm()
        {
            InitializeComponent();
        }
        private void StorageForm_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(143, 142, 191), ButtonBorderStyle.Solid);
        }
        private void StorageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private async void StorageForm_Load(object sender, EventArgs e)
        {
            // Получение данных из Tag и использование их
            if (Tag != null)
            {
                int loc_id = (int)Tag;
                panel2.Width = LocWidth;
                panel2.Height = LocHeight;

                string apiUrlRack = "https://helow19274.ru/aip/api/rack";
                string apiUrlStock = "https://helow19274.ru/aip/api/stock";
                string authorizationToken = "5RNYBdLduTDxQCcM8YYrb5nA:H4dScAyGbS89KgLgZBs2vPsk";
                RackService rackService = new RackService(apiUrlRack, authorizationToken);

                try
                {
                    List<Rack> racks = await rackService.GetRackInfoApi(loc_id);
                    int height = (int)(flowLayoutPanel1.Height / 6);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }

            }
        }
    }
}
