namespace Pseudographics
{
    internal abstract class Program
    {
        private static void Main()
        {
            int useChoice;
            do
            {
                Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
                Console.WriteLine($"1. Намалюйте прямокутний трикутник \n2. Двоє друзів \n3. Тризначний код \n4. Послідовність Фібоначчі \n5. Послідовність Лукаса \n6. Вихід з програми");
                Console.Write("Ваш вибір: ");
                useChoice = Convert.ToInt32(Console.ReadLine());

                switch (useChoice)
                {
                    case 1:
                        Console.Clear();
                        DrawRectangular();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    // case 2:
                    //     Console.Clear();
                    //     AccumulationMoney();
                    //     Console.ReadKey();
                    //     Console.Clear();
                    //     break;
                    // case 3:
                    //     Console.Clear();
                    //     Combinations();
                    //     Console.ReadKey();
                    //     Console.Clear();
                    //     break;
                    // case 4:
                    //     Console.Clear();
                    //     Fibonacci();
                    //     Console.ReadKey();
                    //     Console.Clear();
                    //     break;
                    // case 5:
                    //     Console.Clear();
                    //     Lucas();
                    //     Console.ReadKey();
                    //     Console.Clear();
                    //     break;
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

        private static void DrawRectangular()
        {
            int rectangularWidth;
            char rectangularSymbol;
            Console.WriteLine("Програма №1 запущена!");
            Console.Write("Введіть ширину прямокутного трикутника: ");
            while (!int.TryParse(Console.ReadLine(), out rectangularWidth))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            Console.Write("Введіть символ прямокутного трикутника: ");
            while (!char.TryParse(Console.ReadLine(), out rectangularSymbol))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }

            char[,] triangle = new char[rectangularWidth, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }

            for (int i = rectangularWidth - 1; i >= 0; i--)
            {
                for (int j = 0; j < rectangularWidth; j++)
                {
                    triangle[i, j] = rectangularSymbol;
                }
                rectangularWidth--;
            }
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    Console.Write(triangle[i, j]);
                }

                Console.WriteLine();
            }

        }

        private static void DrawIsoscelesTriangle()
        {
            int rectangularHeight;
            char rectangularSymbol;
            Console.WriteLine("Програма №1 запущена!");
            Console.Write("Введіть ширину прямокутного трикутника: ");
            while (!int.TryParse(Console.ReadLine(), out rectangularHeight))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            Console.Write("Введіть символ прямокутного трикутника: ");
            while (!char.TryParse(Console.ReadLine(), out rectangularSymbol))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }

            char[,] triangle = new char[rectangularHeight, rectangularHeight];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }
            
            for (int i = rectangularHeight - 1; i >= 0; i--)
            {
                for (int j = 0; j < rectangularHeight; j++)
                {
                    triangle[i, j] = rectangularSymbol;
                }
                rectangularHeight--;
            }
            
            
        }
    }
}