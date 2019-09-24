using Dispositivo.Resource;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispositivo
{
    class Dispositivo
    {
        public static List<String> listaDeMensagens = new List<String>();
        public const int valorLivre = 0;
        public const int valorObstaculo = 1;
        public const int valorProfundidadeMaxima = 3;
        public const int valorMaximoMinaTerrestre = 100;
        static void Main(string[] args)
        {
            var entrada = Console.ReadLine();

            while (entrada != null)
            {
                try
                {
                    Console.Clear();
                    listaDeMensagens.Clear();
                    var eixos = entrada.Split(' ');
                    if (eixos.Length != 2)
                    {
                        throw new Exception();
                    }
                    var x = Convert.ToInt32(eixos[0]);
                    var y = Convert.ToInt32(eixos[1]);
                    var matrizAgua = new int[x, y];
                    var matrizObstaculo = new int[x, y];
                    var matrizMinaTerrestre = new int[x, y];
                    var random = new Random();

                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            matrizAgua[i, j] = random.Next(valorLivre, valorProfundidadeMaxima + 1);
                            matrizObstaculo[i, j] = random.Next(valorObstaculo + 1);
                            matrizMinaTerrestre[i, j] = random.Next(valorLivre, valorMaximoMinaTerrestre + 1);
                        }
                    }
                    CarregarTodasAsGrids(matrizAgua, matrizObstaculo, matrizMinaTerrestre, x, y);
                    listaDeMensagens.ForEach(m => Console.WriteLine(m));
                }
                catch
                {
                    Console.WriteLine(DispositivoReconhecimentoTerrenoResource.ERRO_INPUT_INCORRETO);
                }
                finally
                {
                    entrada = Console.ReadLine();
                }
            }

        }
        private static void CarregarTodasAsGrids(int[,] matrizAgua, int[,] matrizObstaculo, int[,] matrizMinaTerrestre, int x, int y)
        {
            ProcessarDadosDasMatrizes(matrizAgua, matrizObstaculo, matrizMinaTerrestre);
            listaDeMensagens.Add(DispositivoReconhecimentoTerrenoResource.MAPA_AGUA);
            CarregarGridsParaApresentacaoConsole(matrizAgua, x, y);
            listaDeMensagens.Add(DispositivoReconhecimentoTerrenoResource.MAPA_OBSTACULO);
            CarregarGridsParaApresentacaoConsole(matrizObstaculo, x, y);
            listaDeMensagens.Add(DispositivoReconhecimentoTerrenoResource.MAPA_MINA);
            CarregarGridsParaApresentacaoConsole(matrizMinaTerrestre, x, y);
        }
        private static void ProcessarDadosDasMatrizes(int[,] matrizAgua, int[,] matrizObstaculo, int[,] matrizMinaTerrestre)
        {
            var percentualCobertoAguaOuObstaculos = new VerificaAreaIndisponivelService();
            var profundidadeMediaAreaCobertaPorAgua = new VerificaAreaProfundidadeService();
            var leituraLinhasColunasQuePossamSerUltrapassadas = new VerificaAreaTravessiaService();
            var localizacaoIlhota = new VerificaAreaIlhotaService();
            var nivelDeSeguranca = new VerificaAreaSegurancaService();

            listaDeMensagens.Add(percentualCobertoAguaOuObstaculos.AguaOuObstaculos(matrizAgua, matrizObstaculo));
            listaDeMensagens.Add(profundidadeMediaAreaCobertaPorAgua.ProfundidadeMedia(matrizAgua));
            listaDeMensagens.Add(localizacaoIlhota.TemIlhota(matrizAgua, matrizObstaculo, matrizMinaTerrestre));
            listaDeMensagens.Add(nivelDeSeguranca.NivelDeSeguranca(matrizMinaTerrestre));
            listaDeMensagens.Add(leituraLinhasColunasQuePossamSerUltrapassadas.PodePassar(matrizAgua, matrizObstaculo, matrizMinaTerrestre));
        }
        private static void CarregarGridsParaApresentacaoConsole(int[,] a, int x, int y)
        {
            var fraseAuxiliar = new StringBuilder();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    string formatacao;
                    switch (a[i, j].ToString().Length)
                    {
                        case 1:
                            formatacao = "  ";
                            break;
                        case 2:
                            formatacao = " ";
                            break;
                        default:
                            formatacao = "";
                            break;
                    }
                    fraseAuxiliar.Append(String.Format(formatacao + "{0} ", a[i, j]));
                }
                fraseAuxiliar.AppendLine();
            }
            listaDeMensagens.Add(fraseAuxiliar.ToString());
        }
    }
}


