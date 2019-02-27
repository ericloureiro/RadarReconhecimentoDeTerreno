using System;

namespace Dispositivo
{
    class Dispositivo
    {
        static void Main(string[] args)
        {
            #region matriz
            int[,] matrizObstaculo = new int[3, 3]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 1 }
            };

            int[,] matrizAgua = new int[3, 3]
{
                { 1, 1, 1 },
                { 1, 0, 1 },
                { 3, 3, 5 }
};

            int[,] matrizMinaTerrestre = new int[3, 3]
            {
                { 25, 52, 35 },
                { 26, 0, 14 },
                { 2, 95, 7 }
            };

            #endregion
            //6 - leitura de um terreno e informe o percentual de sua área coberta por água ou obstáculos.
            AreaIndisponivel a = new AreaIndisponivel();
            a.AguaOuObstaculos(matrizAgua, matrizObstaculo);
            Console.WriteLine(a);

            //7 - leitura de um terreno e informe a profundidade média de toda sua área coberta por água.
            AreaProfundidade b = new AreaProfundidade();
            b.ProfundidadeMedia(matrizAgua);
            Console.WriteLine(b);

            //8 - leitura de linhas/colunas que possam ser ultrapassadas. 
            //    caso somente uma linha/coluna e com probabilidade maior que 10% de conter minas, o usuário deve ser avisado
            AreaTravessia c = new AreaTravessia();
            c.PodePassar(matrizAgua, matrizObstaculo, matrizMinaTerrestre);
            Console.WriteLine(c);

            //9 - leitura de um terreno e informe seu nível de segurança.
            AreaSegurança d = new AreaSegurança();
            d.NivelDeSeguranca(matrizMinaTerrestre);
            Console.WriteLine(d);

            //10 - leitura de um terreno e determine se no terreno existe uma ilhota estrategicamente útil,
            //     Uma ilhota é um espaço de 1m² de terra cercado de água por todos os lados. 
            //     Só é estrategicamente útil se não possuir um obstáculo e possuir probabilidade 0 de conter minas.
            AreaIlhota e = new AreaIlhota();
            e.TemIlhota(matrizAgua, matrizObstaculo, matrizMinaTerrestre);

        }
        public static void View(int[,] a)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    System.Console.Write("{0} ", a[i, j]);
                System.Console.WriteLine();
            }

        }
    }
}


