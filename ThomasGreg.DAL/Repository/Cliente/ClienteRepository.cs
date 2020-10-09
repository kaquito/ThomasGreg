using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using ThomasGreg.Entidade;

namespace ThomasGreg.DAL.Repository.Cliente
{
    public class ClienteRepository : Base.Dapper
    {

        public bool Add(ThomasGreg.Entidade.Cliente cliente)
        {
            try
            {
                var sql = "exec AdicionarCliente @Nome, @Email,@Status,@LogoTipo ,@DataCadastro";

                var param = new
                {
                    Nome = cliente.NOME,
                    Email = cliente.EMAIL,
                    Status = cliente.STATUS,
                    LogoTipo = cliente.LOGOTIPO,
                    DataCadastro = DateTime.Now
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

        public bool Update(ThomasGreg.Entidade.Cliente cliente)
        {
            try
            {
                var sql = "exec AtualizarCliente @idCliente, @Nome, @Email,@Status, @LogoTipo";

                var param = new
                {
                    idCliente = cliente.ID_CLIENTE,
                    Nome = cliente.NOME,
                    Email = cliente.EMAIL,
                    Status = cliente.STATUS,
                    LogoTipo = cliente.LOGOTIPO
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

        public ThomasGreg.Entidade.Cliente Buscar(string email)
        {
            try
            {
                var sql = "exec BuscarCliente @Email";

                var param = new { Email = email };

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

        public IEnumerable<ThomasGreg.Entidade.Cliente> BuscarTodos()
        {
            try
            {
                var sql = "exec BuscarTodosClientes";
                               
                using (var conn = Connection)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var objeto = conn.Query<ThomasGreg.Entidade.Cliente>(sql).AsList();

                    return objeto;
                }
            }
            catch (Exception)
            {
                return new List<ThomasGreg.Entidade.Cliente>();
            }

        }

        public bool Delete(string email)
        {
            try
            {
                var sql = "exec DeleteCliente @Email";

                var param = new { Email = email };

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
