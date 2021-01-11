namespace WebServiceVagtPlan
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NyVagt")]
    public partial class NyVagt
    {
        public int NyVagtID { get; set; }

        [StringLength(30)]
        public string NyVagtNavn { get; set; }

        [StringLength(30)]
        public string NyVagtAfdeling { get; set; }

        [StringLength(30)]
        public string NyVagtLokation { get; set; }

        [StringLength(30)]
        public string NyVagtTid { get; set; }

        [StringLength(30)]
        public string NyVagtDato { get; set; }
    }
}
