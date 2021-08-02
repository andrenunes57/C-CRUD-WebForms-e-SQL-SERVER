using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Consulta
{
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand comando;
        SqlDataAdapter da;
        SqlDataReader dr;

        string strSQL;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T16M5FS\SQLEXPRESS; Database = Cliente; Integrated Security=True;");

                strSQL = "INSERT INTO CAD_CLIENTE (NOME, NUMERO) VALUES (@NOME, @NUMERO)";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            } 
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T16M5FS\SQLEXPRESS; Database = Cliente; Integrated Security=True;");

                strSQL = "SELECT * FROM CAD_CLIENTE";

                DataSet ds = new DataSet();

                da = new SqlDataAdapter(strSQL, conexao);

                conexao.Open();

                da.Fill(ds);

                dgvDados.DataSource = ds.Tables[0];
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T16M5FS\SQLEXPRESS; Database = Cliente; Integrated Security=True;");

                strSQL = "SELECT * FROM CAD_CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);

                conexao.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtNome.Text = (string)dr["nome"];
                    txtNumero.Text = Convert.ToString(dr["numero"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T16M5FS\SQLEXPRESS; Database = Cliente; Integrated Security=True;");

                strSQL = "UPDATE CAD_CLIENTE SET NOME = @NOME, NUMERO = @NUMERO WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server = DESKTOP-T16M5FS\SQLEXPRESS; Database = Cliente; Integrated Security=True;");

                strSQL = "DELETE CAD_CLIENTE WHERE ID = @ID";

                comando = new SqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@ID", txtID.Text);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
    }
}
