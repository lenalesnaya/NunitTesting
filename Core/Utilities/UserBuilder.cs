using Bogus;
using Core.Models;
using Core.Configurations;

namespace Core.Utilities
{
    public static class UserBuilder
    {
        static readonly Faker faker = new();

        public static User StandartUser => new()
        {
                FirstName = ConfigurationManager.User.FirstName,
                LastName = ConfigurationManager.User.LastName,
                Email = ConfigurationManager.User.Email,
                Password = ConfigurationManager.User.Password,
                ZipCode = ConfigurationManager.User.ZipCode
        };

        public static User GetRandomUser() => new()
        {
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Internet.Email(provider: "AT_TMSQAC01_TEST.automation"),
            Password = faker.Internet.Password(10),
            ZipCode = Convert.ToString(faker.Random.Digits(5, 0, 9))
        };

        public static User CreateUser(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
        }
    }
}