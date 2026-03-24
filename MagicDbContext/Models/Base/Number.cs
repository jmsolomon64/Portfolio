using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicDbContext;

[Table("Number", Schema = "base")]
public class Number
{
    [Key]
    public int NumberId {get; set;}
    [MaxLength(500)]
    public string Description {get; set;} = "Not much is known yet...";
}
