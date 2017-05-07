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
    
    public partial class Media
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Album { get; set; }
        public Nullable<System.DateTime> DataAcquisizione { get; set; }
        public int Dimensione { get; set; }
        public string Percorso { get; set; }
        public Nullable<int> Altezza { get; set; }
        public Nullable<int> Larghezza { get; set; }
        public string Formato { get; set; }
        public Nullable<int> Orientamento { get; set; }
        public Nullable<decimal> GpsLat { get; set; }
        public Nullable<decimal> GpsLong { get; set; }
        public Nullable<bool> Dispositivo { get; set; }
        public int FKDispositivo { get; set; }
    
        public virtual Dispositivi Dispositivi { get; set; }
        public virtual Foto Foto { get; set; }
        public virtual Video Video { get; set; }
    }
}
