using Models.DatabaseModels.VehicleRegistration.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DatabaseModels.VehicleRegistration.Core
{
    public class VehicleArticleDelivery : BaseModel
    {
        [Key]
        public long ArticleDeliveryId { get; set; }

        //[Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string FatherName { get; set; }

        [StringLength(20)]
        public string CNIC { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [ForeignKey("Application")]
        public long ApplicationId { get; set; }
        public virtual Application Application { get; set; }


        [ForeignKey("VehicleArticles")]
        public long VehicleArticleId { get; set; }
        public virtual VehicleArticle VehicleArticle { get; set; }
    }
}
