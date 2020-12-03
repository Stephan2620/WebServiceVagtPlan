namespace WebServiceVagtPlan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medarbejder")]
    public partial class Medarbejder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MedarbejderID { get; set; }

        [StringLength(30)]
        public string Navn { get; set; }

        [StringLength(30)]
        public string Telefon { get; set; }
    }
}
