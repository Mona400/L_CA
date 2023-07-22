using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(5000)]
        public string SubjectNameAr { get; set; }
        [StringLength(5000)]
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
    }
}
