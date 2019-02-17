using System;

namespace FcmConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Authentication keys
            string serverKey = "AAAAsx_3OiY:APA91bFKFI-9ECNtaHochZXhCFq69uhDjOCj1RnqxGfQmR9MlfIzIe544JRqhQO9Tw5ka1iyhIdjcp96uN-usiJfglbtN2GrZHarI1L2HG4mRWQTlSmrZ9zdbKrGPLZQSW33fVH-Kaec";
            string senderId = "769335441958";
            string deviceKey;

            // Get the deviceKey from console
            Console.WriteLine("Enter device key : ");
            deviceKey = Console.ReadLine();

            var fcmSender = new FCMSender(serverKey, senderId);
            var message = new FCMMessage
            {
                ReceiverDeviceKey = deviceKey,
                Message = new FCMMessage.MessageBody
                {
                    Title = "TestMessage",
                    Body = "this is a test message",
                    ClickAction = "https://firebase.google.com/docs/cloud-messaging/",
                    Sound = "Enable"
                }
            };
            var fcmResponse = fcmSender.Send(message).Result;

            Console.WriteLine("FCM server is saying: {0}", fcmResponse);
        }
    }
}
