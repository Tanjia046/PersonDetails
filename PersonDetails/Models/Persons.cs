using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonDetails.Models
{
    public class Persons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(50)]
        public string Address { get; set; }


        [Required]
        [StringLength(50)]
        public string Occupation { get; set; }


        [Required]
        [StringLength(50)]
        public string Area { get; set; }


        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactNo { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }


        [Required]       
        public bool IsActive { get; set; }

    }
}