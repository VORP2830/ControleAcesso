using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Tests
{
    public class ProfileTest
    {
        [Fact(DisplayName = "Create Valid Profile")]
        public void CreateProfile_WithValidData_ShouldSucceed()
        {
            string name = "Admin";
            string description = "Administrator profile";

            var profile = new Profile(name, description);

            Assert.Equal(name, profile.Name);
            Assert.Equal(description, profile.Description);
        }

        [Fact(DisplayName = "Create Profile With Invalid Name Should Throw Exception")]
        public void CreateProfile_WithInvalidName_ShouldThrowException()
        {
            string name = "A";
            string description = "Administrator profile";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var profile = new Profile(name, description);
            });
        }

        [Fact(DisplayName = "Create Profile With Invalid Description Should Throw Exception")]
        public void CreateProfile_WithInvalidDescription_ShouldThrowException()
        {
            string name = "Admin";
            string description = "Desc";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var profile = new Profile(name, description);
            });
        }

        [Fact(DisplayName = "Create Profile With Empty Name Should Throw Exception")]
        public void CreateProfileWithEmptyName_ShouldThrowException()
        {
            string name = "";
            string description = "Administrator profile";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var profile = new Profile(name, description);
            });
        }

        [Fact(DisplayName = "Create Profile With Empty Description Should Throw Exception")]
        public void CreateProfileWithEmptyDescription_ShouldThrowException()
        {
            string name = "Admin";
            string description = "";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var profile = new Profile(name, description);
            });
        }
    }
}
