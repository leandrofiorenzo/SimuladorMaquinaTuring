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

            txtEstadoInicial.Enabled = habilitar;
            txtEstadoInicial.ReadOnly = !habilitar;
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

            txtEstadoInicial.Enabled = true;
            txtEstadoInicial.ReadOnly = false;
        }

        private void GenerarMaquinaDeTuring()
        {
            try
            {
                Validar();

                maquinaDeTuring = new MaquinaDeTuring(
                        txtEstadoInicial.Text.Trim(),
                        new Cabezal(new List<char>(rtbEntrada.Text.Trim().ToCharArray())),
                        dgvTablaTransiciones,
                        int.Parse(txtIntervaloTiempo.Text));

                MessageBox.Show("La máquina de turing se ha generado correctamente, comience a utilizarla.", "Máquina de turing", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (maquinaDeTuring == null)
                {
                    MessageBox.Show("Por favor, presione el botón 'generar' para crear la maquina de turing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BtnCorrerPresionado(false);

                ResaltarCaracterEntrada();
                ResaltarFilaTablaDeTransiciones();

                maquinaDeTuring.CambiarEstadoAEjecutandose();

                Loop();
            }
            catch (Exception ex)
            {
                BtnCorrerPresionado(true);
                maquinaDeTuring = null;
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            try
            {
                if (maquinaDeTuring == null)
                {
                    MessageBox.Show("Por favor, genere una maquina de turing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                maquinaDeTuring.CambiarEstadoAEjecutandose();

                if (maquinaDeTuring.HaFinalizado())
                {
                    MessageBox.Show("Done! " + maquinaDeTuring.EstadoActual);
                    return;
                }

                maquinaDeTuring = maquinaDeTuring.Step();
                rtbSalida.Text = maquinaDeTuring.Cabezal.ObtenerCintaProcesada();
                ResaltarCaracterEntrada();
                ResaltarFilaTablaDeTransiciones();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    rtbSalida.Text = maquinaDeTuring.Cabezal.ObtenerCintaProcesada();

                    ResaltarCaracterEntrada();
                    ResaltarFilaTablaDeTransiciones();

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
                            txtEstadoInicial.Text.Trim(),
                            new Cabezal(new List<char>(rtbEntrada.Text.Trim().ToCharArray())),
                            dgvTablaTransiciones,
                            int.Parse(txtIntervaloTiempo.Text));

                    maquinaDeTuring.CambiarEstadoAPausa();

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
            if (string.IsNullOrEmpty(rtbEntrada.Text))
            {
                rtbEntrada.Focus();
                throw new ArgumentException("Por favor, ingrese un input.");
            }

            if (string.IsNullOrEmpty(txtEstadoInicial.Text))
            {
                txtEstadoInicial.Focus();
                throw new ArgumentException("Por favor, ingrese un estado inicial.");
            }

            if (string.IsNullOrEmpty(txtIntervaloTiempo.Text))
            {
                txtIntervaloTiempo.Focus();
                throw new ArgumentException("Por favor, ingrese un interválo de tiempo mayor o igual que 0.");
            }
        }

        private void ResaltarFilaTablaDeTransiciones()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ResaltarFilaTablaDeTransiciones));
                return;
            }

            dgvTablaTransiciones.Rows[maquinaDeTuring.IndiceEnLaTablaAnterior].DefaultCellStyle.BackColor = SystemColors.Window;

            dgvTablaTransiciones.Rows[maquinaDeTuring.IndiceEnLaTabla].DefaultCellStyle.BackColor = Color.Red;

            dgvTablaTransiciones.Update();
        }

        private void ResaltarCaracterEntrada()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(ResaltarCaracterEntrada));
                return;
            }

            rtbEntrada.Select(maquinaDeTuring.Cabezal.PosicionDelCabezalAnterior, 1);
            rtbEntrada.SelectionColor = SystemColors.WindowText;

            rtbEntrada.Select(maquinaDeTuring.Cabezal.PosicionDelCabezal, 1);
            rtbEntrada.SelectionColor = Color.Red;

            rtbEntrada.Update();
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
            dgvTablaTransiciones.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.0F);
            dgvTablaTransiciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            rtbEntrada.SelectionAlignment = HorizontalAlignment.Center;
            rtbSalida.SelectionAlignment = HorizontalAlignment.Center;

            cmbDireccion.SelectedIndex = 0;
        }

        private void txtIntervaloTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGenerarTM_Click(object sender, EventArgs e)
        {
            GenerarMaquinaDeTuring();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ValidarTransicion();
        }

        private void ValidarTransicion()
        {
            string estado = txtEstado.Text;
            string leer = txtLeer.Text;
            string escribir = txtEscribir.Text;
            int direccion = cmbDireccion.SelectedIndex;
            string estadoSiguiente = txtEstadoSiguiente.Text;

            if (string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("Por favor, ingrese un estado válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(leer) || leer.Length != 1)
            {
                MessageBox.Show("Por favor, ingrese un caracter a leer válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(escribir) || escribir.Length != 1)
            {
                MessageBox.Show("Por favor, ingrese un caracter a escribir válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(estadoSiguiente))
            {
                MessageBox.Show("Por favor, ingrese un estado siguiente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvTablaTransiciones.Rows.Add(
                estado, 
                leer, 
                escribir, 
                direccion == 0 ? 'L' : 'R', 
                estadoSiguiente,
                "Eliminar");
            Limpiar();
            txtEstado.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtEstado.Text = string.Empty;
            txtLeer.Text = string.Empty;
            txtEscribir.Text = string.Empty;
            cmbDireccion.SelectedIndex = 0;
            txtEstadoSiguiente.Text = string.Empty;
        }

        private void dgvTablaTransiciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dgvTablaTransiciones.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}

