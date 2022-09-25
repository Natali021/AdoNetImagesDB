
namespace AdoNetImages3
{
    partial class BookDatalis
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
            this.pbBook = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbPublishyear = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBook)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBook
            // 
            this.pbBook.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbBook.Location = new System.Drawing.Point(0, 0);
            this.pbBook.Name = "pbBook";
            this.pbBook.Size = new System.Drawing.Size(544, 250);
            this.pbBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbBook.TabIndex = 0;
            this.pbBook.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Publishyear:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Author:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Title:";
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbTitle.Location = new System.Drawing.Point(111, 272);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(400, 13);
            this.lbTitle.TabIndex = 14;
            // 
            // lbPublishyear
            // 
            this.lbPublishyear.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbPublishyear.Location = new System.Drawing.Point(361, 344);
            this.lbPublishyear.Name = "lbPublishyear";
            this.lbPublishyear.Size = new System.Drawing.Size(150, 13);
            this.lbPublishyear.TabIndex = 15;
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbPrice.Location = new System.Drawing.Point(111, 344);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(150, 13);
            this.lbPrice.TabIndex = 16;
            // 
            // lbAuthor
            // 
            this.lbAuthor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbAuthor.Location = new System.Drawing.Point(111, 307);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(400, 13);
            this.lbAuthor.TabIndex = 17;
            // 
            // BookDatalis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 386);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbPublishyear);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbBook);
            this.Name = "BookDatalis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookDatalis";
            ((System.ComponentModel.ISupportInitialize)(this.pbBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pbBook;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbTitle;
        public System.Windows.Forms.Label lbPublishyear;
        public System.Windows.Forms.Label lbPrice;
        public System.Windows.Forms.Label lbAuthor;
    }
}