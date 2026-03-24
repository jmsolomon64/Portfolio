using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

[Table("Symbol", Schema = "base")]
public class Symbol
{
    [Key]
    public int SymbolId {get; set;}
    [MaxLength(50)]
    public string Name {get; set;}
    [Column("NVARCHAR(255)")]
    public string Glyph {get; set;}
}
