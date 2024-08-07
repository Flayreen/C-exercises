﻿namespace Pseudographics
{
    internal abstract class Program
    {
        private static void Main()
        {
            int useChoice;
            do
            {
                Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
                Console.WriteLine($"1. Намалюйте прямокутний трикутник \n2. Намалюйте рівнобедрений трикутник \n3. Намалюйте трикутник, який прилягає до лівої сторони \n4. Намалюйте трикутник, який прилягає до правої сторони \n5. Намалюйте пісковий годинник \n6. Вийти з програми");
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
                    case 4:
                        Console.Clear();
                        DrawRightTriangle();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        DrawVerticalSandClock();
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

        private static void DrawRectangular()
        {
            // Отримання даних про трикутник від користувача
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
            
            // Створення розмірів трикутника
            char[,] triangle = new char[rectangularWidth, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }
            
            // Заповнення трикутника символами
            for (int i = rectangularWidth - 1; i >= 0; i--)
            {
                for (int j = 0; j < rectangularWidth; j++)
                {
                    triangle[i, j] = rectangularSymbol;
                }
                rectangularWidth--;
            }
            
            // Виведення трикутника в консоль
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
            // Отримання даних про трикутник від користувача
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
            
            // Створення розмірів трикутника
            int rectangularWidth = ((rectangularHeight - 1) * 2) + 1;
            char[,] triangle = new char[rectangularHeight, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }
            
            // Заповнення трикутника символами
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
            
            // Виведення трикутника в консоль
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
            // Отримання даних про трикутник від користувача
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
            
            // Створення розмірів трикутника
            int rectangularHeight = ((rectangularWidth - 1) * 2) + 1;
            char[,] triangle = new char[rectangularHeight, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }
            
            // Заповнення трикутника символами
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
            
            // Виведення трикутника в консоль
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    Console.Write(triangle[i, j]);
                }

                Console.WriteLine();
            }

        }
        
        private static void DrawRightTriangle()
        {
            // Отримання даних про трикутник від користувача
            int rectangularWidth;
            char rectangularSymbol;
            Console.WriteLine("Програма №4 запущена!");
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
            
            // Створення розмірів трикутника
            int rectangularHeight = ((rectangularWidth - 1) * 2) + 1;
            char[,] triangle = new char[rectangularHeight, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }
            
            // Заповнення трикутника символами
            int start = 0;
            int right = rectangularWidth - 1;
            for (int i = rectangularHeight / 2; i >= 0; i--)
            {
                for (int j = right; j > right - rectangularWidth; j--)
                {
                    triangle[i, j] = rectangularSymbol;
                    triangle[i + start, j] = rectangularSymbol;
                }
                rectangularHeight--;
                rectangularWidth --;
                start += 2;
            }
            
            // Виведення трикутника в консоль
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    Console.Write(triangle[i, j]);
                }

                Console.WriteLine();
            }

        }
        
        private static void DrawVerticalSandClock()
        {
            // Отримання даних про годинника від користувача
            int rectangularHeight;
            char rectangularSymbol;
            Console.WriteLine("Програма №5 запущена!");
            Console.Write("Введіть висоту однієї частини пісочного годинника: ");
            while (!int.TryParse(Console.ReadLine(), out rectangularHeight))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            Console.Write("Введіть символ пісочного годинника: ");
            while (!char.TryParse(Console.ReadLine(), out rectangularSymbol))
            {
                Console.Write("Будь ласка, введіть коректне значення! ");
            }
            
            // Створення розмірів годинника
            int totalRectangleHeight = rectangularHeight * 2;
            int rectangularWidth = ((rectangularHeight - 1) * 2) + 1;
            char[,] triangle = new char[totalRectangleHeight, rectangularWidth];
            
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 0; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = ' ';
                }
            }
            
            
            // Заповнення годинника символами
            int start = 0;
            int upperWay = 0;
            for (int i = totalRectangleHeight - 1; i >= 0; i--)
            {
                for (int j = start; j < rectangularWidth; j++)
                {
                    triangle[i, j] = rectangularSymbol;
                    triangle[upperWay, j] = rectangularSymbol;
                }

                upperWay++;
                start++; 
                rectangularWidth--;
                totalRectangleHeight--;
            }
            
            // Виведення годинника в консоль
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