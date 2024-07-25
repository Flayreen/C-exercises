namespace Array1;

internal abstract class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int useChoice;
        do
        {
            Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
            Console.WriteLine($"1. Кількість повтореннь в масиві \n2. Обернути масив \n3. Посортувати масив \n4. Double масив \n5. Вийти з програми");
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
                    break;
                case 3:
                    Console.Clear();
                    int[] array3 = [33, 101, 410, 16, 0, 50];
                    SortAndSumArray(array3);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    double[] array4 = [1, 10.5, 5.25, -2.3, -1];
                    DoubleArray(array4);
                    Console.ReadKey();
                    Console.Clear();
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

    private static void SortAndSumArray(int[] numbers)
    {
        string[] sortedArray = numbers.Select(num => num.ToString()).ToArray();
        int[] sumArray = new int[sortedArray.Length];
        
        for (int i = 0; i < sortedArray.Length - 1; i++)
        {
            for (int j = 0; j < sortedArray.Length - i - 1; j++)
            {
                int previousValue = sortedArray[j]
                    .ToCharArray()
                    .Aggregate(0, (acc, value) => acc + (value - '0'));
                int nextValue = sortedArray[j + 1]
                    .ToCharArray()
                    .Aggregate(0, (acc, value) => acc +  (value - '0'));

                string temp = sortedArray[j];

                if (previousValue > nextValue)
                {
                    sortedArray[j] = sortedArray[j + 1];
                    sortedArray[j + 1] = temp;
                    sumArray[j] = nextValue;
                    sumArray[j + 1] = previousValue;
                }
                else
                {
                    sumArray[j] = previousValue;
                    sumArray[j + 1] = nextValue;
                }   
            }
        }
        
        Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
        Console.WriteLine("Sum array: " + string.Join(", ", sumArray));
    }

    private static void DoubleArray(double[] numbers)
    {
        double[] newArray = (double[])numbers.Clone();
        
        double sum = newArray
            .Where(n => n < 0)
            .Aggregate(0.0, (acc, value) => acc + value);
        
        double multi = newArray
            .Where((n, index) => index % 2 == 0)
            .Aggregate(1.0, (acc, value) => acc * value);

        double[] positiveArray = newArray.Where(n => n > 0.0).ToArray();

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Multi: " + multi);
        Console.WriteLine("Positive array : " + string.Join(", ", positiveArray));
    }
}