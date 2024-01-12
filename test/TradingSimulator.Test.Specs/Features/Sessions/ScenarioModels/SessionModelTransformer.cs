using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TradingSimulator.Test.Specs.ScreenPlay.Sessions.Commands;
using TradingSimulator.Test.Specs.Shared;

namespace TradingSimulator.Test.Specs.Features.Sessions.ScenarioModels;

[Binding]
public class SessionModelTransformer
{
    [StepArgumentTransformation]
    public DefineSessionCommand ConvertoToDefineCommand(Table table)
    {
        var model = table.CreateInstance<SessionModel>();
        return new DefineSessionCommand
        {
            Id = Guid.NewGuid(),
            Code = model.Code,
            OpeningDate = CalenderService.Get(model.OpeningDate).Date,
            ClosingDate = CalenderService.Get(model.ClosingDate).Date,
        };
    }
}