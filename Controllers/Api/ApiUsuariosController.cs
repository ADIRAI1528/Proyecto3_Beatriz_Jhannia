using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]

Public class ApiUsuariosController : ControllerBase
{
    // Metodos para hacer las operaciones CRUD
    // C = Create
    // R = Update
    // D = Delete

    private readonly IMongoCollection<Usuario> Collection;

    public ApiUsuariosController()
    {
        var client = new MongoClient(CadenaConexion.Mongo_DB);
        var database = client.GetDatabase("parcial3_Escuela");
        this.collection = database.GetCollection<Usuario>("Usuarios");
    }

    [HttpGet]

    public IActionResult ListarUsuarios()
    {
        var filter = FilterDefinition<Usuario>.Empty;
        var list = this.collection.Find(filter).ToList();
        return ok(list);
    }
}
