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
            this.btnView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvScreening)).BeginInit();
            this.SuspendLayout();
            // 
            // gvScreening
            // 
            this.gvScreening.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvScreening.Location = new System.Drawing.Point(438, 105);
            this.gvScreening.Name = "gvScreening";
            this.gvScreening.RowHeadersWidth = 51;
            this.gvScreening.RowTemplate.Height = 24;
            this.gvScreening.Size = new System.Drawing.Size(766, 393);
            this.gvScreening.TabIndex = 0;
            // 
            // btnArrange
            // 
            this.btnArrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(137)))));
            this.btnArrange.ForeColor = System.Drawing.Color.White;
            this.btnArrange.Location = new System.Drawing.Point(21, 419);
            this.btnArrange.Name = "btnArrange";
            this.btnArrange.Size = new System.Drawing.Size(154, 79);
            this.btnArrange.TabIndex = 2;
            this.btnArrange.Text = "Arrange Screenig Schedule";
            this.btnArrange.UseVisualStyleBackColor = false;
            this.btnArrange.Click += new System.EventHandler(this.btnArrange_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(137)))));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(181, 419);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(130, 78);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Delete OverScreening";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(448, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "Screening Manager";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbMovie
            // 
            this.lbMovie.BackColor = System.Drawing.Color.Beige;
            this.lbMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMovie.FormattingEnabled = true;
            this.lbMovie.ItemHeight = 25;
            this.lbMovie.Location = new System.Drawing.Point(21, 105);
            this.lbMovie.Name = "lbMovie";
            this.lbMovie.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMovie.Size = new System.Drawing.Size(411, 304);
            this.lbMovie.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(137)))));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(317, 419);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(115, 78);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View Screening";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // ScreeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(1216, 528);
            this.Controls.Add(this.btnView);
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
        private System.Windows.Forms.Button btnView;
    }
}

