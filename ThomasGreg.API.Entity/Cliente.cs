using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Entidade
{
    public class Cliente
    {
        public int ID_CLIENTE { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public StatusCliente STATUS { get; set; }
        public Byte[] LOGOTIPO { get; set; }
        public DateTime DATA_CADASTRO { get; set; }
    }

    public enum StatusCliente
    {
        Inativo = 0,
        Ativo = 1
    }
}
