using System.Net;
using System.Threading.Tasks;
using APIConexao.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIConexao.Models;

namespace APIConexao.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {

        private DataContext dc;

        public EstadoController(DataContext context){

            this.dc = context;
        }

        [HttpPost("estado")]

        public async Task<ActionResult> cadastrar([FromBody] Estado e){

            dc.tb_trancado.Add(e);
            await dc.SaveChangesAsync();

            return Created("Status da porta", e);
        }

        [HttpGet("estado")]
        public async Task<ActionResult> listar(){

            var dados = await dc.tb_trancado.ToListAsync();
            return Ok(dados);

        }

        [HttpGet("estado/{codigo}")]
        public Estado filtrar(int codigo){

            Estado e = dc.tb_trancado.Find(codigo);

            return e;

        }

        [HttpPut("estado")]
        public async Task<ActionResult> editar([FromBody] Estado e){
            
            dc.tb_trancado.Update(e);
            await dc.SaveChangesAsync();
            return Ok(e);
        }
        
        [HttpDelete("estado/{codigo}")]
        public async Task<ActionResult> remover(int codigo){
            
            Estado e = filtrar(codigo);

            if(e == null){
                return NotFound();
            }
            else{

                dc.tb_trancado.Remove(e);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
    }
}