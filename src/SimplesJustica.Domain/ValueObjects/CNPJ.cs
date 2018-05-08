using SimplesJustica.Domain.ValueObjects.Base;

namespace SimplesJustica.Domain.ValueObjects
{
    public class CNPJ : ValueObject
    {
        private string _cnpj;

        public string Cnpj
        {
            get => _cnpj;
            set => _cnpj = value;
        }

        public CNPJ(string doc)
        {
            _cnpj = doc;
        }

        public override bool EhValido()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            _cnpj = _cnpj.Trim();
            _cnpj = _cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (_cnpj.Length != 14)
            {
                return false;
            }

            var tempCnpj = _cnpj.Substring(0, 12);
            var soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }

            var resto = (soma % 11);
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }

            resto = (soma % 11);
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto;
            return _cnpj.EndsWith(digito);
        }
    }
}
