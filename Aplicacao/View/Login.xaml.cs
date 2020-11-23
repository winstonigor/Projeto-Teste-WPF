using Aplicacao.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aplicacao
{
    /// <summary>
    /// Lógica interna para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }


        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



        private void btnEntrar_Click_1(object sender, RoutedEventArgs e)
        {

            SqlConnection connectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["BDTESTE"].ConnectionString);

            try {

                if (txtLogin.Text.Length == 0 || pswLogin.Password.Length == 0) {
                    System.Windows.MessageBox.Show("Campos em branco");
                    txtLogin.Focus();
                }
                else {

                    string senha, uti;
                    uti = txtLogin.Text;
                    senha = pswLogin.Password;

                    var comandoSQL = "SELECT * FROM [Usuario] WHERE [Usu_nome] = @utilizador AND [Usu_psw] = @password";

                    SqlCommand cmd = new SqlCommand(comandoSQL, connectionString);

                    cmd.Parameters.Add("@utilizador", SqlDbType.VarChar).Value = uti;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = senha;

                    connectionString.Open(); //Abre a conexão com a BD

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0) //Login com sucesso
                    {
                        System.Windows.Forms.MessageBox.Show("Login realizado com sucesso!", "Parabéns!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainWindow m = new MainWindow();
                        Close();
                        m.ShowDialog();
                    }

                }
            }
            catch (SqlException erro) {
                System.Windows.Forms.MessageBox.Show(erro + "");
            }
        }

        private void btnCadastro_Click(object sender, RoutedEventArgs e)
        {
            LoginCadastro lc = new LoginCadastro();
            lc.ShowDialog();
        }
    } 
}

