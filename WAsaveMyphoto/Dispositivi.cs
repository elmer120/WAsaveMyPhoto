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
    
    public partial class Dispositivi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dispositivi()
        {
            this.Media = new HashSet<Media>();
        }
    
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string VersioneAndroid { get; set; }
        public int SpazioLibero { get; set; }
        public int FKUtente { get; set; }
    
        public virtual Utenti Utenti { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Media> Media { get; set; }
    }
}
