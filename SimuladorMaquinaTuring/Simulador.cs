using SimuladorMaquinaTuring.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimuladorMaquinaTuring
{
    public partial class Simulador : Form
    {
        private MaquinaDeTuring maquinaDeTuring = null;

        public Simulador()
        {
            InitializeComponent();
        }

        private void BtnCorrerPresionado(bool habilitar)
        {
            btnCorrer.Enabled = habilitar;
            btnSiguiente.Enabled = habilitar;
        }

        private void BtnPausarPresionado(bool habilitar)
        {
            btnPausar.Enabled = habilitar;
        }
        private void BtnSiguientePresionado()
        {

        }

        private void btnDetenerPresionado()
        {
            btnCorrer.Enabled = true;
            btnSiguiente.Enabled = true;
            btnPausar.Enabled = true;
            btnDetener.Enabled = true;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();

                BtnCorrerPresionado(false);

                if (maquinaDeTuring == null)
                {
                    maquinaDeTuring = new MaquinaDeTuring(
                            "q0",
                            new Cabezal(new List<char>(rtbEntrada.Text.ToCharArray()), 0),
                            Utilidades.GenerarTablaDeTransiciones(dgvTablaTransiciones),
                            int.Parse(txtIntervaloTiempo.Text),
                            0);
                }

                dgvTablaTransiciones.Rows[maquinaDeTuring.IndiceEnLaTabla].DefaultCellStyle.BackColor = Color.Red;
                dgvTablaTransiciones.Update();

                rtbEntrada.Select(maquinaDeTuring.Cabezal.PosicionDelCabezal, 1);
                rtbEntrada.SelectionColor = Color.Red;
                rtbEntrada.Update();

                maquinaDeTuring.CambiarEstadoACorrer();

                Loop();

            }
            catch (Exception ex)
            {
                BtnCorrerPresionado(true);
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();

                if (maquinaDeTuring == null)
                {
                    maquinaDeTuring = new MaquinaDeTuring(
                       "q0",
                       new Cabezal(new List<char>(rtbEntrada.Text.ToCharArray()), 0),
                       Utilidades.GenerarTablaDeTransiciones(dgvTablaTransiciones),
                       int.Parse(txtIntervaloTiempo.Text),
                       0);
                }

                if (maquinaDeTuring.EstadoActual.Contains("accept") || maquinaDeTuring.EstadoActual.Contains("reject"))
                    MessageBox.Show("Done! " + maquinaDeTuring.EstadoActual);
                else
                    maquinaDeTuring = maquinaDeTuring.Step();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loop()
        {
            var thread = new Thread(() =>
            {
                while (!maquinaDeTuring.HaFinalizado())
                {
                    if (maquinaDeTuring.EstaPausada()) return;

                    maquinaDeTuring = maquinaDeTuring.Step();

                    ResaltarFila("");

                    Thread.Sleep(maquinaDeTuring.IntervaloDeTiempo * 1000);
                }

                MessageBox.Show("Done! " + maquinaDeTuring.EstadoActual);

            });
            thread.Start();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            try
            {
                if (maquinaDeTuring != null)
                {
                    BtnPausarPresionado(false);
                    maquinaDeTuring.CambiarEstadoAPausa();
                }
            }
            catch (Exception ex)
            {
                BtnPausarPresionado(true);
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                if (maquinaDeTuring != null)
                {
                    btnDetenerPresionado();

                    maquinaDeTuring = new MaquinaDeTuring(
                         "q0",
                         new Cabezal(new List<char>(rtbEntrada.Text.ToCharArray()), 0),
                         Utilidades.GenerarTablaDeTransiciones(dgvTablaTransiciones),
                         int.Parse(txtIntervaloTiempo.Text),
                         0);

                    foreach (DataGridViewRow dataGridViewRow in dgvTablaTransiciones.Rows)
                    {
                        dataGridViewRow.DefaultCellStyle.BackColor = SystemColors.Window;
                        rtbEntrada.Update();
                    }

                    rtbEntrada.Select(0, rtbEntrada.Text.Length - 1);
                    rtbEntrada.SelectionColor = SystemColors.WindowText;

                    dgvTablaTransiciones.Update();
                    rtbEntrada.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(txtIntervaloTiempo.Text))
            {
                throw new ArgumentException("Ingrese un interválo de tiempo válido.");
            }

            if (string.IsNullOrEmpty(rtbEntrada.Text))
            {
                throw new ArgumentException("Ingrese un input válido.");
            }
        }

        public void ResaltarFila(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ResaltarFila), new object[] { value });
                return;
            }

            rtbEntrada.Select(maquinaDeTuring.Cabezal.PosicionDelCabezalAnterior, 1);
            rtbEntrada.SelectionColor = SystemColors.WindowText;

            rtbEntrada.Select(maquinaDeTuring.Cabezal.PosicionDelCabezal, 1);
            rtbEntrada.SelectionColor = Color.Red;

            dgvTablaTransiciones.Rows[maquinaDeTuring.IndiceEnLaTablaAnterior].DefaultCellStyle.BackColor = SystemColors.Window;
            dgvTablaTransiciones.Rows[maquinaDeTuring.IndiceEnLaTabla].DefaultCellStyle.BackColor = Color.Red;

            rtbEntrada.Update();
            dgvTablaTransiciones.Update();
        }

        private void cmbCargarPruebas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmbCargarPruebas.SelectedIndex)
                {
                    case 0:
                        dgvTablaTransiciones.DataSource = TransicionesEjemplo.Contiene101();
                        break;
                    default:
                        MessageBox.Show("Ocurrió un problema: no se encontró la tabla de transición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Simulador_Load(object sender, EventArgs e)
        {
            dgvTablaTransiciones.AutoGenerateColumns = false;
        }

        private void txtIntervaloTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

