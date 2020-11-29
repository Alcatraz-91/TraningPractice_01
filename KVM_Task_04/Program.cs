using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVM_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Random rnd = new Random();

                int bossHealth = 700;
                int playerHealth = 350;
                int playerAttack = 0;

                bool Orchid = false;
                int Assassinate = 1;

                int Turn = rnd.Next(1, 3);
                int bossAttack = rnd.Next(1, 5);
                int DefaultAttack = 35;

                Console.WriteLine("В этой деревне живет выдающийся и легендарный охотник по имени Кардел Остроглаз, считающийся лучшим стрелком всех времен. Благодаря его умениям, он был прозван Снайпером. Его дед славился тем, что производил превосходные патроны для ружей, но сам никогда не стрелял из винтовок. Однажды он увидел, как Кардел в свои четыре года взял в руки ружье, и с тех пор он нарек ему великое будущее превосходного стрелка.");


                Console.WriteLine("\nТы шел до потайной лавки и вдруг встретил Рошана(Далее босс)");

                Console.WriteLine("\nТвои способности: " +
                                  "\n1. Default attack - Стандартный удар без использования способностей. " +
                                  "\n2. Orchid - Запрещает выбранной цели использовать способности. " +
                                  "\n3. Headshot - Кардел хорошо прицеливается и выстреливает врагу прямо в голову" +
                                  "\n4. Healing salve - Кардел восстанавливает себе 70 единиц здоровья. " +
                                  "\n5. Assassinate - Кардел заряжает винтовку особыми патронами, что увеличивает урон от Headshot в 2 раза");

                Console.WriteLine("\nНажми любую кнопку, чтобы начать сражение");
                Console.ReadKey();

                while (true)
                {
                    Console.WriteLine($"\nТвое здоровье: {playerHealth} " +
                                      $"\nЗдоровье босса: {bossHealth}");
                    if (Turn == 1)
                    {
                        Console.WriteLine("\n\n\nСейчас твоя очередь атаковать");
                        do
                        {
                            Console.WriteLine("Нажми 0 если забыл свои способности");

                            if (!int.TryParse(Console.ReadLine(), out playerAttack))
                                Console.WriteLine("\nЦифры, не буквы!");
                            else
                                break;
                        } while (true);

                        switch (playerAttack)
                        {
                            case 0:
                                Console.WriteLine("\nТвои способности: " +
                                  "\n1. Default attack - Стандартный удар без использования способностей. " +
                                  "\n2. Orchid - Запрещает выбранной цели использовать способности. " +
                                  "\n3. Headshot - Кардел хорошо прицеливается и выстреливает врагу прямо в голову" +
                                  "\n4. Healing salve - Кардел восстанавливает себе 70 единиц здоровья. " +
                                  "\n5. Assassinate - Кардел заряжает винтовку особыми патронами, что увеличивает урон от Headshot в 2 раза");
                                break;
                            case 1:
                                Console.Write("Обычный выстрел" +
                                              $"\nБосс потерял {DefaultAttack} hp");
                                bossHealth -= DefaultAttack;
                                Turn = 2;
                                break;
                            case 2:
                                Console.WriteLine("Орчид, " +
                                                  "Босс не может атаковать тебя в следующем ходу.");
                                Orchid = true;
                                Turn = 2;
                                break;
                            case 3:
                                Console.WriteLine("Выстрел в голову." +
                                              $"\nБосс потерял {DefaultAttack * Assassinate} hp");
                                bossHealth -= DefaultAttack * Assassinate;
                                Turn = 2;
                                break;
                            case 4:
                                playerHealth += 70;
                                Console.WriteLine($"Ты восстановил себе 70 hp. Теперь у тебя {playerHealth} hp.");
                                Turn = 2;
                                break;
                            case 5:
                                Console.WriteLine("Ты зарядил особые патроны. Теперь урон больше в два раза.");
                                Assassinate *= 2;
                                Turn = 2;
                                break;
                            default:
                                playerHealth -= 1;
                                Console.WriteLine($"Ты пытался придумать новую способность прямо на поле боя, но ничего не вышло. Теперь у тебя {playerHealth} hp.");
                                Turn = 2;
                                break;
                        }
                    }
                    else

                    {
                        Console.WriteLine("\n\n\nБосс атакует");
                        switch (bossAttack)
                        {
                            case 1:
                                Console.WriteLine("Босс просто ударил тебя рукой." +
                                                  "\nТы потерял 50 hp.");
                                playerHealth -= 50;
                                break;
                            case 2:
                                if (!Orchid)
                                {
                                    Console.WriteLine("Босс ударил тебя ногой" +
                                                      "\nТы потерял 100 hp.");
                                    playerHealth -= 100;
                                }
                                else
                                {
                                    Console.WriteLine("Orchid не дает боссу использовать способности");
                                    Orchid = false;
                                }
                                break;
                            case 3:
                                Console.WriteLine("Босс устал, у тебя есть шанс использовать способность.");
                                break;
                            case 4:
                                if (!Orchid)
                                {
                                    bossHealth += 100;
                                    Console.WriteLine("Босс восстанавливает себе 100 hp." +
                                                      $"Теперь у босса {bossHealth} hp.");
                                }
                                else
                                {
                                    Console.WriteLine("Orchid не дает боссу использовать способности");
                                    Orchid = false;
                                }
                                break;
                            case 5:
                                if (!Orchid)
                                {
                                    Console.WriteLine("Босс призывает духов из ада" +
                                                      "\nТы потерял 130 hp.");
                                    playerHealth -= 130;
                                }
                                else
                                {
                                    Console.WriteLine("Orchid не дает боссу использовать способности");
                                    Orchid = false;
                                }
                                break;
                        }
                        bossAttack = rnd.Next(1, 5);
                        Turn = 1;
                    }
                    if (bossHealth <= 0)
                    {
                        Console.WriteLine("\n\nБосс пал, теперь вы можете спокойно идти в лавку.");
                        break;
                    }
                    if (playerHealth <= 0)
                    {
                        Console.WriteLine("\n\nСилы истощены, вы проиграли.");
                        break;
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
