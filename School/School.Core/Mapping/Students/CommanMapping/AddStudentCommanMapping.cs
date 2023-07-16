using AutoMapper;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Mapping.Students
{
  public partial class StudentProfile : Profile
    {
        public void AddStudentCommanMapping()
        {
            CreateMap<AddStudentCommand, Student>()
                .ForMember(des => des.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
