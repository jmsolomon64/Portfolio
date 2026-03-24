using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

public enum ElementType
{
    Chaos,
    Order,
    Fire,
    Water,
    Earth,
    Air
}

[Table("Element", Schema = "element")]
public class Element
{
    [Key]
    public int ElementId {get; set;}
    //Fire, Water, Earth, Air, Chaos, Order
    [MaxLength(5)]
    public string Name {get; set;} = "Please add name to this symbol!";
    [ForeignKey(nameof(MainSymbol))]
    public int? MainSymbolId {get; set;}
    public virtual Symbol? MainSymbol {get; set;}
    public virtual ICollection<ElementAlias> Aliases {get; set;} = new List<ElementAlias>();
    public virtual ICollection<ElementPlanetaryCorrespondence> PlanetaryCorrespondences {get; set;} = new List<ElementPlanetaryCorrespondence>();
    public virtual ICollection<ElementSymbol> OtherSymbols {get; set;} = new List<ElementSymbol>();
}
