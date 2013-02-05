//Copyright (C) 2013  Johan Karlsson  <johangithub@gmail.com>
//
//CumulusChat is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//CumulusChat is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with CumulusChat.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CumulusChat {
    public partial class ChatForm : Form {
        private ChatApplication chatApplication;

        public ChatForm() {
            InitializeComponent();
            this.chatApplication = new ChatApplication();
            this.chatApplication.Init(OnMessageReceived);
            this.myName.Text = this.chatApplication.GetRandomName();
        }

        private void sendButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(this.myName.Text)) {
                MessageBox.Show("Please enter your name first");
            } else {
                this.chatApplication.SendMessage(this.myName.Text + ": "+ myMessage.Text);
                myMessage.Text = string.Empty;
            }
        }

        private void OnMessageReceived(string message) {
            this.messageHistory.Text += message + Environment.NewLine;
            this.messageHistory.SelectionStart = this.messageHistory.Text.Length;
            this.messageHistory.ScrollToCaret();
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.chatApplication.Dispose();
        }

    }
}
