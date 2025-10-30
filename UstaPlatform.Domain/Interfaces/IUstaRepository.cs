using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Domain.Interfaces;

public interface IUstaRepository
{
    IEnumerable<Usta> GetByExpertise(string uzmanlik);
    void Update(Usta usta);
}
