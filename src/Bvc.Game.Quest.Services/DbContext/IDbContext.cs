using Bvc.Game.Quest.Services.Domain;
using Dapper;

namespace Bvc.Game.Quest.Services.DbContext;

public interface IDbContext
{
    T Get<T>(int id) where T : IEntity;
}

public class GameQuestDbContext : IDbContext
{
    public T Get<T>(int id) where T : IEntity
    {
        throw new NotImplementedException();
    }
}