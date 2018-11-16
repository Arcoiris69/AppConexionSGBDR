using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppConexionSGBDR
{
    public partial class TreeViewMySQL : Form
    {
       
        public TreeViewMySQL(MySql.Data.MySqlClient.MySqlConnection conn, string database)
        {
            InitializeComponent();
            treeView(conn, database);
        }
        
        

        public void treeView(MySql.Data.MySqlClient.MySqlConnection conn, string database)
        {
            tvData.Nodes.Clear();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT schema_name FROM information_schema.schemata WHERE schema_name = '"+database+"';", conn);
            try
            {
                MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
                int nodos = rdr.FieldCount;
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        string c = rdr.GetName(i);
                        tvData.Nodes.Add(rdr[c].ToString());
                    }
                }
                rdr.Close();
                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT table_name FROM information_schema.tables where table_schema = '" + database + "';", conn);
                MySql.Data.MySqlClient.MySqlDataReader rdr2 = cmd2.ExecuteReader();

                string[] vect = new string[rdr2.FieldCount];
                while (rdr2.Read())
                {
                    for (int i = 0; i < rdr2.FieldCount; i++)
                    {
                        string c = rdr2.GetName(i);
                        tvData.Nodes[0].Nodes.Add(rdr2[c].ToString());
                        vect[i] = rdr2[c].ToString();
                    }
                }
                rdr2.Close();

                for (int x = 0; x < vect.GetLongLength(0); x++)
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT COLUMN_NAME  FROM information_schema.columns where TABLE_NAME='" + vect[x] + "';", conn);
                    MySql.Data.MySqlClient.MySqlDataReader rdr3 = cmd2.ExecuteReader();
                    while (rdr3.Read())
                    {
                        for (int i = 0; i < rdr3.FieldCount; i++)
                        {
                            string c = rdr3.GetName(i);
                            tvData.Nodes[0].Nodes[x].Nodes.Add(rdr3[c].ToString());
                        }
                    }
                    rdr3.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("no ha seleccionado ninguna BD");

            }
        }

        

        private void tvData_DoubleClick(object sender, EventArgs e)
        {
        }

        private void tvData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show(e.Node.Text);
        }
        private  void getColumn(string columnName,bool rid, int cant, MySql.Data.MySqlClient.MySqlDataReader rdr2, int node)
        {
            while (rid)
            {
                for (int i = 0; i < cant; i++)
                {
                    string c = rdr2.GetName(i);
                    tvData.Nodes[0].Nodes[node].Nodes.Add(rdr2[c].ToString());
                }
            }

        }
        
    }
        
    }

