using System.Drawing;
using System.Windows.Forms;

namespace AppliancesProcurement
{
    partial class AddPurchaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cbProduct;
        private ComboBox cbSupplier;
        private NumericUpDown numQuantity;
        private Button btnSave;
        private Button btnCancel;
        private Label lbl1;
        private Label lbl2;
        private Label lbl3;
        private Panel pnlHeader;
        private Label lblHeaderTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbProduct = new ComboBox();
            this.cbSupplier = new ComboBox();
            this.numQuantity = new NumericUpDown();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lbl1 = new Label();
            this.lbl2 = new Label();
            this.lbl3 = new Label();
            this.pnlHeader = new Panel();
            this.lblHeaderTitle = new Label();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // Панель заголовка
            this.pnlHeader.BackColor = Color.FromArgb(0, 120, 215);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(400, 55);

            this.lblHeaderTitle.Dock = DockStyle.Fill;
            this.lblHeaderTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = Color.White;
            this.lblHeaderTitle.Text = "НОВАЯ ПОСТАВКА";
            this.lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Поля
            this.lbl1.Text = "Наименование товара";
            this.lbl1.Font = new Font("Segoe UI", 9F);
            this.lbl1.ForeColor = Color.DimGray;
            this.lbl1.Location = new Point(40, 75);
            this.lbl1.AutoSize = true;

            this.cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbProduct.Font = new Font("Segoe UI", 10F);
            this.cbProduct.Location = new Point(40, 95);
            this.cbProduct.Size = new Size(320, 26);

            this.lbl2.Text = "Поставщик";
            this.lbl2.Font = new Font("Segoe UI", 9F);
            this.lbl2.ForeColor = Color.DimGray;
            this.lbl2.Location = new Point(40, 135);
            this.lbl2.AutoSize = true;

            this.cbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSupplier.Font = new Font("Segoe UI", 10F);
            this.cbSupplier.Location = new Point(40, 155);
            this.cbSupplier.Size = new Size(320, 26);

            this.lbl3.Text = "Количество (шт)";
            this.lbl3.Font = new Font("Segoe UI", 9F);
            this.lbl3.ForeColor = Color.DimGray;
            this.lbl3.Location = new Point(40, 195);
            this.lbl3.AutoSize = true;

            this.numQuantity.Font = new Font("Segoe UI", 10F);
            this.numQuantity.Location = new Point(40, 215);
            this.numQuantity.Size = new Size(120, 25);
            this.numQuantity.Minimum = 1;
            this.numQuantity.Value = 1;

            // Кнопки
            this.btnSave.Text = "ДОБАВИТЬ";
            this.btnSave.BackColor = Color.FromArgb(0, 120, 215);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            this.btnSave.Location = new Point(40, 270);
            this.btnSave.Size = new Size(200, 42);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "ОТМЕНА";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = Color.LightGray;
            this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.Location = new Point(250, 270);
            this.btnCancel.Size = new Size(110, 42);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Форма
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 345);
            this.Controls.AddRange(new Control[] { pnlHeader, lbl1, cbProduct, lbl2, cbSupplier, lbl3, numQuantity, btnSave, btnCancel });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddPurchaseForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Оформление";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}