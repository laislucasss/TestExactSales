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

namespace TesteExactSales
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Shown(object sender, EventArgs e)
        {
              string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=exactdev.database.windows.net;Initial Catalog=TesteTecnicoDEV;User ID=exactsales;Password=ug2nUyrEq40UYO4eWbRH";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM dbo.Pessoa RIGHT JOIN dbo.Cargo ON dbo.Pessoa.idCargo = dbo.Cargo.ID";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(1) + "\n";
            }
            MessageBox.Show(Output);
            cnn.Close();
        }
    }
}
