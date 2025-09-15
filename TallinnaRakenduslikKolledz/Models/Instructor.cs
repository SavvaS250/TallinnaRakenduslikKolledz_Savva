using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Perekonnanimi")]
        public string LastName {  get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Eesnimi")]
        public string Firstname { get; set; }

        [Display(Name = "Õpetaja nimi")]
        public string Fullname 
        { 
            get { return LastName + ", " + Firstname; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Tööletulemiskuupäev")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment {  get; set; }
        [Display(Name = "Õpetaja Email")]
        public string? Email { get; set; }
        public int? Boyfriends { get; set; }
        public string? Phone {  get; set; }


    }
}
