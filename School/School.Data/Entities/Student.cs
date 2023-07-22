using School.Data.Commans;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        [Key]
        public int StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department Department { get; set; }
    }
}
