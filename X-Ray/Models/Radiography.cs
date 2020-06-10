using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using X_Ray.Enums;

namespace X_Ray.Models
{
    public class Radiography
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] public string PatientCode { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        public string NameOfFather { get; set; }
        public string NameOfMother { get; set; }
        [Required] public string InsuranceCode { get; set; }
        public Enumeration.Gender Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required] public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string WorkingPhone { get; set; }
        [Required] public string MobilePhone { get; set; }
        [Required] public string RadiographyCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required] public DateTime DateOfSubmission { get; set; }
        public string Reasoning { get; set; }
        public string RadiographyActions { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SuggestedDate { get; set; }
        public TimeSpan SuggestedDateTime { get; set; }
        [Required] public Enumeration.Priority Priority { get; set; }
        public virtual ApplicationUser Doctor { get; set; }
        public Enumeration.Status Status { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        public ApplicationUser ModifiedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Modified { get; set; }


    }

}