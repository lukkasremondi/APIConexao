using System.ComponentModel.DataAnnotations;

namespace APIConexao.Models
{
    public class Trancar
    {
        [Key]
        public int id {get;set;}

        public int status {get;set;}
    }
}