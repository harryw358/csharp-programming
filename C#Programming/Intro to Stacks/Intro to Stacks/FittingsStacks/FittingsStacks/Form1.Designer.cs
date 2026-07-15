namespace FittingsStacks
{
    partial class frmFittings
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
            this.txtFittingDate = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStockLeft = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.nudNumOfTyres = new System.Windows.Forms.NumericUpDown();
            this.txtCarReg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRecordFitting = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudNewStock = new System.Windows.Forms.NumericUpDown();
            this.btnAddNewStock = new System.Windows.Forms.Button();
            this.btnNextTyre = new System.Windows.Forms.Button();
            this.btnPreviousTyre = new System.Windows.Forms.Button();
            this.btnPreviousFitting = new System.Windows.Forms.Button();
            this.btnNextFitting = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTyreType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfTyres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFittingDate
            // 
            this.txtFittingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFittingDate.Location = new System.Drawing.Point(195, 173);
            this.txtFittingDate.Name = "txtFittingDate";
            this.txtFittingDate.Size = new System.Drawing.Size(122, 28);
            this.txtFittingDate.TabIndex = 26;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(192, 257);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(30, 31);
            this.lblCost.TabIndex = 33;
            this.lblCost.Text = "£";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(161, 433);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(65, 24);
            this.lblPrice.TabIndex = 36;
            this.lblPrice.Text = "PRICE";
            // 
            // lblStockLeft
            // 
            this.lblStockLeft.AutoSize = true;
            this.lblStockLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLeft.Location = new System.Drawing.Point(160, 391);
            this.lblStockLeft.Name = "lblStockLeft";
            this.lblStockLeft.Size = new System.Drawing.Size(126, 24);
            this.lblStockLeft.TabIndex = 35;
            this.lblStockLeft.Text = "STOCK LEFT";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(160, 347);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(59, 24);
            this.lblType.TabIndex = 34;
            this.lblType.Text = "TYPE";
            // 
            // nudNumOfTyres
            // 
            this.nudNumOfTyres.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumOfTyres.Location = new System.Drawing.Point(195, 132);
            this.nudNumOfTyres.Name = "nudNumOfTyres";
            this.nudNumOfTyres.Size = new System.Drawing.Size(50, 28);
            this.nudNumOfTyres.TabIndex = 24;
            this.nudNumOfTyres.ValueChanged += new System.EventHandler(this.nudNumOfTyres_valueChanged);
            // 
            // txtCarReg
            // 
            this.txtCarReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarReg.Location = new System.Drawing.Point(195, 88);
            this.txtCarReg.Name = "txtCarReg";
            this.txtCarReg.Size = new System.Drawing.Size(122, 28);
            this.txtCarReg.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(96, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "Cost";
            // 
            // btnRecordFitting
            // 
            this.btnRecordFitting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordFitting.Location = new System.Drawing.Point(387, 111);
            this.btnRecordFitting.Name = "btnRecordFitting";
            this.btnRecordFitting.Size = new System.Drawing.Size(154, 34);
            this.btnRecordFitting.TabIndex = 28;
            this.btnRecordFitting.Text = "Record fitting";
            this.btnRecordFitting.UseVisualStyleBackColor = true;
            this.btnRecordFitting.Click += new System.EventHandler(this.btnRecordFitting_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 391);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "Stock left:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 29;
            this.label5.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Date of fitting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Car registration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Number of tyres";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tyre Fitting Program";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(31, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(519, 10);
            this.label9.TabIndex = 37;
            this.label9.Text = "label9";
            // 
            // nudNewStock
            // 
            this.nudNewStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNewStock.Location = new System.Drawing.Point(341, 387);
            this.nudNewStock.Name = "nudNewStock";
            this.nudNewStock.Size = new System.Drawing.Size(40, 28);
            this.nudNewStock.TabIndex = 39;
            // 
            // btnAddNewStock
            // 
            this.btnAddNewStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewStock.Location = new System.Drawing.Point(387, 384);
            this.btnAddNewStock.Name = "btnAddNewStock";
            this.btnAddNewStock.Size = new System.Drawing.Size(122, 31);
            this.btnAddNewStock.TabIndex = 38;
            this.btnAddNewStock.Text = "Add new stock";
            this.btnAddNewStock.UseVisualStyleBackColor = true;
            this.btnAddNewStock.Click += new System.EventHandler(this.btnAddNewStock_Click);
            // 
            // btnNextTyre
            // 
            this.btnNextTyre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextTyre.Location = new System.Drawing.Point(164, 479);
            this.btnNextTyre.Name = "btnNextTyre";
            this.btnNextTyre.Size = new System.Drawing.Size(109, 30);
            this.btnNextTyre.TabIndex = 41;
            this.btnNextTyre.Text = ">";
            this.btnNextTyre.UseVisualStyleBackColor = true;
            this.btnNextTyre.Click += new System.EventHandler(this.btnNextTyre_Click);
            // 
            // btnPreviousTyre
            // 
            this.btnPreviousTyre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPreviousTyre.Location = new System.Drawing.Point(38, 476);
            this.btnPreviousTyre.Name = "btnPreviousTyre";
            this.btnPreviousTyre.Size = new System.Drawing.Size(109, 33);
            this.btnPreviousTyre.TabIndex = 40;
            this.btnPreviousTyre.Text = "<";
            this.btnPreviousTyre.UseVisualStyleBackColor = true;
            this.btnPreviousTyre.Click += new System.EventHandler(this.btnPreviousTyre_Click);
            // 
            // btnPreviousFitting
            // 
            this.btnPreviousFitting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPreviousFitting.Location = new System.Drawing.Point(387, 191);
            this.btnPreviousFitting.Name = "btnPreviousFitting";
            this.btnPreviousFitting.Size = new System.Drawing.Size(69, 33);
            this.btnPreviousFitting.TabIndex = 42;
            this.btnPreviousFitting.Text = "<";
            this.btnPreviousFitting.UseVisualStyleBackColor = true;
            this.btnPreviousFitting.Click += new System.EventHandler(this.btnPreviousFitting_Click);
            // 
            // btnNextFitting
            // 
            this.btnNextFitting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextFitting.Location = new System.Drawing.Point(475, 191);
            this.btnNextFitting.Name = "btnNextFitting";
            this.btnNextFitting.Size = new System.Drawing.Size(66, 30);
            this.btnNextFitting.TabIndex = 43;
            this.btnNextFitting.Text = ">";
            this.btnNextFitting.UseVisualStyleBackColor = true;
            this.btnNextFitting.Click += new System.EventHandler(this.btnMostRecentFitting_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(387, 151);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(154, 34);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "Clear fitting";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(59, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 24);
            this.label12.TabIndex = 45;
            this.label12.Text = "Tyre type";
            // 
            // lblTyreType
            // 
            this.lblTyreType.AutoSize = true;
            this.lblTyreType.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTyreType.Location = new System.Drawing.Point(192, 221);
            this.lblTyreType.Name = "lblTyreType";
            this.lblTyreType.Size = new System.Drawing.Size(0, 31);
            this.lblTyreType.TabIndex = 46;
            // 
            // frmFittings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 530);
            this.Controls.Add(this.lblTyreType);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnNextFitting);
            this.Controls.Add(this.btnPreviousFitting);
            this.Controls.Add(this.btnNextTyre);
            this.Controls.Add(this.btnPreviousTyre);
            this.Controls.Add(this.nudNewStock);
            this.Controls.Add(this.btnAddNewStock);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFittingDate);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStockLeft);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.nudNumOfTyres);
            this.Controls.Add(this.txtCarReg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRecordFitting);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmFittings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fittings";
            this.Load += new System.EventHandler(this.frmFittings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfTyres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFittingDate;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStockLeft;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.NumericUpDown nudNumOfTyres;
        private System.Windows.Forms.TextBox txtCarReg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRecordFitting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudNewStock;
        private System.Windows.Forms.Button btnAddNewStock;
        private System.Windows.Forms.Button btnNextTyre;
        private System.Windows.Forms.Button btnPreviousTyre;
        private System.Windows.Forms.Button btnPreviousFitting;
        private System.Windows.Forms.Button btnNextFitting;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTyreType;
    }
}

