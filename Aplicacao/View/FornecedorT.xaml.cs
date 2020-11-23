using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Domain;
using Data;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Aplicacao
{
    /// <summary>
    /// Lógica interna para Fornecedor.xaml
    /// </summary>

    public partial class FornecedorT : Window
    {
        private int txtCod;

        public FornecedorT()
        {
            InitializeComponent();
            //if (!ExibirDados()) {
              //  MessageBox.Show("Erro0");
            //}

        }

        /*private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try {
                ExibirDados();
            }
            catch (Exception ex) {
                MessageBox.Show("Erro : " + ex.Message);
                this.Close();
            }
        }*/

      
        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            tbCadastro.IsSelected = true;
            btnCadForSalvar.Visibility = Visibility.Visible;

        }

        private void btnCadForSalvar_Click_1(object sender, RoutedEventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.For_nome = txtForNome.Text;
            fornecedor.For_cnpj = txtCadFonecCNPJ.Text;
            fornecedor.For_endereco = txtCadFonecCNPJ.Text;

            if (chb_CadFornec.IsChecked == true) {
                fornecedor.For_ativ = true;//(bool)chb_CadFornec.IsChecked;
            }
            else {
                fornecedor.For_ativ = false;
            }

            using (Contexto con = new Contexto()) {
                con.Fornecedor.Add(fornecedor);
                con.SaveChanges();
                MessageBox.Show("CaDastro Realizado com Sucesso!");

            }
            LimpaTela();
        }

        /* public void ExibirDados()
         {
             DataTable dtb = Acesso.getTabela();
             dgFonec.DataContext = dtb.DefaultView;
         }*/


        //Funciona
       /* public bool ExibirDados()
        {
            SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["BDTESTE"].ConnectionString);
           bool status = false;
            try {
                connectionString.Open();
                SqlCommand comandoSQL = new SqlCommand("Select * from Fornecedor", connectionString);
                SqlDataAdapter adp = new SqlDataAdapter(comandoSQL);
                DataTable ds = new DataTable();
                adp.Fill(ds);//"ExibirDados");
                dgFonec.ItemsSource = ds.DefaultView;
                status = true;


            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
            finally {
                connectionString.Close();
            }
            return status;
        }*/


        private void LimpaTela()
        {
            txtForNome.Text = ("");
            txtCadFonecCNPJ.Text = ("");
            txtCadFornEnd.Text = ("");
            txtForNome.Focus();
        }

        private void btnCadFornCanc_Click(object sender, RoutedEventArgs e)
        {
            tbConsulta.IsSelected = true;
            //ExibirDados();
            ListarDados();
            txtPesquisa.Focus();
        }
         
        // Dois Clik no grid
        private void dgFonec_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.tbCadastro.IsSelected = true;

            if (dgFonec.SelectedIndex >= 0) {
                
                Fornecedor f = (Fornecedor)dgFonec.SelectedItem;
                txtCod = f.For_codigo;
                txtForNome.Text = f.For_nome;
                txtCadFonecCNPJ.Text = f.For_cnpj;
                txtCadFornEnd.Text = f.For_endereco;
                chb_CadFornec.Tag = f.For_ativ;

                btnSalvarAlt.Visibility = Visibility.Visible;
                btnCadForSalvar.Visibility = Visibility.Hidden;
                //MessageBox.Show("ss");
                tbCadastro.IsSelected = true; //NÃO FUNCIONA E NÃO SEI PQ... REVISAR DEPOIS


            }




            //Funciona
            /*try {
                if (sender != null) {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1) {
                        //This is the code which helps to show the data when the row is double clicked.
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        DataRowView dr = (DataRowView)dgr.Item;

                        Fornecedor f = new Fornecedor();
                        f.For_codigo = (int)dr[0];
                        f.For_nome = dr[1].ToString();
                        f.For_cnpj = dr[2].ToString();
                        f.For_endereco = dr[3].ToString();
                        f.For_ativ = (bool)dr[4];

                        txtForNome.Text = f.For_nome;
                    }

                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }



            tbCadastro.IsSelected = true;*/

            //}
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.ListarDados();
        }

        private void ListarDados()
        {
            using (Contexto c = new Contexto()) {
                var consulta = c.Fornecedor;
                dgFonec.ItemsSource = consulta.ToList();
            }
        }


        private void Alteratab()
        {
            tbCadastro.IsSelected = true;
        }

        private void chb_CadFornec_Checked(object sender, RoutedEventArgs e)
        {

        }

        //Alterar
        private void btnSalvarAlt_Click(object sender, RoutedEventArgs e)
        {         
                     

            using (Contexto con = new Contexto()) {

                Fornecedor fornecedoralt = con.Fornecedor.Find(Convert.ToInt32(txtCod));

                
                fornecedoralt.For_nome = txtForNome.Text;
                fornecedoralt.For_cnpj = txtCadFonecCNPJ.Text;
                fornecedoralt.For_endereco = txtCadFonecCNPJ.Text;
                //con.Fornecedor.Add(fornecedor);
                con.SaveChanges();
                MessageBox.Show("CaDastro Atualizado com Sucesso!");

            }
            LimpaTela();
            tbConsulta.IsSelected = true;
        }
    }
}
