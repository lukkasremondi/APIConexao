using System.ComponentModel.DataAnnotations;

namespace APIConexao.Models
{
    public class Estado
    {
        [Key]
        public int id {get;set;}

        public int trancado {get;set;}
        
    }
}