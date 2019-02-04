using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Login2_Click(object sender, RoutedEventArgs e)
        {
  
            Login1 log= new Login1();
            log.Show();
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";  
        }

        private void button3_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (checkemail() == true)
            {
                errormessage.Text = "Email id already registered";
            }
            else
            {
                if (textBoxEmail.Text.Length == 0)
                {
                    errormessage.Text = "Enter an email";
                    textBoxEmail.Focus();
                }
                else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Enter valid mail";
                    textBoxEmail.Select(0, textBoxEmail.Text.Length);
                    textBoxEmail.Focus();
                }
                else
                {
                    string firstname = textBoxFirstName.Text;
                    string lastname = textBoxLastName.Text;
                    string email = textBoxEmail.Text;
                    string password = passwordBox1.Password;
                    if (passwordBox1.Password.Length == 0)
                    {
                        errormessage.Text = "Enter password";
                        passwordBoxConfirm.Focus();
                    }
                    else if (passwordBox1.Password != passwordBoxConfirm.Password)
                    {
                        errormessage.Text = "Confirm password must be same as password";
                        passwordBoxConfirm.Focus();
                    }
                    else
                    {
                        errormessage.Text = "";
                        string address = textBoxAddress.Text;
                        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rushabhg\Documents\basic1.mdf;Integrated Security=True;Connect Timeout=30");
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Insert into Registration (FirstName,LastName,Email,Password,Address) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + address + "')", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show( "You have Registered successfully.....");
                        Login1 log = new Login1();
                        log.Show();
                        Close();
                    }
                }


            }
        }

        private Boolean checkemail()
        {
        
            Boolean emailavailable = false;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\rushabhg\Documents\basic1.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from registration where email='" + textBoxEmail.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                emailavailable = true;
            }
            con.Close();
            return emailavailable;
        }
     
    }
}
