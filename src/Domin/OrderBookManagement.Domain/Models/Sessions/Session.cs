using OrderBookManagement.Infrastructure.Domain;

namespace OrderBookManagement.Domain.Models.Sessions;

public class Session : AggregateRoot<SessionId>
{
    private Session()
    {
    }
    
    public Session(SessionArg arg)
    {
        Id = arg.Id;
        Code = arg.Code;
        OpeningDate = arg.OpeningDate;
        ClosingDate = arg.ClosingDate;
    }
    
    public string Code { get; private set; }
    public DateTime OpeningDate { get; private set; }
    public DateTime ClosingDate { get; private set; }
}