﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.CORE.ThreatCrowd
{
    public class TCHashes
    {
        public int Id { get; set; }
        public int ThreatCrowd_Id { get; set; }
        public virtual ThreatCrowdInfo ThreatCrowdInfo { get; set; }
        public string Hash { get; set; }
    }
}
