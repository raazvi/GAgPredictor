using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAg_Predictor
{
    internal class GAgPredictor : IBranchPredictor
    {

        int intrariInTabela;
        int HRGlobal;
        int LRU;
        string tipArhitectura;
        int nrBitiPredictie;

        //PHT
        public PatternHistory[] patternHistoryTable;

        // Calea spre fisierul .tra
        private string traceFilePath;
        private string traceFileName;

        //Instructiuni - variabile
        private int numarTotalInstructiuni;
        public string[] instructiuni;
        private int instructiuneCurentaIndex;
        private string instructiuneCurenta;

        private int instructiuniJumpFacute;
        private int instructiuniJumpNefacute;

        //Program Counter
        private long PCCurent;
        private long PCTarget;
        private long PCHigh;
        private int  numarBitiPCLow;

        //HR
        private int HR;
        private int HRurmator;

        //Predictie
        private int predictiiCorecte;
        private int predictiiIncorecte;
        private int predictiiIncorecteTargetGresit;

        //Hit And Miss
        private int numarHIT;
        private int numarMISS;

        //Diverse
        private long linieActuala;
        private int PC_HR;

        //Events
        public event EventHandler SimulationComplete;

        /// <summary>
        /// Initializeaza predictorul GAg cu datele introduse de utilizator.
        /// </summary>
        public void Initializare(string traceFile, int numarIntrariInTabela, int istorieGlobala, string tipArh, int nrBitiPred)
        {
            this.traceFilePath = traceFile;
            this.intrariInTabela = numarIntrariInTabela;
            this.HRGlobal = istorieGlobala;
            this.tipArhitectura = tipArh;
            this.nrBitiPredictie = nrBitiPred;

            //Initializare variabile legate de instructiuni
            this.instructiuni = null;
            this.numarTotalInstructiuni = 0;
            this.readTraceFile(this.traceFilePath);
            this.instructiuneCurentaIndex = 0;
            this.instructiuneCurenta = "";

            this.instructiuniJumpFacute = 0;
            this.instructiuniJumpNefacute = 0;

            this.PCCurent = 0;
            this.PCHigh = 0;
            this.PCTarget = 0;
            this.numarBitiPCLow = 0;

            this.HR = 0;
            this.HRurmator = 0;

            this.predictiiCorecte = 0;
            this.predictiiIncorecte = 0;

            this.numarHIT = 0;
            this.numarMISS = 0;

            this.linieActuala = -1;
            this.PC_HR = 0;
            this.predictiiIncorecteTargetGresit= 0;

        }

        /// <summary>
        /// Functia care initializeaza algoritmul de predictie.
        /// </summary>
        public void GAgPredictorAlgorithm()
        {
            if (this.tipArhitectura.Equals("MapatDirect"))
            {
                this.MDAlgorithm();
            }
            else
            {
                this.CAAlgorithm();
            }
        }

        /// <summary>
        /// Agloritmul de predictie pentru arhitectura Mapata Direct
        /// </summary>
        public void MDAlgorithm()
        {
            bool predictie;
            linieActuala = this.PC_HR;

            //Verifica daca tag-ul de pe linia actuala = PC_high
            if (PCHigh == patternHistoryTable[linieActuala].tag)
            {
                //Cazul in care este egalitate => HIT
                this.numarHIT++;
                //Saltul nu se face
                if (instructiuneCurenta.ToUpper().Contains("N"))
                {
                    
                    if (patternHistoryTable[linieActuala].predictie < 2)
                    {
                        predictie = true;
                        patternHistoryTable[linieActuala].predictie = 0;
                    }
                    else
                    {
                        predictie = false;
                        if (this.nrBitiPredictie == 1)
                        {
                            patternHistoryTable[linieActuala].predictie = 0;
                        }
                        else
                        {
                            patternHistoryTable[linieActuala].predictie--;
                        }
                    }
                    if (predictie == true)
                    {
                        HRurmator = (HRurmator << 1) & ((int)Math.Pow((long)2, HRGlobal) - 1);
                        instructiuniJumpNefacute++;
                        if (patternHistoryTable[linieActuala].target == PCTarget)
                        {
                            predictiiCorecte++;
                        }
                        else
                        {
                            patternHistoryTable[linieActuala].target = PCTarget;
                            predictiiIncorecteTargetGresit++;
                        }
                    }
                    else
                    {
                        if (patternHistoryTable[linieActuala].predictie > 0)
                        {
                            HRurmator= (1 | (HRurmator << 1)) & ((int)Math.Pow((long)2, HRGlobal) - 1);
                            instructiuniJumpFacute++;
                        }

                        if (patternHistoryTable[linieActuala].predictie < 2)
                        {
                            patternHistoryTable[linieActuala].target = PCTarget;
                        }

                        predictiiIncorecte++;
                    }
                }
                else
                {
                    if (patternHistoryTable[linieActuala].predictie > 1)
                    {
                        predictie = true;
                        patternHistoryTable[linieActuala].predictie = 3;
                    }
                    else
                    {
                        predictie = false;
                        if (this.nrBitiPredictie == 1)
                        {
                            patternHistoryTable[linieActuala].predictie = 3;
                        }
                        else
                        {
                            patternHistoryTable[linieActuala].predictie++;
                        }
                    }

                    if (predictie == true)
                    {
                        HRurmator = (1 | (HRurmator << 1)) & ((int)Math.Pow((long)2, HRGlobal) - 1);
                        instructiuniJumpFacute++;
                        if (patternHistoryTable[linieActuala].target == PCTarget)
                        {
                            predictiiCorecte++;
                        }
                        else
                        {
                            patternHistoryTable[linieActuala].target = PCTarget;
                            predictiiIncorecteTargetGresit++;
                        }
                    }
                    else
                    {
                        if (patternHistoryTable[linieActuala].predictie < 3)
                        {
                            HRurmator = (HRurmator << 1) & ((int)Math.Pow((long)2, HRGlobal) - 1);
                            instructiuniJumpNefacute++;
                        }

                        if (patternHistoryTable[linieActuala].predictie > 1)
                        {
                            patternHistoryTable[linieActuala].target = PCTarget;
                        }

                        predictiiIncorecte++;
                    }
                }

            }
            else
            {
                //Cazul in care nu e egalitate => MISS
                numarMISS++;
                if (!instructiuneCurenta.ToUpper().Contains("N")){
                    patternHistoryTable[linieActuala].tag = PCHigh;
                    patternHistoryTable[linieActuala].target= PCTarget;
                    patternHistoryTable[linieActuala].predictie = 2;
                    HRurmator = (1 | (HRurmator << 1)) & ((int)Math.Pow((long)2, HRGlobal) - 1);
                }
            }
            
        }

        /// <summary>
        /// Algoritmul de predictie pentru arhitectura Complet Asociativa
        /// </summary>
        public void CAAlgorithm()
        {
            bool predictie;
            long i, j, fRecord = -1, tagRecord = -1, LRURecord = -1, minLRUCounter;
            minLRUCounter = LRU + 1;
            linieActuala = PC_HR;
            for (i = 0; i < intrariInTabela; i++)
            {
                if ((patternHistoryTable[i].tag == -1) && (fRecord == -1))
                {
                    fRecord = i;
                }

                if (patternHistoryTable[i].LRU < minLRUCounter)
                {
                    minLRUCounter = patternHistoryTable[i].LRU;
                    LRURecord = i;
                }
                if (PCCurent == patternHistoryTable[i].tag)
                {
                    tagRecord = i;
                    if (instructiuneCurenta.ToUpper().Contains("NT"))
                    {
                        if (patternHistoryTable[i].predictie < 2)
                        {
                            predictie = true;
                            patternHistoryTable[i].predictie = 0;
                        }
                        else
                        {
                            predictie = false;
                            if (nrBitiPredictie == 1)
                            {
                                patternHistoryTable[i].predictie = 0;
                            }
                            else
                            {
                                patternHistoryTable[i].predictie--;
                            }
                        }

                        if (predictie == true)
                        {
                            instructiuniJumpNefacute++;
                            if (patternHistoryTable[i].target == PCTarget)
                            {
                                predictiiCorecte++;
                            }
                            else
                            {
                                patternHistoryTable[i].target = PCTarget;
                                predictiiIncorecteTargetGresit++;
                            }
                        }
                        else
                        {
                            if (patternHistoryTable[i].predictie > 0)
                            {
                                instructiuniJumpFacute++;
                            }
                            if (patternHistoryTable[i].predictie < 2)
                            {
                                patternHistoryTable[i].target = PCTarget;
                            }
                            predictiiIncorecte++;
                        }
                    }
                    else
                    {
                        if (patternHistoryTable[i].predictie > 1)
                        {
                            predictie = true;
                            patternHistoryTable[i].predictie = 3;
                        }
                        else
                        {
                            predictie = false;
                            if (nrBitiPredictie == 1)
                            {
                                patternHistoryTable[i].predictie = 3;
                            }
                            else
                            {
                                patternHistoryTable[i].predictie++;
                            }
                        }

                        if (predictie == true)
                        {
                            instructiuniJumpFacute++;
                            if (patternHistoryTable[i].target == PCTarget)
                            {
                                predictiiCorecte++;
                            }
                            else
                            {
                                patternHistoryTable[i].target = PCTarget;
                                predictiiIncorecteTargetGresit++;
                            }
                        }
                        else
                        {
                            if (patternHistoryTable[i].predictie < 3)
                            {
                                instructiuniJumpNefacute++;
                            }

                            if (patternHistoryTable[i].predictie > 1)
                            {
                                patternHistoryTable[i].target= PCTarget;
                            }

                            predictiiIncorecte++;
                        }
                    }
                    break;
                }
            }

            if (tagRecord != -1)
            {
                numarHIT++;
                linieActuala = tagRecord;
                for (j = 0; j < intrariInTabela; j++)
                {
                    if (patternHistoryTable[j].LRU > 0)
                    {
                        patternHistoryTable[j].LRU--;
                    }

                    patternHistoryTable[tagRecord].LRU = LRU;
                }
            }
            else
            {
                if ((fRecord != -1) && (!instructiuneCurenta.ToUpper().Contains("NT")))
                {
                    numarMISS++;
                    linieActuala = fRecord;
                    patternHistoryTable[fRecord].tag = PCCurent;
                    patternHistoryTable[fRecord].target = PCTarget;
                    patternHistoryTable[fRecord].predictie = 2;
                    for (j = 0; j < intrariInTabela; j++)
                    {
                        if (patternHistoryTable[j].LRU > 0)
                        {
                            patternHistoryTable[j].LRU--;
                        }
                    }
                    patternHistoryTable[fRecord].LRU = LRU;
                }
                else
                {
                    if ((LRURecord != -1) && (!instructiuneCurenta.ToUpper().Contains("NT")))
                    {
                        numarMISS++;
                        linieActuala = LRURecord;
                        patternHistoryTable[LRURecord].tag= PCCurent;
                        patternHistoryTable[LRURecord].target = PCTarget;
                        patternHistoryTable[LRURecord].predictie = 2;
                        for(j = 0; j < intrariInTabela; j++)
                        {
                            if (patternHistoryTable[j].LRU > 0)
                            {
                                patternHistoryTable[j].LRU--;
                            }
                        }
                        patternHistoryTable[LRURecord].LRU = LRU;
                    }
                }
            }


        }

        /// <summary>
        /// Citeste fisierul trace, daca acesta nu este gol, apoi updateaza numarul total de instructiuni si vectorul de instructiuni
        /// </summary>
        public void readTraceFile(string filePath)
        {
            StreamReader traceFile= null;

            try
            {
                if ((!filePath.Equals(null)) && (filePath != ""))
                {
                    traceFile = new StreamReader(filePath);
                    if (!traceFile.Equals(null))
                    {
                        this.instructiuni = traceFile.ReadToEnd().Replace("\r\n", "\r").Split('\r');

                        for(int k=0; k<this.instructiuni.Length;k++)
                        {
                            //Filtrarea elementelor care sunt goale
                            if (instructiuni[k] != "")
                            {
                                instructiuni[numarTotalInstructiuni++] = instructiuni[k];
                            }
                        }

                        traceFile.Close();
                    }
                }
            }
            catch(Exception eroare)
            {
                Console.WriteLine(eroare.Message);
            }
            
        }

        /// <summary>
        /// Trece la urmatoarea instructiune din vectorul de instructiuni
        /// </summary>
        public bool getUrmatoareaInstructiune()
        {
            bool existaInstructiuneUrmatoare = false;
            this.HR = this.HRurmator;
            if (this.instructiuneCurentaIndex <= this.numarTotalInstructiuni)
            {
                string[] aux = instructiuni[instructiuneCurentaIndex].Split(' ');
                if (aux.Length >= 3)
                {
                    instructiuneCurenta = aux[0];  //instructiunea
                    PCCurent = long.Parse(aux[1]); //adresa curenta
                    PCTarget = long.Parse(aux[2]); //adresa destinatie

                    this.instructiuneCurentaIndex++; //trecem la instructiunea urmatoare

                    //Contorizam daca se face saltul sau nu
                    if (this.instructiuneCurenta.ToUpper().CompareTo("NT") == 0)
                    {
                        this.instructiuniJumpNefacute++;
                    }
                    else
                    {
                        this.instructiuniJumpFacute++;
                    }

                    this.PC_HR = Converter.binarToDecimal(Converter.decimalToBinar(this.PCCurent, this.numarBitiPCLow) + Converter.decimalToBinar(this.HR, this.HRGlobal));
                    this.PCHigh = this.PCCurent >> this.numarBitiPCLow;
                    existaInstructiuneUrmatoare = true;
                }
            
            }

            this.GAgPredictorAlgorithm();
            return existaInstructiuneUrmatoare;
        }

        /// <summary>
        /// Simuleaza executarea instructiunilor salvate din fisierul trace ales
        /// </summary>
        public void simulareCompleta()
        {
            while (getUrmatoareaInstructiune()) ;

            // Trigger the SimulationComplete event
            OnSimulationComplete(EventArgs.Empty);
        }

        //Trigger pentru event de simulare completa
        protected virtual void OnSimulationComplete(EventArgs e)
        {
            SimulationComplete?.Invoke(this, e);
        }

        //Constructori
        public GAgPredictor() { }

        public GAgPredictor(int intrariInTabela, int hRGlobal, int lRU, string tipArhitectura, int nrBitiPredictie)
        {
            this.intrariInTabela = intrariInTabela;
            HRGlobal = hRGlobal;
            LRU = lRU;
            this.tipArhitectura = tipArhitectura;
            this.nrBitiPredictie = nrBitiPredictie;
        }

        //Getters and Setters - Pentru a testa functiile pe parcursul dezvoltarii aplicatiei
        public int getNumarTotalInstructiuni()
        {
            return this.numarTotalInstructiuni;
        }
        public string getInstructiuneAtIndex(int index)
        {
            return this.instructiuni[index];
        }
        public string getTraceFilepath()
        {
            return this.traceFilePath;
        }
        public int getInstructiuniJumpFacute()
        {
            return this.instructiuniJumpFacute;
        }
        public int getInstructiuniJumpNefacute()
        {
            return this.instructiuniJumpNefacute;
        }
        public int getNumarHIT()
        {
            return this.numarHIT;
        }
        public int getNumarMISS()
        {
            return this.numarMISS;
        }
        public int getPredictiiCorecte()
        {
            return this.predictiiCorecte;
        }
        public int getPredictiiIncorecte()
        {
            return this.predictiiIncorecte;
        }
        public int getIntrariInTabela()
        {
            return this.intrariInTabela;
        }
        public int getLRU()
        {
            if (this.tipArhitectura == "MapatDirect")
            {
                return -1;
            }
            else
            {
                return this.LRU;
            }
            
        }
        public string getTraceFileName()
        {
            return this.traceFileName;
        }
        public void setTraceFileName(String traceFileName)
        {
            this.traceFileName = traceFileName;
        }
        public int getNumarBitiPredictie()
        {
            return this.nrBitiPredictie;
        }
        public string getArhitectura()
        {
            return this.tipArhitectura;
        }
        public int getBitiHR()
        {
            if (this.tipArhitectura == "MapatDirect")
            {
                return this.HR;
            }
            else
            {
                return -1;
            }
        }
    }
}
