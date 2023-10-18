using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Tests
{
    public class FunctionalityTest
    {
        [Fact(DisplayName = "Create Valid Functionality")]
        public void CreateFunctionality_WithValidData_ShouldSucceed()
        {
            string name = "FunctionalityName";
            string description = "Functionality Description";

            var functionality = new Functionality(name, description);

            Assert.Equal(name, functionality.Name);
            Assert.Equal(description, functionality.Description);
        }

        [Fact(DisplayName = "Create Functionality With Invalid Name Should Throw Exception")]
        public void CreateFunctionality_WithInvalidName_ShouldThrowException()
        {
            string name = "Fn";
            string description = "Functionality Description";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var functionality = new Functionality(name, description);
            });
        }

        [Fact(DisplayName = "Create Functionality With Invalid Description Should Throw Exception")]
        public void CreateFunctionality_WithInvalidDescription_ShouldThrowException()
        {
            string name = "FunctionalityName";
            string description = "Desc";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var functionality = new Functionality(name, description);
            });
        }

        [Fact(DisplayName = "Create Functionality With Empty Name Should Throw Exception")]
        public void CreateFunctionalityWithEmptyName_ShouldThrowException()
        {
            string name = "";
            string description = "Functionality Description";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var functionality = new Functionality(name, description);
            });
        }

        [Fact(DisplayName = "Create Functionality With Empty Description Should Throw Exception")]
        public void CreateFunctionalityWithEmptyDescription_ShouldThrowException()
        {
            string name = "FunctionalityName";
            string description = "";

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var functionality = new Functionality(name, description);
            });
        }
    }
}
