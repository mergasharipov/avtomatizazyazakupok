using System.Drawing;
using System.Windows.Forms;
using AppliancesProcurementApp;

namespace AppliancesProcurement
{
    // Класс главной формы приложения: визуальное представление таблицы закупок
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvPurchases;
        private ToolStrip toolStrip1;
        private ToolStripButton btnAddPurchase;
        private ToolStripButton btnDeletePurchase; // Кнопка удаления для администратора
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblUserStatus;
        private ToolStripStatusLabel lblSpring;

        // Метод для очистки ресурсов при закрытии формы
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Инициализация компонентов интерфейса (автоматически генерируемый код)
        private void InitializeComponent()
        {
            this.dgvPurchases = new DataGridView();
            this.toolStrip1 = new ToolStrip();
            this.btnAddPurchase = new ToolStripButton();
            this.btnDeletePurchase = new ToolStripButton();
            this.statusStrip1 = new StatusStrip();
            this.lblUserStatus = new ToolStripStatusLabel();
            this.lblSpring = new ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // Панель инструментов: содержит основные действия пользователя
            this.toolStrip1.BackColor = Color.White;
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new Size(24, 24);
            this.toolStrip1.Items.AddRange(new ToolStripItem[] {
                this.btnAddPurchase,
                new ToolStripSeparator(),
                this.btnDeletePurchase
            });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new Padding(10, 5, 10, 5);
            this.toolStrip1.Size = new Size(900, 45);
            this.toolStrip1.TabIndex = 0;

            // Кнопка "Новая закупка"
            this.btnAddPurchase.Font = new Font("Segoe UI Semibold", 10F);
            this.btnAddPurchase.ForeColor = Color.FromArgb(0, 120, 215);
            this.btnAddPurchase.Name = "btnAddPurchase";
            this.btnAddPurchase.Size = new Size(150, 32);
            this.btnAddPurchase.Text = "➕ Новая закупка";
            this.btnAddPurchase.Click += new System.EventHandler(this.btnAddPurchase_Click);

            // Кнопка "Удалить": доступна только администратору (логика проверки в MainForm.cs)
            this.btnDeletePurchase.Font = new Font("Segoe UI Semibold", 10F);
            this.btnDeletePurchase.ForeColor = Color.FromArgb(220, 53, 69); // Красный цвет для предупреждения
            this.btnDeletePurchase.Name = "btnDeletePurchase";
            this.btnDeletePurchase.Size = new Size(100, 32);
            this.btnDeletePurchase.Text = "🗑 Удалить";
            this.btnDeletePurchase.Click += new System.EventHandler(this.btnDeletePurchase_Click);

            // Таблица данных (DataGridView)
            this.dgvPurchases.AllowUserToAddRows = false;
            this.dgvPurchases.AllowUserToDeleteRows = false;
            this.dgvPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchases.BackgroundColor = Color.White;
            this.dgvPurchases.BorderStyle = BorderStyle.None;
            this.dgvPurchases.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(240, 240, 240);
            headerStyle.Font = new Font("Segoe UI Semibold", 9F);
            headerStyle.ForeColor = Color.Black;
            headerStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            this.dgvPurchases.ColumnHeadersDefaultCellStyle = headerStyle;

            this.dgvPurchases.Dock = DockStyle.Fill;
            this.dgvPurchases.EnableHeadersVisualStyles = false;
            this.dgvPurchases.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvPurchases.Location = new Point(0, 45);
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.ReadOnly = true;
            this.dgvPurchases.RowHeadersVisible = false;
            this.dgvPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchases.Size = new Size(900, 530);
            this.dgvPurchases.TabIndex = 1;

            // Информационная строка состояния
            this.statusStrip1.BackColor = Color.FromArgb(0, 120, 215);
            this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.lblSpring, this.lblUserStatus });
            this.statusStrip1.Location = new Point(0, 575);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(900, 25);
            this.statusStrip1.TabIndex = 2;

            this.lblSpring.Name = "lblSpring";
            this.lblSpring.Size = new Size(710, 20);
            this.lblSpring.Spring = true;

            this.lblUserStatus.ForeColor = Color.White;
            this.lblUserStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblUserStatus.Name = "lblUserStatus";
            // Параметры формы
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(900, 600);
            this.Controls.Add(this.dgvPurchases);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Учет закупок бытовой техники";
            this.WindowState = FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}