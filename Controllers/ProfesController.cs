using EjercicioPOO2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioPOO2
{
    public class ProfesController : Controller
    
    {
         private readonly ILogger<ProfesController> _logger;
        public ProfesController(ILogger<ProfesController> logger)
        {
             _logger = logger;
        }
      

       public IActionResult ProfesAdd()
        {
            return View();  
        }  

         [HttpPost]
         public IActionResult ProfesAdd(ProfeModel profes)
        {
           if(!ModelState.IsValid)
           {
            _logger.LogWarning("El objeto no es valido");
            return View();
           }

            _logger.LogInformation("El objeto es valido");
         
            return Redirect("ListaProfesores");
        }  

           public IActionResult ListaProfesores()
    {
       
        ProfeModel profe=new ProfeModel();
        profe.Nombre="Pedro Zorrilla";
        profe.Carrera="Cincias";
        profe.Sexo="Masculino";
        

        ProfeModel profe2=new ProfeModel();
        profe2.Nombre="Juan Escutia";
         profe2.Carrera="Historia";
        profe2.Sexo="Masculino";
        

       

        ProfeModel profe3=new ProfeModel();
        profe3.Nombre="Erika Hernandez";
         profe3.Carrera="Cálculo integral".ToUpper();
        profe3.Sexo="Femenino";
        
        ProfeModel profe4=new ProfeModel();
        profe4.Nombre="Ricardo Elizalde";
         profe4.Carrera="POO2".ToUpper();
        profe4.Sexo="Masculino";

       //OBJETO DE LISTA DE PROFES
       List<ProfeModel>list=new List<ProfeModel>();    
        list.Add(profe);
        list.Add(profe2);
        list.Add(profe3);
        list.Add(profe4);

        

        return View(list);
    }

          public IActionResult ProfesSave()
        {

            return Redirect("ListaProfesores");
        }   

        public IActionResult ProfeShowAndEdit(Guid Id)   
        {
            ProfeModel profe= new ProfeModel();
            profe.Id=Id;   
            profe.Nombre="Profesor cargado"; 
            return View(profe);  
        }

        public IActionResult ProfesEdit(Guid Id)
        {
             ProfeModel Docente=new ProfeModel();  
           Docente.Id=new Guid();
            Docente.Nombre="profesor agregado";
            return View(Docente);
        }


             [HttpPost]
                 public IActionResult ProfesEdit(ProfeModel maestro)
        {
             if(!ModelState.IsValid)
           {
            _logger.LogWarning("El objeto no es valido");
            maestro.Nombre="Maestro no es valido";
            return View(maestro);
           }

            _logger.LogInformation("El objeto es valido");
         
            return Redirect("DegreeList");
           

           
        }




        public IActionResult ProfeShowToDelete(Guid Id)
        {

            
              ProfeModel profe= new ProfeModel();
            profe.Id=Id;   
            profe.Nombre="Profe para borrar"; 
            return View(profe); 
           
        }
         public IActionResult profesDeleted()
         {
            /*Borrar el registro*/

            return Redirect("ListaProfesores");
         }
       
    }
    
}