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
    public class TrancarController : ControllerBase
    {
        private DataContext dc;

        public TrancarController(DataContext context){

            this.dc = context;
        }


        [HttpPost("trancar")]

        public async Task<ActionResult> cadastrar([FromBody] Trancar t){

            dc.tb_trancar.Add(t);
            await dc.SaveChangesAsync();

            return Created("Status da porta", t);
        }


        [HttpGet("trancar")]
        public async Task<ActionResult> listar(){

            var dados = await dc.tb_trancar.ToListAsync();
            return Ok(dados);

        }


        [HttpGet("trancar/{codigo}")]
        public Trancar filtrar(int codigo){

            Trancar t = dc.tb_trancar.Find(codigo);

            return t;

        }


        [HttpPut("trancar")]
        public async Task<ActionResult> editar([FromBody] Trancar t){
            
            dc.tb_trancar.Update(t);
            await dc.SaveChangesAsync();
            return Ok(t);
        }

        [HttpDelete("trancar/{codigo}")]
        public async Task<ActionResult> remover(int codigo){
            
            Trancar t = filtrar(codigo);

            if(t == null){
                return NotFound();
            }
            else{

                dc.tb_trancar.Remove(t);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }
        
    }
}