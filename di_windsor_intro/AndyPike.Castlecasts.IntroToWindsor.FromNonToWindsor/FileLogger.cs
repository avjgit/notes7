﻿using System;

namespace AndyPike.Castlecasts.IntroToWindsor.FromNonToWindsosr
{
    public class FileLogger : ILogger
    {
        public void Info(string message)
        {
            //Write the message to a file
            Console.WriteLine("Logging: " + message);
        }
    }
}