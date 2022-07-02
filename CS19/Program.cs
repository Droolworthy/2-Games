using System;

namespace CS19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(); //ранодом
            int Nero = 100; // охотник на демонов Неро
            int stinger = 20;// жало
            int highside = 50; // подбросить врага вверх
            int millionStab = 100;  // миллион ударов 
            int triggerHeart = 150; // разряд поражающий серде
            int bossMundus = 500; // босс
            int bossDamage = 20; // урон от босса
            int death = 0; //смерть
            string userInput; //ввод
            bool exitApp = true; // булевое выражение, выход из игры
            int DevilTrigger = 250; // дьявольский триггер. атака на 1 ход на 50 ед, риск кровотечения 50 процентов.
            int medicalPackage = 25; // хил, восстанавливает 25 здоровья
            int recoveryBossMundus = 50; //хил демона 
            int bleeding = 50; //кровотечение
            int probabilityActivationDevilTrigger = 50; //вероятность активации девил триггера
            int emptyMedicalBag = 0; //пустой мед пакет
            int maxhealthbossMundus = 550; // макс запаз жизей босса
            int maxHealthNero = 125; // максимальный запас Неро

            Console.WriteLine("Вы охотник на демонов Неро, перед вами главный демон игры Мундус. Начнём!");
            Console.WriteLine();
            Console.WriteLine($"У босса {bossMundus} хп");
            Console.WriteLine($"У вас {Nero} хп");
            Console.WriteLine();
            Console.WriteLine("1 - Жало.");
            Console.WriteLine("2 - Подбросить врага вверх.");
            Console.WriteLine("3 - Миллион ударов.");
            Console.WriteLine("4 - Разряд поражающий сердце.");
            Console.WriteLine("5 - Дьявольский триггер. Атака на 250 едениц. Риск кровотечения составляет 50 процентов.");
            Console.WriteLine("6 - Медицинский пакет. Восстанавливает здоровье на 25 едениц. При использовании Демон восстанавливает 50 едениц.");
            Console.WriteLine("7 - Выход из игры");
            Console.WriteLine();
            Console.Write("Введите команду: ");
            userInput = Console.ReadLine();

            while (exitApp)
            {
                if (Nero <= death)
                {
                    Console.WriteLine(" Победа Демона! Попробуй ещё раз!");
                    break;
                }
                else if (bossMundus <= death)
                {
                    Console.WriteLine(" Победа Неро! Демон разлетается на тысячи кусков, отправляйся в АД!");
                    break;
                }
                
                switch (userInput)
                {
                    case "1":
                        bossMundus -= stinger;
                        Nero -= bossDamage;
                        Console.WriteLine($"У босса осталось {bossMundus} хп.");
                        Console.WriteLine($"У вас осталось {Nero} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "2":
                        bossMundus -= highside;
                        Nero -= bossDamage;
                        Console.WriteLine($"У босса осталось {bossMundus} хп.");
                        Console.WriteLine($"У вас осталось {Nero} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "3":
                        bossMundus -= millionStab;
                        Nero -= bossDamage;
                        Console.WriteLine($"У босса осталось {bossMundus} хп.");
                        Console.WriteLine($"У вас осталось {Nero} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "4":
                        bossMundus -= triggerHeart;
                        Nero -= bossDamage;
                        Console.WriteLine($"У босса осталось {bossMundus} хп.");
                        Console.WriteLine($"У вас осталось {Nero} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "5":

                        if (probabilityActivationDevilTrigger > random.Next(1,100))
                        {
                            bossMundus -= DevilTrigger;
                            Console.WriteLine($"Вы активируйте дьявольсий триггер и превращайтесь в Демона! " +
                                $"Вы наносите {DevilTrigger} едениц урона!");
                            Console.WriteLine($"У босса осталось {bossMundus} хп.");
                            Console.WriteLine($"У вас осталось {Nero} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        else
                        {
                            Nero -= bleeding;
                            Console.WriteLine("Попытка провалилась! При активации превращения, " +
                                "у вас открылась старая рана и пошла кровь, которая нанесла вам 50 едениц урона!");
                            Console.WriteLine($"У босса осталось {bossMundus} хп.");
                            Console.WriteLine($"У вас осталось {Nero} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        userInput = Console.ReadLine();
                        break; 
                    case "6":

                        if (Nero < maxHealthNero || bossMundus < maxhealthbossMundus)
                        {
                            Nero += medicalPackage;
                            bossMundus += recoveryBossMundus;
                            Console.WriteLine($"Вы использовали аптечку. Теперь у Неро {Nero} хп.");
                            Console.WriteLine($"Демон не сидел не месте и решил восстановится, теперь у него {bossMundus} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        else
                        {
                            Nero += emptyMedicalBag;
                            bossMundus += emptyMedicalBag;
                            Console.WriteLine("Вы попробовали воспользоваться аптечкой, но в ней пусто. Атакуйте!");
                            Console.Write("Следующая атака под номером - ");
                        }
                        userInput = Console.ReadLine();
                        break;
                    case "7":
                        exitApp = false;
                        break;
                    default:
                        {
                            Console.WriteLine("Введите команды 1, 2, 3, 4, 5, 6 или 7 - выход из игры.");
                            Console.Write("Ввод - ");
                            userInput = Console.ReadLine();
                            break;
                        }
                }
            }
        }
    }
}
