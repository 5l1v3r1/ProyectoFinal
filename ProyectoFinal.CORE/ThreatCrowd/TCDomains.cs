﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinal.CORE.ThreatCrowd
{
    public class TCDomains
    {
        public int Id { get; set; }

        public virtual ThreatCrowdInfo ThreatCrowdInfo { get; set; }

        [ForeignKey("ThreatCrowdInfo")]
        public int ThreatCrowd_Id { get; set; }

        

        public string Domain { get; set; }
    }
}
