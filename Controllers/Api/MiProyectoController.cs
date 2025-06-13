using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[Route("presentacion")]
public class MiProyectoController : ControllerBase
{

     [HttpGet("integrantes")]
    public IActionResult ObtenerIntegrantes()
    {
        var proyecto = new
        {
          
            Nombreintegrante1 = "Batriz Gonzalez",
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
    
    [HttpGet("presentacion")]
    public IActionResult ObtenerPresentacion()
    {
       var client = new MongoClient(CadenasConexion.MONGO_DB);
         var database = client.GetDatabase("Escuela_Beatriz_Jhannia");
        var collection = database.GetCollection<Equipo>("Equipo");

        var filter = FilterDefinition<Equipo>.Empty;
        var item = collection.Find(filter).FirstOrDefault();

        return Ok(item);
    }
}