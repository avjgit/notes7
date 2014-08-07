using System;

namespace AndyPike.Castlecasts.IntroToWindsor.FromNonToWindsor
{
    public class PlainTextEmailer : INotifier
    {
        public void Send(Customer customer, string message)
        {
            //Send an email to customer.Email
            Console.WriteLine("Emailing customer");
        }
    }
}