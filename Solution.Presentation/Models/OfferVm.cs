using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Presentation.Models
{
    public class OfferVm
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public int? ProductId { get; set; }

        public ProductVm productvm { get; set; }

        public List<SelectListItem> CourseCategoryList { get; set; } //Use it to store the Category information

    }
}