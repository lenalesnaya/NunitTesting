using Bogus;
using SharelaneAutomation.Configurations;

namespace SharelaneAutomation.Models.Utilities
{
    public static class UserBuilder
    {
        static readonly Faker faker = new();

        public static User StandartUser => new()
        {
            FirstName = SharelaneConfigurationManager.User.FirstName,
            LastName = SharelaneConfigurationManager.User.LastName,
            Email = SharelaneConfigurationManager.User.Email,
            Password = SharelaneConfigurationManager.User.Password,
            ZipCode = SharelaneConfigurationManager.User.ZipCode
        };

        public static User GetRandomUser() => new()
        {
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Internet.Email(provider: "AT_TMSQAC01_TEST.automation"),
            Password = faker.Internet.Password(10),
            ZipCode = faker.Random.String(5, '0', '9')
        };

        public static User CreateUser(
            string firstName,
            string lastName,
            string email,
            string password,
            string? zipCode = null)
        {
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                ZipCode = zipCode
            };
        }
    }
}