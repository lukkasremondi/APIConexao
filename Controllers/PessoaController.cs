using System.Threading.Tasks;
using APIConexao.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIConexao.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController
    {
        [HttpGet("oi")]
        public string oi(){
            return "Hello World";
        }

    }
}