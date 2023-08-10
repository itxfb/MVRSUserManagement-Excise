using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwVehicleArticleDelivery
    {
        public long VehicleArticleDeliveryId { get; set; }
        //public long ArticleDeliveryId { get; set; }

        public long ApplicationId { get; set; }

        public long VehicleArticleId { get; set; }
        public string VehicleArticleName { get; set; }

       
        public string Name { get; set; }

       
        public string FatherName { get; set; }

        
        public string CNIC { get; set; }

        
        public string Mobile { get; set; }

       
        public string Address { get; set; }

        
        public string Remarks { get; set; }

    }
}
