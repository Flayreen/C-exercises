using System.Threading.Channels;

namespace Circles
{
    internal abstract class Program
    {
        private static void Main()
        {
            int useChoice;
            do
            {
                Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
                Console.WriteLine($"1. Велозмагання \n2. Двоє друзів \n3. Тризначний код \n4. Послідовність Фібоначчі \n5. Послідовність Лукаса \n6. Вихід з програми");
                Console.Write("Ваш вибір: ");
                useChoice = Convert.ToInt32(Console.ReadLine());

                switch (useChoice)
                {
                    case 1:
                        Console.Clear();
                        DaysForTraining();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        AccumulationMoney();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Combinations();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        Fibonacci();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Lucas();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine("Пока!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Невірне значення");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (useChoice != 6);
        }

        private static void DaysForTraining()
        {
            int startDistance;
            int goalDistance;
            Console.WriteLine("Програма №1 запущена!");
            Console.Write("Введіть скільки км ви можете проїхати в 1 день: ");
            while (!int.TryParse(Console.ReadLine(), out startDistance))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            
            Console.Write("Введіть бажаний результат: ");
            while (!int.TryParse(Console.ReadLine(), out goalDistance))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            
            int day = 0;
            for (double i = startDistance; i <= goalDistance; i += i * 0.05)
            {
                day++;
            }

            Console.WriteLine($"Ви досягнете бажаний результат через {day} днів");
        }

        private static void AccumulationMoney()
        {
            Console.WriteLine("Програма №2 запущена!");
            decimal mikeMoney = 100M;
            decimal andreyMoney = 100M;
            int countMonth = 0;
            
            do
            {
                mikeMoney += 10;
                andreyMoney += andreyMoney * 0.05M;
                countMonth++;
            } while (mikeMoney > andreyMoney);

            if (countMonth >= 12)
            {
                int years = countMonth / 12;
                int month = countMonth - (years * 12);
                Console.WriteLine($"{years} years, {month} month");
            }
            else
            {
                Console.WriteLine($"{countMonth} month");
            }
        }

        private static void Combinations()
        {
            Console.WriteLine("Програма №3 запущена!");
            List<int[]> combinations = [];

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k <= 9; k++)
                        {
                            if (k != j && k != i)
                            {
                                combinations.Add([i, j, k]);
                            }
                        }   
                    }
                }
            }

            int countCombinations = combinations.Count;
            int timeSeconds = countCombinations * 3;

            Console.WriteLine($"Кількість комбінацій: {countCombinations}");
            Console.WriteLine($"Час на всі комбінації: {timeSeconds / 60} хвилин, {timeSeconds % 60} секунд");
        }

        private static void Fibonacci()
        {
            int countFibonacci;
            Console.WriteLine("Програма №4 запущена!");
            Console.Write("Введіть кількість чисел Фібоначчі: ");
            while (!int.TryParse(Console.ReadLine(), out countFibonacci))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            
            if (countFibonacci <= 0)
            {
                Console.WriteLine("Please enter a positive integer.");
                return;
            }
            
            int[] fibonacciRow = new int[countFibonacci];
            for (int i = 0; i < countFibonacci; i++)
            {
                if (i == 0 || i == 1)
                {
                    fibonacciRow[i] = 1;
                }
                else
                {
                    fibonacciRow[i] = fibonacciRow[i - 1] + fibonacciRow[i - 2];
                }
            }

            Console.WriteLine("Fibonacci row " + String.Join(", ", fibonacciRow));
        }
        
        private static void Lucas()
        {
            int maxValue;
            Console.WriteLine("Програма №5 запущена!");
            Console.Write("Введіть чисело Лукаса: ");
            while (!int.TryParse(Console.ReadLine(), out maxValue))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            
            if (maxValue < 3)
            {
                Console.WriteLine("Please enter number >= 3.");
                return;
            }

            var lucasRow = new List<int>() {2 , 1};

            while (true)
            {
                int next = lucasRow[lucasRow.Count - 1] + lucasRow[lucasRow.Count - 2];
                
                if (next > maxValue)
                {
                    break;
                }

                lucasRow.Add(next);;
            }


            Console.WriteLine("Lucas row " + String.Join(", ", lucasRow));
        }
    }
}