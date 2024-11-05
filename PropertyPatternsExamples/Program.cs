using System;

namespace PropertyPatternsExamples
{
    // Kullanıcı bilgilerini tutan bir sınıf
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Farklı kullanıcı örnekleri oluşturma
            var user1 = new User { Name = "Alice", Age = 25, Country = "USA" };
            var user2 = new User { Name = "Bob", Age = 17, Country = "Canada" };
            var user3 = new User { Name = "Charlie", Age = 30, Country = "UK" };
            var user4 = new User { Name = "David", Age = 40, Country = "Australia" };

            // Kullanıcı özelliklerine göre mesaj oluşturma
            Console.WriteLine(GetUserGreeting(user1));
            Console.WriteLine(GetUserGreeting(user2));
            Console.WriteLine(GetUserGreeting(user3));
            Console.WriteLine(GetUserGreeting(user4));
        }

        // Property patterns kullanarak kullanıcıya özel mesaj döndüren metot
        static string GetUserGreeting(User user) => user switch
        {
            { Country: "USA", Age: >= 18 } => $"Hello {user.Name} from the USA! You are an adult.",
            { Country: "USA", Age: < 18 } => $"Hello {user.Name} from the USA! You are a minor.",
            { Country: "Canada" } => $"Hello {user.Name} from Canada! Welcome!",
            { Age: > 30 } => $"Hello {user.Name}! It's great to meet someone with experience.",
            _ => $"Hello {user.Name} from {user.Country}!"
        };

        // Farklı bir örnek: Nesne özelliklerine göre işlem yapan property pattern
        static void ProcessUser(User user)
        {
            Console.WriteLine(user switch
            {
                { Age: >= 18, Country: "Australia" } => $"{user.Name} is an adult from Australia.",
                { Age: < 18 } => $"{user.Name} is underage.",
                { Country: "UK" } => $"{user.Name} is from the UK.",
                _ => $"{user.Name} is from a country outside our specific pattern checks."
            });
        }
    }
}
