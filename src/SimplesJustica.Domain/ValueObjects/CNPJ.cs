using System;
using System.Reflection.Emit;
using SimplesJustica.Domain.ValueObjects.Base;

namespace SimplesJustica.Domain.ValueObjects
{
    public class CNPJ : ValueObject
    {
        private string _stringValue;

        public string StringValue
        {
            get => TratarFormatoSaida(_stringValue);
            set => _stringValue = TratarFormatoEntrada(value);
        }

        public CNPJ(string cnpj)
        {
            _stringValue = TratarFormatoEntrada(cnpj);
        }

        public override bool EhValido()
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (_stringValue.Length != 14)
            {
                return false;
            }

            string testeRepeticao = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    testeRepeticao += i.ToString();
                }

                if (_stringValue == testeRepeticao)
                    return false;

                testeRepeticao = "";
            }

            var tempCnpj = _stringValue.Substring(0, 12);
            var soma = 0;
            for (int i = 0; i < 12; i++)
            {
                try
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                }
                catch
                {
                    return false;
                }
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
                try
                {
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                }
                catch
                {
                    return false;
                }
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
            return _stringValue.EndsWith(digito);
        }

        private string TratarFormatoEntrada(string value)
        {
            return value.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        }

        private static string TratarFormatoSaida(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public override string ToString()
        {
            return StringValue;
        }
    }
}
