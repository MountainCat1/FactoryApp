using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FactoryApp.Models;

public class RepairmenModel
{
    [Key]
    public Guid Id { get; set; }

    [DisplayName("ФИО")]
    public string FullName { get; set; }
}