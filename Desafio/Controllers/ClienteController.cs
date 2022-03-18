using Desafio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Desafio.Controllers
{

    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> Lista = new List<Cliente>()
        {
            new Cliente()
            {
                Id = 1,
                Nome = "Gilberto",
                Sobrenome = "Borges",
                Cpf = "1203256952012",
                DataNascimento = new DateTime(2002,09,24)
            },
            new Cliente()
            {
                Id = 2,
                Nome = "Gilberto",
                Sobrenome = "Ferreira",
                Cpf = "1203256952022",
                DataNascimento = new DateTime(2002,09,1)
            }
        };

        public ClienteController()
        {
        }

        ///<summary>
        /// Consultar dados de todos clientes 
        /// </summary>
        /// <returns>Objeto contendo os dados dos Clientes.</returns>
        [HttpGet]
        [Route("api/v1/cliente")]
        public ActionResult<List<Cliente>> ClienteBuscarTodos()
        {
            if (Lista == null || Lista.Count == 0)
            {
                return NotFound("Nenhum cliente encontrado !");
            }
            return Ok(Lista);
        }


        ///<summary>
        /// Atualizar dados de um cliente a partir do Cpf
        /// </summary>
        /// <param name="Cpf">Cpf cliente</param>
        /// <returns>Objeto contendo os dados de um cliente.</returns>
        [HttpGet]
        [Route("api/v1/cliente/{cpf}")]
        public ActionResult<string> ClienteBuscar(string cpf)
        {
            var cliente = Lista.FirstOrDefault(c => c.Cpf == cpf);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado !");
            }
            return Ok(cliente);
        }


        [HttpPost]
        [Route("api/v1/cliente")]
        public ActionResult<string> ClienteCadastrar([FromBody] Cliente cliente)
        {
            try
            {
                // validar dados de entrada
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //inserir no banco de dados 
                Lista.Add(cliente);
                //retorno de mensagem para o cliente 
                return Ok("Cliente cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar cliente!");
            }

        }

        /////<summary>
        ///// Atualizar dados de um cliente a partir do Id
        ///// </summary>
        ///// <param name="Id">Id cliente</param>
        ///// <returns>Objeto contendo os dados de um cliente.</returns>

        [HttpPut]
        [Route("api/v1/cliente/{cpf}")]
        public ActionResult<string> ClienteAtulizar(string cpf, [FromBody] Cliente cliente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var clienteBusca = Lista.FirstOrDefault(c => c.Cpf == cpf);
                if (clienteBusca != null)
                {
                    clienteBusca.Nome = cliente.Nome;
                    clienteBusca.Sobrenome = cliente.Sobrenome;
                }

                return Ok("Atualizado com sucesso!");
            }
            catch
            {
                return NotFound("Cliente nao encontrado!");
            }
        }

        /////<summary>
        ///// Deletar dados de um cliente a partir do Cpf
        ///// </summary>
        ///// <param name="Cpf">Cpf cliente</param>

        [HttpDelete]
        [Route("api/v1/cliente/{cpf}")]
        public ActionResult<string>ClienteDeletar(string cpf)
        {
            
            var cliente = Lista.FirstOrDefault(c => c.Cpf == cpf);
            if (Lista.Remove(cliente!) == false)
            {
                return NotFound("Cliente não encontrado!");
            }

            return Ok("Cliente Removido com sucesso!");
        }
    }
}
