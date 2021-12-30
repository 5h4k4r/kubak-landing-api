using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace KubakLandingApi.Models;

public class ViewCounter
{

  public int Count { get; set; }
}
