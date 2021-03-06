﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinal.CORE
{
    public class Comment
    {
        /// <summary>
        /// Id del comentario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Usuario del comentario
        /// </summary>
        public virtual ApplicationUser User { get; set; }

        /// <summary>
        /// Id del usuario que ha escrito el comentario
        /// </summary>
        [ForeignKey("User")]
        public string User_Id { get; set; }

        /// <summary>
        /// Malware del comentario
        /// </summary>
        public virtual Malware Malware { get; set; }

        /// <summary>
        /// Id del malware asociado al comentario
        /// </summary>
        [ForeignKey("Malware")]
        public int Malware_Id { get; set; }

        /// <summary>
        /// Comentario escrito por el usuario
        /// </summary>
        public string TextComment { get; set; }


    }
}
