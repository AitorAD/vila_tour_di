using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di.Forms.Commons {
    public partial class FormReport : Form {

        private int tipo;
        private string pdfPath = ("Reporte.pdf");

        public FormReport(List<Festival> festivals) {
            tipo = 1;
            InitializeComponent();
            lblCat.Text = "No se que";
        }

        public FormReport(List<Place> places) {
            tipo = 2;
            InitializeComponent();
            lblCat.Text = "Categorías:";
            loadComboBox(tipo);
            listBox.DisplayMember = "name";
        }

        public FormReport(List<Recipe> recipes) {
            tipo = 3;
            InitializeComponent();
            lblCat.Text = "Ingredientes:";
            loadComboBox(tipo);
            comboBox.DropDownWidth = 300;
        }

        private void loadComboBox(int tipo) {
            if (tipo == 1) load1();
            if (tipo == 2) loadCategories();
            if (tipo == 3) loadIngredients();
        }

        private void load1() { }

        private void loadCategories() {
            List<CategoryPlace> categories = CategoryPlaceService.GetCategoriesPlaces();
            comboBox.Items.Clear();
            comboBox.DisplayMember = "name";
            foreach (var category in categories) {
                comboBox.Items.Add(category);
            }
        }

        private void loadIngredients() {
            List<Ingredient> ingredients = IngredientService.GetIngredients();
            comboBox.Items.Clear();
            comboBox.DisplayMember = "name";

            var groupedIngredients = ingredients.GroupBy(i => i.category.name);
            foreach (var group in groupedIngredients) {
                CategoryIngredient categoryIngredient = new CategoryIngredient(group.Key);
                comboBox.Items.Add("---" + categoryIngredient.name.ToUpper() + "---");

                foreach (var ingredient in group) {
                    comboBox.Items.Add(ingredient);
                }
            }
        }

        private void btnDeleteFilter_Click(object sender, EventArgs e) {
            if (listBox.SelectedItem != null) {
                listBox.Items.Remove(listBox.SelectedItem);
            } else {
                MessageBox.Show("Por favor, selecciona un elemento para eliminar.",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e) {
            if (tipo == 2) {
                var selectedItem = comboBox.SelectedItem as CategoryPlace;

                if (selectedItem != null && listBox.Items.Cast<CategoryPlace>().Any(category => category.name.Equals(selectedItem.name))) {
                    MessageBox.Show("Error. Categoría repetida",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                } else if (selectedItem != null) {
                    listBox.Items.Add(selectedItem);
                } else {
                    MessageBox.Show("Error. Selecciona una categoría",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                }
            }

            if(tipo == 3) {
                var selectedItem = comboBox.SelectedItem as Ingredient;

                if (selectedItem != null && listBox.Items.Cast<Ingredient>().Any(category => category.name.Equals(selectedItem.name))) {
                    MessageBox.Show("Error. Ingrediente repetido",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                } else if (selectedItem != null) {
                    listBox.Items.Add(selectedItem);
                } else {
                    MessageBox.Show("Error. Selecciona un Ingrediente",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                }
            }
        }

        private void crearPDF(List<Place> places = null, List<Recipe> recipes = null, List<string> filtros = null) {
            try {
                using (PdfWriter writer = new PdfWriter(pdfPath))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf, new PageSize(792, 612))) {

                    document.SetMargins(60, 20, 55, 20);

                    PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);


                    AddHeader(document);

                    string[] columnas = new string[] { };
                    float[] tamanyos = { 4, 2, 4 };

                    if (tipo == 2) {
                        columnas = new string[] { "Nombre", "Puntuación Media", "Categoría" };
                    } else if (tipo == 3) {
                        columnas = new string[] { "Nombre", "Puntuación Media", "Ingredientes" };
                    }

                    Table tabla = new Table(UnitValue.CreatePercentArray(tamanyos));
                    tabla.SetWidth(UnitValue.CreatePercentValue(100));

                    foreach (string columna in columnas) {
                        tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                    }

                    // Si los filtros están vacíos, mostramos todos los elementos
                    if (filtros == null || filtros.Count == 0) {
                        if (tipo == 2 && places != null) {
                            foreach (var place in places) {
                                tabla.AddCell(new Cell().Add(new Paragraph(place?.name ?? "Desconocido").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(place?.averageScore.ToString() ?? "0").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(place?.categoryPlace?.name ?? "Sin categoría").SetFont(fontContenido)));
                            }
                        } else if (tipo == 3 && recipes != null) {
                            foreach (var recipe in recipes) {
                                string ingredientes = recipe.ingredients != null ? string.Join(", ", recipe.ingredients.Select(i => i.name)) : "Sin ingredientes";
                                tabla.AddCell(new Cell().Add(new Paragraph(recipe?.name ?? "Desconocido").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(recipe?.averageScore.ToString() ?? "0").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(ingredientes).SetFont(fontContenido)));
                            }
                        }
                    }
                    // Si hay filtros, los aplicamos
                    else {
                        if (tipo == 2 && places != null) {
                            var placesFiltrados = places.Where(p => filtros.Contains(p.categoryPlace?.name)).ToList();
                            foreach (var place in placesFiltrados) {
                                tabla.AddCell(new Cell().Add(new Paragraph(place?.name ?? "Desconocido").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(place?.averageScore.ToString() ?? "0").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(place?.categoryPlace?.name ?? "Sin categoría").SetFont(fontContenido)));
                            }
                        } else if (tipo == 3 && recipes != null) {
                            var recipesFiltrados = recipes.Where(r => r.ingredients.Any(i => filtros.Contains(i.name))).ToList();
                            foreach (var recipe in recipesFiltrados) {
                                string ingredientes = recipe.ingredients != null ? string.Join(", ", recipe.ingredients.Select(i => i.name)) : "Sin ingredientes";
                                tabla.AddCell(new Cell().Add(new Paragraph(recipe?.name ?? "Desconocido").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(recipe?.averageScore.ToString() ?? "0").SetFont(fontContenido)));
                                tabla.AddCell(new Cell().Add(new Paragraph(ingredientes).SetFont(fontContenido)));
                            }
                        }
                    }

                    document.Add(tabla);
                }

                // Cargar y mostrar el PDF en AxAcroPDF
                MostrarPDF();
            } catch (Exception ex) {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddHeader(Document document) {
            // Crear la tabla para el encabezado (con logo y título)
            Table headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 1, 5 }));
            headerTable.SetWidth(UnitValue.CreatePercentValue(100));

            // Cargar el logo
            try {
                ImageData logo = ImageDataFactory.Create("C:/Users/dam_lco/Documents/GitHub/vila_tour_pmdm/assets/logo_foreground.png"); // Ruta del archivo de imagen
                Image logoImage = new Image(logo).SetAutoScale(true).SetWidth(20); // Ajustar tamaño del logo
                headerTable.AddCell(new Cell().Add(logoImage));
            } catch (Exception ex) {
                MessageBox.Show($"Error al cargar el logo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                headerTable.AddCell(new Cell().Add(new Paragraph("Logo no encontrado")));
            }

            // Título del informe
            Paragraph title = new Paragraph("Reporte de Lugares, Recetas o Ingredientes")
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                .SetFontSize(16)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

            headerTable.AddCell(new Cell().Add(title));

            // Añadir la tabla al documento (encabezado)
            document.Add(headerTable);
        }

        private void MostrarPDF() {
            try {
                if (File.Exists(pdfPath)) {
                    axAcroPDF.LoadFile(pdfPath);
                    axAcroPDF.setView("Fit");
                    axAcroPDF.setShowToolbar(false);
                    axAcroPDF.setShowScrollbars(true);
                } else {
                    MessageBox.Show("El archivo PDF no se generó correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error al mostrar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string> ObtenerFiltros() {
            List<string> filtros = new List<string>();

            foreach (var item in listBox.Items) {
                if (item is CategoryPlace category) {
                    filtros.Add(category.name);  // Filtrar por nombre de categoría
                } else if (item is Ingredient ingredient) {
                    filtros.Add(ingredient.name);  // Filtrar por nombre de ingrediente
                }
            }

            return filtros;
        }

        private void btnCrear_Click(object sender, EventArgs e) {
            List<string> filtros = ObtenerFiltros();  // Obtener los filtros del listBox

            if (tipo == 2) {
                List<Place> places = PlaceService.GetAllPlaces(); // Suponiendo que tengas un servicio para obtener los lugares
                crearPDF(places: places, filtros: filtros);  // Pasar los filtros al crear el PDF
            } else if (tipo == 3) {
                List<Recipe> recipes = RecipeService.GetAllRecipes(); // Suponiendo que tengas un servicio para obtener recetas
                crearPDF(recipes: recipes, filtros: filtros);  // Pasar los filtros al crear el PDF
            }
        }

    }
}