using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAg_Predictor
{
    public partial class outForm : Form
    {
        //Date initiale
        public string traceFilePath {  get; set; }
        public string traceFileName { get; set; }
        public int numarBitiPredictie {  get; set; }
        public int numarIntrariInTabela {  get; set; }
        public string arhitecturaAleasa {  get; set; }
        public int bitiHR {  get; set; }
        public int bitiLRU {  get; set; }

        //Date rezultate dupa simulare
        public int instructiuniJumpNefacute { get; set; }
        public int instructiuniJumpFacute {  get; set; }
        public int numarHIT {  get; set; }
        public int numarMISS {  get; set; }
        public int predictiiCorecte {  get; set; }
        public int predictiiIncorecte {  get; set; }


        public outForm()
        {
            InitializeComponent();
        }

        internal void showSimulationResults()
        {
            int totalSalturi = instructiuniJumpFacute + instructiuniJumpNefacute;
            double procentSalturiFacute = (instructiuniJumpFacute * 100.0) / totalSalturi;
            procentSalturiFacute = Math.Round(procentSalturiFacute, 3);
            double procentSalturiNefacute = (instructiuniJumpNefacute * 100.0) / totalSalturi;
            procentSalturiNefacute = Math.Round(procentSalturiNefacute, 3);

            int totalHitMiss = numarHIT + numarMISS;
            double procentHit = Math.Round(((numarHIT * 100.0) / totalHitMiss),3);
            double procentMiss = Math.Round(((numarMISS * 100.0) / totalHitMiss),3);

            int totalPredictii = predictiiCorecte + predictiiIncorecte;
            double procentPredictiiCorecte = Math.Round(((predictiiCorecte * 100.0) / totalPredictii), 3);
            double procentPredictiiIncorecte= Math.Round(((predictiiIncorecte * 100.0) / totalPredictii), 3);

            traceFileLabel.Text = "Trace File Name: "+ traceFileName;
            totalSalturiTextBox.Text = totalSalturi.ToString();
            salturiFacuteTextBox.Text = instructiuniJumpFacute.ToString();
            salturiNefacuteTextBox.Text = instructiuniJumpNefacute.ToString();
            numarMissTextBox.Text=numarMISS.ToString();
            numarHitTextBox.Text = numarHIT.ToString();
            procSalturiFacuteTextBox.Text = procentSalturiFacute.ToString();
            procSalturiNefacuteTextBox.Text = procentSalturiNefacute.ToString();
            procMissTextBox.Text = procentMiss.ToString();
            procHitTextBox.Text=procentHit.ToString();
            predictiiCorecteTextBox.Text = predictiiCorecte.ToString();
            predictiiIncorecteTextBox.Text=predictiiIncorecte.ToString();
            procPredictiiCorecteTextBox.Text=procentPredictiiCorecte.ToString();
            procPredictiiIncorecteTextBox.Text=procentPredictiiIncorecte.ToString();

            //Titlul Formei
            detailsLabel.Text = formatFormTitle();

            //Time Stamp
            DateTime currentDateTime = DateTime.Now;
            timeStampLabel.Text="Time stamp: "+ currentDateTime.ToString("dd-MM-yyyy HH:mm:ss");

            //disableTextBoxes();
        }

        private string formatFormTitle()
        {
            string title="";
            if (arhitecturaAleasa == "MapatDirect")
            {
                arhitecturaAleasa = "Mapata Direct";
            }
            else
            {
                arhitecturaAleasa = "Complet Asociativa";
            }

            title ="Arhitectura: " + arhitecturaAleasa+", ";
            title = title + "Numar intrari in tabela: " + numarIntrariInTabela+", ";
            title = title + "Numar biti predictie: " + numarBitiPredictie + ", ";


            if (this.bitiLRU != -1)
            {
                title=title+"Numar biti LRU: "+bitiLRU+". ";
            }
            else
            {
                title = title + "Numar biti HR: " + bitiHR + ". ";
            }

            return title;
        }

        private void disableTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = false;
                }
            }
        }
    }
}
