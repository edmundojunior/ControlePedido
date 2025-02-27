﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlePedido
{
    public partial class frmLiberacao : Form
    {
        public int usuario = 0;
        public bool liberado = false;

        Usuarios usuarios = new Usuarios();

        public frmLiberacao()
        {
            InitializeComponent();
            limpar();
        }

        private void frmLiberacao_Load(object sender, EventArgs e)
        {

        }

        private void limpar()
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
            

            txtLogin.Focus();   

        }
        private void bntSair_Click(object sender, EventArgs e)
        {
            liberado = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            liberacao();
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLogin.Text = txtLogin.Text.ToUpper();

                
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void liberacao()
        {

            if (txtLogin.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Favor informar os dados de acesso do Usuário", "Importante");
                limpar();
                return;
            }

            if (usuarios.retornaPermissao(txtLogin.Text.ToUpper(), txtSenha.Text))
            {
                lblAviso.Visible = false;

                if (usuarios.retornaAutorizacao(txtLogin.Text, txtSenha.Text))
                {
                    liberado = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuário não possui Permissão para Entregar Produto, \n verificar com Administrador ");
                    liberado = false;
                }
            }
            else
            {
                lblAviso.Visible = true;
                limpar();
            }
            


        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
