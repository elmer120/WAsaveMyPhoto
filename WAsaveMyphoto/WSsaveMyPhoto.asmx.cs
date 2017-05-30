using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace WAsaveMyphoto
{
    /// <summary>
    /// Descrizione di riepilogo per WSsaveMyPhoto
    /// </summary>
    [WebService(Namespace = "http://it.pedrazzi.marco.savemyphoto/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSsaveMyPhoto : System.Web.Services.WebService
    {
        //IMPLEMENTARE CONTROLLI SUI DATI IN INGRESSO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


        //context db
        SaveMyPhotoEntities ctx;

        //Crea il contesto
        private void CreaContesto()
        {
            if (this.ctx == null)
            {
                this.ctx = new SaveMyPhotoEntities();
            }
        }

        /// <summary>
        /// Controlla se l'utente inserito esiste nel database
        /// </summary>
        /// <param name="nomeUtente"></param>
        /// <returns></returns>
        private bool UtenteCheck(String nomeUtente)
        {

            if (nomeUtente != null)
            {
                if (nomeUtente != "")
                {

                    this.CreaContesto();

                    Utenti utente = (from u in this.ctx.Utenti
                                     where u.NomeUtente == nomeUtente
                                     select u).FirstOrDefault();
                    //se esiste già un utente
                    if (utente != null)
                    {
                        return true;
                    }
                }
                return false;
            }

            return false;
        }

        /// <summary>
        /// Recupera l'id del utente se presente
        /// </summary>
        /// <param name="nomeUtente"></param>
        /// <returns></returns>
        private int GetIdUtente(String nomeUtente)
        {

            if (nomeUtente != null)
            {
                if (nomeUtente != "")
                {

                    this.CreaContesto();

                    Utenti utente = (from u in this.ctx.Utenti
                                     where u.NomeUtente == nomeUtente
                                     select u).First();
                    //se esiste 
                    if (utente != null)
                    {
                        return utente.ID;
                    }
                }
                return -1;
            }

            return -1;
        }


        /// <summary>
        /// Associa un nuovo dispositivo a un utente già presente
        /// </summary>
        /// <param name="macAddr"></param>
        /// <param name="marca"></param>
        /// <param name="modello"></param>
        /// <param name="versioneAndroid"></param>
        /// <param name="spazioLibero"></param>
        /// <param name="fkUtente"></param>
        /// <returns>FkDispositivo</returns>

        private int RegistrazioneNuovoDispositivo(String marca, String modello, String versioneAndroid, int spazioLibero, int fkUtente)
        {
            this.CreaContesto();

                //aggiungo il dispositivo
                Dispositivi dispositivo = ctx.Dispositivi.Add(new Dispositivi()
                {
                    Marca = marca,
                    Modello = modello,
                    VersioneAndroid = versioneAndroid,
                    SpazioLibero = spazioLibero,
                    FKUtente = fkUtente
                });
                try
                {
                    //Salvo i cambiamenti in caso contrario Roolback
                    if (ctx.SaveChanges() > 0)
                    {
                        return dispositivo.ID;
                    }
                }
                catch (Exception)
                {

                    return -1;
                }


                return -1;
            
        }

        /// <summary>
        /// Debug per saveChanges
        /// </summary>
        /// <param name="context"></param>
        private void SaveChanges(SaveMyPhotoEntities context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

        //----------------------------------ACCEDI--------------------------------------------------------------------------

        /// <summary>
        /// Controlla che il nome utente inserito esista e che la password sia corretta
        /// </summary>
        /// <param name="nomeUtente"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [WebMethod]
        public bool CredenzialiCheck(String nomeUtente, String password)
        {

            if (nomeUtente != null && nomeUtente != "")
            {
                //se l'utente esiste e password non è vuota
                if (UtenteCheck(nomeUtente) && password != null && password != "")
                {

                    this.CreaContesto();

                    Utenti utente = (from u in this.ctx.Utenti
                                     where u.NomeUtente == nomeUtente
                                     select u).First();
                    //password corretta?
                    if (utente.Password == Servizi.md5(password))
                    {
                        return true;
                    }
                    return false;
                }

            }

            return false;
        }

        /// <summary>
        /// Associa un nuovo dispositivo ad un utente già presente
        /// </summary>
        /// <param name="macAddr"></param>
        /// <param name="marca"></param>
        /// <param name="modello"></param>
        /// <param name="versioneAndroid"></param>
        /// <param name="spazioLibero"></param>
        /// <param name="fkUtente"></param>
        /// <returns></returns>
        [WebMethod]
        public int AssociaNuovoDispositivo(String marca, String modello, String versioneAndroid, int spazioLibero, String nomeUtente)
        {
            this.CreaContesto();

            
                //recupero l'id del utente
                int fkUtente = GetIdUtente(nomeUtente);
                if (fkUtente != -1)
                {
                    //aggiungo il dispositivo
                    Dispositivi dispositivo = ctx.Dispositivi.Add(new Dispositivi()
                    {
                        Marca = marca,
                        Modello = modello,
                        VersioneAndroid = versioneAndroid,
                        SpazioLibero = spazioLibero,
                        FKUtente = fkUtente
                    });
                    try
                    {
                        //Salvo i cambiamenti in caso contrario Roolback
                        if (ctx.SaveChanges() > 0)
                        {
                        return dispositivo.ID;
                        }
                    }
                    catch (Exception)
                    {

                        return -1;
                    }
                }

                return -1;
            
        }

        //----------------------------------FINE ACCEDI--------------------------------------------------------------------------


        //----------------------------------REGISTRAZIONE-------------------------------------------------------------------------
        /// <summary>
        /// Registra un nuovo utente nel db
        /// </summary>
        /// <param name="nomeUtente"></param>
        /// <param name="mail"></param>
        /// <param name="password"></param>
        /// <param name="macAddr"></param>
        /// <param name="marca"></param>
        /// <param name="modello"></param>
        /// <param name="versioneAndroid"></param>
        /// <param name="spazioLibero"></param>
        /// <returns>fkDispositivo</returns>
        [WebMethod]
        public int RegistrazioneNuovoUtente(String nomeUtente, String mail, String password, String marca, String modello, String versioneAndroid, int spazioLibero)
        {

            //se l'utente non esiste già
            if (!UtenteCheck(nomeUtente))
            {
                this.CreaContesto();

                //aggiungo il nuovo utente
                Utenti utente = this.ctx.Utenti.Add(new Utenti()
                {
                    NomeUtente = nomeUtente,
                    //DATA NASCITA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    Mail = mail,
                    Password = Servizi.md5(password)
                });


                //Registro il dispositivo 
                return RegistrazioneNuovoDispositivo(marca, modello, versioneAndroid, spazioLibero, utente.ID);
              
            }
            return -1;
        }
        //----------------------------------FINE REGISTRAZIONE-------------------------------------------------------------------------

        //-------------------------------------GESTIONE MEDIA----------------------------------------------------------------------------

        /// <summary>
        /// Inserisce il record per il media caricato attraverso la pagina WFupload.aspx 
        /// </summary>
        /// <param name="nomeFile"></param>
        /// <returns></returns>
        [WebMethod]
        public bool AggiungiMedia(String nomeFile,String album,DateTime dataAcquisizione,int dimensione,String nomeUtente,int altezza,int larghezza,String formato,String orientamento,Double gpsLat,Double gpsLong,int fkDispositivo)
        {
            CreaContesto();
            
            //recupero il percorso dove è stato salvato
            String percorso = "Media" + "\\" + nomeUtente + "\\" + nomeFile;


            //creo il nuovo record e imposto che il media è ancora presente sul dispositivo
            Media media = this.ctx.Media.Add(new Media()
            {
                Nome = nomeFile,
                Album = album,
                DataAcquisizione = dataAcquisizione,
                Dimensione = dimensione,
                Percorso = percorso,
                Altezza = altezza,
                Larghezza = larghezza,
                Formato = formato,
                Orientamento = Convert.ToInt32(orientamento),
                GpsLat = (decimal)gpsLat,
                GpsLong = (decimal)gpsLong,
                Dispositivo = true,
                FKDispositivo = fkDispositivo,
            });

            
            //salvo i cambiamenti
            if (ctx.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
        
        
        /// <summary>
        /// Aggiorna il media quando viene rimosso dal dispositivo
        /// </summary>
        /// <returns></returns>
        /// 
        [WebMethod]

        public bool AggiornaMedia(int fkDispositivo,String nomeFile)
        {
            CreaContesto();

            //recupero il media
            Media media = (from Media in ctx.Media
                           where Media.FKDispositivo == fkDispositivo
                           where Media.Nome == nomeFile
                           select Media).First();
            //imposto che il media non è più presente sul dispositivo
            media.Dispositivo = false;

            //salvo i cambiamenti
            if(ctx.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Ritorna la lista dei media di tutti i dispositivi tranne quelli che ci sono già sul dispositivo
        /// </summary>
        /// <param name="nomeUtente"></param>
        /// <param name="nomeFile"></param>
        /// <returns></returns>
        [WebMethod]
        public List<String> CheckMediaOnServer(String nomeUtente, int idDispositivo)
        {
            CreaContesto();
            List<String> listMedia = new List<String>();
            //recupero tutti i dispositivi dell'utente
            int idUtente = (from u in ctx.Utenti
                            where u.NomeUtente == nomeUtente
                            select u.ID).FirstOrDefault();

            var dispositivi = from d in ctx.Dispositivi
                              where d.FKUtente == idUtente
                              select d;

            if (dispositivi != null)
            {
                //per ogni dispositivo
                foreach (var dispositivo in dispositivi)
                {
                    //per gli altri dispositivi recupero tutti i media
                    if (dispositivo.ID != idDispositivo)
                    {
                        //recupero i media
                        var medias = (from m in ctx.Media
                                      where m.FKDispositivo == dispositivo.ID
                                      select m).ToList();

                        if (medias != null)
                        {
                            //per ogni media
                            foreach (var media in medias)
                            {
                                listMedia.Add(media.DataAcquisizione.ToString());
                                listMedia.Add(media.Percorso);
                                listMedia.Add(media.Nome);
                                listMedia.Add(media.Formato);
                                listMedia.Add(media.Dimensione.ToString());
                                listMedia.Add(media.Altezza.ToString());
                                listMedia.Add(media.Larghezza.ToString());
                                listMedia.Add(media.Orientamento.ToString());
                                listMedia.Add(media.GpsLat.ToString());
                                listMedia.Add(media.GpsLong.ToString());
                            }
                        }
                    }
                    //per il dispositivo che fa richesta della lista recupero solo quelle che sono solo sul server
                    else
                    {
                        //recupero i media che hanno dispositivo a 0
                        var medias = (from m in ctx.Media
                                      where m.FKDispositivo == dispositivo.ID
                                      && m.Dispositivo==false
                                      select m).ToList();

                        if (medias != null)
                        {
                            //per ogni media
                            foreach (var media in medias)
                            {
                                listMedia.Add(media.DataAcquisizione.ToString());
                                listMedia.Add(media.Percorso);
                                listMedia.Add(media.Nome);
                                listMedia.Add(media.Formato);
                                listMedia.Add(media.Dimensione.ToString());
                                listMedia.Add(media.Altezza.ToString());
                                listMedia.Add(media.Larghezza.ToString());
                                listMedia.Add(media.Orientamento.ToString());
                                listMedia.Add(media.GpsLat.ToString());
                                listMedia.Add(media.GpsLong.ToString());
                            }
                        }
                    }
                }
                return listMedia;
            }
            return listMedia;
        }
 

        //-------------------------------------FINE GESTIONE MEDIA-----------------------------------------------------------------------



        //--------------------------------METODI NULLI---------------------------------------------------------------------------------
        [WebMethod]
        public bool ResetSistema()
        {
            this.CreaContesto();

            //prima svuota le tb con FK
            var listOfTables = new List<string> { "Video", "Foto", "Media", "Dispositivi", "Utenti" };

            foreach (var tableName in listOfTables)
            {
                ctx.Database.ExecuteSqlCommand("DELETE FROM [" + tableName + "]");
            }

            //se è andato a buon fine
            if (ctx.SaveChanges() > 0)
            {
                return true;

            }
            return false;
        }


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HelloWorldP(int i)
        {
            return "Hello World" + i;
        }

        [WebMethod]
        public string HelloWorldTest()
        {
            return "Hello World";
        }


        [WebMethod]
        public string HelloWorldTestTest()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HelloWorldTestTestTest()
        {
            return "Hello World";
        }
    }
}
