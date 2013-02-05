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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System.IO;
using Microsoft.WindowsAzure;

namespace CumulusChat {
    class ChatApplication : IDisposable {
        private string topicName = "CumulusChatTopic";
        private MessagingFactory factory;
        private TopicClient topicClient;
        private SubscriptionClient subClient;
        private NamespaceManager namespaceManager;
        private string subscriptionName;
        private Random random;
        public delegate void MessageReceived(string message);

        public async void Init(MessageReceived messageReceivedHandler) {
            this.random = new Random();

            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.AutoDetect;

            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            this.factory = MessagingFactory.CreateFromConnectionString(connectionString);
            this.namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.TopicExists(topicName)) {
                namespaceManager.CreateTopic(topicName);
            }

            this.subscriptionName = Guid.NewGuid().ToString();

            // Not needed, it's a GUID
            if (!namespaceManager.SubscriptionExists(topicName, subscriptionName)) {
                namespaceManager.CreateSubscription(topicName, subscriptionName);
            }

            this.topicClient = factory.CreateTopicClient(topicName);

            this.subClient = factory.CreateSubscriptionClient(topicName, subscriptionName);

            while (true) {
                await ReceiveMessageTaskAsync(messageReceivedHandler);
            }
        }

        private string ReceiveMessage() {

            BrokeredMessage brokeredMessage = this.subClient.Receive();
            string message = string.Empty;
            if (brokeredMessage != null) {
                try {
                    message = brokeredMessage.GetBody<string>();
                    Console.WriteLine("Body: " + message);

                    Console.WriteLine("MessageID: " + brokeredMessage.MessageId);

                    // Remove message from subscription
                    brokeredMessage.Complete();
                } catch (Exception) {
                    // Indicate a problem, unlock message in subscription
                    brokeredMessage.Abandon();
                }
            }
            return message;
        }

        private async Task ReceiveMessageTaskAsync(MessageReceived messageReceivedHandler) {
            Task<BrokeredMessage> t = Task<BrokeredMessage>.Factory.FromAsync(this.subClient.BeginReceive, subClient.EndReceive, null);
            BrokeredMessage brokeredMessage = await t;
            string message;
            if (brokeredMessage != null) {
                try {
                    message = brokeredMessage.GetBody<string>();

                    // Remove message from subscription
                    brokeredMessage.Complete();

                    messageReceivedHandler(message);
                } catch (Exception) {
                    // Indicate a problem, unlock message in subscription
                    brokeredMessage.Abandon();
                }
            }
        }

        private Task SendMessagesTaskAsync(string message) {
            Task t = Task.Factory.FromAsync(this.topicClient.BeginSend, this.topicClient.EndSend, new BrokeredMessage(message), null);
            return t;
        }

        public void SendMessage(string message) {
            this.topicClient.Send(new BrokeredMessage(message));
        }


        private void SendMessageAPM(string message) {
            this.topicClient.BeginSend(new BrokeredMessage(message), processEndSend, this.topicClient);
        }

        void processEndSend(IAsyncResult result) {
            TopicClient tc = result.AsyncState as TopicClient;
            tc.EndSend(result);
            Console.WriteLine("Message sent");
        }

        public string GetRandomName() {
            string name = string.Empty;
            string wovels = "aoueiy";
            string theRest = "qwrtpsdfghjklzxcvbnm";
            int parts = this.random.Next(5);
            for (int i = 0; i < parts; i++) {
                if (i == 0) {
                    name += Char.ToUpper(theRest[this.random.Next(20)]);
                } else {
                    name += theRest[this.random.Next(20)];
                }
                name += wovels[this.random.Next(6)];
            }
            return name;
        }

        public void Dispose() {
            try {
                this.namespaceManager.DeleteSubscription(this.topicName, this.subscriptionName);
            } catch { }
        }
    }
}
