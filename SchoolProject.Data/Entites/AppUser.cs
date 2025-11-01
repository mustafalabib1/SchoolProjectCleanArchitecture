using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class AppUser : IdentityUser
    {
        public Title? title { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        // --- Education & Affiliation ---
        [Required]
        public Education Education { get; set; }

        [Required]
        public Degree Degree { get; set; }

        public string? SpecificFieldOfStudy { get; set; }

        [Required]
        public string Affiliation { get; set; }

        // --- Contact & Location ---
        [Required]
        public string MobileNumber { get; set; } // Separate from the default 'PhoneNumber'

        public string? HomePage { get; set; }

        [Required]
        public LookUpCountry Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalAddress { get; set; }
        [EmailAddress]
        public string? AlternativeEmailAddress { get; set; }

        // --- Account & ID ---
        [Required]
        public string PassportPhotoPath { get; set; } // Stores the file path or URL for the photo
    }
}