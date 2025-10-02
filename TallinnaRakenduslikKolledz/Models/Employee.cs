using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        public string FirstName { get; set; }

        [Display(Name = "Töötaja nimi")]
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Tööletulemiskuupäev")]
        public DateTime HireDate { get; set; }
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }
        public int? InstructorID { get; set; }
        public int? Salary { get; set; }
        public int? DepartentID { get; set; }
        public int? PeopleMurdered { get; set; }
    }
}
