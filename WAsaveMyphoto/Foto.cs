//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WAsaveMyphoto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Foto
    {
        public int ID { get; set; }
        public Nullable<bool> Flash { get; set; }
    
        public virtual Media Media { get; set; }
    }
}