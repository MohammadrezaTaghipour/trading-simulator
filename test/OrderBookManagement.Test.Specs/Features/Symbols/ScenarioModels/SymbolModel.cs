using OrderBookManagement.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OrderBookManagement.Test.Specs.Features.Symbols.ScenarioModels;

public class SymbolModel
{
    public string Code { get; set; }
}

[Binding]
public class SymbolModelTransformer
{
    [StepArgumentTransformation]
    public DefineSymbolCommand ConvertoToDefineCommand(Table table)
    {
        var model = table.CreateInstance<SymbolModel>();
        return new DefineSymbolCommand(Guid.NewGuid(), model.Code);
    }
}