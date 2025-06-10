using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


 [Route("presentacion")]
public class MiProyectoController : ControllerBase

{
    [HttpGet("integrantes")]
    public IActionResult Obtenerintegrantes()
    {
        var proyecto = new
        {
          
            Nombreintegrante1 = "Beatriz Gonzalez",
            Nombreintegrante2 = "Jhannia Castillo",
        

        };

        return Ok(proyecto);
    }

    

    [HttpGet("proyecto")]
    public IActionResult ObtenerProyecto()
    {
        var proyecto = new
        {
           escuela = "Cbtis105",
            carrera = "Programacion",
            grupo = "D",
            datos_semestre = "Cuarto semestre",
            proyecto = "Configuración de Proyecto y Backend",
            integrante1 = "Beatriz Gonzalez",
            integrante2 = "Jhannia Castillo",
            fecha = new DateTime(2025, 6, 5)

        };

        return Ok(proyecto);
    }


}

