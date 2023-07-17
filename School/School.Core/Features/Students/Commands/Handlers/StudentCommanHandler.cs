using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Handelers
{
    public class StudentCommanHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;
        public StudentCommanHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentServices.AddAsync(studentMapper);
            if (result == "Success")
                return Created("Added Successfully");
            else
                return BadRequest<string>();
        }
    }
}
