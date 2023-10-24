using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Tests
{
    public class MenuOptionTest
    {
        [Fact(DisplayName = "Create Valid MenuOption")]
        public void CreateMenuOption_WithValidData_ShouldSucceed()
        {
            string name = "Home";
            string url = "/home";
            int position = 1;
            long? menuDadId = null; 
            long functionalityId = 1; 

            var menuOption = new MenuOption(name, url, position, menuDadId, functionalityId);

            Assert.Equal(name, menuOption.Name);
            Assert.Equal(url, menuOption.URL);
            Assert.Equal(position, menuOption.Position);
            Assert.Equal(menuDadId, menuOption.MenuDadId);
            Assert.Equal(functionalityId, menuOption.FunctionalityId);
        }

        [Fact(DisplayName = "Create MenuOption With Invalid Name Should Throw Exception")]
        public void CreateMenuOption_WithInvalidName_ShouldThrowException()
        {
            string name = "H";
            string url = "/home";
            int position = 1;
            long? menuDad = null;
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var menuOption = new MenuOption(name, url, position, menuDad, functionalityId);
            });
        }

        [Fact(DisplayName = "Create MenuOption With Invalid URL Should Throw Exception")]
        public void CreateMenuOption_WithInvalidURL_ShouldThrowException()
        {
            string name = "Home";
            string url = "/";
            int position = 1;
            long? menuDad = null;
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var menuOption = new MenuOption(name, url, position, menuDad, functionalityId);
            });
        }

        [Fact(DisplayName = "Create MenuOption With Empty Name Should Throw Exception")]
        public void CreateMenuOptionWithEmptyName_ShouldThrowException()
        {
            string name = "";
            string url = "/home";
            int position = 1;
            long? menuDad = null;
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var menuOption = new MenuOption(name, url, position, menuDad, functionalityId);
            });
        }

        [Fact(DisplayName = "Create MenuOption With Empty URL Should Throw Exception")]
        public void CreateMenuOptionWithEmptyURL_ShouldThrowException()
        {
            string name = "Home";
            string url = "";
            int position = 1;
            long? menuDad = null;
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var menuOption = new MenuOption(name, url, position, menuDad, functionalityId);
            });
        }

        [Fact(DisplayName = "Create MenuOption With Invalid Position Throw Exception")]
        public void CreateMenuOptionWithInvalidPosition_ShouldThrowException()
        {
            string name = "Home";
            string url = "";
            int position = 0;
            long? menuDad = null;
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var menuOption = new MenuOption(name, url, position, menuDad, functionalityId);
            });
        }

        [Fact(DisplayName = "Create MenuOption With Invalid Funcionality Id Throw Exception")]
        public void CreateMenuOptionWithInvalidFuncionalityId_ShouldThrowException()
        {
            string name = "Home";
            string url = "";
            int position = 1;
            long? menuDad = null;
            long functionalityId = 0;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var menuOption = new MenuOption(name, url, position, menuDad, functionalityId);
            });
        }
    }
}
