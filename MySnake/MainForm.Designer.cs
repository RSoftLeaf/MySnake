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
            this.components = new System.ComponentModel.Container();
            this.tbConsole = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbConsoleFull = new System.Windows.Forms.RichTextBox();
            this.lbShowLengthSpeed = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbConsole.Location = new System.Drawing.Point(368, 475);
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.Size = new System.Drawing.Size(339, 23);
            this.tbConsole.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(713, 475);
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
            this.tbConsoleFull.ReadOnly = true;
            this.tbConsoleFull.Size = new System.Drawing.Size(420, 457);
            this.tbConsoleFull.TabIndex = 2;
            this.tbConsoleFull.Text = "C# Started\n";
            // 
            // lbShowLengthSpeed
            // 
            this.lbShowLengthSpeed.AutoSize = true;
            this.lbShowLengthSpeed.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbShowLengthSpeed.Location = new System.Drawing.Point(12, 365);
            this.lbShowLengthSpeed.Name = "lbShowLengthSpeed";
            this.lbShowLengthSpeed.Size = new System.Drawing.Size(0, 22);
            this.lbShowLengthSpeed.TabIndex = 3;
            this.lbShowLengthSpeed.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.lbShowLengthSpeed);
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
        private Label lbShowLengthSpeed;
        private System.Windows.Forms.Timer timer2;
    }
}