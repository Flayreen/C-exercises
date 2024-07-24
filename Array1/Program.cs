namespace Array1;

internal abstract class Program
{
    private void Main()
    {
        int useChoice;
        do
        {
            Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
            Console.WriteLine($"1. Кількість повтореннь в масиві \n5. Вийти з програми");
            Console.Write("Ваш вибір: ");
            useChoice = Convert.ToInt32(Console.ReadLine());

            switch (useChoice)
            {
                case 1:
                    Console.Clear();
                    int number = 5;
                    int[] array = [5, 5, 6, 7, 5, 3];
                    CountNumberInArray(array, number);
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

    private void CountNumberInArray(int[] array, int desiredNumber)
    {
        int count = array.Count(number => number == desiredNumber);
        Console.WriteLine(count);
    }
}