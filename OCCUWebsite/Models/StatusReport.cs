using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCCUWebsite.Models;

public class StatusReport
{
    public int ID { get; set; }
    [Required]
    [StringLength(50)]
    [Display(Name = "StatusName")]
    public string StatusName { get; set; }
    [Required]
    [StringLength(50)]
    [Column("CurrentValue")]
    [Display(Name = "Current Value")]
    public string CurrentValue { get; set; }

}
