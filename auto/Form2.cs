using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace auto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Fillcombo();
            Fillcombo1();
        }

        void Fillcombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select * from Hospital.Order;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string medicine = myReader.GetString("id_medicine");
                    comboBox1.Items.Add(medicine);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void Fillcombo1()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select * from Hospital.Order;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string user = myReader.GetString("id_client");
                    comboBox2.Items.Add(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "insert into Hospital.Order(id_medicine,id_client,data_of_receipt,data_medicine_delivery,price) values('" + this.comboBox1.Text + "','" + this.comboBox2.Text + "','" + this.dateTimePicker1.Text + "','" + this.dateTimePicker2.Text + "','" + this.textBox6.Text + "');";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Додано");
                while (myReader.Read())
                {

                }
            }
            catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        }
    }

