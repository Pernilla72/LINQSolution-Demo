

namespace LINQDemo
{
    internal class Program
    {   // KLassen Enumerable innehåler samtliga LINQ metoder så som tex. metoden WHERE
        //public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool>precicate)
        static void Main(string[] args)
        {
            int[] ints = [72, 23, 4, 55, 88, 69];  //IEnumerable-compatible type

            var q = ints
                .Where (y => y < 60);

            foreach (int item in q)
            {
                Console.WriteLine(item);
            }

            //List av double
            List<double> doubles = [3.14, 3.55, 4.77, 88.2, 69.96]; //IEnumerable-compatible type
            var b = doubles
                .Where (d => d == 3.14 || d < 5);

            foreach (double item in b)
            {
                Console.WriteLine(item);
            }

            //List av patient
            List<Patient> patients = new List<Patient>()
            {
                new Patient() {FirstName = "Pernilla", LastName = "Karlsson", City = "Lidköping", YearOfBirth = 1972, HeightInCm = 171, WeightInKg = 88.2},
                new Patient() {FirstName = "Anna", LastName = "Fröjd", City = "Göteborg", YearOfBirth = 1982, HeightInCm = 166.7, WeightInKg = 65},
                new Patient() {FirstName = "Kalle", LastName = "Olsson", City = "Lidköping", YearOfBirth = 1948, HeightInCm = 159, WeightInKg = 68.9},
                new Patient() {FirstName = "Olle", LastName = "Jönsson", City = "Malmö", YearOfBirth = 1998, HeightInCm = 179.2, WeightInKg = 94},
                new Patient() {FirstName = "Per", LastName = "Persson", City = "Göteborg", YearOfBirth = 1966, HeightInCm = 178, WeightInKg = 91}
            };


            var sortedPatients = patients
                .OrderBy(p => p.LastName)  //I förrsta hand
                .ThenBy(p => p.FirstName)  //i andra hand
                .ThenBy(p => p.YearOfBirth);  //I tredje hand.

            Console.WriteLine("=====================");

            foreach (var patient in sortedPatients)
            {
                Console.WriteLine(patient);
            }
            Console.WriteLine("=====================");


            Patient myPatient = patients
                .First(p => p.LastName == "Karlsson");
            Console.WriteLine("=== My Patient ===");
            Console.WriteLine(myPatient);
            Console.WriteLine("=== My Patient ===");


            //Plocka ut alla patienter vars BMI översktiger 25
            var q3 = patients
                .Where(p => p.BMI < 28);
            foreach (var pat in q3)
            {
                Console.WriteLine(patients);
            }

            //var q4 = q3
            //    .Select(p => $"{p.FirstName} {p.LastName} har ett BMI, {p.BMI} som ligger under gränsvärdet 28");

            var q6 = patients
                .Where(p => p.BMI < 28)
                .OrderByDescending(p => p.YearOfBirth)
                .Select(p => $"{p.FirstName} {p.LastName} har ett BMI, {p.BMI} som ligger under 28");

           

            foreach (var pat in q6)
            {
                Console.WriteLine(pat);
            }


            // Average är exempel på en non-defferable LINQ metod (utförs direkt)
            var averageAge = patients
                .Average(patients => DateTime.Now.Year - patients.YearOfBirth);

            var q7 = patients
                .GroupBy(p => p.City);

            foreach (var group in q7)
            {
                Console.WriteLine($"Patienter i {group.Key} ");
                foreach (var pat in group)
                {
                    Console.WriteLine($"\t{ pat}");
                }
                Console.WriteLine();
            }
        }




        static bool Filter(int intvalue)
        {
            return intvalue < 60;
        }
    }
}
