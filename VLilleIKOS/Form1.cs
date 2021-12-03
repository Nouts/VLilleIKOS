using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace VLilleIKOS
{

    public partial class Form1 : Form
    {
        shortVlille quaiDuWault = new shortVlille("QUAI DU WAULT");
        shortVlille rueNatio = new shortVlille("RUE NATIONALE");
        shortVlille jarVauban = new shortVlille("JARDIN VAUBAN");
        shortVlille chmpMars = new shortVlille("CHAMP DE MARS");
        shortVlille straz = new shortVlille("PLACE DE STRASBOURG");
        


        public Form1()
        {
            InitializeComponent();
            

            
            RefreshAll();


           
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshAll();
            //MessageBox.Show("REFRESH");
        }

        public void RefreshAll()
        {
            quaiDuWault.Refesh();
            rueNatio.Refesh();
            jarVauban.Refesh();
            chmpMars.Refesh();

            label1.Text = quaiDuWault.printStation();
            label2.Text = rueNatio.printStation();
            label3.Text = jarVauban.printStation();
            label4.Text = chmpMars.printStation();
            label5.Text = straz.printStation();
            label6.Text = "Dernier rafraichissement: " + DateTime.Now.ToString();
        }

        
       
        /*
private static void TimerEventProcessor(Object myObject,EventArgs myEventArgs)                                   
{
myTimer.Stop();


myTimer.Enabled = true;

}*/
    }





    public class shortVlille
    {
        public string nomDeStation;
        public string nbVelo;
        public bool connected;
        public shortVlille(string nomDeLaStation)
        {
            nomDeStation = nomDeLaStation;
            string station = nomDeLaStation.Replace(' ', '+');
            var emp = getRequest("api/records/1.0/search/?dataset=vlille-realtime&q=&facet=libelle&facet=nom&facet=commune&facet=etat&facet=type&facet=etatconnexion&refine.nom=" + station);
            nbVelo = sortComponent("nbvelosdispo", emp);
            if(emp.Contains("CONNECTED"))
            {
                connected = true;
            }
            else
            {
                connected = false;
            }
            
        }
        public void Refesh()
        {
            var emp = getRequest("api/records/1.0/search/?dataset=vlille-realtime&q=&facet=libelle&facet=nom&facet=commune&facet=etat&facet=type&facet=etatconnexion&refine.nom=" + nomDeStation);
            string station = nomDeStation.Replace(' ', '+');
            nbVelo = sortComponent("nbvelosdispo", emp);
            if (emp.Contains("CONNECTED"))
            {
                connected = true;
            }
            else
            {
                connected = false;
            }
        }
        public string printStation()
        {
            if (connected)
                return "Velos disponible " + nomDeStation + " " + nbVelo;
            else
                return nomDeStation + " deconnecté";
        }

        public string getRequest(string request)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://opendata.lillemetropole.fr/");

            HttpResponseMessage response = client.GetAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        public string sortComponent(string component, string request)
        {
            int i = request.IndexOf(component) + component.Length + 1;
            string value = "";
            while (request[i] != ',')
            {
                value += request[i];
                i++;
            }
            return value;
        }

    }
    



}

