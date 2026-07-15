namespace Exercise4
{
    partial class frmCreateNewTyreType
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
            this.lblType = new System.Windows.Forms.Label();
            this.lblStockLeft = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.nudStockLeft = new System.Windows.Forms.NumericUpDown();
            this.btnRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudStockLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblType.Location = new System.Drawing.Point(16, 23);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(68, 29);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type";
            // 
            // lblStockLeft
            // 
            this.lblStockLeft.AutoSize = true;
            this.lblStockLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblStockLeft.Location = new System.Drawing.Point(16, 84);
            this.lblStockLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockLeft.Name = "lblStockLeft";
            this.lblStockLeft.Size = new System.Drawing.Size(111, 29);
            this.lblStockLeft.TabIndex = 1;
            this.lblStockLeft.Text = "Stock left";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.lblPrice.Location = new System.Drawing.Point(16, 139);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(69, 29);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Price";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txtType.Location = new System.Drawing.Point(155, 28);
            this.txtType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(132, 34);
            this.txtType.TabIndex = 3;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.txtPrice.Location = new System.Drawing.Point(155, 139);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(132, 34);
            this.txtPrice.TabIndex = 4;
            // 
            // nudStockLeft
            // 
            this.nudStockLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.nudStockLeft.Location = new System.Drawing.Point(155, 81);
            this.nudStockLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudStockLeft.Name = "nudStockLeft";
            this.nudStockLeft.Size = new System.Drawing.Size(57, 34);
            this.nudStockLeft.TabIndex = 5;
            // 
            // btnRecord
            // 
            this.btnRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnRecord.Location = new System.Drawing.Point(95, 201);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(136, 42);
            this.btnRecord.TabIndex = 6;
            this.btnRecord.Text = "Create";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // frmCreateNewTyreType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(336, 271);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.nudStockLeft);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStockLeft);
            this.Controls.Add(this.lblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmCreateNewTyreType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new tyre type";
            ((System.ComponentModel.ISupportInitialize)(this.nudStockLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStockLeft;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.NumericUpDown nudStockLeft;
        private System.Windows.Forms.Button btnRecord;
    }
}