using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPZExamServer.Data.Models;

public class Student: EntityBase
{
    [Required]
    public string Name { get; set; }
}