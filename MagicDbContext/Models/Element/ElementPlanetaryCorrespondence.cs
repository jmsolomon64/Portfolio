using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

[Table("ElementPlanetaryCorrespondence", Schema = "element")]
public class ElementPlanetaryCorrespondence
{
    [Key]
    public int CorrespondenceId {get; set;}
    [ForeignKey(nameof(Element))]
    public int ElementId {get; set;}
    public virtual Element? Element {get; set;}
    [ForeignKey(nameof(Planet))]
    public int PlanetId {get; set;}
    public virtual Planet? Planet {get; set;}
}
