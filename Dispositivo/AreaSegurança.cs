namespace Dispositivo
{
    //9 - leitura de um terreno e informe seu nível de segurança.
    public class AreaSegurança
    {
        public double PorcentagemSeguranca { get; set; }
        public double NivelDeSeguranca(int[,] matrizMinaTerrestre)
        {
            double total = matrizMinaTerrestre.Length;
            double perigo = 0;
            for (int i = 0; i < matrizMinaTerrestre.GetLength(0); i++)
            {
                for (int j = 0; j < matrizMinaTerrestre.GetLength(1); j++)
                {
                    if (matrizMinaTerrestre[i, j] >= 50)
                    {
                        perigo += matrizMinaTerrestre[i, j];
                    }
                }
            }
            PorcentagemSeguranca = perigo / total;
            return PorcentagemSeguranca;
        }

        public override string ToString()
        {
            if (PorcentagemSeguranca == 0)
            {
                return $"Perigo no Terreno: {PorcentagemSeguranca:F2} % - Nível 1 – Área segura";
            }
            else if (PorcentagemSeguranca <= 10)
            {
                return $"Perigo no Terreno: {PorcentagemSeguranca:F2} %  - Nível 2 – Área de atenção";
            }
            else if (PorcentagemSeguranca <= 50)
            {
                return $"Perigo no Terreno: {PorcentagemSeguranca:F2} %  - Nível 3 – Área perigosa";
            }
            else
            {
                return $"Perigo no Terreno: {PorcentagemSeguranca:F2} %  - Nível 4 - Área não recomendada";
            }
        }
    }
}
