using Common;

namespace MagicDbContext;

public class ElementSeed : ISeed
{
    private readonly MagicDbContext _ctx;
    public ElementSeed(MagicDbContext ctx)
    {
        _ctx = ctx;
    }

    public int Priority() => 2;

    public Task Seed()
    {
        return Task.Run(() =>
        {
            Console.WriteLine("Seeding Elements...");
            SeedElements();
        });
    }

    private void SeedElements()
    {
        List<ElementType> elements = EnumExtensions.GetEnumValues<ElementType>();
        foreach(ElementType element in elements)
            SeedElement((int)element, nameof(element));
    }


    private void SeedElement(int elementId, string name, string symbol = "")
    {
        Element? temp = _ctx.Elements.FirstOrDefault(x => elementId == x.ElementId);
        if(temp == null) temp = new Element() { ElementId = elementId };

        Symbol? symbolRecord = _ctx.Symbols.FirstOrDefault(x => x.Glyph == symbol); 

        temp.MainSymbolId = symbolRecord?.SymbolId;
        temp.Name = name;
        
        _ctx.Elements.Update(temp);
    }
}
