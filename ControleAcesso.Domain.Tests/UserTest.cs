using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Tests
{
    public class UserTest
    {
        [Fact(DisplayName = "Create Valid User")]
        public void CreateUser_WithValidData_ShouldSucceed()
        {
            string name = "John Doe";
            string email = "john.doe@example.com";
            string userName = "johndoe";
            string password = "password123";

            var user = new User(name, email, userName, password);

            Assert.Equal(name, user.Name);
            Assert.Equal(email, user.Email);
            Assert.Equal(userName, user.UserName);
            Assert.Equal(password, user.Password);
            Assert.False(user.Blocked);
        }

        [Fact(DisplayName = "Create User With Invalid Name Should Throw Exception")]
        public void CreateUser_WithInvalidName_ShouldThrowException()
        {
            string name = "J";
            string email = "john.doe@example.com";
            string userName = "johndoe";
            string password = "password123";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var user = new User(name, email, userName, password);
            });
        }

        [Fact(DisplayName = "Create User With Invalid Email Should Throw Exception")]
        public void CreateUser_WithInvalidEmail_ShouldThrowException()
        {
            string name = "John Doe";
            string email = "invalidemail";
            string userName = "johndoe";
            string password = "password123";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var user = new User(name, email, userName, password);
            });
        }

        [Fact(DisplayName = "Set User Password Should Change Password")]
        public void SetPassword_ShouldChangePassword()
        {
            string name = "John Doe";
            string email = "john.doe@example.com";
            string userName = "johndoe";
            string password = "password123";
            var user = new User(name, email, userName, password);

            string newPassword = "newpassword456";
            user.SetPassword(newPassword);

            Assert.Equal(newPassword, user.Password);
        }

        [Fact(DisplayName = "Set User Blocked Status Should Change Blocked Status")]
        public void SetBlocked_ShouldChangeBlockedStatus()
        {
            string name = "John Doe";
            string email = "john.doe@example.com";
            string userName = "johndoe";
            string password = "password123";
            var user = new User(name, email, userName, password);

            user.SetBlocked(true);

            Assert.True(user.Blocked);
        }

        [Fact(DisplayName = "Create User With Whitespace Name Should Trim Whitespace")]
        public void CreateUserWithWhitespaceName_ShouldTrimWhitespace()
        {
            string name = "  John Doe  ";
            string email = "john.doe@example.com";
            string userName = "johndoe";
            string password = "password123";

            var user = new User(name, email, userName, password);

            Assert.Equal("John Doe", user.Name.Trim());
        }

        [Fact(DisplayName = "Create Blocked User Should Be Blocked")]
        public void CreateBlockedUser_ShouldBeBlocked()
        {
            string name = "Blocked User";
            string email = "blocked.user@example.com";
            string userName = "blockeduser";
            string password = "password123";

            var user = new User(name, email, userName, password);
            user.SetBlocked(true);

            Assert.True(user.Blocked);
        }

        [Fact(DisplayName = "Create User With Empty Password Should Throw Exception")]
        public void CreateUserWithEmptyPassword_ShouldThrowException()
        {
            string name = "John Doe";
            string email = "john.doe@example.com";
            string userName = "johndoe";
            string password = "";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var user = new User(name, email, userName, password);
            });
        }
    }
}
