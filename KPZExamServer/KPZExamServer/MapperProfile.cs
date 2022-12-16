using AutoMapper;
using KPZExamServer.Data.Models;
using KPZExamServer.ViewModels;

namespace KPZExamServer;

public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<Assignment, AssignmentView>().ReverseMap();
        CreateMap<AssignmentUpdate, Assignment>().ReverseMap();
        CreateMap<AssignmentInsert, Assignment>().ReverseMap();
        CreateMap<Assignment, Assignment>();
        
        CreateMap<StudentAssignmentState, StudentAssignmentStateView>().ReverseMap();
        CreateMap<StudentAssignmentState, StudentAssignmentState>();
    }
}