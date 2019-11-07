using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class ReclamationVm
    {
        [Key]
        public int Idrec { get; set; }
        public string titre { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        
        public string objet { get; set; }
        public string contenu { get; set; }

        public string type { get; set; }

        public string etat { get; set; }




    }
}