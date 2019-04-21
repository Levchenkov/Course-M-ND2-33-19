using System;
namespace Htp.Validation.Domain.Contracts.Models
{
    public class PaymentModel : LinkedResourceBase, IModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        // TODO: Add other fields

        //First Name - обязательное.
        //Middle Name - обязательное.
        //Last Name - обязательное.
        //Address - обязательное, разрешены буквы, цифры, пробелы, знаки препинания, дефисы и все прочее, что используется в адресах.
        //City - обязательное, разрешены только буквы, пробелы, дефисы.
        //Country - обязательное, разрешены только буквы, пробелы, дефисы.
        //Post Code - обязательное, 5 цифр.
        //Email - обязательное, электронный ящик.
        //Amount - сумма платежа, обязательное, от 0.01 и до 99999.99.
        //Description - описание платежа, опционально, не длиннее 250 символов.
        //Credit Card Number - 16 цифр, удовлетворяет формуле: https://en.wikipedia.org/wiki/Luhn_algorithm. Кастомная серверная + клиентская валидации.
        //Expiration Month - месяц, от 1 и до 12, больше текущей даты.
        //Expiration Year - год, больше текущей даты.
        //Security Code - CVV, 3 цифры. добавляем только create

    }
}
