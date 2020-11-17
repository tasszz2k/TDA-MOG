namespace DTA_Theater.view
{
    partial class FoodOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gvFoods = new System.Windows.Forms.DataGridView();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnChoose = new System.Windows.Forms.Button();
            this.gvPickeds = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPickeds)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFoods
            // 
            this.gvFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFoods.Location = new System.Drawing.Point(12, 12);
            this.gvFoods.MultiSelect = false;
            this.gvFoods.Name = "gvFoods";
            this.gvFoods.RowHeadersWidth = 51;
            this.gvFoods.RowTemplate.Height = 24;
            this.gvFoods.Size = new System.Drawing.Size(347, 357);
            this.gvFoods.TabIndex = 0;
            this.gvFoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFoods_CellClick);
            this.gvFoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFoods_CellContentClick);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(374, 66);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 22);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(374, 141);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 32);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = ">>";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // gvPickeds
            // 
            this.gvPickeds.AllowUserToAddRows = false;
            this.gvPickeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPickeds.Location = new System.Drawing.Point(517, 12);
            this.gvPickeds.Name = "gvPickeds";
            this.gvPickeds.RowHeadersWidth = 51;
            this.gvPickeds.RowTemplate.Height = 24;
            this.gvPickeds.Size = new System.Drawing.Size(699, 286);
            this.gvPickeds.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(517, 307);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(77, 65);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1095, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total:";
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Location = new System.Drawing.Point(600, 308);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(78, 65);
            this.btnPrintBill.TabIndex = 2;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(1093, 329);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(46, 17);
            this.lbTotal.TabIndex = 6;
            this.lbTotal.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pick";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(374, 38);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(120, 22);
            this.txtName.TabIndex = 8;
            // 
            // FoodOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 381);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvPickeds);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.gvFoods);
            this.Name = "FoodOrderForm";
            this.Text = "FoodOrderForm";
            this.Load += new System.EventHandler(this.FoodOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPickeds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvFoods;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.DataGridView gvPickeds;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
    }
}