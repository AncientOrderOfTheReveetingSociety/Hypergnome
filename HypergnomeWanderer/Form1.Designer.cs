namespace HypergnomeWanderer
{
    partial class Krandlebob
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Krandlebob));
            this.GnomeMove = new System.Windows.Forms.Timer(this.components);
            this.Spritesheet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Spritesheet)).BeginInit();
            this.SuspendLayout();
            // 
            // GnomeMove
            // 
            this.GnomeMove.Enabled = true;
            this.GnomeMove.Tick += new System.EventHandler(this.GnomeMove_Tick);
            // 
            // Spritesheet
            // 
            this.Spritesheet.BackColor = System.Drawing.Color.Transparent;
            this.Spritesheet.Image = ((System.Drawing.Image)(resources.GetObject("Spritesheet.Image")));
            this.Spritesheet.Location = new System.Drawing.Point(0, 0);
            this.Spritesheet.Name = "Spritesheet";
            this.Spritesheet.Size = new System.Drawing.Size(64, 192);
            this.Spritesheet.TabIndex = 0;
            this.Spritesheet.TabStop = false;
            this.Spritesheet.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Krandlebob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(32, 32);
            this.Controls.Add(this.Spritesheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(32, 32);
            this.MinimumSize = new System.Drawing.Size(32, 32);
            this.Name = "Krandlebob";
            this.Text = "Krandlebob";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Spritesheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GnomeMove;
        private System.Windows.Forms.PictureBox Spritesheet;
    }
}

