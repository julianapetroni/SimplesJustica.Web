﻿using System;

namespace SimplesJustica.Application.Models
{
    public class ReclamacaoModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        public Guid AutorId { get; set; }
        public virtual AutorModel Audor { get; set; }

        public Guid? EmpresaId { get; set; }
        public virtual EmpresaModel Reu { get; set; }

        public Guid? AcusadoId { get; set; }
        public virtual AcusadoModel Acusado { get; set; }

        public Guid? ConciliadorId { get; set; }
        public virtual ConciliadorModel Conciliador { get; set; }
    }
}