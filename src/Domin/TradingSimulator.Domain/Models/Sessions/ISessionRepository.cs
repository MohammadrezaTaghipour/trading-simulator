using TradingSimulator.Infrastructure.Domain;

namespace TradingSimulator.Domain.Models.Sessions;

public interface ISessionRepository: IRepository
{
    Task<Session> GetBy(SessionId id, CancellationToken cancellationToken);
    Task Add(Session session, CancellationToken cancellationToken);
}