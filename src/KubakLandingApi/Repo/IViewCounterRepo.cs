using KubakLandingApi.Models;

namespace KubakLandingApi.Repo;
public interface IViewCounterRepo
{
  Task<ViewCounter> GetViewCount();
}