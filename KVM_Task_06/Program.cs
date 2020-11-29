using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVM_Task_06
{
    class Program
{
    private static string[,] _dossier = new string[0, 2];
    private static int _size = 0;

    static void Main(string[] args)
    {
        int Command = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Отдел кадров");
            Console.WriteLine("1 - Добавить досье.");
            Console.WriteLine("2 - Показать все досье.");
            Console.WriteLine("3 - Удалить досье.");
            Console.WriteLine("4 - Поиск по фамилии.");
            Console.WriteLine("5 - Выйти из программы.");
            do
            {
                Console.Write("\nВведите номер команды: ");
                if (!int.TryParse(Console.ReadLine(), out Command))
                    Console.WriteLine("\nЦифры, не буквы!");
                else if (Command == 1)
                {
                    AddDossier();
                    break;
                }
                else if (Command == 2)
                {
                    ShowDossiers();
                    break;
                }
                else if (Command == 3)
                {
                    ShowDossiers();
                    RemoveDossier();
                    break;
                }
                else if (Command == 4)
                {
                    Console.WriteLine("Назовите свою фамилию: ");
                    string surname = Console.ReadLine();
                    SearchDossier(surname);
                    break;
                }
                else if (Command == 5)
                {
                    Console.WriteLine("Выход из программы");
                    Environment.Exit(1);
                }
                else
                    Console.WriteLine("Неверные данные.");
            } while (true);
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
    }

    private static void AddDossier()
    {
        Console.Write("\nВведите фамилию: ");
        string fio = Console.ReadLine() + " ";

        Console.Write("Введите имя: ");
        fio += Console.ReadLine() + " ";

        Console.Write("Введите отчество: ");
        fio += Console.ReadLine();

        Console.Write("Введите свою должность: ");
        string post = Console.ReadLine();

        int newsize = _size + 1;

        string[,] cloneDos = new string[newsize, 2];
        for (int i = 0; i < Math.Min(_size, newsize); i++)
        {
            cloneDos[i, 0] = _dossier[i, 0];
            cloneDos[i, 1] = _dossier[i, 1];
        }
        for (int i = _size; i < newsize; i++)
        {
            cloneDos[i, 0] = "";
            cloneDos[i, 1] = "";
        }
        _dossier = cloneDos;
        _size = newsize;

        _dossier[_size - 1, 0] = fio;
        _dossier[_size - 1, 1] = post;
        Console.WriteLine("\n..Досье добавлено");
    }





    private static void ShowDossiers()
    {
        if (_size > 0)
        {
            Console.WriteLine("Список досье:");
            for (int i = 0; i < _size; i++) Console.WriteLine($"{i + 1}) {_dossier[i, 0]} - {_dossier[i, 1]}");
        }
        else
        {
            Console.WriteLine("Досье нет.");
        }
    }



    private static void RemoveDossier()
    {
        int numberOfDossier;
        if (_size > 0)
        {
            do
            {
                Console.WriteLine("Введите нормер удаляемого файла");

                if (!int.TryParse(Console.ReadLine(), out numberOfDossier))
                    Console.WriteLine("\nЦифры, не буквы!");
                else if (--numberOfDossier >= _size || numberOfDossier < 0)
                    Console.WriteLine("Неправильный индекс");
                else
                    break;
            } while (true);

            string[,] cloneDossier = new string[_size - 1, 2];
            int tempNum = 0;
            for (int i = 0; i < _size; i++)
            {
                if (i != numberOfDossier)
                {
                    cloneDossier[tempNum, 0] = _dossier[i, 0];
                    cloneDossier[tempNum, 1] = _dossier[i, 1];
                    tempNum++;
                }
                else
                {
                    Console.WriteLine($"Досье {_dossier[i, 0]} удалено");
                }
            }
            _dossier = cloneDossier;
            _size -= 1;
        }
    }





    private static void SearchDossier(string searchForSurname)
    {
        int count = 0;
        for (int i = 0; i < _size; i++)
        {
            if (_dossier[i, 0].IndexOf(searchForSurname) >= 0)
            {
                Console.WriteLine($"Досье: {i + 1}) {_dossier[i, 0]} - {_dossier[i, 1]}");
                count++;
            }
        }
        if (count == 0)
        {
            Console.WriteLine("Досье с такой фамилией не существует");
        }
    }
}
}