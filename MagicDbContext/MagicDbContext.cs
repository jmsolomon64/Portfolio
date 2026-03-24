using Microsoft.EntityFrameworkCore;

namespace MagicDbContext;

public class MagicDbContext : DbContext
{
    public MagicDbContext() {}
    public MagicDbContext(DbContextOptions options) : base(options) {}

    //----- base
    public virtual DbSet<Alias> Aliases {get; set;}
    public virtual DbSet<Planet> Planets {get; set;}
    public virtual DbSet<Symbol> Symbols {get; set;}
    public virtual DbSet<Number> Numbers {get; set;}
    //----- element
    public virtual DbSet<Element> Elements {get; set;}
    public virtual DbSet<ElementAlias> ElementAliases {get; set;}
    public virtual DbSet<ElementPlanetaryCorrespondence> ElementPlanetaryCorrespondences {get; set;}
    public virtual DbSet<ElementSymbol> ElementalSymbols {get; set;}
}
