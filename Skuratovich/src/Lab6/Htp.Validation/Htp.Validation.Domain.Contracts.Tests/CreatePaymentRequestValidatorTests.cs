using FluentValidation.TestHelper;
using Htp.Validation.Domain.Contracts.Comands;
using Htp.Validation.Domain.Contracts.Validators;
using NUnit.Framework;

namespace Tests
{
    public class CreatePaymentRequestValidatorTests
    {
        // https://fluentvalidation.net/testing
        private CreatePaymentRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new CreatePaymentRequestValidator();
        }

        [Test]
        public void Should_have_error_when_FirstName_is_null()
        {
            // Arrange
            var payment = new CreatePaymentRequest { FirstName = "", CreditCardNumber = "5555555555554444" };

            // Act
            validator.ShouldHaveValidationErrorFor(x => x.FirstName, string.Empty);

            // Assert
        }
    }
}