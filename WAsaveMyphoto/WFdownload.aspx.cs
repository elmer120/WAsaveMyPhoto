using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAsaveMyphoto
{
    public partial class WFdownload : System.Web.UI.Page
    {
        public string NomeUtente
        {
            get
            {
                return nomeUtente;
            }

            set
            {
                nomeUtente = value;
            }
        }

        public string IdDispositivo
        {
            get
            {
                return idDispositivo;
            }

            set
            {
                idDispositivo = value;
            }
        }

        private String nomeUtente;

        private String idDispositivo;

        private SaveMyPhotoEntities ctx;
        public SaveMyPhotoEntities Ctx
        {
            get
            {
                return ctx;
            }

            set
            {
                ctx = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //private void CreaContesto()
        //{
        //    if (this.ctx == null)
        //    {
        //        this.ctx = new SaveMyPhotoEntities();
        //    }
        //}

        //private void DownloadMedia()
        //{
        //    //recupero le variabili post
        //    this.NomeUtente = Request.Form.Get("nomeUtente");
        //    this.IdDispositivo = Request.Form.Get("idDispositivo");

        //    //recupero l'utente
        //    this.CreaContesto();

        //    Utenti utente = (from u in this.ctx.Utenti
        //                     where u.NomeUtente == nomeUtente
        //                     select u).FirstOrDefault();
            
        //    if (utente != null)
        //    {
        //        //recupero tutti i dispositivi dell'utente
        //        var dispositivi = from d in ctx.Dispositivi
        //                          where d.FKUtente == utente.ID
        //                          select d.ID;
                
        //        //per ogni dispositivo
        //        foreach (var dispositivo in dispositivi)
        //        {
        //            //recupero i media
        //            var medias = from m in ctx.Media
        //                         where m.FKDispositivo == dispositivo
        //                         select m;
                    


        //        }

        //    }



        //}
    }
}