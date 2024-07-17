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
                Console.WriteLine($"1. Намалюйте прямокутний трикутник \n2. Намалюйте рівнобедрений трикутник \n3. Намалюйте трикутник, який прилягає до лівої сторони \n4. Послідовність Фібоначчі \n5. Послідовність Лукаса \n6. Вихід з програми");
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
                    case 2:
                        Console.Clear();
                        DrawIsoscelesTriangle();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        DrawLeftTriangle();
                        Console.ReadKey();
                        Console.Clear();
                        break;
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
            Console.WriteLine("Програма №2 запущена!");
            Console.Write("Введіть висоту рівностороннього трикутника: ");
            while (!int.TryParse(Console.ReadLine(), out rectangularHeight))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            Console.Write("Введіть символ прямокутного трикутника: ");
            while (!char.TryParse(Console.ReadLine(), out rectangularSymbol))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }

            int rectangularWidth = ((rectangularHeight - 1) * 2) + 1;
            char[,] triangle = new char[rectangularHeight, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }

            int start = 0;
            for (int i = rectangularHeight - 1; i >= 0; i--)
            {
                for (int j = start; j < rectangularWidth; j++)
                {
                    triangle[i, j] = rectangularSymbol;
                }
                rectangularHeight--;
                rectangularWidth --;
                start++;
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
        
        private static void DrawLeftTriangle()
        {
            int rectangularWidth;
            char rectangularSymbol;
            Console.WriteLine("Програма №3 запущена!");
            Console.Write("Введіть довжину трикутника: ");
            while (!int.TryParse(Console.ReadLine(), out rectangularWidth))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            Console.Write("Введіть символ трикутника: ");
            while (!char.TryParse(Console.ReadLine(), out rectangularSymbol))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            
            int rectangularHeight = ((rectangularWidth - 1) * 2) + 1;
            char[,] triangle = new char[rectangularHeight, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }

            int start = 0;
            for (int i = rectangularHeight / 2; i >= 0; i--)
            {
                for (int j = 0; j < rectangularWidth; j++)
                {
                    triangle[i, j] = rectangularSymbol;
                    triangle[i + start, j] = rectangularSymbol;
                }
                rectangularHeight--;
                rectangularWidth --;
                start += 2;
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
    }
}