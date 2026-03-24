using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

[Table("Alias", Schema = "base")]
public class Alias
{
    [Key]
    public int AliasId {get; set;}
    [MaxLength(250)]
    public string Name {get; set;} = "Not yet known";
}
