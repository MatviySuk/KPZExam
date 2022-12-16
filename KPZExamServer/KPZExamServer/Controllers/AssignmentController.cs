using AutoMapper;
using KPZExamServer.Data.Models;
using KPZExamServer.Services;
using KPZExamServer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KPZExamServer.Controllers;

[Route("assignments")]
[ApiController]
public class AssignmentController: ControllerBase
{
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;

    public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
    {
        _assignmentService = assignmentService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AssignmentInsert assignmentInsert)
    {
        var assignment = _mapper.Map<Assignment>(assignmentInsert);
        await _assignmentService.Create(assignment);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(AssignmentUpdate assignmentUpdate)
    {
        var assignment = _mapper.Map<Assignment>(assignmentUpdate);
        await _assignmentService.Update(assignment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _assignmentService.Delete(id);
        return NoContent();
    }

    // [HttpPut("remove-lesson")]
    // public async Task<IActionResult> RemoveLesson(int lessonId, int assignmentId)
    // {
    //     await _assignmentService.RemoveLesson(lessonId, assignmentId);
    //     return Ok();
    // }
    //
    // [HttpPut("add-lesson")]
    // public async Task<IActionResult> AddLesson(int lessonId, int assignmentId)
    // {
    //     await _assignmentService.AddLesson(lessonId, assignmentId);
    //     return Ok();
    // }

    [HttpGet("{id}/get-sas")]
    public async Task<IActionResult> GetSASs(int id)
    {
        var SASs = await _assignmentService.GetStudentStates(id);
        return Ok(_mapper.Map<IList<StudentAssignmentStateView>>(SASs));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var assignment = await _assignmentService.Get(id);
        return Ok(_mapper.Map<AssignmentView>(assignment));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assignments = await _assignmentService.GetAll();
        return Ok(_mapper.Map<IList<AssignmentView>>(assignments));
    }
}