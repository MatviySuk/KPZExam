using KPZExamServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KPZExamServer.Data;

public class JournalContext: DbContext
{
    public DbSet<Assignment> Assignments { get; set; }
    
    public DbSet<Student> Students { get; set; }
    
    public DbSet<StudentAssignmentState> AssignmentStates { get; set; }

    public JournalContext(DbContextOptions<JournalContext> options) : base(options)
    {
        
    }
}