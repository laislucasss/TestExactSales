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
            string connetionString = @"Data Source=exactdev.database.windows.net;Initial Catalog=TesteTecnicoDEV;User ID=exactsales;Password=ug2nUyrEq40UYO4eWbRH"; ;
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();
            
            string sql = "SELECT dbo.Pessoa.nome Nome, dbo.Pessoa.sexo Sexo, dbo.Cargo.nomecargo Cargo FROM dbo.Pessoa RIGHT JOIN dbo.Cargo ON dbo.Pessoa.idCargo = dbo.Cargo.ID";

            SqlCommand command = new SqlCommand(sql, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable tabela = new DataTable();
            dataAdapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            cnn.Close();
        }
    }
}
