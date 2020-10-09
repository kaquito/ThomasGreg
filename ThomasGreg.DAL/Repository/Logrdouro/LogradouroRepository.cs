using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ThomasGreg.DAL.Repository.Logrdouro
{
    public class LogradouroRepository : Base.Dapper
    {
        public bool Add(ThomasGreg.Entidade.Logradouro logradouro)
        {
            try
            {
                var sql = "exec AdicionarLogradouro @idClinte, @endereco,@numero,@Status";

                var param = new
                {
                    idClinte = logradouro.ID_CLIENTE,
                    endereco = logradouro.ENDERECO,
                    numero = logradouro.NUMERO,
                    Status = logradouro.STATUS
                };

                using (var conn = Connection)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var linha = conn.Execute(sql, param);

                    return (linha > 0 ? true : false);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(ThomasGreg.Entidade.Logradouro logradouro)
        {
            try
            {
                var sql = "exec AtualizaLogradouro @idLogradouro, @idClinte, @endereco,@numero,@Status";

                var param = new
                {
                    idLogradouro = logradouro.ID_LOGRADOURO,
                    idClinte = logradouro.ID_CLIENTE,
                    endereco = logradouro.ENDERECO,
                    numero = logradouro.NUMERO,
                    Status = logradouro.STATUS
                };

                using (var conn = Connection)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var linha = conn.Execute(sql, param);

                    return (linha > 0 ? true : false);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ThomasGreg.Entidade.Cliente Buscar(int idClinte)
        {
            try
            {
                var sql = "exec BuscarLogradouro @idClinte";

                var param = new { idClinte = idClinte };

                using (var conn = Connection)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var objeto = conn.QuerySingleOrDefault<ThomasGreg.Entidade.Cliente>(sql, param);

                    return objeto;
                }
            }
            catch (Exception)
            {
                return new ThomasGreg.Entidade.Cliente();
            }

        }

        public bool Delete(int idLogradouro)
        {
            try
            {
                var sql = "exec DeleteLogradouro @idLogradouro";

                var param = new { idLogradouro = idLogradouro };

                using (var conn = Connection)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var linha = conn.Execute(sql, param);

                    return (linha > 0 ? true : false);
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
