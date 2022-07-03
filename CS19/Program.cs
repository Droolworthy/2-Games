using System;

namespace CS19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(); //ранодом
            int Nero = 100; // охотник на демонов Неро
            int stinger = 100;// жало
            int highside = 50; // подбросить врага вверх
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
            bool stingerEffect = false;

            Console.WriteLine("Вы охотник на демонов Неро, перед вами главный демон игры Мундус. Начнём!");
            Console.WriteLine();
            Console.WriteLine($"У босса {bossMundus} хп");
            Console.WriteLine($"У вас {Nero} хп");
            Console.WriteLine();
            Console.WriteLine("1 - Жало.");
            Console.WriteLine("2 - Подбросить врага вверх.");
            Console.WriteLine("3 - Дьявольский триггер. Атака на 250 едениц. Риск кровотечения составляет 50 процентов.");
            Console.WriteLine("4 - Медицинский пакет. Восстанавливает здоровье на 25 едениц. При использовании Демон восстанавливает 50 едениц.");
            Console.WriteLine("5 - Выход из игры");
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
                        if (stingerEffect == true)
                        {
                            bossMundus -= stinger;
                            stingerEffect = false;
                            Console.WriteLine($"Ваш клинок превращается в острое жало и взымается вверх нанося Мундусу {stinger} урона");
                            Nero -= bossDamage;
                            Console.WriteLine($"У босса осталось {bossMundus} хп.");
                            Console.WriteLine($"У вас осталось {Nero} хп.");
                        }
                        else
                        {
                            Console.WriteLine("Чтобы активировать жало, вам нужно подбросить врага вверх!");
                            Console.Write("Следующая атака под номером - ");
                            userInput = Console.ReadLine();
                        }
                        break;
                    case "2":
                        if (stingerEffect == true)
                        bossMundus -= highside;
                        Nero -= bossDamage;
                        stingerEffect = true;
                        Console.WriteLine($"Вы подкинули демона вверх нанеся ему {highside} урона.");
                        Console.WriteLine($"У босса осталось {bossMundus} хп.");
                        Console.WriteLine($"У вас осталось {Nero} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "3":

                        if (probabilityActivationDevilTrigger > random.Next(1, 100))
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
                            Console.WriteLine($"Попытка провалилась! При активации превращения, " +
                                $"у вас открылась старая рана и пошла кровь, которая нанесла вам {bleeding} едениц урона!");
                            Console.WriteLine($"У босса осталось {bossMundus} хп.");
                            Console.WriteLine($"У вас осталось {Nero} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        userInput = Console.ReadLine();
                        break;
                    case "4":

                        if (Nero < maxHealthNero || bossMundus < maxhealthbossMundus)
                        {
                            Nero += medicalPackage;
                            bossMundus += recoveryBossMundus;
                            Console.WriteLine($"Вы использовали аптечку восстановив {medicalPackage} здоровья. Теперь у Неро {Nero} хп.");
                            Console.WriteLine($"Демон не сидел не месте и решил восстановить {recoveryBossMundus} здоровья, " +
                                $"теперь у него {bossMundus} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        else
                        {
                            Nero += emptyMedicalBag;
                            bossMundus += emptyMedicalBag;
                            Console.WriteLine($"Вы уже пользовались аптечкой, в ней ничего нет. " +
                                $"Вы восстанавливайте {emptyMedicalBag} хп. Атакуйте!");
                            Console.Write("Следующая атака под номером - ");
                        }
                        userInput = Console.ReadLine();
                        break;
                    case "5":
                        exitApp = false;
                        break;
                    default:
                        {
                            Console.WriteLine("Введите команды 1, 2, 3, 4, 5 - выход из игры.");
                            Console.Write("Ввод - ");
                            userInput = Console.ReadLine();
                            break;
                        }
                }
            }
        }
    }
}
