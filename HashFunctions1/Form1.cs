using HashFunctions1;
using System;
using System.Windows.Forms;

namespace HashFunctions1
{
    public partial class Form1 : Form
    {
        private HashTable hashTable;

        public Form1()
        {
            InitializeComponent();
            hashTable = new HashTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var atleta = new Atleta
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = int.Parse(txtEdad.Text),
                Sexo = txtSexo.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                Categoria = txtCategoria.Text
            };
            hashTable.AddAtleta(atleta);
            MessageBox.Show("Atleta agregado.");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text;
            var atleta = hashTable.SearchAtleta(apellido);
            if (atleta != null)
            {
                txtNombre.Text = atleta.Nombre;
                txtEdad.Text = atleta.Edad.ToString();
                txtSexo.Text = atleta.Sexo;
                txtFechaNacimiento.Text = atleta.FechaNacimiento.ToString("dd/MM/yyyy");
                txtCategoria.Text = atleta.Categoria;
                MessageBox.Show("Atleta encontrado.");
            }
            else
            {
                MessageBox.Show("Atleta no encontrado.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var atleta = new Atleta
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Edad = int.Parse(txtEdad.Text),
                Sexo = txtSexo.Text,
                FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                Categoria = txtCategoria.Text
            };
            hashTable.UpdateAtleta(atleta);
            MessageBox.Show("Atleta actualizado.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string apellido = txtApellido.Text;
            hashTable.DeleteAtleta(apellido);
            MessageBox.Show("Atleta eliminado.");
        }
    }
}

