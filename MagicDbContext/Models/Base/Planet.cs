using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

public enum ClassicalPlanets
{
    Moon,
    Mercury,
    Venus,
    Sun,
    Mars,
    Jupiter,
    Saturn
}

public enum SequelPlanets
{
    Ceres, //TODO: Research this
    Uranus,
    Neptune,
    Pluto,
    Eris //TODO: Research this
}

[Table("Planet", Schema = "base")]
public class Planet
{
    [Key]
    public int PlanetId {get; set;}
    public bool IsClassical {get; set;}
    [MaxLength(7)]
    public string Name {get; set;} = "PlanetX";
    [ForeignKey(nameof(Symbol))]
    public int? SymbolId {get; set;}
    public Symbol? Symbol {get; set;}
    public int PlanetEnum {get; set;}
}
