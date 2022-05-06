
namespace LibraryApp
{
    partial class BookElement
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookName = new System.Windows.Forms.Label();
            this.authorF = new System.Windows.Forms.Label();
            this.authorNO = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bookImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bookName
            // 
            this.bookName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(148)))), ((int)(((byte)(157)))));
            this.bookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bookName.Location = new System.Drawing.Point(3, 202);
            this.bookName.Name = "bookName";
            this.bookName.Size = new System.Drawing.Size(165, 44);
            this.bookName.TabIndex = 1;
            this.bookName.Click += new System.EventHandler(this.BookElement_Click);
            // 
            // authorF
            // 
            this.authorF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.authorF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(239)))), ((int)(((byte)(159)))));
            this.authorF.Location = new System.Drawing.Point(3, 169);
            this.authorF.Name = "authorF";
            this.authorF.Size = new System.Drawing.Size(165, 33);
            this.authorF.TabIndex = 2;
            this.authorF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.authorF.Click += new System.EventHandler(this.BookElement_Click);
            // 
            // authorNO
            // 
            this.authorNO.BackColor = System.Drawing.Color.Blue;
            this.authorNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(239)))), ((int)(((byte)(159)))));
            this.authorNO.Location = new System.Drawing.Point(32, 136);
            this.authorNO.Name = "authorNO";
            this.authorNO.Size = new System.Drawing.Size(136, 33);
            this.authorNO.TabIndex = 3;
            this.authorNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.authorNO.Click += new System.EventHandler(this.BookElement_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(4, 130);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(164, 2);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // bookImage
            // 
            this.bookImage.Image = global::LibraryApp.Properties.Resources._2022_02_15_23_00_14;
            this.bookImage.Location = new System.Drawing.Point(4, 0);
            this.bookImage.Name = "bookImage";
            this.bookImage.Size = new System.Drawing.Size(164, 133);
            this.bookImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bookImage.TabIndex = 5;
            this.bookImage.TabStop = false;
            this.bookImage.Click += new System.EventHandler(this.BookElement_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pictureBox1.Location = new System.Drawing.Point(3, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.BookElement_Click);
            // 
            // BookElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(239)))), ((int)(((byte)(159)))));
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.bookImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.authorNO);
            this.Controls.Add(this.authorF);
            this.Controls.Add(this.bookName);
            this.Name = "BookElement";
            this.Size = new System.Drawing.Size(176, 267);
            this.Click += new System.EventHandler(this.BookElement_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label bookName;
        private System.Windows.Forms.Label authorF;
        private System.Windows.Forms.Label authorNO;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox bookImage;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
