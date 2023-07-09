using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FactoryApp.Models;

public class DirectorModel
{
    [Key]
    public Guid Id { get; set; }
    
    [DisplayName("директор")]
    public string FullName { get; set; }
}