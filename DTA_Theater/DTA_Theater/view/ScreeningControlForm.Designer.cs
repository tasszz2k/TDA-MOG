namespace DTA_Theater
{
    partial class ScreeningForm
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
            this.gvScreening = new System.Windows.Forms.DataGridView();
            this.btnArrange = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMovie = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvScreening)).BeginInit();
            this.SuspendLayout();
            // 
            // gvScreening
            // 
            this.gvScreening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvScreening.Location = new System.Drawing.Point(317, 105);
            this.gvScreening.Name = "gvScreening";
            this.gvScreening.RowHeadersWidth = 51;
            this.gvScreening.RowTemplate.Height = 24;
            this.gvScreening.Size = new System.Drawing.Size(471, 393);
            this.gvScreening.TabIndex = 0;
            // 
            // btnArrange
            // 
            this.btnArrange.Location = new System.Drawing.Point(21, 419);
            this.btnArrange.Name = "btnArrange";
            this.btnArrange.Size = new System.Drawing.Size(154, 79);
            this.btnArrange.TabIndex = 2;
            this.btnArrange.Text = "Arrange Screenig Schedule";
            this.btnArrange.UseVisualStyleBackColor = true;
            this.btnArrange.Click += new System.EventHandler(this.btnArrange_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(181, 419);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 78);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Delete OverScreening";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Screening Manager";
            // 
            // lbMovie
            // 
            this.lbMovie.FormattingEnabled = true;
            this.lbMovie.ItemHeight = 16;
            this.lbMovie.Location = new System.Drawing.Point(21, 105);
            this.lbMovie.Name = "lbMovie";
            this.lbMovie.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbMovie.Size = new System.Drawing.Size(290, 308);
            this.lbMovie.TabIndex = 4;
            // 
            // ScreeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 528);
            this.Controls.Add(this.lbMovie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnArrange);
            this.Controls.Add(this.gvScreening);
            this.Name = "ScreeningForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvScreening)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvScreening;
        private System.Windows.Forms.Button btnArrange;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbMovie;
    }
}

