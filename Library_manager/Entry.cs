using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Library_manager
{
    public partial class Entry : Form
    {
        private bool mConnectionOk;

        public Entry()
        {
            InitializeComponent();
            mConnectionOk = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "" && textBox2.Text != "")
                && (textBox1.Text != "Введите логин" && textBox2.Text != "Введите пароль")
                && (textBox1.Text != "Заполните это поле!" && textBox2.Text != "Заполните это поле!"))
            {
                //String resultString = Program.getSQLiteConnection(textBox1.Text, textBox2.Text);
                SQLiteConnection sqlite_conn = Program.getSQLiteConnection(textBox1.Text, textBox2.Text);
                try
                {
                    if (sqlite_conn != null)
                    {
                        Globals.setSQLiteConnection(sqlite_conn);
                        MessageBox.Show("Соединение создано!");
                        mConnectionOk = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (textBox1.Text == ""
                    || textBox1.Text == "Введите логин"
                    || textBox1.Text == "Заполните это поле!")
                {
                    textBox1.ForeColor = Color.Red;
                    textBox1.Text = "Заполните это поле!";
                }
                if (textBox2.Text == ""
                    || textBox2.Text == "Введите пароль"
                    || textBox2.Text == "Заполните это поле!")
                {
                    textBox2.UseSystemPasswordChar = false;
                    textBox2.ForeColor = Color.Red;
                    textBox2.Text = "Заполните это поле!";
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.ForeColor = Color.Black;
            textBox2.Text = "";
        }

        private void Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mConnectionOk)
            {
                Application.Exit();
            }
        }

    }
}
