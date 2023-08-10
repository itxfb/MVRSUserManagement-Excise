using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.ViewModels.VehicleRegistration.Core
{
    public class VwApplicationStatus
    {
        public long ApplicationId { get; set; }

        public long ApplicationTypeId { get; set; }
        public string ApplicationType { get; set; }

        public long ApplicationStatusId { get; set; }
        public string ApplicationStatus { get; set; }

        public long ApplicationPhaseId { get; set; }
        public string ApplicationPhase { get; set; }
    }    
}
