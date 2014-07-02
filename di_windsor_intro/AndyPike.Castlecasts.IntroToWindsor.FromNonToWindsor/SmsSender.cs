using System;

namespace AndyPike.Castlecasts.IntroToWindsor.FromNonToWindsor
{
    public class SmsSender : INotifier
    {
        public void Send(Customer customer, string message)
        {
            Console.WriteLine("Sending SMS to customer");
        }
    }
}