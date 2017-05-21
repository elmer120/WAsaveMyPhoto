using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAsaveMyphoto
{
    public partial class WFfoto : System.Web.UI.Page
    {
        SaveMyPhotoEntities ctx;

        protected void Page_Load(object sender, EventArgs e)
        {
            getAllFoto();
        }

        private void getAllFoto()
        {
            CreaContesto();

            //recupero tutti gli utenti
            var utenti = from c in ctx.Utenti
                         select c;

            //per ogni utente
            foreach (Utenti utente in utenti)
            {
                //creo la tabella
                Table tb = new Table();
                //imposto stile tb
                tb.Style.Add("border", "1px solid black");
                
                tb.CellPadding = 5;
                tb.HorizontalAlign = HorizontalAlign.Justify;
                tb.GridLines = GridLines.Both;
                tb.ID = utente.ID.ToString();

                //aggiungo nuova riga
                TableRow tr = new TableRow();

                tr.Cells.Add(new TableHeaderCell(){Text = "ID"});
                tr.Cells.Add(new TableHeaderCell(){Text = "NomeUtente"});

                tb.Rows.Add(tr);
                    //aggiungo il contenuto
                    //creo nuova riga
                    tr = new TableRow();
                    tr.Cells.Add(new TableCell(){Text = utente.ID.ToString()});
                    tr.Cells.Add(new TableCell(){Text = utente.NomeUtente});
                    //aggiungo nuova riga
                    tb.Rows.Add(tr);
                    //AGG TABELLA AL DIV
                    divFoto.Controls.Add(tb);

                        //recupero tutti i dispositivi dell'utente
                        var dispositivi = from d in ctx.Dispositivi
                                          where d.FKUtente==utente.ID
                                          select d;
                
                        //per ogni dispositivo
                        foreach (var dispositivo in dispositivi)
                        {
                            //imposto gli header per la tb dispositivo
                            tb = new Table();
                            //imposto stile tb
                            tb.Style.Add("border", "1px solid black");

                            tb.CellPadding = 5;
                            tb.HorizontalAlign = HorizontalAlign.Justify;
                            tb.GridLines = GridLines.Both;
                            tb.ID = 'd'+dispositivo.ID.ToString();
            
                            //creo la riga
                            tr = new TableRow();
                            tr.Cells.Add(new TableHeaderCell() { Text = "ID" });
                            tr.Cells.Add(new TableHeaderCell() { Text = "Dispositivo" });
                            //aggiungo la riga
                            tb.Rows.Add(tr);

                            //aggiungo il contenuto
                            //creo la riga
                            tr = new TableRow();
                            tr.Cells.Add(new TableCell() { Text = dispositivo.ID.ToString() });
                            tr.Cells.Add(new TableCell() { Text = dispositivo.Modello });
                            //aggiungo la riga
                            tb.Rows.Add(tr);
                            //AGG TABELLA AL DIV
                            divFoto.Controls.Add(tb);

                                    //recupero tutti i media del dispositivo
                                    var medias = from m in ctx.Media
                                                            where m.FKDispositivo == dispositivo.ID
                                                            select m;
                                    //per ogni media
                                    foreach (var media in medias)
                                    {
                                        //imposto gli header per la tb media
                                        tb = new Table();
                                        //imposto stile tb
                                        tb.Style.Add("border", "1px solid black");
                                        
                                        tb.CellPadding = 5;
                                        tb.HorizontalAlign = HorizontalAlign.Justify;
                                        tb.GridLines = GridLines.Both;
                                        tb.ID = 'm'+media.ID.ToString();

                                        //creo la riga
                                        tr = new TableRow();
                                        tr.Cells.Add(new TableHeaderCell() { Text = "Nome" });
                                        tr.Cells.Add(new TableHeaderCell() { Text = "Dimensione" });
                                        tr.Cells.Add(new TableHeaderCell() { Text = "DataAquisizione" });
                                        tr.Cells.Add(new TableHeaderCell() { Text = "Height" });
                                        tr.Cells.Add(new TableHeaderCell() { Text = "Width" });
                                        tr.Cells.Add(new TableHeaderCell() { Text = "Orientamento" });
                                        tr.Cells.Add(new TableHeaderCell() { Text = "Media" });
                                        //aggiungo la riga
                                        tb.Rows.Add(tr);
                                            //aggiungo il contenuto
                                            //creo la riga
                                            tr = new TableRow();
                                            tr.Cells.Add(new TableCell() { Text = media.Nome });
                                            tr.Cells.Add(new TableCell() { Text = media.Dimensione.ToString() });
                                            tr.Cells.Add(new TableCell() { Text = media.DataAcquisizione.ToString() });
                                            tr.Cells.Add(new TableCell() { Text = media.Altezza.ToString() });
                                            tr.Cells.Add(new TableCell() { Text = media.Larghezza.ToString() });
                                            tr.Cells.Add(new TableCell() { Text = media.Orientamento.ToString() });
                                            tr.Cells.Add(new TableCell() { Text = "<img src='" + media.Percorso+"'"+"style='width:20%; height:auto;'" });
                                            //aggiungo la riga
                                            tb.Rows.Add(tr);
                                            //AGG TABELLA AL DIV
                                            divFoto.Controls.Add(tb);
                                    }
                    
                        }
                       
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