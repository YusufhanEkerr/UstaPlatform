using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Domain.Interfaces;

public interface IWorkOrderRepository
{
    void Add(IsEmri isEmri);
    IEnumerable<IsEmri> GetAll();
}
