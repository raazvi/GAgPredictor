using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAg_Predictor
{
    public interface IBranchPredictor
    {
        //Interfata pentru predictorul general
        void GAgPredictorAlgorithm();
        void Initializare(string traceFile, int numarIntrariInTabela, int HRGlobal, string tipArhitectura, int nrBitiPredictie);
    }
}
