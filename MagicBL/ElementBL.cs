using MagicDbContext;
using Microsoft.EntityFrameworkCore;

namespace MagicBL;

public class ElementBL : IElement
{
    private readonly MagicDbContext.MagicDbContext _ctx;
    
    public ElementBL(MagicDbContext.MagicDbContext ctx)
    {
        _ctx = ctx;
    }

    public bool AddElementAlias(int elementId, string alias)
    {
        throw new NotImplementedException();
    }

    public bool AddPlanetaryCorrespondence(int elementId, int planetId)
    {
        throw new NotImplementedException();
    }

    public bool AddSymbol(int elementId, int symbolId)
    {
        throw new NotImplementedException();
    }

    public Element? GetElementById(int elementId)
    {
        IQueryable<Element> element = _ctx.Elements
            .Where(x => x.ElementId == elementId);
        IncludeElementDetails(element);
        return element.FirstOrDefault();
    }

    public IEnumerable<Element> GetElements(bool includeDetails = false)
    {
        IQueryable<Element> elements = _ctx.Elements;
        if(includeDetails) IncludeElementDetails(elements);
        return elements.ToList();
    }

    private void IncludeElementDetails(IQueryable<Element> elements)
    {
        elements.Include(x => x.MainSymbol)
        .Include(x => x.Aliases)
        .Include(x => x.PlanetaryCorrespondences)
        .Include(x => x.OtherSymbols);
    }
}
