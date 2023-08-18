using System.ComponentModel.DataAnnotations;

namespace testTechniqueWeCount.Models
{
    public class Candidature
    {
        [Key]
        public int Id { get; set; }
        public String? Nom { get; set; }
        public String? Prenom { get; set; }
        public String? Mail { get; set; }
        public String? Telephone { get; set; }
        public String? NiveauEtude { get; set; }
        public int AnneeExperience { get; set; }
        public String? DernierEmployeur { get; set; }
        public String? CvPath  { get; set; }
    }
}
