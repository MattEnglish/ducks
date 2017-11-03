using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck
{
    class Program
    {
        static void Main(string[] args)
        {
            var quack = new Duck("Sir Quackalot", "Mallard", 100, 17);
            var duckBio = new Dictionary<Duck, string>();
            var imposter = new Duck("Sir Quackalot", "swan",300,42);
            duckBio.Add(quack,"does not actually quack a lot.");
            Console.WriteLine(duckBio[imposter]);
            try
            {
                Console.WriteLine(duckBio[new Duck("bob", " ", 1, 1)]);
            }
            catch
            {
                Console.WriteLine("bob not in dictionary");
            }

            var ducks = new List<Duck>
            {
                quack,
                imposter,
                new Duck("Donald", "monster", 100000, 1200),
                new Duck("a", "alien", 100000, 1200),
                new Duck("b", "alien", 100000, 1200)
            };
            ducks.Sort();
            foreach (var duck in ducks)
            {
                Console.WriteLine(duck.Name);
            }
        }
    }

    public class Duck: IComparable<Duck>
    {
        public string Name { get; }
        public string Type { get; }
        public int WeightInGrams { get; }
        public int AgeInMonths { get; }

        public Duck(string name, string type, int weightInGrams, int ageInMonths)
        {
            Name = name;
            Type = type;
            WeightInGrams = weightInGrams;
            AgeInMonths = ageInMonths;
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Name == ((Duck)obj).Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public int CompareTo(Duck other)
        {
            if (other.Equals(this))
            {
                return 0;
            }
            return other.Name.CompareTo(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    
}
