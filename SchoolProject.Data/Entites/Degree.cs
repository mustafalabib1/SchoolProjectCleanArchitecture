using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entites
{
    public enum Degree
    {
        Professor,

        [Display(Name = "Associate Professor")]
        AssociateProfessor,

        [Display(Name = "Assistant Professor")]
        AssistantProfessor,

        Instructor,

        Other
    }
}