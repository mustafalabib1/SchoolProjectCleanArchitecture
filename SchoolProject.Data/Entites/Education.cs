using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entites
{
    public enum Education
    {
        [Display(Name = "Ph.D.")]
        PhD,

        [Display(Name = "M.D.")]
        MD,

        [Display(Name = "Ph.D. Candidate")]
        PhDCandidate,

        [Display(Name = "M.Sc.")]
        MSc,

        [Display(Name = "M.Sc. Student")]
        MScStudent,

        [Display(Name = "B.Sc.")]
        BSc,

        [Display(Name = "B.Sc. Student")]
        BScStudent,

        [Display(Name = "Other")]
        Other
    }
}