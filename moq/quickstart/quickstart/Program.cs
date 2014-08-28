using System;
using Moq;

namespace quickstart
{
    class Program
    {
        static void Main(string[] args)
        {
            var mock = new Mock<ILoveThisFramework>();

            // ok, means - prepare mock object
            mock.Setup(framework => framework.DownloadExists("2.0")).Returns(true);

            // ok, means - create an object based on mock blueprint
            ILoveThisFramework lovable = mock.Object;
            
            // call method (return to which we recorded just lines before
            bool downloadable;

            downloadable = lovable.DownloadExists("2.0");

            if (downloadable)
            {
                Console.WriteLine("downloadable");
            }
            else
            {
                Console.WriteLine("not downloadable");
            } 
            
            downloadable = lovable.DownloadExists("3.0");

            if (downloadable)
            {
                Console.WriteLine("downloadable");
            }
            else
            {
                Console.WriteLine("not downloadable");
            }

            // verify that method was called
            mock.Verify(framework => framework.DownloadExists("2.0"), Times.AtMostOnce());
            Console.ReadLine();
        }
    }
}
