using ControleAcesso.Domain.Entities;
using ControleAcesso.Domain.Validation;

namespace ControleAcesso.Domain.Tests
{
    public class MethodsTest
    {
        [Fact(DisplayName = "Create Valid Method")]
        public void CreateMethod_WithValidData_ShouldSucceed()
        {
            string description = "Method Description";
            string className = "ClassName";
            string methodName = "MethodName";
            long functionalityId = 1;

            var method = new Methods(description, className, methodName, functionalityId);

            Assert.Equal(description, method.Description);
            Assert.Equal(className, method.Class);
            Assert.Equal(methodName, method.Method);
            Assert.Equal(functionalityId, method.FunctionalityId);
        }

        [Fact(DisplayName = "Create Method With Invalid Description Should Throw Exception")]
        public void CreateMethod_WithInvalidDescription_ShouldThrowException()
        {
            string description = "Desc";
            string className = "ClassName";
            string methodName = "MethodName";
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Invalid Class Should Throw Exception")]
        public void CreateMethod_WithInvalidClass_ShouldThrowException()
        {
            string description = "Method Description";
            string className = "Cls";
            string methodName = "MethodName";
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Invalid Method Name Should Throw Exception")]
        public void CreateMethod_WithInvalidMethodName_ShouldThrowException()
        {
            string description = "Method Description";
            string className = "ClassName";
            string methodName = "Mthd";
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Empty Description Should Throw Exception")]
        public void CreateMethodWithEmptyDescription_ShouldThrowException()
        {
            string description = "";
            string className = "ClassName";
            string methodName = "MethodName";
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Empty Class Should Throw Exception")]
        public void CreateMethodWithEmptyClass_ShouldThrowException()
        {
            string description = "Method Description";
            string className = "";
            string methodName = "MethodName";
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Empty Method Name Should Throw Exception")]
        public void CreateMethodWithEmptyMethodName_ShouldThrowException()
        {
            string description = "Method Description";
            string className = "ClassName";
            string methodName = "";
            long functionalityId = 1;

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Empty Functionality ID Should Throw Exception")]
        public void CreateMethodWithEmptyFunctionalityId_ShouldThrowException()
        {
            string description = "Valid Method";
            string className = "TestClass";
            string methodName = "TestMethod";
            long functionalityId = 0; 

            Assert.Throws<DomainExceptionValidation>(() =>
            {
                var method = new Methods(description, className, methodName, functionalityId);
            });
        }

        [Fact(DisplayName = "Create Method With Valid Data AndCheckActive Should Be Active")]
        public void CreateMethodWithValidDataAndCheckActive_ShouldBeActive()
        {
            string description = "Valid Method";
            string className = "TestClass";
            string methodName = "TestMethod";
            long functionalityId = 1;

            var method = new Methods(description, className, methodName, functionalityId);

            Assert.True(method.Active);
        }
    }
}
