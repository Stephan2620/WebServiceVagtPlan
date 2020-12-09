namespace WebServiceVagtPlan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vagt")]
    public partial class Vagt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VagtID { get; set; }

        [StringLength(30)]
        public string Afdeling { get; set; }

        [StringLength(30)]
        public string Lokation { get; set; }

        [StringLength(30)]
        public string Tid { get; set; }
    }
}
