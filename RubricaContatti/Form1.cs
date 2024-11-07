using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RubricaContatti
{
    public partial class Form1 : Form
    {
        List<Contatto> Contatti = new List<Contatto>();
        string fileName = "contacts.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtTelefono.Text.Length==10)
            {
                bool campi = controlloCampi(txtTelefono.Text);
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
                MessageBox.Show("Inserisci tutti i campi(Telefono almeno 10 caratteri)");
        }

        private bool controlloCampi(string telefono)
        {
            bool right = true;
            foreach (var contatto in Contatti)
            {
                if (telefono == contatto.Telefono)
                {
                    right = false;
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
                ricaricaListBox("");
                txtName.Text = "";
                txtTelefono.Text = "";
                txtResearch.Text = "";
            }
        }

        private void ricaricaListBox(string research)
        {
            lsbContatti.Items.Clear();
            foreach (var contatto in Contatti)
            {
                if (research == "" || controllaSubString(research, contatto))
                    lsbContatti.Items.Add(contatto.ToString());
            }
        }

        private bool controllaSubString(string research, Contatto contatto)
        {
            bool sottostringa = true;
            for (int i = 0; i < research.Length && sottostringa; i++)
            {
                if (research[i] != contatto.Nominativo[i])
                    sottostringa = false;
            }
            return sottostringa;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lsbContatti.SelectedIndex == -1)
                MessageBox.Show("Seleziona un contatto da modificare");
            else
            {
                bool campi = controlloCampi(txtTelefono.Text);
                if (campi)
                {
                    Contatti[lsbContatti.SelectedIndex].Nominativo = txtName.Text;
                    Contatti[lsbContatti.SelectedIndex].Telefono = txtTelefono.Text;
                    ricaricaListBox("");
                    txtName.Text = "";
                    txtTelefono.Text = "";
                    txtResearch.Text = "";
                }
                else
                {
                    MessageBox.Show("Inserisci un tel. non duplicato");
                    txtTelefono.Text = "";
                }

            }
        }

        private void lsbContatti_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] datas = lsbContatti.SelectedItem.ToString().Split('-');
            txtName.Text = datas[0].Trim();
            txtTelefono.Text = datas[1].Trim();
        }

        private void txtResearch_TextChanged(object sender, EventArgs e)
        {
            ricaricaListBox(txtResearch.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var contatto in Contatti)
            {
                sw.WriteLine(contatto.ToString());
            }
            sw.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader("contacts.txt");
                string[] datas;
                while (!sr.EndOfStream)
                {
                    datas = sr.ReadLine().Split('-');
                    if (controlloCampi(datas[1].Trim()))
                    {
                        Contatto c = new Contatto(datas[0].Trim(), datas[1].Trim());
                        Contatti.Add(c);
                    }
                }
                ricaricaListBox("");
                sr.Close();
            }
            else
                MessageBox.Show("File non trovato");
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
