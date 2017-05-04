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
        protected void Page_Load(object sender, EventArgs e)
        {
            SaveFile();
            /*
            string summary;
            summary = "|Metodo: " + Request.HttpMethod +
                  "<br>|Headers: " + Request.Headers +
                "  <br>|Content type: " + Request.ContentType +
                "  <br>|Input lenght: " + Request.InputStream.Length;

            HttpFileCollection uploadFiles = Request.Files;

            // Build HTML listing the files received.
            summary += "<br> File: " + uploadFiles.Count;



            // Loop over the uploaded files and save to disk.
            int i;
            for (i = 0; i < uploadFiles.Count; i++)
            {
                HttpPostedFile postedFile = uploadFiles[i];

                // Access the uploaded file's content in-memory:
                System.IO.Stream inStream = postedFile.InputStream;
                byte[] fileData = new byte[postedFile.ContentLength];
                inStream.Read(fileData, 0, postedFile.ContentLength);

                // Save the posted file in our "data" virtual directory.
                postedFile.SaveAs(Server.MapPath("files") + "\\" + postedFile.FileName);

                // Also, get the file size and filename (as specified in
                // the HTML form) for each file:
                summary += postedFile.FileName + ": "
                    + postedFile.ContentLength.ToString() + " bytes";
            }




            lblLog.Text = summary;*/
        }


        private string[] fotoEstensioni = { ".jpg", ".png", ".jpeg", ".bmp" };

        private String nomeUtente;

        private String idDispositivo;

        private String album;

        private String percorsoAssoluto;

        private SaveMyPhotoEntities ctx;
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

        public string Album
        {
            get
            {
                return album;
            }

            set
            {
                album = value;
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

        private void SaveFile()
        {

            //recupero la collezione dei media caricati
            HttpFileCollection uploadMedias = Request.Files;
            

            //recupero le variabili post
            this.NomeUtente = Request.Form.Get("nomeUtente");
            this.IdDispositivo = Request.Form.Get("idDispositivo");

            //ciclo i file
            for (int i = 0; i < uploadMedias.Count; i++)
            {
                //controllo l'estensione

                if (fotoEstensioni.Contains(Path.GetExtension(uploadMedias[i].FileName)))
                {
                    SaveMedia(uploadMedias[i], this.NomeUtente, this.IdDispositivo, "Foto");
                }
                else
                {
                    SaveMedia(uploadMedias[i], this.NomeUtente, this.IdDispositivo, "Video");
                }
            }

        }

        private bool SaveMedia(HttpPostedFile media, String directory, String subDirectory, String tipo)
        {
            // Leggo lo stream
            System.IO.Stream inStream = media.InputStream;
            byte[] mediaDati = new byte[media.ContentLength];
            inStream.Read(mediaDati, 0, media.ContentLength);

            //Creo l'albero delle directory se non esiste
            this.percorsoAssoluto = "Media" + "\\" + directory + "\\" + subDirectory + "\\" + tipo;
            Directory.CreateDirectory(Server.MapPath(percorsoAssoluto));

            // Salvo il file sul server
            media.SaveAs(Server.MapPath(percorsoAssoluto) + "\\" + media.FileName);

            return true;

        }

    
    }
}