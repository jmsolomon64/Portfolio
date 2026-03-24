using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

[Table("ElementAlias", Schema = "element")]
public class ElementAlias
{
    [Key]
    public int ElementAliasId {get; set;}
    [ForeignKey(nameof(Element))]
    public int ElementId {get; set;}
    public virtual Element? Element {get; set;}
    [ForeignKey(nameof(Alias))]
    public int AliasId {get; set;}
    public virtual Alias? Alias {get; set;}
}
