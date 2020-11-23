using Data;
using Domain;
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

namespace Aplicacao.View
{
    /// <summary>
    /// Lógica interna para LoginCadastro.xaml
    /// </summary>
    public partial class LoginCadastro : Window
    {
        public LoginCadastro()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario u = new Usuario();


            if (txtLogCad1.Text.Length == 0) {
                MessageBox.Show("O campo usuario não pode ser vazio!");
                txtLogCad1.Focus();
            }
            else if (pswLogCad1.Password.Length == 0 || pswLogCad2.Password.Length == 0)
            //@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                MessageBox.Show("O campo senha não pode ser vazio!");
                txtLogCad1.Focus();
            }
            else if (pswLogCad1.Password != pswLogCad2.Password) {
                MessageBox.Show("As senhas não são iguais. Verifique !");

            }
            else {
                u.Usu_nome = txtLogCad1.Text;
                u.Usu_psw = pswLogCad2.Password;
                u.Usu_tipo = "ADM";

                using (Contexto bd = new Contexto()) {

                    bd.Usuario.Add(u);
                    bd.SaveChanges();

                }
                MessageBox.Show("Cadastro realizado com sucesso!!");

                Close();
            }
        }
    }
}

