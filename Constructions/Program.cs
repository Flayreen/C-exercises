
namespace Constructions
{
    internal class Program
    {
        private static void Main()
        {
            int[] validChoices = [1, 2, 3, 4];
            int useChoice;
            do
            {
                Console.WriteLine("Вибери задачу з переліку, вибравши її номер");
                foreach (var program in _programs)
                {
                    Console.WriteLine($"{program.Key}. {program.Value}");
                }

                while ((int.TryParse(Console.ReadLine(), out useChoice)) &&
                       !Array.Exists(validChoices, element => element == useChoice))
                {
                    Console.Write("Невірний ввід. Введіть коректне число ");
                }

                switch (useChoice)
                {
                    case 1:
                        Console.Clear();
                        IsEqualNumbers();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        IsAcceptableAge();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        TransportCompany();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Пока!");
                        break;
                }
            } while (useChoice != 4);
        }

        private static Dictionary<int, string> _programs = new Dictionary<int, string>()
        {
            { 1, "Перевірка рівності чисел" },
            { 2, "Купівля напою" },
            { 3, "Транспортна компанія" },
            { 4, "Вихід з програми" }
        };
        
        private static Dictionary<string, string> _products = new Dictionary<string, string>()
        {
            { "1", "сок" },
            { "2", "пиво" },
            { "3", "горілка" },
        };

        private static void IsEqualNumbers()
        {
            float firstNumber;
            float secondNumber;

            Console.WriteLine("Програма №1 запущена!");

            Console.Write("Введіть перше число: ");
            while (!float.TryParse(Console.ReadLine(), out firstNumber))
            {
                Console.Write("Неправильний ввід. Будь ласка введіть коректне число: ");
            }

            Console.Write("Введіть друге число: ");
            while (!float.TryParse(Console.ReadLine(), out secondNumber))
            {
                Console.Write("Неправильний ввід. Будь ласка введіть коректне число: ");
            }

            if (firstNumber > secondNumber)
            {
                Console.WriteLine("Число 1 більше за число 2");
            }
            else if (firstNumber < secondNumber)
            {
                Console.WriteLine("Число 1 менше за число 2");
            }
            else
            {
                Console.WriteLine("Числа дорівнюють одне одному");
            }
        }

        private static void IsAcceptableAge()
        {
            int userAge;
            string? selectedProduct = null;

            Console.WriteLine("Програма №2 запущена!");

            Console.Write("Введіть свій вік: ");
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.Write("Неправильний ввід. Будь ласка, введіть коректний вік! ");
            }

            Console.WriteLine("Що ви хочете придбати?");
            foreach (KeyValuePair<string, string> product in _products)
            {
                Console.WriteLine($"{product.Key}. {product.Value}");
            }

            Console.Write("Введіть назву продукту або його номер ");
            do
            {
                if (!string.IsNullOrEmpty(selectedProduct))
                {
                    Console.Write("Неправильний ввід. Будь ласка, введіть коректний код або назву продукту! ");
                }

                selectedProduct = Console.ReadLine()!.Trim().ToLower();
            } while (!_products.ContainsKey(selectedProduct) && !_products.ContainsValue(selectedProduct));


            switch (selectedProduct)
            {
                case "1" or "сок":
                    Console.WriteLine("Ви успішно придбали сік");
                    break;
                case "2" or "пиво":
                    if (userAge >= 18)
                    {
                        Console.WriteLine("Ви успішно придбали пиво");
                    }
                    else
                    {
                        Console.WriteLine("Пиво заборонено для продажі до 18 років");
                    }

                    break;
                case "3" or "горілка":
                    if (userAge is >= 18 and <= 65)
                    {
                        Console.WriteLine("Ви успішно придбали водяру");
                    }
                    else if (userAge > 65)
                    {
                        Console.WriteLine("Ви успішно придбали водяру, але нерекомендовано її приймати у вашому віці");
                    }
                    else
                    {
                        Console.WriteLine("Водку заборонено для продажі до 21 року");
                    }

                    break;

            }
        }

        private static void TransportCompany()
        {
            const int buses = 20;
            const int personal = 39;
            const int pricePerDay = 350;

            int countPassengers;
            int countDays;
            Console.WriteLine("Програма №3 запущена!");

            Console.Write("Введіть кількість пасажирів: ");
            while (!int.TryParse(Console.ReadLine(), out countPassengers))
            {
                Console.Write("Неправильний ввід. Будь ласка, введіть коректну кількість пасажирів! ");
            }

            Console.Write("Введіть бажану кількість днів туру: ");
            while (!int.TryParse(Console.ReadLine(), out countDays))
            {
                Console.Write("Неправильний ввід. Будь ласка, введіть коректну кількість днів туру! ");
            }

            var countBuses = countPassengers > 40 ? Math.Ceiling(Convert.ToDouble(countPassengers) / 40) : 1;
            var fullCost = countBuses * pricePerDay * countDays;
            var countPersonal = countBuses * 2;
            bool isEnoughPersonal = personal >= countPersonal;
            bool isEnoughBuses = buses >= countBuses;

            Console.WriteLine("Користувач");
            Console.WriteLine("|");
            Console.WriteLine($"Пасажири: {countPassengers}");
            Console.WriteLine("|");
            Console.WriteLine($"Днів: {countDays}");
            Console.WriteLine("|");
            Console.WriteLine($"Ціна: {fullCost} євро");
            Console.WriteLine("");
            Console.WriteLine("Результат");
            Console.WriteLine("|");
            Console.WriteLine($"Автобуси: {countBuses}");
            Console.WriteLine("|");
            Console.WriteLine($"Персонал: {countPersonal}");

            if (!isEnoughPersonal || !isEnoughBuses)
            {
                Console.WriteLine($"Нестача: {(isEnoughBuses ? "" : (countBuses - buses) + " автобусів")} {(isEnoughPersonal ? "" : "та " + (countPersonal - personal) + " людей з персоналу")}");
            }
        }
    }
}