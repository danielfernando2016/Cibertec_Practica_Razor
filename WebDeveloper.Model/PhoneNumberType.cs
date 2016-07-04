using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDeveloper.Model
{
    [Table("Person.PhoneNumberType")]
    public partial class PhoneNumberType
    {
        //public PhoneNumberType()
        //{
        //    PersonPhone = new HashSet<PersonPhone>();
        //}

        public int PhoneNumberTypeID { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50)]
        public string Name { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Modified Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDate { get; set; }

        
        //public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
