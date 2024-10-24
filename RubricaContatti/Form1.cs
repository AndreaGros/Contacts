using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubricaContatti
{
    public partial class Form1 : Form
    {
        List<Contatto> Contatti = new List<Contatto>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtTelefono.Text != "")
            {
                bool campi=controlloCampi();
                if (campi)
                {
                    Contatto c = new Contatto(txtName.Text, txtTelefono.Text);
                    Contatti.Add(c);
                    lsbContatti.Items.Add(c.ToString());
                    txtName.Text = "";
                    txtTelefono.Text = "";
                }
                else
                {
                    MessageBox.Show("Inserisci un tel. non duplicato");
                    txtTelefono.Text = "";
                }
            }
            else
                MessageBox.Show("Inserisci tutti i campi");
        }

        private bool controlloCampi()
        {
            bool right = true;
            foreach (var contatto in Contatti)
            {
                if(txtTelefono.Text==contatto.Telefono)
                {
                    right=false;
                    break;
                }
            }
            return right;
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (lsbContatti.SelectedIndex == -1)
                MessageBox.Show("Seleziona un contatto da eliminare");
            else
            {
                Contatti.Remove(Contatti[lsbContatti.SelectedIndex]);
                ricaricaListBox();
            }
        }

        private void ricaricaListBox()
        {
            lsbContatti.Items.Clear();
            foreach (var contatto in Contatti)
                lsbContatti.Items.Add(contatto.ToString());
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lsbContatti.SelectedIndex == -1)
                MessageBox.Show("Seleziona un contatto da modificare");
            else
            {
                
            }
        }

        private void lsbContatti_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name;
            string number;
            string[] datas=lsbContatti.SelectedItems.ToString().Split('-');
        }
    }
}
