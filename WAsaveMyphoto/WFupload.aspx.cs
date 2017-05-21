using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WAsaveMyphoto
{
    public partial class WFupload : System.Web.UI.Page
    {

        private String nomeUtente;

        private String percorsoAssoluto;

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
        public string PercorsoAssoluto
        {
            get
            {
                return percorsoAssoluto;
            }

            set
            {
                percorsoAssoluto = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LeggiUpload(); 
        }


    
        private void LeggiUpload()
        {

            //recupero la collezione dei media caricati
            HttpFileCollection uploadMedias = Request.Files; 

            //recupero le variabili post
            this.NomeUtente = Request.Form.Get("nomeUtente");

            //ciclo i file
            for (int i = 0; i < uploadMedias.Count; i++)
            {
                //Salvo su filesystem
                SalvaMedia(uploadMedias[i], this.NomeUtente);
            }

        }

        private bool SalvaMedia(HttpPostedFile media, String directory)
        {
            // Leggo lo stream
            System.IO.Stream inStream = media.InputStream;
            byte[] mediaDati = new byte[media.ContentLength];
            inStream.Read(mediaDati, 0, media.ContentLength);

            //Creo l'albero delle directory se non esiste

                                   // root/Media/nomeutente/nomeFile
            this.PercorsoAssoluto = "Media" + "\\" + directory;
            Directory.CreateDirectory(Server.MapPath(this.PercorsoAssoluto));

            // Salvo il file sul server
            media.SaveAs(Server.MapPath(this.PercorsoAssoluto) + "\\" + media.FileName);

            return true;

        }

    
    }
}