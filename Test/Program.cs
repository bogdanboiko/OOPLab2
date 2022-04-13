using OOPLab2;
using System.Text.Json;

namespace OOPLab2
{
    class Program
    {
        static string[] countries = new string[] { "Australia", "Brazil", "USA", "Ukraine", "China", "Germany", "France", "Kongo" };
        static string[] animal = new string[] { "Bear", "Tiger", "Racoon", "Frog", "Spider", "Falcon", "Deer", "Hippo", "Giraffe", "Alligator" };
        static string[] name = new string[] { "Santa", "Nik", "Zozo", "Kim", "Sam", "Nik", "Jeff", "Jack" };


        public static void Main(string[] args)
        {
            Controller controller = new Controller();
            Random random = new Random();
         
            List<Accomodation> list = new List<Accomodation>();
            for (int i = 0; i < 5; i++)
            {
                List<AnimalAccount> animals = new List<AnimalAccount>();
                int animalQuantity = random.Next(1, 7);

                for (int a = 0; a < animalQuantity; a++)
                {
                    int countryIndex = random.Next(0, countries.Length);
                    int animalIndex = random.Next(0, animal.Length);
                    int nameIndex = random.Next(0, name.Length);
                    int year = random.Next(2000, DateTime.Now.Year - 2);
                    int month = random.Next(1, 12);
                    int day = random.Next(1, 28);
                    int yearArrival = random.Next(year, DateTime.Now.Year);
                    int monthArrival = random.Next(1, 12);
                    int dayArrival = random.Next(1, 28);
                    animals.Add(new AnimalAccount(random.Next(1000, 200000), new Animal(animal[animalIndex], countries[countryIndex], name[nameIndex], new DateTime(year, month, day)), new DateTime(yearArrival, monthArrival, dayArrival)));
                }
                AccomodationType type = AccomodationType.Aquarium;

                switch (random.Next(1, 5))
                {
                    case 1: type = AccomodationType.Aquarium; break;
                    case 2: type = AccomodationType.Aviary; break;
                    case 3: type = AccomodationType.Terrarium; break;
                    case 4: type = AccomodationType.Cage; break;
                }
                list.Add(new Accomodation(type, i, random.Next(20, 2000), random.Next(1000, 200000), animals));
            }

            controller.Serialize(list);

            controller.Deserialize().ForEach(item => { Console.WriteLine(item.ToShortString()); });
        }

        
    }
}