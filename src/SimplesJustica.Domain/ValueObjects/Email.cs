using System.Text.RegularExpressions;
using SimplesJustica.Domain.ValueObjects.Base;

namespace SimplesJustica.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private string _stringValue;

        public string StringValue
        {
            get => _stringValue;
            set => _stringValue = TratarFormatoEntrada(value);
        }

        protected Email()
        {
            //Requisito do EntityFramework
        }

        public Email(string email)
        {
            StringValue = TratarFormatoEntrada(email);
        }

        public override bool EhValido()
        {
            return Regex.IsMatch(_stringValue, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private string TratarFormatoEntrada(string value)
        {
            return value.Trim().ToLower();
        }

        public override string ToString()
        {
            return StringValue;
        }
    }
}
