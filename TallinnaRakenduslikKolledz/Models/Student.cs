using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }

        public int? Phone {  get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
    }
}
