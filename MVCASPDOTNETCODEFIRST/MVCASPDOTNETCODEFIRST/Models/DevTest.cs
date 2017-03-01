using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCASPDOTNETCODEFIRST.Models
{

    public class DevTest
    {
        [Key]
        public virtual int ID { get; set; }
        [MaxLength(255)]
        public virtual string CampaignName { get; set; }

        public virtual DateTime? Date { get; set; }

        public virtual int? Clicks { get; set; }

        public virtual int? Conversions { get; set; }

        public virtual int? Impressions { get; set; }
        [MaxLength(255)]
        public virtual string AffiliateName { get; set; }

        

    }
}