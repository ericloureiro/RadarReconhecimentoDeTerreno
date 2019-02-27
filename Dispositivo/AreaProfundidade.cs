namespace Dispositivo
{
    //7 - leitura de um terreno e informe a profundidade média de toda sua área coberta por água.
    public class AreaProfundidade
    {
        public double MediaDaProfundidade { get; set; }
        public double ProfundidadeMedia(int[,] matrizAgua)
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
            return MediaDaProfundidade;
        }

        public override string ToString()
        {
            return "Profundidade Média: " + MediaDaProfundidade + " metro(s)";
        }
    }
}
