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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            Fillcombo();
            Fillcombo1();
            Fillcombo2();
            FillcomboDel();
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
                    string order = myReader.GetString("id_order");
                    comboBox1.Items.Add(order);
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
                    string medicine = myReader.GetString("id_medicine");
                    comboBox2.Items.Add(medicine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void Fillcombo2()
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
                    string client = myReader.GetString("id_client");
                    comboBox3.Items.Add(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void FillcomboDel()
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
                    string order = myReader.GetString("id_order");
                    comboBox4.Items.Add(order);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            // MySqlCommand cmdDataBase = new MySqlCommand("select * from Hospital.Order;", conDataBase);
            MySqlCommand cmdDataBase = new MySqlCommand("select id_order as '№ замовлення',id_medicine as'№ товару',id_client as'№ клієнта',data_of_receipt as'дата отримання замовлення',data_medicine_delivery as'дата видачі замовлення',price as'ціна замовлення' from Hospital.Order;", conDataBase);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView1.DataSource = bSource;
                sda.Update(dbdataset);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "update Hospital.Order set id_order='" + this.comboBox1.Text + "',id_medicine='" + this.comboBox2.Text + "',id_client='" + this.comboBox3.Text + "',data_of_receipt='" + this.dateTimePicker1.Text + "',data_medicine_delivery='" + this.dateTimePicker2.Text + "',price='" + this.textBox7.Text + "' where id_order='" + this.comboBox1.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Зміни внесено");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "delete from Hospital.Order where id_order='" + this.comboBox4.Text + "';";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Дані видалено");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["№ замовлення"].Value.ToString();
                comboBox2.Text = row.Cells["№ товару"].Value.ToString();
                comboBox3.Text = row.Cells["№ клієнта"].Value.ToString();
                dateTimePicker1.Text = row.Cells["дата отримання замовлення"].Value.ToString();
                dateTimePicker2.Text = row.Cells["дата видачі замовлення"].Value.ToString();
                textBox7.Text = row.Cells["ціна замовлення"].Value.ToString();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
