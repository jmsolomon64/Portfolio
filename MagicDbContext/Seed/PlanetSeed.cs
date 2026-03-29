using Common;

namespace MagicDbContext;

public class PlanetSeed : ISeed
{
    private readonly MagicDbContext _ctx;

    public PlanetSeed(MagicDbContext ctx)
    {
        _ctx = ctx;
    }

    public int Priority() => 1;

    public void Seed()
    {
        Console.WriteLine("Seeding Planets...");
        SeedClassicalPlanets();
        SeedSequelPlanets();
    }

    private void SeedClassicalPlanets()
    {
        List<ClassicalPlanets> planets = EnumExtensions.GetEnumValues<ClassicalPlanets>();
        foreach(ClassicalPlanets planet in planets)
            SeedPlanet((int)planet, planet.ToString(), true);            
    }

    private void SeedSequelPlanets()
    {
        List<SequelPlanets> planets = EnumExtensions.GetEnumValues<SequelPlanets>();
        foreach(SequelPlanets planet in planets)
            SeedPlanet((int)planet, planet.ToString(), false);
    }
        

    private void SeedPlanet(int planetEnum, string name, bool IsClassical, string symbol = "")
    {
        Planet? temp = _ctx.Planets.FirstOrDefault(x => x.PlanetEnum == planetEnum);
        bool isNew = temp == null;
        if(isNew) temp = new Planet() { Name = name };

        Symbol? symbolRecord = _ctx.Symbols.FirstOrDefault(x => x.Glyph == symbol); 

        temp.Name = name;
        temp.SymbolId = symbolRecord?.SymbolId;
        temp.IsClassical = IsClassical;

        if(isNew) _ctx.Planets.Add(temp);
        else _ctx.Planets.Update(temp);
    }
}
