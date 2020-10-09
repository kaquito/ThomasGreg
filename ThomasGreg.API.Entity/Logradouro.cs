using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Entidade
{
   public class Logradouro
    {
        public int ID_LOGRADOURO { get; set; }
        public int ID_CLIENTE { get; set; }
        public string ENDERECO { get; set; }
        public string NUMERO { get; set; }
        public StatusLogradouro STATUS { get; set; }
        public DateTime DATA_CADASTRO { get; set; }
    }

    public enum StatusLogradouro
    {
        Inativo = 0,
        Ativo = 1
    }
}
