

using System;

namespace shopping.Infrastructure.Exceptions
{
    public class PublisherException : Exception
    {
        public PublisherException(string message) : base(message)
        {
            GuardarLog(message);
        }

        static void GuardarLog(string message)
        {
           
            Console.WriteLine($"Error: {message}");
            // Aqui lo dejare asi hasta ahora. el que me compre el programa que me indique si le envio cartas.
        }
    }
}
