using Dispositivo.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dispositivo
{
    public class VerificaAreaTravessiaService
    {
        private List<int> PossiveisLinhas = new List<int>();
        private List<int> PossiveisColunas = new List<int>();
        private List<int> SomaLinCol = new List<int>();
        public string PodePassar(int[,] matrizAgua, int[,] matrizObstaculo, int[,] matrizMinaTerrestre)
        {
            var resultado = new StringBuilder();
            var podePassar = true;
            for (int i = 0; i < matrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    if (matrizAgua[i, j] > 1 || matrizObstaculo[i, j] != 0)
                    {
                        podePassar = false;
                        break;
                    }
                }
                if (podePassar)
                {
                    PossiveisLinhas.Add(i);
                }
            }
            for (int j = 0; j < matrizAgua.GetLength(1); j++)
            {
                for (int i = 0; i < matrizAgua.GetLength(0); i++)
                {
                    if (matrizAgua[i, j] > 1 || matrizObstaculo[i, j] != 0)
                    {
                        podePassar = false;
                        break;
                    }
                }
                if (podePassar)
                {
                    PossiveisColunas.Add(j);
                }
            }
            SomaLinCol.AddRange(PossiveisLinhas);
            SomaLinCol.AddRange(PossiveisColunas);
            if (SomaLinCol.Count > 1)
            {
                resultado.AppendLine(DispositivoReconhecimentoTerrenoResource.MENSAGEM_TRAVESSIA_LINHAS_COLUNAS);
                foreach (int item in PossiveisLinhas)
                {
                    resultado.AppendLine(DispositivoReconhecimentoTerrenoResource.LABEL_LINHA + (item + 1));
                }
                foreach (int item in PossiveisColunas)
                {
                    resultado.AppendLine(DispositivoReconhecimentoTerrenoResource.LABEL_COLUNA + (item + 1));
                }
            }
            else if (SomaLinCol.Count == 1)
            {
                var perigo = 0.0;
                if (PossiveisLinhas.Count == 1)
                {
                    for (int j = 0; j < matrizMinaTerrestre.GetLength(1); j++)
                    {
                        perigo += matrizMinaTerrestre[PossiveisLinhas.ElementAt(0), j];
                    }
                    resultado.AppendLine(String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_TRAVESSIA_LINHA, PossiveisLinhas.FirstOrDefault() +1, (perigo / matrizMinaTerrestre.GetLength(0)).ToString("F2")));
                }
                else if (PossiveisColunas.Count == 1)
                {
                    for (int i = 0; i < matrizMinaTerrestre.GetLength(0); i++)
                    {
                        perigo += matrizMinaTerrestre[i, PossiveisColunas.ElementAt(0)];
                    }
                    resultado.AppendLine(String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_TRAVESSIA_COLUNA, PossiveisColunas.FirstOrDefault() +1, (perigo / matrizMinaTerrestre.GetLength(1)).ToString("F2")));
                }
            }
            else
            {
                resultado.AppendLine(DispositivoReconhecimentoTerrenoResource.MENSAGEM_TRAVESSIA_INEXISTENTE);
            }
            return resultado.ToString();
        }
    }
}
