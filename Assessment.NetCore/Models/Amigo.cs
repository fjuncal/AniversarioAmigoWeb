using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment.NetCore.Models
{
    [Table("AMIGO_TB")]
    public class Amigo
    {
        [Key]
        public long id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dataDeNascimento { get; set; }
    }
}