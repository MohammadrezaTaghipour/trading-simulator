using OrderBookManagement.Domain.Models.Sessions;
using OrderBookManagement.Infrastructure.Application;

namespace OrderBookManagement.Application.Sessions;

public class SessionsCommandHandlers : ICommandHandler<DefineSessionCommand>
{
    private readonly ISessionRepository _repository;

    public SessionsCommandHandlers(ISessionRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DefineSessionCommand command, CancellationToken token)
    {
        var arg = CreateArgFrom(command);
        var session = new Session(arg);
        await _repository.Add(session, token);
    }

    private SessionArg CreateArgFrom(DefineSessionCommand command)
    {
        return new SessionArg
        {
            Id = new SessionId(command.Id),
            Code = command.Code,
            OpeningDate = command.OpeningDate,
            ClosingDate = command.ClosingDate
        };
    }
}