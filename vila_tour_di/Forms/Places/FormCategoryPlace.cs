﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vila_tour_di.Services;

namespace vila_tour_di.Forms.Places
{
    public partial class FormCategoryPlace : Form
    {
        private DataTable originalDatatable;

        public FormCategoryPlace()
        {
            InitializeComponent();
            originalDatatable = loadCategoriesData();
            guna2DataGridViewCATING.DataSource = originalDatatable;
            guna2DataGridViewCATING.AutoGenerateColumns = true;
            guna2DataGridViewCATING.AutoResizeColumnHeadersHeight();
            guna2DataGridViewCATING.AutoResizeColumns();
        }

        public DataTable loadCategoriesData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Nombre");

            List<CategoryPlace> categories = CategoryPlaceService.GetCategoriesPlaces();

            foreach (var category in categories)
            {
                table.Rows.Add(category.id, category.name);
            }

            return table;
        }

        public void loadCategoriesInDataGridView()
        {
            DataTable categoriesTable = loadCategoriesData();
            guna2DataGridViewCATING.DataSource = categoriesTable;
            guna2DataGridViewCATING.Refresh();
        }

        private void bttnAddCategory_Click_1(object sender, EventArgs e)
        {
            FormAddEditCategoryPlace formAddCategory = new FormAddEditCategoryPlace();
            formAddCategory.StartPosition = FormStartPosition.CenterParent;
            formAddCategory.ShowDialog();
            loadCategoriesInDataGridView();
        }

        private void btnEditCategory_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (guna2DataGridViewCATING.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = guna2DataGridViewCATING.SelectedRows[0];

                    int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);
                    string name = selectedRow.Cells["Nombre"].Value.ToString();

                    CategoryPlace category = new CategoryPlace
                    {
                        id = id,
                        name = name
                    };

                    FormAddEditCategoryPlace formAddCategory = new FormAddEditCategoryPlace(category);
                    formAddCategory.StartPosition = FormStartPosition.CenterParent;
                    formAddCategory.ShowDialog();

                    loadCategoriesInDataGridView();
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona una categoría para editar.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar editar la categoría: {ex.Message}");
            }
        }

        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridViewCATING.SelectedRows.Count > 0)
            {
                var selectedRow = guna2DataGridViewCATING.SelectedRows[0];

                int id = (int)Convert.ToInt64(selectedRow.Cells["ID"].Value);

                var confirmResult = MessageBox.Show($"¿Estás seguro de que quieres eliminar {selectedRow.Cells["Nombre"].Value}?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    string token = AppState.JwtData.Token;
                    bool success = CategoryPlaceService.DeleteCategoryPlace(id);

                    if (success)
                    {
                        guna2DataGridViewCATING.DataSource = loadCategoriesData();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún ingrediente");
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}