using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadarPlot
{
    public partial class RadarEditDialog : Form
    {
        private double X, Y;
        private double Offset;
        private Radar radar;
        public RadarEditDialog(Radar r)
        {
            InitializeComponent();
            radar = r;
            X = r.Location.X;
            Y = r.Location.Y;
            Offset = r.Offset;
            textBox4.Text = X.ToString();
            textBox5.Text = Y.ToString();
            textBox6.Text = Offset.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            radar.Location.X = (int)X;
            radar.Location.Y = (int)Y;
            radar.Offset = Offset;
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                X = double.Parse(textBox4.Text);
            }
            catch
            {

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Y = double.Parse(textBox5.Text);
            }
            catch
            {

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Offset = double.Parse(textBox6.Text);
            }
            catch
            {

            }
        }
    }
}
