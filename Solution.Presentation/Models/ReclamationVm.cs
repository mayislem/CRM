using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Models
{
    public enum typevm { Technique, Financiere }
    public class ReclamationVm
    {
        [Key]
        public int Idrec { get; set; }
        [Required(ErrorMessage = "Vous devez saisir le titre")]
        public string titre { get; set; }
      
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
    // [Required(ErrorMessage = "Vous devez saisir l'objet")]
        public string objet { get; set; }
    //  [Required(ErrorMessage = "Vous devez saisir le contenu")]
        public string contenu { get; set; }
     //   [Required(ErrorMessage = "Vous devez saisir le type")]

        public typevm type { get; set; }
   //     [Required(ErrorMessage = "Vous devez saisir l'etat")]
        public string etat { get; set; }
        public string ImageURL { get; set; }
        [Display(Name = "reclamation Product")]
        public int? ProductId { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> types { get; set; }



    }
}