﻿using System;

namespace SimplesJustica.Domain.ValueObjects
{
    public class Genero
    {
        public enum GeneroType
        {
            Masculino,
            Feminino,
            Indefinido
        }

        protected Genero()
        {
            //Requisito do EF
        }

        public Genero(GeneroType genero)
        {
            _genero = genero;
        }

        private GeneroType _genero;
        public string StringValue
        {
            get
            {
                switch (_genero)
                {
                    case GeneroType.Feminino:
                        return "Feminino";
                        break;
                    case GeneroType.Masculino:
                        return "Masculino";
                        break;
                    case GeneroType.Indefinido:
                        return "Indefinido";
                        break;
                    default: return "";
                }
            }
            set
            {
                _genero = value.ParseEnum<GeneroType>();
            }
        }

        public GeneroType TypeValue => _genero;
    }
}
