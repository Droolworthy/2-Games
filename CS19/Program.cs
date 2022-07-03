using System;

namespace CS19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(); //ранодом
            string userInput; //ввод
            int Nero = 100; // охотник на демонов Неро, 100 хп
            int stinger = 100;// жало, 100 урона
            int highSide = 50; // подбросить врага вверх, 50 урона
            int bossMundus = 500; // босс, 500 здоровья
            int bossDamage = 20; // урон от босса, 20 ед
            int death = 0; //смерть
            int devilTrigger = 250; // дьявольский триггер, 250 урона
            int medicalPackage = 25; // хил, восстанавливает 25 здоровья
            int recoveryBossMundus = 50; //хил демона 
            int bleeding = 50; //кровотечение
            int probabilityActivationDevilTrigger = 50; //вероятность активации девил триггера
            int emptyMedicalBag = 0; //пустой мед пакет
            int maxHealthBossMundus = 550; // макс запаз жизей босса
            int maxHealthNero = 125; // максимальный запас Неро
            bool stingerEffect = false; //активация клинка Жало
            bool exitApp = true; // булевое выражение, выход из игры

            Console.WriteLine("Вы охотник на демонов Неро, перед вами главный демон игры Мундус. Начнём!");
            Console.WriteLine();
            Console.WriteLine($"У босса {bossMundus} хп");
            Console.WriteLine($"У вас {Nero} хп");
            Console.WriteLine();
            Console.WriteLine($"1 - Жало. Острый клинок, который активируется в воздухе, нанося {stinger} урона.");
            Console.WriteLine($"2 - Подбросить врага вверх. Способность Неро наносящая {highSide} урона. " +
                $"Даёт возможность активировать первый скилл - Жало."); 
            Console.WriteLine($"3 - Дьявольский триггер. Атака на {devilTrigger} едениц. " +
                $"Риск кровотечения составляет {bleeding} процентов.");
            Console.WriteLine($"4 - Медицинский пакет. Восстанавливает здоровье на {medicalPackage} едениц. " +
                $"При использовании Демон восстанавливает {recoveryBossMundus} едениц.");
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
                        }
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "2":
                        bossMundus -= highSide;
                        Nero -= bossDamage;
                        stingerEffect = true;
                        Console.WriteLine($"Вы подкинули демона вверх нанеся ему {highSide} урона.");
                        Console.WriteLine($"У босса осталось {bossMundus} хп.");
                        Console.WriteLine($"У вас осталось {Nero} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "3":
                        if (probabilityActivationDevilTrigger > random.Next(1, 100))
                        {
                            bossMundus -= devilTrigger;
                            Console.WriteLine($"Вы активируйте дьявольсий триггер и превращайтесь в Демона! " +
                                $"Вы наносите {devilTrigger} едениц урона!");
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
                        if (Nero < maxHealthNero || bossMundus < maxHealthBossMundus)
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
