namespace KPZExamServer.ViewModels;

public class StudentAssignmentStateView
{
    public int ID { get; set; }

    public int StudentId { get; set; }
    
    public int AssignmentId { get; set; }
    
    public bool IsPresent { get; set; }
    
    public int Mark { get; set; } 
}