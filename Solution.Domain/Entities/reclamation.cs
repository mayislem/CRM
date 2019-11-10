using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public enum typevm { Technique, Financiere }
    public class reclamation
    {

       [Key]
        public int Idrec { get; set; }
      //  [Required(ErrorMessage = "Vous devez saisir le titre")]
        public string titre { get; set; }

      //  [Required(ErrorMessage = "Vous devez saisir la  date")]
        public DateTime date { get; set; }
      //  [Required(ErrorMessage = "Vous devez saisir l'objet")]
        public string objet { get; set; }
      //  [Required(ErrorMessage = "Vous devez saisir le contenu")]
        public string contenu { get; set; }
      //  [Required(ErrorMessage = "Vous devez choisir l'etat")]
        public string etat { get; set; }

        public string ImageURL { get; set; }
        //[Required(ErrorMessage = "Vous devez choisir l'etat")]
        public typevm type { get; set; }
        public int? ProductId { get; set; }
        // PROP DE NAVIG
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


    }
}
