using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaIndisponivelService
    {
        private double PorcentagemOcup { get; set; }
        public void AguaOuObstaculos(Dispositivo d)
        {
            var ocup = 0;
            var nada = 0;
            for (int i = 0; i < d.MatrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < d.MatrizAgua.GetLength(1); j++)
                {
                    var aux = (d.MatrizAgua[i, j] > 0 || d.MatrizObstaculo[i, j] > 0) ? ocup++ : nada++;
                }
            }
            var total = ocup + nada;
            PorcentagemOcup = ocup * 100.0 / total;
            d.Mensagens.Add(String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_OCUPADA_AGUA_OBSTACULO, PorcentagemOcup.ToString("F2")));
        }
    }
}
