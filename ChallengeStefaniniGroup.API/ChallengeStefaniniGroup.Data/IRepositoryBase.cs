using MongoDB.Bson;

namespace ChallengeStefaniniGroup.Data;

public interface IRepositoryBase<T> where T : class
{
    Task<T?> GetById(ObjectId id);

    Task<List<T>> GetAll();

    Task<bool> Add(T newObject);

    Task<(bool, string)> Update(T objectDomain);

    Task<(bool, string)> Delete(ObjectId id);
}
