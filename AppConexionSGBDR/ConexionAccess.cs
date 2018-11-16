using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppConexionSGBDR
{
    public partial class ConexionAccess : Form
    {
        

        public ConexionAccess()
        {
            InitializeComponent();
        }
        OleDbConnection con;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Downloads\CPremier_Limpia.accdb";
                con = new OleDbConnection(ConnectionString);
                con.Open();
                MessageBox.Show("conectado");

            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Error de conexion");

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(con.State == ConnectionState.Open)
                {
                    OleDbDataReader rdr;
                    OleDbCommand cmd = new OleDbCommand(txtSentencia.Text, con);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            string c = rdr.GetName(i);
                            lstResult.Items.Add(c + ": " + rdr[c] + Environment.NewLine);
                        }

                        lstResult.Items.Add(Environment.NewLine);
                    }
                    rdr.Close();
                }
                else
                {
                    MessageBox.Show("no hay conexion");
                }
                
            }
            catch(OleDbException ex)
            {
                MessageBox.Show("error");
            }
        }
    }
}
