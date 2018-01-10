using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail; 
using System.Windows.Forms;
using SwissTransport;

namespace floisteinschatz
{
    public partial class Form1 : Form
    {
        Transport transport;

        public Form1()
        {
            InitializeComponent();
            transport = new Transport();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Station> stations = transport.GetStations(textBox1.Text).StationList;
            foreach (Station station in stations)
            {
                listBox1.Items.Add(station.Name);
            }
        }

        //void AutoCompleteText()
        //{
        // textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //AutoCompleteStringCollection coll = new AutoCompleteStringCollection(); 
        //} 

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            List<Station> stations = transport.GetStations(textBox2.Text).StationList;
            foreach (Station station in stations)
            {
                listBox2.Items.Add(station.Name);
            }
        }

        private void changedtext(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        private void changedtext2(object sender, EventArgs e)
        {
            textBox2.Text = listBox2.SelectedItem.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SwissTransport.Transport connection = new SwissTransport.Transport();
            var connect = connection.GetConnections(textBox1.Text, textBox2.Text);
            foreach (var conn in connect.ConnectionList)
            {
                abfahrtsstation.Visible = true;
                abfahrtszeit.Visible = true;
                abfahrtszone.Visible = true;
                ankunftsstation.Visible = true;
                ankunftszeit.Visible = true;
                ankunftszone.Visible = true;
                verspaetung.Visible = true;
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = textBox1.Text;
                row.Cells[1].Value = DateTime.Parse(conn.From.Departure).ToString("HH:mm");
                row.Cells[1].Value = row.Cells[1].Value + " h";
                row.Cells[2].Value = conn.From.Platform;
                row.Cells[3].Value = textBox2.Text;
                row.Cells[4].Value = DateTime.Parse(conn.To.Arrival).ToString("HH:mm");
                row.Cells[4].Value = row.Cells[4].Value + " h";
                row.Cells[5].Value = conn.To.Platform;
                row.Cells[6].Value = conn.To.Delay;
                dataGridView1.Rows.Add(row);
            }

            // List<Connections> connections = transport.GetConnections(textBox1.Text, textBox2.Text).fromStation;
            //foreach (Connections connection in connections)
            //{
            //  listBox3.Items.Add(connection.Name);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(textBox2.Text == ""))
            {
                var station = textBox2.Text;
                string adresse = "https://www.google.ch/maps/place/" + station.ToString();
                System.Diagnostics.Process.Start(adresse);
            }
            else
            {
                MessageBox.Show("Kein Ort eingegeben!", "OK");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!(textBox1.Text == ""))
            {
                var station = textBox1.Text;
                string adresse = "https://www.google.ch/maps/place/" + station.ToString();
                System.Diagnostics.Process.Start(adresse);
            }
            else
            {
                MessageBox.Show("Kein Ort eingegeben!", "OK");
            }
        }

       
    }
}


