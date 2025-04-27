using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace AssistenciaTecnicaAPI;

public class Servico 
{
    [BsonId] //Designa a propriedade como chave primária do documento (id).
    [BsonRepresentation(BsonType.ObjectId)] //Permite a passagem do parâmetro como string em vez de estrutura ObjectId.
    public string? Id { get; set; }

    [BsonElement("Cliente")]
    [JsonPropertyName("Cliente")]
    public string? Cliente { get; set; }
    public string? Endereco { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Telefone { get; set;}
    public string? ServicoExecutado { get; set; }
    public string? Produto { get; set; }
    public string? Categoria { get; set; }
    public string? Defeito { get; set; }
    public decimal Preco { get; set; }
}