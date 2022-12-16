using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KPZExamServer.Data.Models;

namespace KPZExamServer.ViewModels;

public class AssignmentInsert
{
    public string text { get; set; }
    
    public DateTime dateTime { get; set; }
    
    [Required, DefaultValue(0)]
    public int priority { get; set; }
    
    [Required, DefaultValue(0)]
    public int status { get; set; }

    public ICollection<StudentAssignmentState> studentStates = new List<StudentAssignmentState>();
}