namespace WebServiceVagtPlan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VagtPlan")]
    public partial class VagtPlan
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Navn { get; set; }

        [Required]
        [StringLength(30)]
        public string Stilling { get; set; }
    }
}
