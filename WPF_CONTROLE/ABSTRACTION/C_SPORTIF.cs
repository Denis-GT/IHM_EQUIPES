//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_CONTROLE.ABSTRACTION
{
    using System;
    using System.Collections.Generic;
    
    public partial class C_SPORTIF
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string NumAdherent { get; set; }
        public int? Equipe_Id { get; set; }
    
        public virtual C_EQUIPE EQUIPES { get; set; }
    }
}
