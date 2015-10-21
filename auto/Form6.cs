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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            Fillcombo();
            Fillcombo1();
            Fillcombo2();
            Fillcombo3();
            FillcomboDel();
        }
        void Fillcombo()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select * from Hospital.Medicine;";
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
            string Query = "select * from Hospital.Medicine;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string maker = myReader.GetString("maker");
                    comboBox2.Items.Add(maker);
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
            string Query = "select * from Hospital.Medicine;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string medicine = myReader.GetString("type_medicine");
                    comboBox3.Items.Add(medicine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void Fillcombo3()
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select * from Hospital.Medicine;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string country = myReader.GetString("country");
                    comboBox4.Items.Add(country);
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
            string Query = "select * from Hospital.Medicine;";
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
                    comboBox5.Items.Add(medicine);
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
            //MySqlCommand cmdDataBase = new MySqlCommand("select * from Hospital.Medicine;", conDataBase);
            MySqlCommand cmdDataBase = new MySqlCommand("select id_medicine as'№ товару',maker as'Виробник',type_medicine as'Тип ліків',medicine_date as'Дата виготовлення',price as 'ціна',country as '№ країни' from Hospital.Medicine;", conDataBase);
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

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "delete from Hospital.Medicine where id_medicine='" + this.comboBox5.Text + "';";
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "update Hospital.Medicine set id_medicine='" + this.comboBox1.Text + "',maker='" + this.comboBox2.Text + "',type_medicine='" + this.comboBox1.Text + "';";
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["№ товару"].Value.ToString();
                comboBox2.Text = row.Cells["Виробник"].Value.ToString();
                comboBox3.Text = row.Cells["Тип ліків"].Value.ToString();
                textBox4.Text = row.Cells["Дата виготовлення"].Value.ToString();
                textBox5.Text = row.Cells["ціна"].Value.ToString();
                comboBox4.Text = row.Cells["№ країни"].Value.ToString();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
