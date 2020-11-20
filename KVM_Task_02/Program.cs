using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVM_Task_02

{
    class Task2
    {
        static void Main(string[] args)
        {
            string exit = " ";
            Console.WriteLine("Эта программа будет работать, пока не будет введено слово exit");
            while (exit != "exit")
            {
                exit = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Ты ввел: " + exit);
            }
        }
    }
}