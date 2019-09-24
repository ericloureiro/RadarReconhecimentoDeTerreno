using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaProfundidadeService
    {
        private double MediaDaProfundidade { get; set; }
        public void ProfundidadeMedia(Dispositivo d)
        {
            double total = 0;
            double divisor = 0;
            for (int i = 0; i < d.MatrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < d.MatrizAgua.GetLength(1); j++)
                {
                    if (d.MatrizAgua[i, j] > 0)
                    {
                        total += d.MatrizAgua[i, j];
                        divisor++;
                    }
                }
            }
            MediaDaProfundidade = total / divisor;
            d.Mensagens.Add(String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_PROFUNDIDADE_MEDIA, String.Format("{0:0.00}", MediaDaProfundidade)));
        }
    }
}
