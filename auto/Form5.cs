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
    public partial class Form5 : Form
    {
        public Form5()
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
            string Query = "select * from Hospital.Client;";
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
                    comboBox1.Items.Add(client);
                    
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
            string Query = "select * from Hospital.Client;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string dis = myReader.GetString("id_district");
                    comboBox2.Items.Add(dis);
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
            string Query = "select * from Hospital.Client;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string street = myReader.GetString("id_street");
                    comboBox3.Items.Add(street);
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
            string Query = "select * from Hospital.Client;";
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
                    comboBox4.Items.Add(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "update Hospital.Client set id_client='" + this.comboBox1.Text + "',name_client='" + this.textBox2.Text + "',id_district='" + this.comboBox2.Text + "',id_street='" + this.comboBox3.Text + "',house='" + this.textBox5.Text + "',apartment='" + this.textBox6.Text + "',phone='" + this.textBox7.Text + "' where id_client='" + this.comboBox1.Text + "';";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            //MySqlCommand cmdDataBase = new MySqlCommand("select * from car_rental.users;", conDataBase);
            MySqlCommand cmdDataBase = new MySqlCommand("select id_client as '№ клієнта',name_client as 'ПІБ',id_district as '№ області',id_street as '№ вулиці',house as'№ будинку',apartment as '№ квартири',phone as 'телефон' from Hospital.Client;", conDataBase);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["№ клієнта"].Value.ToString();
                textBox2.Text = row.Cells["ПІБ"].Value.ToString();
                comboBox2.Text = row.Cells["№ області"].Value.ToString();
                comboBox3.Text = row.Cells["№ вулиці"].Value.ToString();
                textBox5.Text = row.Cells["№ будинку"].Value.ToString();
                textBox6.Text = row.Cells["№ квартири"].Value.ToString();
                textBox7.Text = row.Cells["телефон"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "delete from Hospital.Client where id_client='" + this.comboBox4.Text + "';";
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
    }
}
