using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TradingSimulator.Test.Specs.ScreenPlay.OrderBooks.Commands;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;

namespace TradingSimulator.Test.Specs.Features.OrderBooks.ScenarioModels;

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