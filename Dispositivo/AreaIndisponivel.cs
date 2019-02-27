namespace Dispositivo
{
    //6 - leitura de um terreno e informe o percentual de sua área coberta por água ou obstáculos.
    public class AreaIndisponivel
    {
        public double PorcentagemOcup { get; set; }
        public double AguaOuObstaculos(int[,] matrizAgua, int[,] matrizObstaculo)
        {
            int ocup = 0;
            int nada = 0;
            for (int i = 0; i < matrizAgua.GetLength(0); i++)
            {
                for (int j = 0; j < matrizAgua.GetLength(1); j++)
                {
                    var aux = (matrizAgua[i, j] > 0 || matrizObstaculo[i, j] > 0) ? ocup++ : nada++;
                }
            }
            int total = ocup + nada;
            PorcentagemOcup = ocup * 100.0 / total;
            return PorcentagemOcup;
        }

        public override string ToString()
        {
            return "Porcentagem ocupada por Água/Obstáculo: " + PorcentagemOcup.ToString("F2") + " %";
        }
    }
}
