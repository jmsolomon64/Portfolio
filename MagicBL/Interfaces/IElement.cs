using MagicDbContext;

namespace MagicBL;

public interface IElement
{
    public IEnumerable<Element> GetElements(bool includeDetails = false);
    public Element? GetElementById(int elementId);
    public bool AddElementAlias(int elementId, string alias);
    public bool AddPlanetaryCorrespondence(int elementId, int planetId);
    public bool AddSymbol(int elementId, int symbolId);
}
