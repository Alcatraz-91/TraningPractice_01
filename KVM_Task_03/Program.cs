using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVM_Task_03
{
    class Program
    {
        private const string password = "IP-18-4";
        private const string message = "Друг, ты классный! Оставайся таким :)";
        static void Main(string[] args)
        {
            int attempts = 0;
            string pass = "";
            while (!pass.Equals(password))
            {
                attempts++;
                if (attempts > 3) System.Environment.Exit(1);
                Console.WriteLine($"Enter the password. Attempt {attempts} of 3");
                pass = Console.ReadLine();
            }
            Console.WriteLine($"You opened a secret message!: {message}");
            Console.ReadKey();
        }
    }
}