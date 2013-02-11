namespace CumulusChat {
    partial class ChatForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.messageHistory = new System.Windows.Forms.TextBox();
            this.myMessage = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.myName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageHistory
            // 
            this.messageHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageHistory.Location = new System.Drawing.Point(5, 38);
            this.messageHistory.Multiline = true;
            this.messageHistory.Name = "messageHistory";
            this.messageHistory.ReadOnly = true;
            this.messageHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageHistory.Size = new System.Drawing.Size(432, 218);
            this.messageHistory.TabIndex = 2;
            // 
            // myMessage
            // 
            this.myMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myMessage.Location = new System.Drawing.Point(8, 262);
            this.myMessage.Multiline = true;
            this.myMessage.Name = "myMessage";
            this.myMessage.Size = new System.Drawing.Size(370, 56);
            this.myMessage.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(384, 265);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(51, 52);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // myName
            // 
            this.myName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myName.Location = new System.Drawing.Point(79, 6);
            this.myName.Name = "myName";
            this.myName.Size = new System.Drawing.Size(345, 20);
            this.myName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Your name:";
            // 
            // ChatForm
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myName);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.myMessage);
            this.Controls.Add(this.messageHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatForm";
            this.Text = "CumulusChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageHistory;
        private System.Windows.Forms.TextBox myMessage;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox myName;
        private System.Windows.Forms.Label label1;
    }
}

