using KPZExamServer.Data.Models;

namespace KPZExamServer.ViewModels;

public class AssignmentView
{
    public int ID { get; set; }
    
    public string text { get; set; }
    
    public DateTime dateTime { get; set; }
    
    public int priority { get; set; }
    
    public int status { get; set; }

    public ICollection<StudentAssignmentState> studentStates { get; set; }
}