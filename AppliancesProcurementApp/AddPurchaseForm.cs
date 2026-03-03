using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppliancesProcurementApp;

namespace AppliancesProcurement
{
    public partial class AddPurchaseForm : Form
    {
        public AddPurchaseForm()
        {
            InitializeComponent();
            // Загружаем списки при инициализации
            LoadComboBoxData();
        }

        // Заполнение выпадающих списков данными из БД
        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Загрузка товаров
                    SqlDataAdapter daProducts = new SqlDataAdapter("SELECT ProductID, ProductName FROM Products", conn);
                    DataTable dtProducts = new DataTable();
                    daProducts.Fill(dtProducts);

                    cbProduct.DataSource = dtProducts;
                    cbProduct.DisplayMember = "ProductName"; // Что видит пользователь
                    cbProduct.ValueMember = "ProductID";     // Что сохраняем в БД

                    // 2. Загрузка поставщиков
                    SqlDataAdapter daSuppliers = new SqlDataAdapter("SELECT SupplierID, CompanyName FROM Suppliers", conn);
                    DataTable dtSuppliers = new DataTable();
                    daSuppliers.Fill(dtSuppliers);

                    cbSupplier.DataSource = dtSuppliers;
                    cbSupplier.DisplayMember = "CompanyName";
                    cbSupplier.ValueMember = "SupplierID";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки справочников: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Сохранение новой закупки
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (cbProduct.SelectedValue == null || cbSupplier.SelectedValue == null)
            {
                MessageBox.Show("Выберите товар и поставщика!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                try
                {
                    string sql = @"INSERT INTO Purchases (ProductID, SupplierID, CreatedBy, Quantity) 
                                   VALUES (@pId, @sId, @uId, @qty)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@pId", cbProduct.SelectedValue);
                    cmd.Parameters.AddWithValue("@sId", cbSupplier.SelectedValue);
                    cmd.Parameters.AddWithValue("@uId", DbConfig.CurrentUserId); // ID из сессии
                    cmd.Parameters.AddWithValue("@qty", numQuantity.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    // Уведомляем вызывающую форму об успехе
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}