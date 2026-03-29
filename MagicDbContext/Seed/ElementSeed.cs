using Common;
using Microsoft.EntityFrameworkCore;

namespace MagicDbContext;

public class ElementSeed : ISeed
{
    private readonly MagicDbContext _ctx;
    public ElementSeed(MagicDbContext ctx)
    {
        _ctx = ctx;
    }

    public int Priority() => 2;

    public void Seed()
    {
        Console.WriteLine("Seeding Elements...");
        SeedElements();
    }

    private void SeedElements() =>
        EnumExtensions.GetEnumValues<ElementType>()
            .ForEach(x => SeedElement((int)x, x.ToString()));


    private void SeedElement(int elementId, string name, string symbol = "")
    {
        Element? temp = _ctx.Elements.FirstOrDefault(x => elementId == x.ElementEnum);
        bool isNew = temp == null;

        if(isNew) temp = new Element() { ElementEnum = elementId };

        Symbol? symbolRecord = _ctx.Symbols.FirstOrDefault(x => x.Glyph == symbol); 

        temp.MainSymbolId = symbolRecord?.SymbolId;
        temp.Name = name;
        
        if(isNew) _ctx.Elements.Add(temp);
        else _ctx.Elements.Update(temp);
    }
}
