using FabricaDeSoftware.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FabricaDeSoftware.App
{
    public partial class ListaCalculos : Form
    {
        private readonly ICalculoDAO _calculoDAO;
        private readonly ICalculoService _calculoService;

        public ListaCalculos(ICalculoDAO calculoDAO, ICalculoService calculoService)
        {
            InitializeComponent();
            _calculoDAO = calculoDAO;
            _calculoService = calculoService;
        }

        private void ListaCalculos_Load(object sender, EventArgs e)
        {
            CarregarGrids();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int.TryParse(txtDistanciaDaReta.Text.Trim(), out int distanciaDaReta);

            if (distanciaDaReta <= 0)
            {
                MessageBox.Show("A distância da reta é obrigatória", "Operação inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _calculoService.RealizarCalculo(new Calculo(Startup.IdConfiguracao, Startup.IdUsuario, distanciaDaReta)).Wait();

            txtDistanciaDaReta.Text = string.Empty;

            CarregarGrids();

            MessageBox.Show("Cálculo realizado com sucesso. Aguardando aprovação", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtDistanciaDaReta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnCalcular.PerformClick();
        }

        private void btnAtualizarConsultas_Click(object sender, EventArgs e)
        {
            CarregarGrids();
        }

        private void CarregarGrids()
        {
            dataGridCalculos.DataSource = _calculoDAO.ObterCalculos().Result;
            dataGridViewFilaCalculo.DataSource = _calculoDAO.ObterFilaCalculos().Result;
        }
    }
}
