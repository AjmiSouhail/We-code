//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace We_code.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inscription
    {
        public int InscriptionID { get; set; }
        public int FormationID { get; set; }
        public int EmployeID { get; set; }
        public System.DateTime DateInscription { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual Formation Formation { get; set; }
        public virtual Participer Participer { get; set; }
    }
}
