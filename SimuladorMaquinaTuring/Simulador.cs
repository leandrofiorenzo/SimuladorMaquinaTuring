using SimuladorMaquinaTuring.Modelo2;
using System;
using System.Data;
using System.Linq;
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIntervalo.Text))
                {
                    MessageBox.Show("Ingrese un interválo de tiempo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (maquinaDeTuring == null)
                {
                    var maquinaDeTuring = new MaquinaDeTuring(
                            "q0",
                            new Cabezal(txtInput.Text.ToCharArray(), 0),
                            MaquinaDeTuringUtilidades.GenerarTablaDeTransiciones(dgvTablaTransiciones),
                            int.Parse(txtIntervalo.Text));

                    Loop(maquinaDeTuring);
                } else {
                    Loop(maquinaDeTuring);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loop(MaquinaDeTuring maquinaDeTuring)
        {
            while (!maquinaDeTuring.EstadoActual.Contains("accept") && !maquinaDeTuring.EstadoActual.Contains("reject"))
            {
                maquinaDeTuring = maquinaDeTuring.Step();
                Thread.Sleep(maquinaDeTuring.IntervaloDeTiempo * 1000);
            }

            Done(maquinaDeTuring);
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            if (maquinaDeTuring.EstadoActual.Contains("accept") || maquinaDeTuring.EstadoActual.Contains("reject"))
                Done(maquinaDeTuring);
            else
                maquinaDeTuring = maquinaDeTuring.Step();
        }

        private void Done(MaquinaDeTuring maquinaDeTuring)
        {
            MessageBox.Show("Done! " + maquinaDeTuring.EstadoActual);
        }


        private void cmbCargarPruebas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cmbCargarPruebas.SelectedIndex)
                {
                    case 0:
                        dgvTablaTransiciones.DataSource = TransicionesDeEjemplo.Contiene101();
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

        private void txtIntervalo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

