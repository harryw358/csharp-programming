
namespace Exercise4
{
    partial class frmTyreFitting
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRecordFitting = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCarReg = new System.Windows.Forms.TextBox();
            this.nudNumOfTyres = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.lblStockLeft = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.btnViewPreviousFittings = new System.Windows.Forms.Button();
            this.btnAddNewStock = new System.Windows.Forms.Button();
            this.btnCreateNewType = new System.Windows.Forms.Button();
            this.btnViewAllStock = new System.Windows.Forms.Button();
            this.txtFittingDate = new System.Windows.Forms.TextBox();
            this.nudNewStock = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfTyres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tyre Fitting Program";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of tyres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Car registration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Date of fitting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 326);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 380);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 29);
            this.label6.TabIndex = 4;
            this.label6.Text = "Stock left:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 432);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "Price:";
            // 
            // btnRecordFitting
            // 
            this.btnRecordFitting.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordFitting.Location = new System.Drawing.Point(489, 174);
            this.btnRecordFitting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRecordFitting.Name = "btnRecordFitting";
            this.btnRecordFitting.Size = new System.Drawing.Size(205, 42);
            this.btnRecordFitting.TabIndex = 3;
            this.btnRecordFitting.Text = "Record fitting";
            this.btnRecordFitting.UseVisualStyleBackColor = true;
            this.btnRecordFitting.Click += new System.EventHandler(this.btnRecordFitting_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(495, 85);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 29);
            this.label8.TabIndex = 12;
            this.label8.Text = "The cost is:";
            // 
            // txtCarReg
            // 
            this.txtCarReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarReg.Location = new System.Drawing.Point(236, 102);
            this.txtCarReg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCarReg.Name = "txtCarReg";
            this.txtCarReg.Size = new System.Drawing.Size(161, 34);
            this.txtCarReg.TabIndex = 0;
            // 
            // nudNumOfTyres
            // 
            this.nudNumOfTyres.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumOfTyres.Location = new System.Drawing.Point(236, 155);
            this.nudNumOfTyres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudNumOfTyres.Name = "nudNumOfTyres";
            this.nudNumOfTyres.Size = new System.Drawing.Size(67, 34);
            this.nudNumOfTyres.TabIndex = 1;
            this.nudNumOfTyres.ValueChanged += new System.EventHandler(this.nudNumOfTyres_valueChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(21, 302);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(692, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "label9";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Location = new System.Drawing.Point(25, 502);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(145, 41);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(193, 506);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(145, 37);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(211, 326);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(77, 29);
            this.lblType.TabIndex = 18;
            this.lblType.Text = "TYPE";
            // 
            // lblStockLeft
            // 
            this.lblStockLeft.AutoSize = true;
            this.lblStockLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockLeft.Location = new System.Drawing.Point(211, 380);
            this.lblStockLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockLeft.Name = "lblStockLeft";
            this.lblStockLeft.Size = new System.Drawing.Size(163, 29);
            this.lblStockLeft.TabIndex = 19;
            this.lblStockLeft.Text = "STOCK LEFT";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(212, 432);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(85, 29);
            this.lblPrice.TabIndex = 20;
            this.lblPrice.Text = "PRICE";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.Location = new System.Drawing.Point(492, 124);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(37, 39);
            this.lblCost.TabIndex = 13;
            this.lblCost.Text = "£";
            // 
            // btnViewPreviousFittings
            // 
            this.btnViewPreviousFittings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPreviousFittings.Location = new System.Drawing.Point(489, 222);
            this.btnViewPreviousFittings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewPreviousFittings.Name = "btnViewPreviousFittings";
            this.btnViewPreviousFittings.Size = new System.Drawing.Size(205, 63);
            this.btnViewPreviousFittings.TabIndex = 4;
            this.btnViewPreviousFittings.Text = "View previous fittings";
            this.btnViewPreviousFittings.UseVisualStyleBackColor = true;
            this.btnViewPreviousFittings.Click += new System.EventHandler(this.btnViewPreviousFittings_Click);
            // 
            // btnAddNewStock
            // 
            this.btnAddNewStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewStock.Location = new System.Drawing.Point(551, 356);
            this.btnAddNewStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddNewStock.Name = "btnAddNewStock";
            this.btnAddNewStock.Size = new System.Drawing.Size(163, 38);
            this.btnAddNewStock.TabIndex = 5;
            this.btnAddNewStock.Text = "Add new stock";
            this.btnAddNewStock.UseVisualStyleBackColor = true;
            this.btnAddNewStock.Click += new System.EventHandler(this.btnAddNewStock_Click);
            // 
            // btnCreateNewType
            // 
            this.btnCreateNewType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewType.Location = new System.Drawing.Point(508, 415);
            this.btnCreateNewType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateNewType.Name = "btnCreateNewType";
            this.btnCreateNewType.Size = new System.Drawing.Size(205, 47);
            this.btnCreateNewType.TabIndex = 6;
            this.btnCreateNewType.Text = "Create new type";
            this.btnCreateNewType.UseVisualStyleBackColor = true;
            this.btnCreateNewType.Click += new System.EventHandler(this.btnCreateNewType_Click);
            // 
            // btnViewAllStock
            // 
            this.btnViewAllStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAllStock.Location = new System.Drawing.Point(508, 469);
            this.btnViewAllStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewAllStock.Name = "btnViewAllStock";
            this.btnViewAllStock.Size = new System.Drawing.Size(205, 42);
            this.btnViewAllStock.TabIndex = 7;
            this.btnViewAllStock.Text = "View all stock";
            this.btnViewAllStock.UseVisualStyleBackColor = true;
            this.btnViewAllStock.Click += new System.EventHandler(this.btnViewAllStock_Click);
            // 
            // txtFittingDate
            // 
            this.txtFittingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFittingDate.Location = new System.Drawing.Point(236, 202);
            this.txtFittingDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFittingDate.Name = "txtFittingDate";
            this.txtFittingDate.Size = new System.Drawing.Size(161, 34);
            this.txtFittingDate.TabIndex = 2;
            // 
            // nudNewStock
            // 
            this.nudNewStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNewStock.Location = new System.Drawing.Point(489, 359);
            this.nudNewStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudNewStock.Name = "nudNewStock";
            this.nudNewStock.Size = new System.Drawing.Size(53, 34);
            this.nudNewStock.TabIndex = 21;
            // 
            // frmTyreFitting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(757, 558);
            this.Controls.Add(this.nudNewStock);
            this.Controls.Add(this.txtFittingDate);
            this.Controls.Add(this.btnViewAllStock);
            this.Controls.Add(this.btnCreateNewType);
            this.Controls.Add(this.btnAddNewStock);
            this.Controls.Add(this.btnViewPreviousFittings);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblStockLeft);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label9);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTyreFitting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tyre Fitting";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumOfTyres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNewStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRecordFitting;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCarReg;
        private System.Windows.Forms.NumericUpDown nudNumOfTyres;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStockLeft;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Button btnViewPreviousFittings;
        private System.Windows.Forms.Button btnAddNewStock;
        private System.Windows.Forms.Button btnCreateNewType;
        private System.Windows.Forms.Button btnViewAllStock;
        private System.Windows.Forms.TextBox txtFittingDate;
        private System.Windows.Forms.NumericUpDown nudNewStock;
    }
}

