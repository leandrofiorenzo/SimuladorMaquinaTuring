using SimuladorMaquinaTuring.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimuladorMaquinaTuring
{
    public partial class frmSimulador : Form
    {
        private MaquinaDeTuring maquinaDeTuring = null;
        private bool PermiteBorrarFila = true;

        public frmSimulador()
        {
            InitializeComponent();
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

                ResaltarCaracterEntrada();
                ResaltarFilaTablaDeTransiciones();
                maquinaDeTuring.CambiarEstadoAEjecutandose();

                btnEditar.Enabled = false;
                btnCorrer.Enabled = false;
                btnSiguiente.Enabled = false;
                btnPausar.Enabled = true;
                btnDetener.Enabled = true;

                Loop();
            }
            catch (Exception ex)
            {
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

                btnEditar.Enabled = false;
                btnCorrer.Enabled = true;
                btnSiguiente.Enabled = true;
                btnPausar.Enabled = false;
                btnDetener.Enabled = true;

                if (maquinaDeTuring.HaFinalizado())
                {
                    Finalizo(maquinaDeTuring.EstadoActual);
                    txtEstadoFinal.Text = maquinaDeTuring.EstadoActual;
                    return;
                }

                maquinaDeTuring = maquinaDeTuring.Step();
                rtbSalida.Text = maquinaDeTuring.Cabezal.ObtenerCintaProcesada();
                ResaltarCaracterEntrada();
                ResaltarFilaTablaDeTransiciones();
                IncrementarPasos(maquinaDeTuring.Pasos.ToString());

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
            var threadMaquina = new Thread(() =>
            {
                try
                {
                    while (!maquinaDeTuring.HaFinalizado())
                    {
                        if (maquinaDeTuring.EstaPausada()) return;
                        maquinaDeTuring = maquinaDeTuring.Step();
                        var cintaProcesada = maquinaDeTuring.Cabezal.ObtenerCintaProcesada();
                        EscribirCintaProcesada(cintaProcesada);
                        ResaltarCaracterEntrada();
                        ResaltarFilaTablaDeTransiciones();
                        IncrementarPasos(maquinaDeTuring.Pasos.ToString());
                        Thread.Sleep(maquinaDeTuring.IntervaloDeTiempo * 1000);
                    }
                    Finalizo(maquinaDeTuring.EstadoActual);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            threadMaquina.Start();
        }

        private void Finalizo(string estadoFinal)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Finalizo), new object[] { estadoFinal });
                return;
            }
            txtEstadoFinal.Text = estadoFinal;
            txtEstadoFinal.BackColor = estadoFinal.Contains("accept") ? Color.SeaGreen : Color.Red;
            txtEstadoFinal.ForeColor = Color.Black;
        }
        private void IncrementarPasos(string pasos) {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(IncrementarPasos), new object[] { pasos });
                return;
            }
            txtPasos.Text = pasos;
        }
        private void EscribirCintaProcesada(string cintaProcesada)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(EscribirCintaProcesada), new object[] { cintaProcesada });
                return;
            }
            rtbSalida.Text = cintaProcesada;
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            try
            {
                if (maquinaDeTuring != null)
                {
                    maquinaDeTuring.CambiarEstadoAPausa();
                }

                btnEditar.Enabled = true;
                btnCorrer.Enabled = true;
                btnSiguiente.Enabled = true;
                btnPausar.Enabled = false;
                btnDetener.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                if (maquinaDeTuring != null)
                {
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

                    txtEstadoFinal.Text = string.Empty;
                    txtEstadoFinal.BackColor = SystemColors.Window;

                    txtPasos.Text = "0";

                    dgvTablaTransiciones.Update();
                    rtbEntrada.Update();
                }

                btnEditar.Enabled = true;
                btnCorrer.Enabled = true;
                btnSiguiente.Enabled = true;
                btnPausar.Enabled = false;
                btnDetener.Enabled = false;

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
                        foreach (var transicionDeLaTabla in Contiene101.ObtenerTablaDeTransiciones())
                        {
                            dgvTablaTransiciones.Rows.Add(
                               transicionDeLaTabla.Estado,
                               transicionDeLaTabla.Leer,
                               transicionDeLaTabla.Escribir,
                               transicionDeLaTabla.Direccion == Modelo.Enums.Direccion.Izquierda ? 'L' : 'R',
                               transicionDeLaTabla.EstadoSiguiente,
                               "Eliminar");
                        }
                        rtbEntrada.Text = Contiene101.ObtenerEntrada();
                        break;
                    case -1:
                        dgvTablaTransiciones.Rows.Clear();
                        dgvTablaTransiciones.Refresh();
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

            cmbDireccion.SelectedIndex = 0;
        }

        private void txtIntervaloTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();

                maquinaDeTuring = new MaquinaDeTuring(
                        txtEstadoInicial.Text.Trim(),
                        new Cabezal(new List<char>(rtbEntrada.Text.Trim().ToCharArray())),
                        dgvTablaTransiciones,
                        int.Parse(txtIntervaloTiempo.Text));

                //Acciones sobre los controles de la sección configuración.            
                //Textbox:
                rtbEntrada.Enabled = false;
                rtbSalida.Enabled = false;
                txtEstadoInicial.Enabled = false;
                txtIntervaloTiempo.Enabled = false;
                txtEstado.Enabled = false;
                txtLeer.Enabled = false;
                txtEscribir.Enabled = false;
                txtEstadoSiguiente.Enabled = false;
                //ComboBox:
                cmbCargarPruebas.Enabled = false;
                cmbDireccion.Enabled = false;
                //Button:
                btnGenerar.Enabled = false;
                btnEditar.Enabled = true;
                btnLimpiar.Enabled = false;
                btnAgregar.Enabled = false;

                //Acciones sobre los controles de la sección acciones
                //Button:
                btnCorrer.Enabled = true;
                btnSiguiente.Enabled = true;
                btnPausar.Enabled = false;
                btnDetener.Enabled = false;

                //Flag para eliminar una fila de la grilla.
                PermiteBorrarFila = false;

                MessageBox.Show("La máquina de turing se ha generado correctamente, comience a utilizarla desde el panel de acciones.", "Máquina de turing", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Acciones sobre los controles de la sección configuración.            
            //Textbox:
            rtbEntrada.Enabled = true;
            rtbSalida.Enabled = true;
            txtEstadoInicial.Enabled = true;
            txtIntervaloTiempo.Enabled = true;
            txtEstado.Enabled = true;
            txtLeer.Enabled = true;
            txtEscribir.Enabled = true;
            txtEstadoSiguiente.Enabled = true;
            //ComboBox.
            cmbCargarPruebas.Enabled = true;
            cmbDireccion.Enabled = true;
            //Button.
            btnGenerar.Enabled = true;
            btnEditar.Enabled = false;
            btnLimpiar.Enabled = true;
            btnAgregar.Enabled = true;

            //Acciones sobre los controles de la sección acciones
            //Button:
            btnCorrer.Enabled = false;
            btnSiguiente.Enabled = false;
            btnPausar.Enabled = false;
            btnDetener.Enabled = false;

            //Flag para eliminar una fila de la grilla.
            PermiteBorrarFila = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea limpiar todo? \n Perderá todo lo cargado, incluso la tabla de transiciones.", "Atención.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (respuesta == DialogResult.OK)
            {
                rtbEntrada.Text = string.Empty;
                rtbSalida.Text = string.Empty;
                txtEstadoInicial.Text = string.Empty;
                txtIntervaloTiempo.Text = "1";
                cmbCargarPruebas.SelectedIndex = -1;
                Limpiar();
            }
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

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (!PermiteBorrarFila)
                {
                    MessageBox.Show("Para poder eliminar la fila debe presionar el botón editar y luego volver a generar la maquina de turing.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dgvTablaTransiciones.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}

