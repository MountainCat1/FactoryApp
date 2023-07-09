using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryApp.Models;

public class WorkshopModel
{
    [Key]
    public string Region { get; set; }
    public Guid DirectorId { get; set; }
    
    
    [ForeignKey(nameof(DirectorId))]
    [DisplayName("директор")]
    public virtual DirectorModel? DirectorModel { get; set; } 
}