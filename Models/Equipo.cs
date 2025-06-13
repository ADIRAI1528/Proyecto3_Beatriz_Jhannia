using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Equipo
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; } 

     [BsonElement("escuela")]
    public string Escuela { get; set; } = string.Empty;

    [BsonElement("carrera")]
    public string Carrera { get; set; } = string.Empty;

    [BsonElement("grupo")]
    public string Grupo { get; set; } = string.Empty;

    [BsonElement("datos_semestre")]
    public int DatosSemestre { get; set; }
    [BsonElement("proyecto")]
    public string NombreProyecto { get; set; }  = string.Empty;

    [BsonElement("integrante1")]
    public string Integrante1 { get; set; } = string.Empty;

    [BsonElement("integrante2")]
    public string Integrante2 { get; set; } = string.Empty;

    [BsonElement("fecha")]
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]  // Para mapear fecha correctamente
    public DateTime Fecha { get; set; }
}