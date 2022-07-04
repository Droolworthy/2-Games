using System;

namespace CS19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random(); 
            string userInput; 
            int neroHealth = 100;  
            int stingerDamage = 100;
            int highSideDamage = 50; 
            int demonHealth = 500; 
            int bossDamage = 20; 
            int lethalAmountHealth = 0; 
            int devilTriggerDamage = 250; 
            int medicalPackageHealth = 25; 
            int recoveryHealthBossMundus = 50; 
            int bleedingDamage = 50; 
            int activationDevilTrigger = 50;
            int minimumActivationDevilTrigger = 1;
            int maximumActivationDevilTrigger = 100;
            int emptyMedicalBagHealth = 0; 
            int maxHealthBossMundus = 550; 
            int maxHealthNero = 125; 
            bool canStingerEffect = false; 
            bool canExitApp = true;

            Console.WriteLine("Вы охотник на демонов Неро, перед вами главный демон игры Мундус. Начнём!");
            Console.WriteLine();
            Console.WriteLine($"У босса {demonHealth} хп");
            Console.WriteLine($"У вас {neroHealth} хп");
            Console.WriteLine();
            Console.WriteLine($"1 - Жало. Острый клинок, который активируется в воздухе, нанося {stingerDamage} урона.");
            Console.WriteLine($"2 - Подбросить врага вверх. Способность Неро наносящая {highSideDamage} урона. " +
                $"Даёт возможность активировать первый скилл - Жало.");
            Console.WriteLine($"3 - Дьявольский триггер. Атака на {devilTriggerDamage} едениц. " +
                $"Риск кровотечения составляет {bleedingDamage} процентов.");
            Console.WriteLine($"4 - Медицинский пакет. Восстанавливает здоровье на {medicalPackageHealth} едениц. " +
                $"При использовании Демон восстанавливает {recoveryHealthBossMundus} едениц.");
            Console.WriteLine("5 - Выход из игры");
            Console.WriteLine();
            Console.Write("Введите команду: ");

            userInput = Console.ReadLine();

            while (canExitApp)
            {
                switch (userInput)
                {
                    case "1":
                        if (canStingerEffect == true)
                        {
                            demonHealth -= stingerDamage;
                            canStingerEffect = false;
                            Console.WriteLine($"Ваш клинок превращается в острое жало и взымается вверх нанося Мундусу {stingerDamage} урона");
                            neroHealth -= bossDamage;
                            Console.WriteLine($"У босса осталось {demonHealth} хп.");
                            Console.WriteLine($"У вас осталось {neroHealth} хп.");
                        }
                        else
                        {
                            Console.WriteLine("Чтобы активировать жало, вам нужно подбросить врага вверх!");
                        }
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "2":
                        demonHealth -= highSideDamage;
                        neroHealth -= bossDamage;
                        canStingerEffect = true;
                        Console.WriteLine($"Вы подкинули демона вверх нанеся ему {highSideDamage} урона.");
                        Console.WriteLine($"У босса осталось {demonHealth} хп.");
                        Console.WriteLine($"У вас осталось {neroHealth} хп.");
                        Console.Write("Следующая атака под номером - ");
                        userInput = Console.ReadLine();
                        break;
                    case "3":
                        if (activationDevilTrigger > random.Next(minimumActivationDevilTrigger, maximumActivationDevilTrigger)) 
                        {
                            demonHealth -= devilTriggerDamage;
                            Console.WriteLine($"Вы активируйте дьявольсий триггер и превращайтесь в Демона! " +
                                $"Вы наносите {devilTriggerDamage} едениц урона!");
                            Console.WriteLine($"У босса осталось {demonHealth} хп.");
                            Console.WriteLine($"У вас осталось {neroHealth} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        else
                        {
                            neroHealth -= bleedingDamage;
                            Console.WriteLine($"Попытка провалилась! При активации превращения, " +
                                $"у вас открылась старая рана и пошла кровь, которая нанесла вам {bleedingDamage} едениц урона!");
                            Console.WriteLine($"У босса осталось {demonHealth} хп.");
                            Console.WriteLine($"У вас осталось {neroHealth} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        userInput = Console.ReadLine();
                        break;
                    case "4":
                        if (neroHealth < maxHealthNero || demonHealth < maxHealthBossMundus)
                        {
                            neroHealth += medicalPackageHealth;
                            demonHealth += recoveryHealthBossMundus;
                            Console.WriteLine($"Вы использовали аптечку восстановив {medicalPackageHealth} здоровья. Теперь у Неро {neroHealth} хп.");
                            Console.WriteLine($"Демон не сидел не месте и решил восстановить {recoveryHealthBossMundus} здоровья, " +
                                $"теперь у него {demonHealth} хп.");
                            Console.Write("Следующая атака под номером - ");
                        }
                        else
                        {
                            neroHealth += emptyMedicalBagHealth;
                            demonHealth += emptyMedicalBagHealth;
                            Console.WriteLine($"Вы уже пользовались аптечкой, в ней ничего нет. " +
                                $"Вы восстанавливайте {emptyMedicalBagHealth} хп. Атакуйте!");
                            Console.Write("Следующая атака под номером - ");
                        }
                        userInput = Console.ReadLine();
                        break;
                    case "5":
                        canExitApp = false;
                        break;
                    default:
                        {
                            Console.WriteLine("Введите команды 1, 2, 3, 4, 5 - выход из игры.");
                            Console.Write("Ввод - ");
                            userInput = Console.ReadLine();
                            break;
                        }
                }

                if (neroHealth <= lethalAmountHealth)
                {
                    Console.WriteLine(" Победа Демона! Попробуй ещё раз!");
                    canExitApp = false;
                }
                else if (demonHealth <= lethalAmountHealth)
                {
                    Console.WriteLine(" Победа Неро! Демон разлетается на тысячи кусков, отправляйся в АД!");
                    canExitApp = false;
                }
            }
        }
    }
}
