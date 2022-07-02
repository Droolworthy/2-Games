using System;

namespace CS19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int Nero = 100; // охотник на демонов Неро
            int stinger = 20;// жало
            int highside = 50; // подбросить врага вверх
            int millionStab = 150;  // миллион ударов 
            int triggerHeart = 250; // разряд поражающий серде
            int bossMundus = 500; // босс
            int bossDamage = 20; // урон от босса
            int death = 0;
            string userInput; //ввод
            bool exitApp = true;

            Console.WriteLine("Вы охотник на демонов Неро, перед вами главный демон игры Мундус. Начнём!");
            Console.WriteLine("1 - Жало");
            Console.WriteLine("2 - Подбросить врага вверх");
            Console.WriteLine("3 - Миллион ударов");
            Console.WriteLine("4 - Разряд поражающий сердце");
            Console.WriteLine("Для выхода из игры нажмите 5");
            Console.Write("Введите команду: ");

            userInput = Console.ReadLine();

            while (exitApp)
            {
                if (Nero <= death)
                {
                    Console.WriteLine(" Победа Демона!");
                    break;
                }
                else if (bossMundus <= death)
                {
                    Console.WriteLine(" Победа Неро!");
                    break;
                }
                if (Nero != death || bossMundus != death)
                {
                    Nero -= bossDamage;
                    Console.WriteLine("У вас осталось " + Nero + " хп");
                }
                switch (userInput)
                {
                    case "1":
                        bossMundus -= stinger;
                        Console.WriteLine($" У босса осталось {bossMundus} хп");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "2":
                        bossMundus -= highside;
                        Console.WriteLine($" У босса осталось {bossMundus} хп");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "3":
                        bossMundus -= millionStab;
                        Console.WriteLine($" У босса осталось {bossMundus} хп");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "4":
                        bossMundus -= triggerHeart;
                        Console.WriteLine($" У босса осталось {bossMundus} хп");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "5":
                        exitApp = false;
                        break;
                    default:
                        {
                            Console.WriteLine("Введите команды 1, 2, 3 или 4");
                            userInput = Console.ReadLine();
                            break;
                        }
                }
            }
        }
    }
}