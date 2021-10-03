using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="required")]
        public string Titulo { get; set;}
        [Required(ErrorMessage = "required")]
        public string Diretor { get; set;}
        public string Genero { get; set; }
        [Range(1,600,ErrorMessage ="Range")]
        public int Duracao { get; set; }
    }
}
