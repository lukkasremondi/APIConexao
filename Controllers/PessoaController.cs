using System.Threading.Tasks;
using APIConexao.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIConexao.Models;

namespace APIConexao.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private DataContext dc;

        public PessoaController(DataContext context){

            this.dc = context;
        }

        [HttpPost("api")]

        public async Task<ActionResult> cadastrar([FromBody] Pessoa p){

            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();

            return Created("Objeto Pessoa", p);
        }


        [HttpGet("oi")]
        public string oi(){
            return "Hello World";
        }

    }
}