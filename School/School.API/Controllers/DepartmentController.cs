using Microsoft.AspNetCore.Mvc;
using School.API.Base;
using School.Core.Features.Departments.Queries.Models;
using School.Data.AppMetaData;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> DepartmentById([FromQuery] GetDepartmentsByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return NewResult(result);
        }
    }
}
