using SkodaApi.Models;
using SkodaApi.Repositories;

namespace SkodaApi.Services;

public class BannerService
{
  private readonly IRepository<Banner> _repository;

  public BannerService(IRepository<Banner> repository)
  {
    _repository = repository;
  }

  public Task<IEnumerable<Banner>> GetAllAsync() => _repository.GetAllAsync();
  public Task<Banner?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
  public Task<Banner> AddAsync(Banner banner) => _repository.AddAsync(banner);
  public Task UpdateAsync(Banner banner) => _repository.UpdateAsync(banner);
  public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}