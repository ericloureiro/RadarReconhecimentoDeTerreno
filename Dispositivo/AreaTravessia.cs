using System;
using System.Collections.Generic;
using System.Linq;


namespace Dispositivo
{
    //8 - leitura de linhas/colunas que possam ser ultrapassadas. 
    //    caso somente uma linha/coluna e com probabilidade maior que 10% de conter minas, o usuário deve ser avisado
    public class AreaTravessia
    {
        public List<int> PossiveisLinhas = new List<int>();
        public List<int> PossiveisColunas = new List<int>();
        public List<int> SomaLinCol = new List<int>();
        public List<string> SobrescreverTexto = new List<string>();
        public void PodePassar(int[,] matrizAgua, int[,] matrizObstaculo, int[,] matrizMinaTerrestre)
        {
            for (int i = 0; i < matrizAgua.GetLength(0); i++) //VERIFICAÇÃO DE LINHAS
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    if (matrizAgua[i, j] > 1 || matrizObstaculo[i, j] != 0)
                    {
                        break;
                    }
                    if (j == matrizAgua.GetLength(1) - 1)
                    {
                        PossiveisLinhas.Add(i);
                    }
                }
            }
            for (int j = 0; j < matrizAgua.GetLength(1); j++) //VERIFICAÇÃO DE COLUNAS
            {
                for (int i = 0; i < matrizAgua.GetLength(0); i++)
                {
                    if (matrizAgua[i, j] > 1 || matrizObstaculo[i, j] != 0)
                    {
                        break;
                    }
                    if (i == matrizAgua.GetLength(1) - 1)
                    {
                        PossiveisColunas.Add(j);
                    }
                }
            }
            SomaLinCol.AddRange(PossiveisLinhas);
            SomaLinCol.AddRange(PossiveisColunas);
            if (SomaLinCol.Count > 1)
            {
                SobrescreverTexto.Add("Travessia nas seguintes Linha(s) / Coluna(s):\n");
                foreach (var item in PossiveisLinhas)
                {
                    SobrescreverTexto.Add($"Linha: {item + 1}\n");
                }
                foreach (var item in PossiveisColunas)
                {
                    SobrescreverTexto.Add($"Coluna: {item + 1}\n");
                }
            }
            else if (SomaLinCol.Count == 1)
            {
                double perigo = 0;
                if (PossiveisLinhas.Count == 1)
                {
                    for (int j = 0; j < matrizMinaTerrestre.GetLength(1); j++)
                    {
                        perigo += matrizMinaTerrestre[PossiveisLinhas.ElementAt(0), j];
                    }
                    SobrescreverTexto.Add($"Travessia somente na Linha: {PossiveisLinhas.ElementAt(0) + 1} Perigo: {(perigo / matrizMinaTerrestre.GetLength(0)):F2} %");
                }
                else if (PossiveisColunas.Count == 1)
                {
                    for (int i = 0; i < matrizMinaTerrestre.GetLength(0); i++)
                    {
                        perigo += matrizMinaTerrestre[i, PossiveisColunas.ElementAt(0)];
                    }
                    SobrescreverTexto.Add($"Travessia somente na Coluna: {PossiveisColunas.ElementAt(0) + 1} Perigo: {(perigo / matrizMinaTerrestre.GetLength(1)):F2} %");
                }
            }
            else
            {
                SobrescreverTexto.Add("Não existem Linhas e Colunas possíves de atravessar.");
            }
        }

        public override string ToString()
        {
            foreach (var item in SobrescreverTexto)
            {
                Console.Write(item);
            }
            return "";
        }
    }
}
