using System.Threading.Channels;

namespace Arithmetic
{
    internal abstract class Program
    {
        private static void Main()
        {
            Console.WriteLine(GetPriceForTaxi(DayOfWeek.Thursday, 0720, 27));
        }
        
        private struct Tariffs
        {
            public DayOfWeek[] Day { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public int Rate { get; set; }
        }
        
        private static string ConvertSecondsToMinutes(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes} minutes {time.Seconds} seconds";
        }
        
        private static string ConvertDaysToMonth(int days)
        {
            int months = days / 30;
            int weeks = (days % 30) / 7;
            int day = days - (months * 30) - (weeks * 7);
            return $"{months} month {weeks} week {day} days";
        }

        private static string GetLocation(int x, int y)
        {
            if (x == 0)
            {
                return "точка лежить на осі x";
            }

            if (y == 0)
            {
                return "точка лежить на осі y";
            }

            return (x, y) switch
            {
                (> 0, > 0) => "1 квадрант",
                (< 0, > 0) => "2 квадрант",
                (< 0, < 0) => "3 квадрант",
                (> 0, < 0) => "4 квадрант",
                _ => "Невизначене розташування"
            };
        }

        private static void CalculateInvestments(int investments, int yearsDuration)
        {
            int totalPercents = (yearsDuration / 5) * 10 ;
            double investmentResult = investments * (1 + totalPercents / 100.0);

            Console.WriteLine($"Сума інвестиції {investments} євро");
            Console.WriteLine($"Через скільки років гроші було знято - {yearsDuration} років");
            Console.WriteLine($"Нараховано відсотків: {totalPercents}%");
            Console.WriteLine($"Прибуток: {investmentResult - investments} євро");
        }

        private static int GetPriceForTaxi(DayOfWeek dayOfWeek, int startTime, int distance)
        {
            List<Tariffs> tariffs = new List<Tariffs>()
            {
                new Tariffs()
                {
                    Day = [DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday], 
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    Rate = 4
                },
                new Tariffs()
                {
                    Day = [DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday], 
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(7, 0, 0),
                    Rate = 6
                },
                new Tariffs()
                {
                    Day = [DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday], 
                    StartTime = new TimeSpan(0, 0, 0),
                    EndTime = new TimeSpan(24, 0, 0),
                    Rate = 8
                },
            };

            TimeSpan convertTimeSpan = new TimeSpan(startTime / 100, startTime % 100, 0);
            var tariff = tariffs.FirstOrDefault(t =>
                t.Day.Contains(dayOfWeek) &&
                (
                    (t.StartTime <= t.EndTime && convertTimeSpan >= t.StartTime && convertTimeSpan < t.EndTime) ||
                    (t.StartTime > t.EndTime && (convertTimeSpan >= t.StartTime || convertTimeSpan < t.EndTime))
                )
            );
            
            return tariff.Rate * distance;
        }
    }
}