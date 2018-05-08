using SimplesJustica.Domain.ValueObjects.Base;

namespace SimplesJustica.Domain.ValueObjects
{
    public class CPF : ValueObject
    {
        private string _cpf;

        public string Cpf
        {
            get => _cpf;
            set => _cpf = value;
        }

        public CPF(string doc)
        {
            _cpf = doc;
        }

        public override bool EhValido()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            _cpf = _cpf.Trim();
            _cpf = _cpf.Replace(".", "").Replace("-", "");

            if (_cpf.Length != 11)
            {
                return false;
            }

            var tempCpf = _cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            var resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto;
            return _cpf.EndsWith(digito);
        }
    }
}
