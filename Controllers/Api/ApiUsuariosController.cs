using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]

public class ApiUsuariosController : ControllerBase
{





  private readonly IMongoCollection<Usuario> collection;
  public ApiUsuariosController()
  {
    var client = new MongoClient(CadenasConexion.MONGO_DB);
    var database = client.GetDatabase("Escuela_Beatriz_Jhannia");
    this.collection = database.GetCollection<Usuario>("Usuarios");

  }

  [HttpGet]
  public IActionResult ListarUsuarios(string? texto)
  {
    var filter = FilterDefinition<Usuario>.Empty;
    if (!string.IsNullOrWhiteSpace(texto))
    {
      var filterNombre = Builders<Usuario>.Filter.Regex(u => u.Nombre, new BsonRegularExpression(texto, "i"));
      var filterCorreo = Builders<Usuario>.Filter.Regex(u => u.Correo, new BsonRegularExpression(texto, "i"));
      filter = Builders<Usuario>.Filter.Or(filterNombre, filterCorreo);
    }
    var list = this.collection.Find(filter).ToList();
    return Ok(list);
  }

[HttpDelete("{id}")]
  public IActionResult Delete(string id)
  {
    var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
    var item = this.collection.Find(filter).FirstOrDefault();
    if (item != null)
    {
      this.collection.DeleteOne(filter);
    }
    return NoContent();
  }
  [HttpPost]
  public IActionResult Create(UsuarioRequest model)
  {
    //1. Validar el modelo para que contenga datos
    if (string.IsNullOrWhiteSpace(model.Correo))
    {
      return BadRequest("El correo es requerido");
    }
   
    if (string.IsNullOrWhiteSpace(model.Password))
    {
      return BadRequest("El password es requerido");
    }

     if (string.IsNullOrWhiteSpace(model.Nombre))
    {
      return BadRequest("El nombre es requerido");
    }
    // Validar que el correo no existe 
    var filter = Builders<Usuario>.Filter.Eq(x=> x.Correo, model.Correo);
    var item = this.collection.Find(filter).FirstOrDefault();
    if (item != null)
    {
      return BadRequest("El correo" + model.Correo + "ya exist en la base de datos");
    }

    Usuario bd= new Usuario();
    bd.Nombre=model.Nombre;
    bd.Correo=model.Correo;
    bd.Password=model.Password;
    this.collection.InsertOne(bd);
    return Ok();
  }
}