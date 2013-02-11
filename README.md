CumulusChat
===========

Chat application with Windows Azure Service Bus backend.

I wrote this simple chat application to learn more about asynchronous (async/await) and Azure Service Bus programming.

Cloud icon by Emey87 (http://emey87.deviantart.com/) released under CC BY-ND 3.0 (http://creativecommons.org/licenses/by-nd/3.0/).

# Prerequisites #

* Visual Studio 2012 .Net 4.5
* Windows Azure Service Bus SDK (Microsoft.ServiceBus.dll): http://www.windowsazure.com/en-us/develop/downloads/
* Windows Azure account: http://www.windowsazure.com/en-us/pricing/free-trial/
* A Service Bus namespace configured: http://www.windowsazure.com/en-us/develop/net/how-to-guides/service-bus-topics/


# How it works #
## Basics ##
* Chat messages from all clients are posted to the same topic.
* By letting all clients subscribe to the same topic, they receive all messages from all clients.

## Details ##
* The connection string is read from App.config
* The topic "CumulusChatTopic" is created if it does not exist.
* A new subscription is created using a GUID as name
* A `TopicClient` is created for sending messages
* The synchronous (blocking) method `TopicClient.Send` is used for sending the chat message.
* A `SubscriptionClient` is created for receiving messages
* An infinite loop is started for receiving messages, by using asynchronous await the application is not blocked - the GUI is still responsive.
