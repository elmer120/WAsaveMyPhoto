using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WAsaveMyphoto
{
    public partial class WFfoto : System.Web.UI.Page
    {
        SaveMyPhotoEntities ctx;
        int utenteId;

        public int UtenteId
        {
            get
            {
                return utenteId;
            }

            set
            {
                utenteId = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //se è autenticato
            if (Session["id"] != null)
            {
                this.UtenteId = (int)Session["id"];
                getMedia(this.UtenteId);
            }
            else
            {
                Response.Redirect("./Index.aspx");
            }
        }

        private void getMedia(int utenteId)
        {
            CreaContesto();
            int filtro = int.Parse(Request.QueryString["id"]);
            //recupero tutti i dispositivi dell'utente
            var dispositivi = from d in ctx.Dispositivi
                              where d.FKUtente==utenteId
                              select d;

            //creo il menu
            CreaNavBar(dispositivi, filtro);
            //genero la galleria richiesta
            GeneraGallery(dispositivi,utenteId, filtro);
 
                        ////per ogni dispositivo
                        //foreach (var dispositivo in dispositivi)
                        //{
                        //    //creo la tabella
                        //    Table tb = new Table();
                        //    //imposto gli header per la tb dispositivo
                        //    tb = new Table();
                        //    //imposto stile tb
                        //    tb.Style.Add("border", "1px solid black");

                        //    tb.CellPadding = 5;
                        //    tb.HorizontalAlign = HorizontalAlign.Justify;
                        //    tb.GridLines = GridLines.Both;
                        //    tb.ID = 'd'+dispositivo.ID.ToString();

                        //    //aggiungo nuova riga
                        //    TableRow tr = new TableRow();
                        //    //creo la riga
                        //    tr = new TableRow();
                        //    tr.Cells.Add(new TableHeaderCell() { Text = "ID" });
                        //    tr.Cells.Add(new TableHeaderCell() { Text = "Dispositivo" });
                        //    //aggiungo la riga
                        //    tb.Rows.Add(tr);

                        //    //aggiungo il contenuto
                        //    //creo la riga
                        //    tr = new TableRow();
                        //    tr.Cells.Add(new TableCell() { Text = dispositivo.ID.ToString() });
                        //    tr.Cells.Add(new TableCell() { Text = dispositivo.Modello });
                        //    //aggiungo la riga
                        //    tb.Rows.Add(tr);
                        //    //AGG TABELLA AL DIV
                        //    divMedia.Controls.Add(tb);

                        //            //recupero tutti i media del dispositivo
                        //            var medias = from m in ctx.Media
                        //                                    where m.FKDispositivo == dispositivo.ID
                        //                                    select m;
                        //            //per ogni media
                        //            foreach (var media in medias)
                        //            {
                        //                //imposto gli header per la tb media
                        //                tb = new Table();
                        //                //imposto stile tb
                        //                tb.Style.Add("border", "1px solid black");
                                        
                        //                tb.CellPadding = 5;
                        //                tb.HorizontalAlign = HorizontalAlign.Justify;
                        //                tb.GridLines = GridLines.Both;
                        //                tb.ID = 'm'+media.ID.ToString();

                        //                //creo la riga
                        //                tr = new TableRow();
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "Nome" });
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "Dimensione" });
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "DataAquisizione" });
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "Height" });
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "Width" });
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "Orientamento" });
                        //                tr.Cells.Add(new TableHeaderCell() { Text = "Media" });
                        //                //aggiungo la riga
                        //                tb.Rows.Add(tr);
                        //                    //aggiungo il contenuto
                        //                    //creo la riga
                        //                    tr = new TableRow();
                        //                    tr.Cells.Add(new TableCell() { Text = media.Nome });
                        //                    tr.Cells.Add(new TableCell() { Text = media.Dimensione.ToString() });
                        //                    tr.Cells.Add(new TableCell() { Text = media.DataAcquisizione.ToString() });
                        //                    tr.Cells.Add(new TableCell() { Text = media.Altezza.ToString() });
                        //                    tr.Cells.Add(new TableCell() { Text = media.Larghezza.ToString() });
                        //                    tr.Cells.Add(new TableCell() { Text = media.Orientamento.ToString() });
                        //                    tr.Cells.Add(new TableCell() { Text = "<img src='" + media.Percorso+"'"+"style='width:20%; height:auto;'" });
                        //                    //aggiungo la riga
                        //                    tb.Rows.Add(tr);
                        //                    //AGG TABELLA AL DIV
                        //                    divMedia.Controls.Add(tb);
                        //            }
                        //} 
        }


        private void CreaNavBar(IQueryable<Dispositivi> dispositivi,int dispositivoRichiesto)
       {
            //PATTERN DA GENERARE
            // < li class="active"><a href = "#" > Home </ a ></ li >
            HtmlGenericControl li = new HtmlGenericControl("li");
            if(dispositivoRichiesto==-1)
            {
                li.Attributes.Add("class", "active");
            }
            HtmlGenericControl anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("href", "WFfoto.aspx?id=-1");
            anchor.InnerText = "Le mie foto";
            li.Controls.Add(anchor);
            navMenu.Controls.Add(li);
            

            foreach (var dispositivo in dispositivi)
            {
                
                //PATTERN DA GENERARE
                // < li >< a href="#">Page 1</a></li>
                // <li><a href = "#" > Page 2</a></li>
                // <li><a href = "#" > Page 3</a></li>

                li = new HtmlGenericControl("li");

                if (dispositivo.ID == dispositivoRichiesto)
                {
                    li.Attributes.Add("class", "active");
                }

                anchor = new HtmlGenericControl("a");

                anchor.Attributes.Add("href", "WFfoto.aspx?id="+dispositivo.ID);
                anchor.Attributes.Add("class", "glyphicon glyphicon-phone");
                anchor.InnerText = dispositivo.Modello;

                li.Controls.Add(anchor);
                navMenu.Controls.Add(li);

            }
            //btn logout
            li = new HtmlGenericControl("li");
            HtmlGenericControl p = new HtmlGenericControl("p");
            p.Attributes.Add("class", "navbar-btn");
            anchor = new HtmlGenericControl("a");
            anchor.Attributes.Add("class", "btn btn-default");
            anchor.Attributes.Add("href", "Logout.aspx");
            anchor.InnerText = "LogOut";
            li.Controls.Add(anchor);
            navMenu.Controls.Add(li);
        }

        private void GeneraGallery(IQueryable<Dispositivi> dispositivi,int idUtente,int filtro)
        {
            IQueryable<Media> medias;
            
            if (filtro != -1)
            {

                //recupero tutti i media del dispositivo
                medias = from m in ctx.Media
                             where m.FKDispositivo == filtro
                             select m;
            }
            else
            {
                List<int> idDisp = new List<int>();
                foreach (var dispositivo in dispositivi)
                {
                    idDisp.Add(dispositivo.ID);
                }
                //recupero tutti i media del utente
                medias = from m in ctx.Media
                             where idDisp.Contains(m.FKDispositivo)
                             select m;
            }

            //popolo la galleria
            //pattern da generare
            //    < div class="row">
            //      <div class="col-sm-6 col-md-4">
            //          <a class="lightbox" href="images/park.jpg">
            //              <img src = "images/park.jpg" alt="Park">
            //          </a>
            //      </div>
            //    </div>

            HtmlGenericControl divRiga = new HtmlGenericControl("div");
            divRiga.Attributes.Add("class", "row");

            foreach (var media in medias)
            {
                HtmlGenericControl divColonna = new HtmlGenericControl("div");
                divColonna.Attributes.Add("class", "col-sm-6 col-md-4");

                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("class", "lightbox");
                anchor.Attributes.Add("href", media.Percorso);

                HtmlGenericControl img = new HtmlGenericControl("img");
                img.Attributes.Add("src", media.Percorso);

                //assemblo il tutto
                anchor.Controls.Add(img);
                divColonna.Controls.Add(anchor);
                divRiga.Controls.Add(divColonna);
                galleria.Controls.Add(divRiga);
            }

        }

        private void CreaContesto()
        {
            if (this.ctx == null)
            {
                this.ctx = new SaveMyPhotoEntities();
            }
        }
    }
}