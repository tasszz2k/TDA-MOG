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
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvFoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPickeds)).BeginInit();
            this.SuspendLayout();
            // 
            // gvFoods
            // 
            this.gvFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFoods.Location = new System.Drawing.Point(93, 11);
            this.gvFoods.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gvFoods.MultiSelect = false;
            this.gvFoods.Name = "gvFoods";
            this.gvFoods.RowHeadersWidth = 51;
            this.gvFoods.RowTemplate.Height = 24;
            this.gvFoods.Size = new System.Drawing.Size(256, 290);
            this.gvFoods.TabIndex = 0;
            this.gvFoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFoods_CellClick);
            this.gvFoods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvFoods_CellContentClick);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(369, 78);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(90, 20);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(369, 115);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(56, 26);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = ">>";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // gvPickeds
            // 
            this.gvPickeds.AllowUserToAddRows = false;
            this.gvPickeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPickeds.Location = new System.Drawing.Point(472, 10);
            this.gvPickeds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gvPickeds.Name = "gvPickeds";
            this.gvPickeds.RowHeadersWidth = 51;
            this.gvPickeds.RowTemplate.Height = 24;
            this.gvPickeds.Size = new System.Drawing.Size(440, 232);
            this.gvPickeds.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(472, 250);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(79, 37);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(773, 260);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total:";
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Location = new System.Drawing.Point(572, 251);
            this.btnPrintBill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(84, 36);
            this.btnPrintBill.TabIndex = 2;
            this.btnPrintBill.Text = "Print Bill";
            this.btnPrintBill.UseVisualStyleBackColor = true;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(820, 262);
            this.lbTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(0, 13);
            this.lbTotal.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pick";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(368, 41);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(91, 20);
            this.txtName.TabIndex = 8;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(7, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(66, 30);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FoodOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 310);
            this.Controls.Add(this.btnBack);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btnBack;
    }
}