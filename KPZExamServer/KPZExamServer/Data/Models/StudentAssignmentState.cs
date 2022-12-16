using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPZExamServer.Data.Models;

public class StudentAssignmentState: EntityBase
{
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    
    [ForeignKey("Assignment")]
    public int AssignmentId { get; set; }
    
    [Required, DefaultValue(true)]
    public bool IsPresent { get; set; }
    
    public int Mark { get; set; } 
}