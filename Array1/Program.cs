namespace Array1;

internal abstract class Program
{
    private static void Main()
    {
        int useChoice;
        do
        {
            Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
            Console.WriteLine($"1. Кількість повтореннь в масиві \n2. Обернути масив \n5. Вийти з програми");
            Console.Write("Ваш вибір: ");
            useChoice = Convert.ToInt32(Console.ReadLine());

            switch (useChoice)
            {
                case 1:
                    Console.Clear();
                    int number = 5;
                    int[] array1 = [5, 5, 6, 7, 5, 3];
                    CountNumberInArray(array1, number);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    int[] array2 = [1, 2, 3, 4, 5, 6];
                    ReverseArray(array2);
                    Console.ReadKey();
                    Console.Clear();
                    foreach (var num in array2)
                    {
                        Console.WriteLine(num);
                    }
                    break;
                case 5:
                    Console.WriteLine("Пока!");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Невірне значення");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        } while (useChoice != 5);
    }

    private static void CountNumberInArray(int[] array, int desiredNumber)
    {
        int count = array.Count(number => number == desiredNumber);
        Console.WriteLine(count);
    }

    private static void ReverseArray(int[] array)
    {
        int[] cloneArray = (int[])array.Clone();
        for (int i = 0; i < cloneArray.Length/2; i++)
        {
            int temp = cloneArray[i];
            cloneArray[i] = cloneArray[cloneArray.Length - 1 - i];
            cloneArray[cloneArray.Length - 1 - i] = temp;
        }

        Console.WriteLine(string.Join(", ", cloneArray));
    }
}