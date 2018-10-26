namespace FPointGame
{
    partial class Form1
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
            this.hunter = new System.Windows.Forms.Label();
            this.subscriber = new System.Windows.Forms.Label();
            this.gOver = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hunter
            // 
            this.hunter.BackColor = System.Drawing.Color.Red;
            this.hunter.ForeColor = System.Drawing.Color.Transparent;
            this.hunter.Location = new System.Drawing.Point(261, 206);
            this.hunter.Name = "hunter";
            this.hunter.Size = new System.Drawing.Size(51, 50);
            this.hunter.TabIndex = 0;
            // 
            // subscriber
            // 
            this.subscriber.BackColor = System.Drawing.Color.Blue;
            this.subscriber.ForeColor = System.Drawing.Color.Transparent;
            this.subscriber.Location = new System.Drawing.Point(512, 206);
            this.subscriber.Name = "subscriber";
            this.subscriber.Size = new System.Drawing.Size(51, 50);
            this.subscriber.TabIndex = 1;
            // 
            // gOver
            // 
            this.gOver.BackColor = System.Drawing.Color.Transparent;
            this.gOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gOver.ForeColor = System.Drawing.Color.Red;
            this.gOver.Location = new System.Drawing.Point(318, 206);
            this.gOver.Name = "gOver";
            this.gOver.Size = new System.Drawing.Size(202, 39);
            this.gOver.TabIndex = 2;
            this.gOver.Text = "GAME OVER";
            this.gOver.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 486);
            this.Controls.Add(this.gOver);
            this.Controls.Add(this.subscriber);
            this.Controls.Add(this.hunter);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "PointGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label hunter;
        private System.Windows.Forms.Label subscriber;
        private System.Windows.Forms.Label gOver;
    }
}

