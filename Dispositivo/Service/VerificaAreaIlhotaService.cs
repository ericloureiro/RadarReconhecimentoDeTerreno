using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaIlhotaService
    {
        public string TemIlhota(int[,] matrizAgua, int[,] matrizObstaculo, int[,] matrizMinaTerrestre)
        {
            for (int i = 0; i < matrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    if (matrizObstaculo[i, j] == 0 && matrizMinaTerrestre[i, j] == 0 && matrizAgua[i, j] == 0 &&
                        j > 0 && i > 0 && j < matrizAgua.GetLength(1) - 1 && i < matrizAgua.GetLength(0) - 1 &&
                        matrizAgua[i, j - 1] > 0 && matrizAgua[i - 1, j - 1] > 0 && matrizAgua[i + 1, j - 1] > 0 &&
                        matrizAgua[i, j + 1] > 0 && matrizAgua[i - 1, j + 1] > 0 && matrizAgua[i + 1, j + 1] > 0
                        && matrizAgua[i - 1, j] > 0 && matrizAgua[i + 1, j] > 0)
                    {
                        return String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_ILHOTA_ESTRATEGICA, i + 1, j + 1);
                    }
                }
            }
            return DispositivoReconhecimentoTerrenoResource.MENSAGEM_NAO_POSSUI_ILHOTA_ESTRATEGICA;
        }
    }
}


