namespace TradingSimulator.Infrastructure.Application;

public interface ICommandHandler<in T>
{
    Task Handle(T command, CancellationToken token);
}

public interface ICommandHandler<in TInput, TOutput>
{
    Task<TOutput> Handle(TInput command, CancellationToken token);
}