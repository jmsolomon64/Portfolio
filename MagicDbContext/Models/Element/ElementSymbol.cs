using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

[Table("ElementSymbol", Schema = "element")]
public class ElementSymbol
{
    [Key]
    public int ElementSymbolId {get; set;}
    [ForeignKey(nameof(Element))]
    public int ElementId {get; set;}
    public virtual Element? Element {get; set;}
    [ForeignKey(nameof(Symbol))]
    public int SymbolId {get; set;}
    public virtual Symbol? Symbol {get; set;}
}
