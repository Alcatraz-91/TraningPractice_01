using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVM_TASK_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold = 0;
            int crystalsToBuy = 0;
            const int crystalCost = 15;

            Console.WriteLine($"Курс кристаллов к золоту - 1 : {crystalCost}");
        inputGoldErr:
            Console.Write("Сколько у тебя золота?: ");
            try
            {
                gold = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЦифры, не буквы!");
                goto inputGoldErr;
            }

            if (gold < 0)
            {
                Console.WriteLine("\nКажется, ты должник");
                Console.Write("Ни кристалов, ни денег :(");
            }
            else if (gold < crystalCost)
            {
                Console.WriteLine("\nДаже на один кристалл не хватит");
                Console.WriteLine($"У вас {gold} золота и {crystalsToBuy} кристаллов.");
            }
            else
            {
            inputCrystalsErr:
                Console.WriteLine("\nСколько кристалов тебе нужно?");

                try
                {
                    crystalsToBuy = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Цифры, не буквы!");
                    goto inputCrystalsErr;
                }


                if (crystalsToBuy * crystalCost > gold)
                {
                    Console.WriteLine("\nКажется, у тебя не хватает золота :(");
                    crystalsToBuy = 0;
                    Console.WriteLine($"У вас {gold} золота и {crystalsToBuy} кристаллов.");
                }
                else
                {
                    gold -= crystalsToBuy * crystalCost;
                    Console.WriteLine($"\nУ вас {gold} золота и {crystalsToBuy} кристаллов.");

                }
            }
            Console.ReadKey();
        }
    }
}