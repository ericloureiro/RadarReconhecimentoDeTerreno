using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaProfundidadeService
    {
        private double MediaDaProfundidade { get; set; }
        public string ProfundidadeMedia(int[,] matrizAgua)
        {
            double total = 0;
            double divisor = 0;
            for (int i = 0; i < matrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    if (matrizAgua[i, j] > 0)
                    {
                        total += matrizAgua[i, j];
                        divisor++;
                    }
                }
            }
            MediaDaProfundidade = total / divisor;
            return String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_PROFUNDIDADE_MEDIA, String.Format("{0:0.00}", MediaDaProfundidade));
        }
    }
}
