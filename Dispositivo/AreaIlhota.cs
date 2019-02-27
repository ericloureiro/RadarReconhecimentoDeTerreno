using System;

namespace Dispositivo
{
    public class AreaIlhota
    {
        //10 - leitura de um terreno e determine se no terreno existe uma ilhota estrategicamente útil,
        //     Uma ilhota é um espaço de 1m² de terra cercado de água por todos os lados. 
        //     Só é estrategicamente útil se não possuir um obstáculo e possuir probabilidade 0 de conter minas.,
        public void TemIlhota(int[,] matrizAgua, int[,] matrizObstaculo, int[,] matrizMinaTerrestre)
        {
            for (int i = 0; i < matrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    if (matrizObstaculo[i, j] == 0 && matrizMinaTerrestre[i, j] == 0 && matrizAgua[i, j] == 0)
                    {
                        if (j > 0 && i > 0 && j < matrizAgua.GetLength(1) - 1 && i < matrizAgua.GetLength(0) - 1)
                        {
                            if (matrizAgua[i, j - 1] > 0               //m² ESQUERDA
                                && matrizAgua[i - 1, j - 1] > 0        //m² ESQUERDA EM CIMA
                                && matrizAgua[i + 1, j - 1] > 0        //m² ESQUERDA EM BAIXO
                                && matrizAgua[i, j + 1] > 0            //m² DIREITA
                                && matrizAgua[i - 1, j + 1] > 0        //m² DIREITA EM CIMA
                                && matrizAgua[i + 1, j + 1] > 0        //m² DIREITA EM BAIXO
                                && matrizAgua[i - 1, j] > 0            //m² CIMA
                                && matrizAgua[i + 1, j] > 0            //m² ABAIXO
                                )
                            {
                                Console.WriteLine($"Possui uma ilhota estratégicamente útil na posição:\nLinha {(i + 1)}, Coluna {(j + 1)}.\n" +
                                    "0 % chance de bombas, água em todos os lados, não possui obstáculo ");
                            }
                        }
                    }
                }
            }
        }
    }
}

