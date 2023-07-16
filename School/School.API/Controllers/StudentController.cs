using MediatR;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;
using School.Data.AppMetaData;
using Router = School.Data.AppMetaData.Router;

namespace School.API.Controllers
{
   
    [ApiController]
    public class StudentController : AppControllerBase
    {
       
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var result =await Mediator.Send(new GetStudentListQuery());
            return Ok( result);
        }
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var result = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(result);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> Create([FromBody]AddStudentCommand addStudentCommand)
        {
            var result = await Mediator.Send(addStudentCommand);
            return NewResult(result);
        }

    }
}
