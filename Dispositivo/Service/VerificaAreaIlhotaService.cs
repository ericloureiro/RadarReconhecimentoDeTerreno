using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaIlhotaService
    {
        public void TemIlhota(Dispositivo d)
        {
            for (int i = 0; i < d.MatrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < d.MatrizAgua.GetLength(1); j++)
                {
                    if (d.MatrizObstaculo[i, j] == 0 && d.MatrizMinaTerrestre[i, j] == 0 && d.MatrizAgua[i, j] == 0 &&
                        j > 0 && i > 0 && j < d.MatrizAgua.GetLength(1) - 1 && i < d.MatrizAgua.GetLength(0) - 1 &&
                        d.MatrizAgua[i, j - 1] > 0 && d.MatrizAgua[i - 1, j - 1] > 0 && d.MatrizAgua[i + 1, j - 1] > 0 &&
                        d.MatrizAgua[i, j + 1] > 0 && d.MatrizAgua[i - 1, j + 1] > 0 && d.MatrizAgua[i + 1, j + 1] > 0
                        && d.MatrizAgua[i - 1, j] > 0 && d.MatrizAgua[i + 1, j] > 0)
                    {
                        d.Mensagens.Add(String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_ILHOTA_ESTRATEGICA, i + 1, j + 1));
                    }
                }
            }
            d.Mensagens.Add(DispositivoReconhecimentoTerrenoResource.MENSAGEM_NAO_POSSUI_ILHOTA_ESTRATEGICA);
        }
    }
}


