
using System.ComponentModel.DataAnnotations;

namespace EjercicioPOO2.Models
{
    public class DegreeModel:BaseModel
    {
        public DegreeModel()
        {

        }
         [Required(ErrorMessage ="El {0} es un campo requerido")]
         [StringLength(maximumLength:50, MinimumLength =5, ErrorMessage ="La longitud del campo{0} debe de ser entre minimo 5 y 10")]
         public string Nombre {get; set;}
          
    }

}