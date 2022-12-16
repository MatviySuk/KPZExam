using KPZExamServer.Data.Models;

namespace KPZExamServer.Services;

public interface IAssignmentService
{
    public Task<IList<Assignment>> GetAll();

    public Task<Assignment> Get(int id);

    public Task Update(Assignment assignment);

    public Task Delete(int id);

    public Task Create(Assignment assignment);
    
    public Task<IList<StudentAssignmentState>> GetStudentStates(int assignmentID);
    
    public Task<IList<Student>> GetStudents(int assignmentID);
}