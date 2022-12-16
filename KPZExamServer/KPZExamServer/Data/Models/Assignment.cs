using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPZExamServer.Data.Models;

public class Assignment: EntityBase
{
    public string text { get; set; }
    
    public DateTime dateTime { get; set; }
    
    [Required, DefaultValue(0)]
    public int priority { get; set; }
    
    [Required, DefaultValue(0)]
    public int status { get; set; }
    
    public ICollection<StudentAssignmentState> studentStates { get; set; }
}