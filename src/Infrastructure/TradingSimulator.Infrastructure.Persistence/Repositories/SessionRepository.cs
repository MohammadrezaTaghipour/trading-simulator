using TradingSimulator.Domain.Models.Sessions;

namespace TradingSimulator.Infrastructure.Persistence.Repositories;

public class SessionRepository : ISessionRepository
{
    public Task<Session> GetBy(SessionId id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Add(Session session, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}