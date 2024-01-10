using OrderBookManagement.Test.Specs.ScreenPlay.Sessions.Commands;
using OrderBookManagement.Test.Specs.Shared;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OrderBookManagement.Test.Specs.Features.Sessions.ScenarioModels;

public class SessionModel
{
    public string Code { get; set; }
    public string OpeningDate { get; set; }
    public string ClosingDate { get; set; }
}

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