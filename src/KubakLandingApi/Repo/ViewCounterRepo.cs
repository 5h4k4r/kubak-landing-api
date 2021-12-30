using KubakLandingApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KubakLandingApi.Repo;
public class ViewCounterRepo : IViewCounterRepo
{

  private static FilterDefinitionBuilder<ViewCounter> Filter = Builders<ViewCounter>.Filter;
  private static UpdateDefinitionBuilder<ViewCounter> Update = Builders<ViewCounter>.Update;
  private static FindOneAndUpdateOptions<ViewCounter> _ReturnAfter = new() { ReturnDocument = ReturnDocument.After, IsUpsert = true };

  private readonly IMongoCollection<ViewCounter> _analytics;

  public ViewCounterRepo(IOptions<DatabaseSettings> options)
  {
    var mongoClient = new MongoClient(options.Value.ConnectionString);
    var db = mongoClient.GetDatabase(options.Value.DatabaseName);
    _analytics = db.GetCollection<ViewCounter>("analytics");
  }

  public async Task<ViewCounter> GetViewCount()
  {
    var doc = await _analytics.FindOneAndUpdateAsync(Filter.Empty, Update.Inc(x => x.Count, 1), _ReturnAfter);
    return doc;
  }

}
