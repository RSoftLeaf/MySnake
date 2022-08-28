namespace MySnake
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbConsoleFull = new System.Windows.Forms.RichTextBox();
            this.lbSnakeLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbConsole.Location = new System.Drawing.Point(368, 415);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(339, 23);
            this.tbConsole.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(713, 415);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbConsoleFull
            // 
            this.tbConsoleFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbConsoleFull.Location = new System.Drawing.Point(368, 12);
            this.tbConsoleFull.Name = "tbConsoleFull";
            this.tbConsoleFull.Size = new System.Drawing.Size(420, 397);
            this.tbConsoleFull.TabIndex = 2;
            this.tbConsoleFull.Text = "";
            // 
            // lbSnakeLength
            // 
            this.lbSnakeLength.AutoSize = true;
            this.lbSnakeLength.Font = new System.Drawing.Font("Arial Black", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbSnakeLength.Location = new System.Drawing.Point(84, 362);
            this.lbSnakeLength.Name = "lbSnakeLength";
            this.lbSnakeLength.Size = new System.Drawing.Size(68, 76);
            this.lbSnakeLength.TabIndex = 3;
            this.lbSnakeLength.Text = "0";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbSnakeLength);
            this.Controls.Add(this.tbConsoleFull);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbConsole);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbConsole;
        private Button btnSend;
        private RichTextBox tbConsoleFull;
        private Label lbSnakeLength;
    }
}