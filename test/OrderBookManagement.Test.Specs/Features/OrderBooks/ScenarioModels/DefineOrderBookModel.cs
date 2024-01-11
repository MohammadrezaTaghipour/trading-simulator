using OrderBookManagement.Test.Specs.ScreenPlay.OrderBooks.Commands;
using OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Commands;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OrderBookManagement.Test.Specs.Features.OrderBooks.ScenarioModels;

public class DefineOrderBookModel
{
    public string Title { get; set; }
    public string SessionCode { get; set; }
}

[Binding]
public class DefineOrderBookModelTransformer
{
    private readonly ScenarioContext _context;

    public DefineOrderBookModelTransformer(ScenarioContext context)
    {
        _context = context;
    }

    [StepArgumentTransformation]
    public DefineOrderBookCommand ConvertToCommand(Table table)
    {
        var model = table.CreateInstance<DefineOrderBookModel>();
        return new DefineOrderBookCommand
        {
            Title = model.Title,
            SessionId = _context.Get<DefineSessionCommand>(model.SessionCode).Id
        };
    }
}