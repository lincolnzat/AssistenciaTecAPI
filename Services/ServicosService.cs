using AssistenciaTecnicaAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AssistenciaTecnicaAPI.Services;

public class ServicosService 
{
    private readonly IMongoCollection<Servico> _assistenciaTecCollection;

    public ServicosService(
        IOptions<AssistenciaTecDatabaseSettings> assistenciaTecnicaDatabaseSettings)
    {
        var mongoClient = new MongoClient (
            assistenciaTecnicaDatabaseSettings.Value.ConnectionString); //Lê instância do servidor pra executar operações do BD.
        
        var mongoDatabase = mongoClient.GetDatabase(
            assistenciaTecnicaDatabaseSettings.Value.DatabaseName); //Representa o BD para a execução de operações.
        
        _assistenciaTecCollection = mongoDatabase.GetCollection<Servico>(
            assistenciaTecnicaDatabaseSettings.Value.AssistenciaTecCollectionName
        ); //Retorna o objeto mongo collection, que representa a coleção.
    } 

    public async Task<List<Servico>> GetAsync() =>
        await _assistenciaTecCollection.Find(_ => true).ToListAsync();

    public async Task<Servico?> GetAsync(string id) =>
        await _assistenciaTecCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync (Servico newServico) =>
        await  _assistenciaTecCollection.InsertOneAsync(newServico);

    public async Task UpdateAsync (string id, Servico updatedServico) =>
        await  _assistenciaTecCollection.ReplaceOneAsync(x => x.Id == id, updatedServico); 

    public async Task RemoveAsync (string id) =>
    await _assistenciaTecCollection.DeleteOneAsync(x => x.Id == id);
}