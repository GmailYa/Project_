using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=213.159.192.108;Initial Catalog=aaa;User ID=admin;Password=admin";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT *FROM[employees]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "                                " + Convert.ToString(sqlReader["NUMBER"]) + "                               " + Convert.ToString(sqlReader["EXPIRIENCE"]) +"              " + Convert.ToString(sqlReader["FIO"])+"                " + Convert.ToString(sqlReader["POST"]));
                }
               
                listBox2.Items.AddRange(listBox1.Items);
                listBox3.Items.AddRange(listBox1.Items);
                listBox4.Items.AddRange(listBox1.Items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            {
                listBox1.Items.Clear();
                SqlDataReader sqlReader = null;

                SqlCommand command = new SqlCommand("SELECT *FROM[employees]", sqlConnection);
                try
                   
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "                                " + Convert.ToString(sqlReader["NUMBER"]) + "                               " + Convert.ToString(sqlReader["EXPIRIENCE"]) + "              " + Convert.ToString(sqlReader["FIO"]) + "                " + Convert.ToString(sqlReader["POST"]));

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }


            if (label4.Visible)
                label4.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [employees] (ID, FIO, POST, NUMBER, EXPIRIENCE) VALUES(@ID, @FIO, @POST, @NUMBER, @EXPIRIENCE)", sqlConnection);
                command.Parameters.AddWithValue("ID", textBox1.Text);
                command.Parameters.AddWithValue("FIO", textBox2.Text);
                command.Parameters.AddWithValue("POST", comboBox1.Text);
                command.Parameters.AddWithValue("NUMBER", textBox3.Text);
                command.Parameters.AddWithValue("EXPIRIENCE", textBox8.Text);


                await command.ExecuteNonQueryAsync();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox8.Clear();

            }
            else
            {
                label4.Visible = true;
                label4.Text = "Поля не заполнены!";
            }
        }
              
    
        private async void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT *FROM[employees]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["ID"]) + "                                " + Convert.ToString(sqlReader["NUMBER"]) + "                               " + Convert.ToString(sqlReader["EXPIRIENCE"]) + "              " + Convert.ToString(sqlReader["FIO"]) + "                " + Convert.ToString(sqlReader["POST"]));
                }
                listBox2.Items.AddRange(listBox1.Items);
                listBox3.Items.AddRange(listBox1.Items);
                listBox4.Items.AddRange(listBox1.Items);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if ((textBox6.TextLength == 8) && ((textBox5.Text).Contains("Грузчик") ^ (textBox5.Text).Contains("Директор") ^ (textBox5.Text).Contains("Диктатор") ^ (textBox5.Text).Contains("Заместитель директора") ^ (textBox5.Text).Contains("Кассир") ^ (textBox5.Text).Contains("Менеджер") ^ (textBox5.Text).Contains("Начальник службы безопасности")))
            {
                if (label9.Visible)
                    label9.Visible = false;

                if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                    !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                    !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                    !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                    !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    SqlCommand command = new SqlCommand("UPDATE [employees] SET [FIO]=@FIO, [POST]=@POST ,[NUMBER]=NUMBER, [EXPIRIENCE]=EXPIRIENCE WHERE [ID]=@ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", textBox6.Text);
                    command.Parameters.AddWithValue("FIO", textBox4.Text);
                    command.Parameters.AddWithValue("POST", textBox5.Text);
                    command.Parameters.AddWithValue("NUMBER", textBox9.Text);
                    command.Parameters.AddWithValue("EXPIRIENCE", textBox10.Text);

                    await command.ExecuteNonQueryAsync();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox9.Clear();
                    textBox10.Clear();


                }
                else if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    label9.Visible = true;
                    label9.Text = "Не все поля заполнены";
                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "Личный номер должен быть заполнен";
                }
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Неверно заполнена должность";
            }

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
                label10.Visible = false;

            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && (textBox7.TextLength == 8)) 
            {
                SqlCommand command = new SqlCommand("DELETE FROM [employees] WHERE [ID]=@ID", sqlConnection);
                command.Parameters.AddWithValue("ID", textBox7.Text);
                await command.ExecuteNonQueryAsync();
                textBox7.Clear();

            } 
            else
            {
                label10.Visible = true;
                label10.Text = "Неверно заполнен личный номер";
            }
              
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа для работы с личными данными сотрудников");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)

                   {
            listBox5.Items.Clear();
            {
                    
                    SqlDataReader sqlReader = null;

                    SqlCommand command = new SqlCommand("UPDATE  [aaa].[dbo].[employees] SET [ZP] = [aaa].[dbo].[employees].[EXPIRIENCE]*[aaa].[dbo].[ZP].[OKLAD] FROM[aaa].[dbo].[ZP],[aaa].[dbo].[employees] SELECT *FROM[employees]", sqlConnection);
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        while (await sqlReader.ReadAsync())
                        {
                            listBox5.Items.Add(Convert.ToString(sqlReader["ID"])+ "           " + Convert.ToString(sqlReader["ZP"])+"                                " + Convert.ToString(sqlReader["POST"])+"                                      "+ Convert.ToString(sqlReader["FIO"]));
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReader != null)
                            sqlReader.Close();
                    }
                }

            }
           
    }
}
