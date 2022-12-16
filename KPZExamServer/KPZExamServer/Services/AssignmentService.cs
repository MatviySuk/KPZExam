using AutoMapper;
using KPZExamServer.Data;
using KPZExamServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KPZExamServer.Services;

public class AssignmentService: IAssignmentService
{
    private readonly JournalContext context;
    private readonly IMapper mapper;

    public AssignmentService(JournalContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }
    
    public async Task Create(Assignment assignment)
    {
        context.Add(assignment);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var assignment = context.Assignments.FirstOrDefault(e => e.ID == id);
        if (assignment == null)
        {
            throw new ArgumentException($"Assignment with id = {id} not found");
        }
        context.Remove(assignment);
        await context.SaveChangesAsync();
    }

    public async Task<Assignment> Get(int id)
    {
        var assignment = await context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            throw new ArgumentException($"Assignment with id = {id} not found");
        }
        return assignment;
    }

    public async Task<IList<Assignment>> GetAll()
    {
        return await context.Assignments.ToListAsync();
    }

    public async Task Update(Assignment assignment)
    {
        var assignmentToUpdate = context.Assignments.FirstOrDefault(x => x.ID == assignment.ID);
        if (assignmentToUpdate == null)
        {
            throw new ArgumentException($"Assignment with id = {assignment.ID} not found");
        }
        mapper.Map(assignment, assignmentToUpdate);
        await context.SaveChangesAsync();
    }

    public async Task<IList<StudentAssignmentState>> GetStudentStates(int assignmentID)
    {
        var assignment = context.Assignments.FirstOrDefault(e => e.ID == assignmentID);
        if (assignment == null)
        {
            throw new ArgumentException($"Assignment with id = {assignmentID} not found");
        }

        return await context.AssignmentStates.Where(sas => sas.AssignmentId == assignmentID).ToListAsync();
    }

    public async Task<IList<Student>> GetStudents(int assignmentID)
    {
        var assignment = context.Assignments.FirstOrDefault(e => e.ID == assignmentID);
        if (assignment == null)
        {
            throw new ArgumentException($"Assignment with id = {assignmentID} not found");
        }

        var studentIds = context.AssignmentStates
            .Where(sas => sas.AssignmentId == assignmentID)
            .Select(sas => sas.StudentId);
            
            
        return await context.Students.Where(s => studentIds.Contains(s.ID)).ToListAsync();
    }
}