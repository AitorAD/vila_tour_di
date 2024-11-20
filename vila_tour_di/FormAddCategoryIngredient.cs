using ClientRESTAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vila_tour_di {
    public partial class FormAddCategoryIngredient : Form {

        bool isEditing = false;
        CategoryIngredient category; // Variable para almacenar la categoría

        public FormAddCategoryIngredient() {
            InitializeComponent();
            labelTitle.Text = "AÑADIR CATEGORIA";
        }

        public FormAddCategoryIngredient(CategoryIngredient category) {
            isEditing = true;
            InitializeComponent();
            labelTitle.Text = "EDITAR CATEGORIA";

            this.category = category;

            guna2TextBoxNombreCat.Text = category.name;
        }

        private void bttbAddIngredient_Click(object sender, EventArgs e) {
            // Obtener los datos del formulario
            string categoryName = guna2TextBoxNombreCat.Text.ToUpper();

            //Logica de editar
            if (isEditing) {
                // Crear un objeto con los datos actualizados
                CategoryIngredient updatedCat = new CategoryIngredient {
                    id = category.id,
                    name = categoryName
                };

                // Serializar el objeto a JSON
                string jsonData = JsonSerializer.Serialize(updatedCat);


                // Configurar la URL para el endpoint de actualización (incluye el ID en la URL)
                string url = $"http://127.0.0.1:8080/categories/{category.id}";
                RestClient client = new RestClient(url, "PUT");

                // Realizar la solicitud PUT
                string res = client.PutItem(jsonData);

                if(res == jsonData) {
                    MessageBox.Show("Categoria editada correctamente.",
                        "Editado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    Dispose();
                } else {
                    MessageBox.Show("Problema al editar categoría. No editada.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
            } else {
                // Creamos la categoria
                CategoryIngredient newCat = new CategoryIngredient(categoryName);

                string jsonData = JsonSerializer.Serialize(newCat);
                string res = string.Empty;

                // Agregamos una nueva categoria
                String url = "http://127.0.0.1:8080/categories";
                RestClient r = new RestClient(url, "POST");

                res = r.PostItem(jsonData); // Realizamos el post
                Console.WriteLine("RESPUESTA: " + res);


                if (res.Contains("\"errorCode\":101")) {
                    MessageBox.Show("Categoria ya existente",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                Dispose();
            }
        }
      

        private void bttnSalir_Click(object sender, EventArgs e) {
            Dispose();
        }
    }
}
