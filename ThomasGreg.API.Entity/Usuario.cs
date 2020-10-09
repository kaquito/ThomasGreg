using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Entidade
{
    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        public string LOGIN { get; set; }
        public string SENHA { get; set; }
        public StatusUsuario STATUS { get; set; }
        public DateTime DATA_CADASTRO { get; set; }
    }

    public enum StatusUsuario
    {
        Inativo = 0,
        Ativo = 1
    }
}
