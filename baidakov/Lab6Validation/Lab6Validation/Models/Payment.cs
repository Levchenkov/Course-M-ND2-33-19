using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Lab6Validation.Validation;

namespace Lab6Validation.Models
{
    [Validator(typeof(PaymentValidator))]
    public class Payment 
    {
        public int Id { get; set; }
        //[Required]
        public string FirstName { get; set; } //обязательное
        //[Required]
        public string MiddleName { get; set; } //обязательное
        //[Required]
        public string LastName { get; set; } //обязательное
        //[Required]
        //[RegularExpression(@"[\w',-\\/.\s]+", ErrorMessage = "Invalid Address")]
        public string Address { get; set; } //обязательное, разрешены буквы, цифры, пробелы, знаки препинания, дефисы и все прочее, что используется в адресах
        //[Required]
        //[RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid City")]
        public string City { get; set; } //обязательное, разрешены только буквы, пробелы, дефисы
        //[Required]
        //[RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Country")]
        public string Country { get; set; } //обязательное, разрешены только буквы, пробелы, дефисы
        //[Required]
        //[RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Invalid PostCode")]
        public string PostCode { get; set; } //обязательное, 5 цифр
        //[Required]
        //[EmailAddress]
        public string Email { get; set; } //обязательное, электронный ящик
        //[Required]
        //[Range(0.01, 99999.99)]
        public double Amount { get; set; } //сумма платежа, обязательное, от 0.01 и до 99999.99
        //[MaxLength(250, ErrorMessage = "Invalid Description, 250 char max")]
        public string Description { get; set; }// описание платежа, опционально, не длиннее 250 символов
        //[CreditCard]
        public string CreditCardNumber { get; set; }//16 цифр, удовлетворяет формуле: https://en.wikipedia.org/wiki/Luhn_algorithm. Кастомная серверная + клиентская валидации
        //[Range(1, 12)]
        public int ExpirationMonth { get; set; } // месяц, от 1 и до 12, больше текущей даты
        
        public int ExpirationYear { get; set; } // год, больше текущей даты
        //[Range(100, 999)]
        public string SecurityCode { get; set; } // CVV, 3 цифры
    }
}