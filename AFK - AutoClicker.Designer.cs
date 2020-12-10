namespace SAMP_CHEAT_KRANE
{
    partial class AFK___AutoClicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.labelChat = new System.Windows.Forms.Label();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.timerChat = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxChat.Location = new System.Drawing.Point(3, 132);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.Size = new System.Drawing.Size(630, 279);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            this.richTextBoxChat.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // labelChat
            // 
            this.labelChat.AutoSize = true;
            this.labelChat.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChat.Location = new System.Drawing.Point(3, 93);
            this.labelChat.Name = "labelChat";
            this.labelChat.Size = new System.Drawing.Size(65, 36);
            this.labelChat.TabIndex = 1;
            this.labelChat.Text = "Chat";
            // 
            // buttonEnable
            // 
            this.buttonEnable.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEnable.Location = new System.Drawing.Point(541, 96);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(92, 33);
            this.buttonEnable.TabIndex = 2;
            this.buttonEnable.Text = "Enable";
            this.buttonEnable.UseVisualStyleBackColor = true;
            this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
            // 
            // timerChat
            // 
            this.timerChat.Interval = 1000;
            this.timerChat.Tick += new System.EventHandler(this.timerChat_Tick);
            // 
            // AFK___AutoClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEnable);
            this.Controls.Add(this.labelChat);
            this.Controls.Add(this.richTextBoxChat);
            this.Name = "AFK___AutoClicker";
            this.Size = new System.Drawing.Size(636, 423);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Timer timerChat;
    }
}
