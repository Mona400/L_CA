using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Models;
using School.Core.Features.Students.Queries.Results;
using School.Data.Entities;
using School.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler:ResponseHandler,
                                IRequestHandler<GetStudentListQuery,Response<List<GetStudentListResponse>>>,
                             IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>

    {                           
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentList= await _studentServices.GetListStudentsAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListResponse>>(StudentList);
            return  Success( StudentListMapper);
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentServices.GetStudentByIdAsync(request.Id);
            if(student==null)
            {
                return NotFound<GetSingleStudentResponse>("Object Not Found");
            }
            var result=_mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }
    }
}
