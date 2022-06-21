
namespace BanMT
{
    partial class fmtkhoadon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmtkhoadon));
            this.label1 = new System.Windows.Forms.Label();
            this.cbomahd = new System.Windows.Forms.ComboBox();
            this.dgvtchoadon = new System.Windows.Forms.DataGridView();
            this.btnin = new System.Windows.Forms.Button();
            this.btndong = new System.Windows.Forms.Button();
            this.btntimkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtchoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Kiếm Hóa Đơn";
            // 
            // cbomahd
            // 
            this.cbomahd.FormattingEnabled = true;
            this.cbomahd.Location = new System.Drawing.Point(198, 137);
            this.cbomahd.Name = "cbomahd";
            this.cbomahd.Size = new System.Drawing.Size(209, 24);
            this.cbomahd.TabIndex = 10;
            this.cbomahd.SelectedIndexChanged += new System.EventHandler(this.cbomahd_SelectedIndexChanged);
            // 
            // dgvtchoadon
            // 
            this.dgvtchoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtchoadon.Location = new System.Drawing.Point(12, 185);
            this.dgvtchoadon.Name = "dgvtchoadon";
            this.dgvtchoadon.RowHeadersWidth = 51;
            this.dgvtchoadon.RowTemplate.Height = 24;
            this.dgvtchoadon.Size = new System.Drawing.Size(849, 211);
            this.dgvtchoadon.TabIndex = 11;
            this.dgvtchoadon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvtchoadon_CellContentClick);
            // 
            // btnin
            // 
            this.btnin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnin.Image = ((System.Drawing.Image)(resources.GetObject("btnin.Image")));
            this.btnin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnin.Location = new System.Drawing.Point(654, 128);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(85, 38);
            this.btnin.TabIndex = 21;
            this.btnin.Text = "IN";
            this.btnin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.Image = global::BanMT.Properties.Resources.exit;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(751, 402);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(110, 36);
            this.btndong.TabIndex = 20;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.Image")));
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(428, 128);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(125, 38);
            this.btntimkiem.TabIndex = 9;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // fmtkhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(873, 443);
            this.Controls.Add(this.btnin);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.dgvtchoadon);
            this.Controls.Add(this.cbomahd);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.label1);
            this.Name = "fmtkhoadon";
            this.Text = "fmtkhoadon";
            this.Load += new System.EventHandler(this.fmtkhoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtchoadon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbomahd;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.DataGridView dgvtchoadon;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnin;
    }
}