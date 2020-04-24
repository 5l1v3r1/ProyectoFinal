﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.CORE.Cuckoo
{
    public class Mark
    {
        /// <summary>
        /// id de mark
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// id de cuckoo siganture asociado
        /// </summary>
        public int Siganture_Id { get; set; }

        /// <summary>
        /// cuckoo signature asociado
        /// </summary>
        public virtual CuckooSignature CuckooSignature { get; set; }

        /// <summary>
        /// Call de mark
        /// </summary>
        public List<MarkCall> Call { get; set; }

        /// <summary>
        /// cid de mark
        /// </summary>
        public int? Cid { get; set; }

        /// <summary>
        /// pid de mark
        /// </summary>
        public int? Pid { get; set; }

        /// <summary>
        /// tipo de mark
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// categoria de amrk
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// descripcion de mark
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ioc de mark
        /// </summary>
        public string Ioc { get; set; }

        /// <summary>
        /// section de mark
        /// </summary>
        public List<MarkSection> MarkSection { get; set; }
    }
}