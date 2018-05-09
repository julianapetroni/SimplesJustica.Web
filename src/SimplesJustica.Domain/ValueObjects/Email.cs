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
            set => _stringValue = value;
        }

        public Email(string email)
        {
            StringValue = email;
        }

        public override bool EhValido()
        {
            return Regex.IsMatch(_stringValue, @"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i");
        }
    }
}
