using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TradingSimulator.Test.Specs.ScreenPlay.Symbols.Commands.Symbols;

namespace TradingSimulator.Test.Specs.Features.Symbols.ScenarioModels;

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