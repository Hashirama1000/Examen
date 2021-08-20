using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AppTutorialesFonsus.Models
{
    public class TutorialModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TutorialId { get; set; }
        public string TutorialFecha { get; set; }
        public string TutorialDescripcion { get; set; }
        public System.Object TutorialIdpago { get; internal set; }
    }
}
