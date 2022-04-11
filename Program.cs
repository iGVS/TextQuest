using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    class Program
    {
        static bool isStart = true;
        static int room = 1;
        static int gold = 0;
        static bool medallion = false;
        static bool ink = true;
        static void Main(string[] args)
        {
            Intro();
            while(true)
            {
                if (room == 1) Tavern();
                else Outdoor();
            }
        }

        static void Tavern()
        {
            int option;
            if (isStart)
            {
                Console.WriteLine("Пожалуй, стоит осмотреться, чтобы было хоть какое-то понимание происходящего...");
                Console.WriteLine("1. Осмотреться вокруг.");
                option = AnswerInRange(1);
                isStart = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы стоите посреди старой таверны, что дальше?");
                Console.WriteLine("1. Осмотреться вокруг.");
                Console.WriteLine("2. Подойти к трактирщику.");
                Console.WriteLine("3. Поговорить с бродягой.");
                Console.WriteLine("4. Выйти из таверны.");
                option = AnswerInRange(4);
            }
            if (option == 1)
            {
                Console.Clear();
                Console.WriteLine("Старая, еле живая таверна, трактирщик протирает кружки, очевидно работы у него не очень много...");
                Console.WriteLine("В единственном грязном окне еле видно пасмурное небо на фоне деревьев... ");
                Console.WriteLine("Слева от входа сидит какой-то бродяга, в дальнем углу кто-то спит...");
                Console.ReadLine();
            }
            else if (option == 2) Innkeeper();
            else if (option == 3) Vagabond();
            else if (option == 4) room = 2;
        }
        static void Innkeeper()
        {
            if(ink)
            {
                Console.Clear();
                Console.WriteLine("Трактирщик замечает, что вы идёте в его сторону:");
                Console.WriteLine("- Проспался?");
                Console.WriteLine("- Да, вроде бы... Как я тут оказался?");
                Console.WriteLine("-Понятия не имею, в начале моей смены ты уже дрых в углу!");
                Console.ReadLine();
                ink = false;
            }
            Console.Clear();
            Console.WriteLine("Вы стоите перед трактирщиком:");
            Console.WriteLine("1. Отойти от трактирщика.");
            Console.WriteLine("2. Попросить выпить.");
            Console.WriteLine("3. Спросить, где мы находимся.");
            int option = AnswerInRange(3);

            if(option == 2)
            {
                Console.Clear();
                Console.WriteLine("- Налей мне чего-нибудь покрепче!");
                Console.WriteLine("- Без проблем, 8 монет!");
                if(gold < 8 )
                {
                    Console.WriteLine("1. -У меня ничего нет.");
                    option = AnswerInRange(1);
                    Console.WriteLine("- No money, no honey !");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("1. - Вот, держи.");
                    Console.WriteLine("2. - Как-то дорого тут у вас...");
                    option = AnswerInRange(2);
                    if(option == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Трактирщик берёт монеты и наливает большую кружку тёмного пива из дубовой бочки...");
                        Console.ReadLine();
                        gold -= 8;
                    }
                    else
                    {
                        Console.WriteLine("- А кому сейчас легко?");
                        Console.ReadLine();
                    }
                }
            }
        }

        static void Vagabond()
        {
            if (!medallion)
            {
                Console.Clear();
                Console.WriteLine("Бродяга не замечает вас, пока вы не подошли к нему в притык.");
                Console.WriteLine("- Жизнь или смерть, грязный бродяга!");
                Console.WriteLine("- Вот, возьми всё что у меня есть, только не трогай меня!");
                Console.WriteLine("1. Забрать всё что у него есть.");
                Console.WriteLine("2. Оставить бродягу в покое.");
                int option = AnswerInRange(2);
                if (option == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Вы забираешь у бродяги медальон и 50 монет.");
                    Console.WriteLine("Бродяга недовольно говорит в вашу сторону: «Я теперь умру с голоду!»");
                    Console.ReadLine();
                    medallion = true;
                    gold += 50;
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Бродяга всадил Вам нож в спину как только Вы отвернулись!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Бродяга недовольно ворчит: «У меня больше ничего нет!»");
                Console.ReadLine();
            }
        }
         
        static void Outdoor()
        {
            Console.Clear();
            Console.WriteLine("Вы стоите перед старой таверной в какой-то глуши, все видимые дороги уходят в лес и не выглядят безопасно...");
            Console.WriteLine("1. Вернуться в таверну.");
            int option = AnswerInRange(1);
            if (option == 1) room = 1;

        }

        static void Intro()
        {
            Console.WriteLine("Вы приходите в сознание, сидя в углу какой-то дряхлой таверны...");
            Console.WriteLine("Вы не помните, как тут оказались, сколько сейчас времени и какой день...");
            Console.WriteLine("Проверив свои карманы вы не находите в них ничего полезного...");
            Console.WriteLine("«Ну, по крайней мере жив, и все конечности на месте!» - с этой мыслью вы решаете встать, хотя и не знаете, зачем...");
            Console.ReadLine();
        }

        static int AnswerInRange(int answerNumber)
        {
            string input = Console.ReadLine();
            int number = -1;
            bool isConverted = int.TryParse(input, out number);
            bool isInRange = number >= 1 && number <= answerNumber;

            while(!isConverted || !isInRange)
            {
                Console.WriteLine("Некорректный выбор, попробуй ещё раз!");
                input = Console.ReadLine();
                isConverted = int.TryParse(input, out number);
                isInRange = number >= 1 && number <= answerNumber;
            }
            return number;
        }
    }
}
