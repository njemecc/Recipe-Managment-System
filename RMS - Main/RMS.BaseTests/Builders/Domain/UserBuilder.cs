using RMS.Domain.Entities;

namespace RMS.BaseTests.Builders.Domain
{
    public class UserBuilder
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;

        public UserBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public ApplicationUser Build()
        {
            return new ApplicationUser(_firstName, _lastName, _email, _password);
        }
    }
}
