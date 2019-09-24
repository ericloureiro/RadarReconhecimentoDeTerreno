using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaIndisponivelService
    {
        private double PorcentagemOcup { get; set; }
        public string AguaOuObstaculos(int[,] matrizAgua, int[,] matrizObstaculo)
        {
            var ocup = 0;
            var nada = 0;
            for (int i = 0; i < matrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    var aux = (matrizAgua[i, j] > 0 || matrizObstaculo[i, j] > 0) ? ocup++ : nada++;
                }
            }
            var total = ocup + nada;
            PorcentagemOcup = ocup * 100.0 / total;
            return String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_OCUPADA_AGUA_OBSTACULO, PorcentagemOcup.ToString("F2"));
        }
    }
}
