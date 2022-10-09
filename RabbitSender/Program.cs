using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

class Send
{
    public static void Main()
    {
        //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
        var factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        //Create the RabbitMQ connection using connection factory details as i mentioned above
        var connection = factory.CreateConnection();




        //var factory = new ConnectionFactory() { HostName = "localhost" };
        //using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            //channel.QueueDeclare(queue: "hello1",
            //                     durable: false,
            //                     exclusive: false,
            //                     autoDelete: false,
            //                     arguments: null);
            for (int i=0;i<5; i++)
            {
                 Task.Delay(50000);
                string message = "Hello World! from "+i;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello1",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
            
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}


