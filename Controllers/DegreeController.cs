using EjercicioPOO2.Models;
using Microsoft.AspNetCore.Mvc;

namespace  EjercicioPOO2
{
    public class DegreeController : Controller
    {
         private readonly ILogger<DegreeController> _logger;
        public DegreeController(ILogger<DegreeController> logger)
        {
             _logger = logger;
        }

        public IActionResult DegreeAdd()
        {
            return View();  
        }   

        
         [HttpPost]
         public IActionResult DegreeAdd(DegreeModel degree)
        {
           if(!ModelState.IsValid)
           {
            _logger.LogWarning("El objeto introdujido es invalido");
            return View();
           }

            _logger.LogInformation("El objeto introdujido es valido");
         
            return Redirect("DegreeList");
        }   

        public IActionResult DegreeList()
    {
        /*Seccion de listado de carrera*/
        _logger.LogInformation("Esto es un mensaje al cargar las carreras");
         //Crear objeto de carrera
         DegreeModel Carrera=new DegreeModel();  
        Carrera.Nombre="Ingenieria en ciencias de datos";

         DegreeModel Carrera2=new DegreeModel();  
        Carrera2.Nombre="Licenciatura en Computacion";

         DegreeModel Carrera3=new DegreeModel();  
        Carrera3.Nombre="Ingenieria Industrial"; 

         //objeto de lista de carreras
         List<DegreeModel>list=new List<DegreeModel>(); 
        list.Add(Carrera);
        list.Add(Carrera2);
        list.Add(Carrera3);

        return View(list);
    }

          public IActionResult DegreeEdit(Guid Id)
    {
            DegreeModel carrera=new DegreeModel();  
           carrera.Id=Id;
            carrera.Nombre="Carrera cargada";
            return View(carrera);
    }

        [HttpPost]
        public IActionResult DegreeEdit(DegreeModel carrera)
        {
             if(!ModelState.IsValid)
           {
            _logger.LogWarning("El objeto introducido no es valido");
            carrera.Nombre="Carrera introducida no es valida";
            return View(carrera);
           }

            _logger.LogInformation("El objeto introducido es valido");
         
            return Redirect("DegreeList");
 
        }

         public IActionResult DegreeShowToDelete(Guid Id)
         {
             DegreeModel carrera=new DegreeModel();  
            carrera.Id=Id;
            carrera.Nombre="Carrera dicidida a borrar";
            return View(carrera);
            
         }

          public IActionResult DegreeDeleted()
          {
            
            return Redirect ("DegreeList");
          }

    }

}