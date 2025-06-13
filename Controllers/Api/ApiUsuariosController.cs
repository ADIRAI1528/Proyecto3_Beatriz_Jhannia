using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]

public class ApiUsuariosController : ControllerBase
{
    // Metodos para hacer las operaciones CRUD
    // C = Create
    // R = Update
    // D = Delete

    private readonly IMongoCollection<Usuario> Collection;

    public ApiUsuariosController()
    {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var database = client.GetDatabase("parcial3_Escuela");
        this.Collection = database.GetCollection<Usuario>("Usuarios");
    }

    [HttpGet]

    public IActionResult ListarUsuarios()
    {
        var filter = FilterDefinition<Usuario>.Empty;
        var list = this.Collection.Find(filter).ToList();
        return Ok(list);
    }
}