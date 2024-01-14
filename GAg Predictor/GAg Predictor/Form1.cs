using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAg_Predictor
{

    public partial class SimulatorForm : Form
    {

        GAgPredictor predictor = new GAgPredictor();
        outForm outputForm;
        string traceFileName;
        public string getTipArhitectura()
        {
            string tipArhitectura = "";

            if (arhitecturaCA.Checked)
            {
                tipArhitectura = "CompletAsociativa";
            }
            else
            {
                tipArhitectura = "MapatDirect";
            }

            return tipArhitectura;
        }
        public int getNumarBitiPredictie()
        {
            int numarBitiPredictie = 0;
            if (predictie1Bit.Checked)
            {
                numarBitiPredictie = 1;
            }
            else
            {
                numarBitiPredictie = 2;
            }

            return numarBitiPredictie;
        }
        private void updateConfigurations()
        {

            if (arhitecturaCA.Checked == true)
            {
                HRParam.Enabled = false;
                LRUParam.Enabled = true;
            }

            if (arhitecturaMD.Checked == true)
            {
                HRParam.Enabled = true;
                LRUParam.Enabled=false;
            }

        }
        public SimulatorForm()
        {
            InitializeComponent();
            updateConfigurations();
            simulateButton.Enabled = false;

            // Subscribe to the event in the constructor
            predictor.SimulationComplete += Predictor_SimulationComplete;
        }
        private void Predictor_SimulationComplete(object sender, EventArgs e)
        {
            if (outputForm == null || outputForm.IsDisposed)
            {
                outputForm = new outForm();
            }

            // Afisarea formei de output
            outputForm.Show();

            //Atribuie detaliile ce tin de simulare
            outputForm.traceFilePath=predictor.getTraceFilepath();
            outputForm.instructiuniJumpFacute=predictor.getInstructiuniJumpFacute();
            outputForm.instructiuniJumpNefacute=predictor.getInstructiuniJumpNefacute();
            outputForm.numarHIT=predictor.getNumarHIT();
            outputForm.numarMISS=predictor.getNumarMISS();
            outputForm.predictiiCorecte=predictor.getPredictiiCorecte();
            outputForm.predictiiIncorecte=predictor.getPredictiiIncorecte();
            outputForm.traceFileName=predictor.getTraceFileName();
            outputForm.numarBitiPredictie = predictor.getNumarBitiPredictie();
            outputForm.arhitecturaAleasa = predictor.getArhitectura();
            outputForm.bitiLRU=predictor.getLRU();
            outputForm.bitiHR = predictor.getBitiHR();
            outputForm.numarIntrariInTabela = predictor.getIntrariInTabela();

            //Updateaza detalii necesare pentru a afisa rezutatul simularii
            outputForm.showSimulationResults();
       
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            arhitecturaCA.Checked = true;
            predictie1Bit.Checked = true;
            simulateButton.Enabled = false;
            liniiTabelParam.Text = "256";
            HRParam.Text = "4";
            LRUParam.Text = "0";
            updateConfigurations();
            predictor.Initializare(traceTextbox.Text, int.Parse(liniiTabelParam.Text), int.Parse(HRParam.Text), getTipArhitectura(), getNumarBitiPredictie());
            traceTextbox.Clear();

        }
        private void predictie1Bit_CheckedChanged(object sender, EventArgs e)
        {
            updateConfigurations();
        }
        private void predictie2Biti_CheckedChanged(object sender, EventArgs e)
        {
            updateConfigurations();
        }
        private void arhitecturaCA_CheckedChanged(object sender, EventArgs e)
        {
            updateConfigurations();
        }
        private void arhitecturaMD_CheckedChanged(object sender, EventArgs e)
        {
            updateConfigurations();
        }
        private void liniiTabelParam_TextChanged(object sender, EventArgs e)
        {
            string newValue = liniiTabelParam.Text;
            string[] acceptedValues = new string[12]{ "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048", "4096" };
            bool isNewValueAccepted = false;
            foreach (string acceptedValue in acceptedValues)
            {
                if(acceptedValue.Equals(newValue)) {  isNewValueAccepted = true; break; }
            }

            if (!isNewValueAccepted)
            {

            }
        }
        private void chooseTraceButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select a trace";
            openFileDialog.Filter = "Trace files (*.tra)|*.tra|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 3;

            string initialDirectory = Path.Combine(Application.StartupPath, "Benchmarks");
            openFileDialog.InitialDirectory = Directory.Exists(initialDirectory) ? initialDirectory : Application.StartupPath;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                traceFileName = Path.GetFileName(selectedFilePath);
                traceTextbox.Text = selectedFilePath;
            }

            simulateButton.Enabled = true;
        }
        private void simulateButton_Click(object sender, EventArgs e)
        {
            predictor.Initializare(traceTextbox.Text,int.Parse(liniiTabelParam.Text),int.Parse(HRParam.Text),getTipArhitectura(),getNumarBitiPredictie());
            predictor.setTraceFileName(traceFileName);
            predictor.patternHistoryTable = new PatternHistory[predictor.getIntrariInTabela()];
            for (int i = 0; i < predictor.getIntrariInTabela(); i++)
            {
                predictor.patternHistoryTable[i] = new PatternHistory();
                predictor.patternHistoryTable[i].LRU = predictor.getLRU();
                predictor.patternHistoryTable[i].tag = -1;
                predictor.patternHistoryTable[i].target = 0;
                predictor.patternHistoryTable[i].predictie = 2;
            }
            
            predictor.simulareCompleta();
        }
    }
}
