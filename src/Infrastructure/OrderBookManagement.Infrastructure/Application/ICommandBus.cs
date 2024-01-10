namespace OrderBookManagement.Infrastructure.Application;

public interface ICommandBus
{
    /// <summary>
    /// It is used for synchronous communication.
    /// It executes command immediately.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand">Incoming command</typeparam>
    /// <returns></returns>
    Task Send<TCommand>(TCommand command, CancellationToken? cancellationToken = null);

    /// <summary>
    /// It is used for synchronous communication.
    /// It executes command immediately.
    /// </summary>
    /// <param name="key">This acts as a partition key.
    /// Commands are partitioned by key into queues.
    /// If the partition key is noy provided all commands are sent to a single queue.</param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand">Incoming command</typeparam>
    /// <returns></returns>
    Task Send<TCommand>(string? key, TCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// It is used for synchronous communication.
    /// It executes command immediately.
    /// </summary>
    /// <param name="key">This acts as a partition key.
    /// Commands are partitioned by key into queues.
    /// If the partition key is noy provided all commands are sent to a single queue.</param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand">Incoming command</typeparam>
    /// <typeparam name="TResult">Result of command execution</typeparam>
    /// <returns></returns>
    Task<CommandBusResult<TResult>> Send<TCommand, TResult>(string? key, TCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    /// It is used for asynchronous communication.
    /// It does not execute command immediately.
    /// It dispatch a single command to a queue to be processed. 
    /// </summary>
    /// <param name="key">This acts as a partition key.
    /// Commands are partitioned by key into queues.
    /// If the partition key is noy provided all commands are sent to a single queue.</param>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TCommand"></typeparam>
    /// <returns></returns>
    Task Dispatch<TCommand>(string? key, TCommand command, CancellationToken cancellationToken);
}

public class CommandBusResult<T>
{
    public CommandBusResult(T item)
    {
        Item = item;
    }

    public T Item { get; private set; }
}