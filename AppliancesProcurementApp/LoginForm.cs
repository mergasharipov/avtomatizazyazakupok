using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AppliancesProcurementApp;

namespace AppliancesProcurement
{
    // partial означает, что класс разделен на несколько файлов
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            // Этот метод находится в файле .Designer.cs
            InitializeComponent();
        }

        // Обработчик события нажатия на кнопку "Войти"
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Простейшая проверка на пустые поля перед запросом к БД
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                try
                {
                    // Используем параметры @l и @p для защиты от SQL-инъекций
                    string sql = "SELECT UserID, FullName, Role FROM Users WHERE Login = @l AND Password = @p";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@l", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Сохраняем данные успешного входа в глобальный конфиг
                        DbConfig.CurrentUserId = (int)reader["UserID"];
                        DbConfig.CurrentUserName = reader["FullName"].ToString();
                        DbConfig.CurrentUserRole = reader["Role"].ToString();

                        // Переход на главную форму
                        new MainForm().Show();
                        this.Hide(); // Скрываем окно входа
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message, "Системная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}