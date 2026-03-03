using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppliancesProcurementApp;

namespace AppliancesProcurement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Настройка прав доступа: кнопка удаления видна только администратору
            btnDeletePurchase.Visible = (DbConfig.CurrentUserRole == "Admin");

            // Подписка на событие закрытия для полного выхода из приложения
            this.FormClosing += (s, e) => Application.Exit();

            // Первичная загрузка данных
            LoadData();
        }

        // Метод для загрузки и отображения данных из БД
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                try
                {
                    // SQL-запрос с объединением таблиц для получения читаемых названий
                    string query = @"
                        SELECT 
                            p.PurchaseID AS [ID],
                            pr.ProductName AS [Товар],
                            s.CompanyName AS [Поставщик],
                            u.FullName AS [Менеджер],
                            p.Quantity AS [Кол-во],
                            p.PurchaseDate AS [Дата]
                        FROM Purchases p
                        JOIN Products pr ON p.ProductID = pr.ProductID
                        JOIN Suppliers s ON p.SupplierID = s.SupplierID
                        JOIN Users u ON p.CreatedBy = u.UserID
                        ORDER BY p.PurchaseDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Привязка данных к таблице
                    dgvPurchases.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Обработчик нажатия кнопки "Новая закупка"
        private void btnAddPurchase_Click(object sender, EventArgs e)
        {
            using (AddPurchaseForm addForm = new AddPurchaseForm())
            {
                // Если запись успешно добавлена (DialogResult.OK), обновляем таблицу
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        // Обработчик нажатия кнопки "Удалить" (только для администратора)
        private void btnDeletePurchase_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.SelectedRows.Count > 0)
            {
                // Получаем ID выбранной записи
                int purchaseId = Convert.ToInt32(dgvPurchases.SelectedRows[0].Cells["ID"].Value);
                string productName = dgvPurchases.SelectedRows[0].Cells["Товар"].Value.ToString();

                var confirmResult = MessageBox.Show(
                    $"Вы уверены, что хотите удалить запись о закупке '{productName}'?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    DeleteRecord(purchaseId);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку в таблице для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Метод для физического удаления записи из БД
        private void DeleteRecord(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                try
                {
                    string sql = "DELETE FROM Purchases WHERE PurchaseID = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    // Обновляем интерфейс
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}