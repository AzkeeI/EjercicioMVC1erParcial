using EjercicioPOO2.Models;
using Microsoft.AspNetCore.Mvc;


namespace EjercicioPOO2
{


    public class AlumnosController : Controller
    {
          private readonly ILogger<AlumnosController> _logger;
        public AlumnosController(ILogger<AlumnosController> logger)
        {
             _logger = logger;
        }

       
        public IActionResult AlumnosAdd()
        {
            return View();
        }

        [HttpPost]
         public IActionResult AlumnosAdd(StudenttModel alumno)
        {
           if(!ModelState.IsValid)
           {
            _logger.LogWarning("El objeto no es valido");
            return View();
           }

            _logger.LogInformation("El objeto es valido");
         
            return Redirect("studentList");
        }   

        public IActionResult StudentList()
        {
            // Crear objetos de alumnos
            StudenttModel alumno = new StudenttModel
            {
                Nombre = "Fernanda Rodriguez",
                Carrera = "Ingeniería en Ciencia de Datos",
                matricula = 43566,
                Edad = 19,
                Sexo = "Femenino"
            };

            StudenttModel alumno2 = new StudenttModel
            {
                Nombre = "Franco Escamilla",
                Carrera = "Licenciatura en Historia",
                matricula = 44760,
                Edad = 23,
                Sexo = "Masculino"
            };

            StudenttModel alumno3 = new StudenttModel
            {
                Nombre = "Julian Macias Lara",
                Carrera = "Ing. Sistemas",
                matricula = 43098,
                Edad = 20,
                Sexo = "Masculino"
            };

           
            List<StudenttModel> list = new List<StudenttModel>
            {
                alumno,
                alumno2,
                alumno3
            };

            return View(list);
        }

        public IActionResult AlumnosSave()
        {
            
            return Redirect("StudentList");
        }

        public IActionResult AlumnosShowAndEdit(Guid Id)
        {
            StudenttModel alumno = new StudenttModel();
            
                alumno.Id = Id;
                alumno.Nombre = "Alumno cargado";
            return View(alumno);
        }

        public IActionResult AlumnosEdit(Guid Id)
        {
            StudenttModel Alumno=new StudenttModel();  
           Alumno.Id=new Guid();
            Alumno.Nombre="Alumno cargado";
            return View(Alumno);
        }

         [HttpPost]
         public IActionResult AlumnosEdit(StudenttModel estudiante)
        {
              if(!ModelState.IsValid)
           {
            _logger.LogWarning("El objeto no es valido");
            estudiante.Nombre="Alumno no valido";
            return View(estudiante);
           }

            _logger.LogInformation("El objeto es valido");
         
            return Redirect("StudentList");
        }


        public IActionResult AlumnosShowToDelete(Guid Id)
        {
        StudenttModel alumno = new StudenttModel();
            
                alumno.Id = Id;
                alumno.Nombre = "Alumno para borrar";
            return View(alumno);
        }

        public IActionResult AlumnosDeleted()
        {
            // Borrar el registro
            return Redirect("StudentList");
        }
    }
}