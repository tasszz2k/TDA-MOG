namespace DTA_Theater.view
{
    partial class InsertUpdateMovieForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxThumbnail = new System.Windows.Forms.PictureBox();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxCast = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxDirector = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoosePictue = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblPath);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnChoosePictue);
            this.panel1.Controls.Add(this.pictureBoxThumbnail);
            this.panel1.Controls.Add(this.nudDuration);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbxDescription);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbxCast);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbxDirector);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxTitle);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbxId);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 633);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBoxThumbnail
            // 
            this.pictureBoxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxThumbnail.Location = new System.Drawing.Point(169, 426);
            this.pictureBoxThumbnail.Name = "pictureBoxThumbnail";
            this.pictureBoxThumbnail.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxThumbnail.TabIndex = 21;
            this.pictureBoxThumbnail.TabStop = false;
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(169, 376);
            this.nudDuration.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudDuration.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(120, 22);
            this.nudDuration.TabIndex = 20;
            this.nudDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(416, 568);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 49);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(233, 568);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 49);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(60, 568);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(116, 49);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 426);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Thumbnail:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Duration (min):";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(169, 274);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(313, 80);
            this.tbxDescription.TabIndex = 12;
            this.tbxDescription.TextChanged += new System.EventHandler(this.tbxPhone_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Description:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // tbxCast
            // 
            this.tbxCast.Location = new System.Drawing.Point(169, 226);
            this.tbxCast.Name = "tbxCast";
            this.tbxCast.Size = new System.Drawing.Size(313, 22);
            this.tbxCast.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cast:";
            // 
            // tbxDirector
            // 
            this.tbxDirector.Location = new System.Drawing.Point(169, 171);
            this.tbxDirector.Name = "tbxDirector";
            this.tbxDirector.Size = new System.Drawing.Size(313, 22);
            this.tbxDirector.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Director:";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(169, 118);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(313, 22);
            this.tbxTitle.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Title:";
            // 
            // tbxId
            // 
            this.tbxId.Enabled = false;
            this.tbxId.Location = new System.Drawing.Point(169, 70);
            this.tbxId.Name = "tbxId";
            this.tbxId.Size = new System.Drawing.Size(313, 22);
            this.tbxId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Movie Management";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChoosePictue
            // 
            this.btnChoosePictue.Location = new System.Drawing.Point(301, 490);
            this.btnChoosePictue.Name = "btnChoosePictue";
            this.btnChoosePictue.Size = new System.Drawing.Size(128, 36);
            this.btnChoosePictue.TabIndex = 22;
            this.btnChoosePictue.Text = "Choose Picture";
            this.btnChoosePictue.UseVisualStyleBackColor = true;
            this.btnChoosePictue.Click += new System.EventHandler(this.btnChoosePictue_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 454);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Path:";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(350, 454);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(40, 17);
            this.lblPath.TabIndex = 24;
            this.lblPath.Text = "none";
            // 
            // InsertUpdateMovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 657);
            this.Controls.Add(this.panel1);
            this.Name = "InsertUpdateMovieForm";
            this.Text = "InsertUpdateMovie";
            this.Load += new System.EventHandler(this.InsertUpdateMovie_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxCast;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxDirector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxThumbnail;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.Button btnChoosePictue;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label7;
    }
}