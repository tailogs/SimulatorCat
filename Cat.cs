using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorCat
{
    public class Cat
    {
        private Random random = new Random();
        private int health    = 100; // health
        private int satisfied = 100; // satisfied
        private int rest      = 100; // rest
        private int hunger    = 100; // hunger
        private int purity    = 100; // purity
        private int wastes    = 100; // toilet
        private int daysLife  = 0;   // number of days of life
        private string name;

        public Cat()
        {
        }

        public void birth()
        {
            Console.Write("Котик рождается, как вы его назовете?\n> ");
            this.name = Console.ReadLine();
        }

        public void live()
        {
            bool livePet = true;
            while (livePet)
            {
                Console.WriteLine("ПИТОМЕЦ: ");
                Console.WriteLine("===[ " + name + " ]==");
                Console.WriteLine("<<< Здоровье: " + health + " >>>");
                Console.WriteLine("1. Ласкать        | " + "Удовлетворенность: " + satisfied);
                Console.WriteLine("2. Играться       | " + "Удовлетворенность: " + satisfied);
                Console.WriteLine("3. Уложить спать  | " + "Отдых:             " + rest);
                Console.WriteLine("4. Покормить      | " + "Голод:             " + hunger);
                Console.WriteLine("5. Помыть         | " + "Чистота:           " + purity);
                Console.WriteLine("6. Поменять лоток | " + "Туалет:            " + wastes);

                Console.Write("> ");
                byte c = 0;
                try
                {
                    c = Convert.ToByte(Console.ReadLine());
                }
                catch (FormatException)
                {
                    c = 25;
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода: введено некорректное значение.");
                    continue;
                }

                tick();

                if (random.Next(0, 2) == 1)
                    voice();

                Console.Clear();

                switch (c)
                {
                    case 1:
                        pet();
                        break;
                    case 2:
                        play();
                        break;
                    case 3:
                        sleep();
                        break;
                    case 4:
                        eat();
                        break;
                    case 5:
                        wash();
                        break;
                    case 6:
                        toilet();
                        break;
                    default:
                        Console.WriteLine("[Выбранный пункт отсутствует]");
                        break;
                }
                livePet = death();
            }
        }
        private void tick()
        {
            for (int i = 0; i < 10; i++)
            {
                health    -= (int)Math.Round(random.NextDouble());
                satisfied -= (int)Math.Round(random.NextDouble());
                rest      -= (int)Math.Round(random.NextDouble());
                hunger    -= (int)Math.Round(random.NextDouble());
                purity    -= (int)Math.Round(random.NextDouble());
                wastes    -= (int)Math.Round(random.NextDouble());
            }
        }

        public void sleep()
        {
            Console.WriteLine(name + " спит...");
            rest += random.Next(30);
            if (rest > 100) rest = 100; // восстанавливаем отдых, но не больше 100
            addHealth();
        }

        public void eat()
        {
            Console.WriteLine(name + " ест...");
            hunger += random.Next(30);
            if (hunger > 100) hunger = 100; // увеличиваем голод, но не больше 100
            addHealth();
        }

        public void wash()
        {
            Console.WriteLine(name + " моется...");
            purity += random.Next(30);
            if (purity > 100) purity = 100; // увеличиваем чистоту, но не больше 100
            addHealth();
        }

        public void play()
        {
            Console.WriteLine(name + " играется...");
            satisfied += random.Next(30);
            if (satisfied > 100) satisfied = 100; // увеличиваем удовлетворенность, но не больше 100
            addHealth();
        }

        public void toilet()
        {
            Console.WriteLine(name + " ходит в туалет...");
            wastes += random.Next(30);
            if (wastes > 100) wastes = 100; // увеличиваем туалет, но не больше 100
            addHealth();
        }

        public void pet()
        {
            Console.WriteLine(name + " доволен лаской...");
            satisfied += random.Next(30);
            if (satisfied > 100) satisfied = 100; // увеличиваем удовлетворенность, но не больше 100
            addHealth();
        }

        String[] catVoice = { "Мур", "Мяу", "Мррр", "Мяур", "Рррррррр", "Рар" };

        public void voice()
        {
            int randomIndex = random.Next(catVoice.Length);
            String voice = catVoice[randomIndex];
            Console.WriteLine(voice + " =>-<=");
        } // говорить

        public void addHealth()
        {
            health += random.Next(30);
            if (health > 100) health = 100;
        }

        public bool death()
        {
            if (rest <= 0)
            {
                Console.WriteLine("Котик устал жить и умер");
                return false;
            }
            else if (hunger <= 0)
            {
                Console.WriteLine("Котик умер голодным");
                return false;
            }
            else if (purity <= 0)
            {
                Console.WriteLine("Котик сильно заболел и умер");
                return false;
            }
            else if (satisfied <= 0)
            {
                Console.WriteLine("Котику стало грустно и он сбежал");
                return false;
            }
            else if (wastes <= 0)
            {
                Console.WriteLine("Котику негде было ходить в туалет и он убежал на улицу");
                return false;
            }
            else if (health <= 0)
            {
                Console.WriteLine("Котик умер из-за слабого здоровья");
                Console.WriteLine("Прижил котик: " + daysLife);
                return false;
            }
            daysLife++;
            return true;
        }

        public static void clearConsole()
        {
            for (int i = 0; i < 50; i++)
                Console.WriteLine();
        }

    }
}
