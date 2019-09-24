using Dispositivo.Resource;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispositivo.Service
{
    public class DispositivoRadarService
    {
        static void Main(string[] args)
        {
            var entrada = Console.ReadLine();

            while (!string.IsNullOrEmpty(entrada))
            {
                try
                {
                    Console.Clear();
                    var tamanhos = entrada.Split(' ');
                    if (tamanhos.Length != 2)
                    {
                        throw new Exception();
                    }
                    var dispositivo = new Dispositivo()
                    {
                        EixoX = int.Parse(tamanhos[0]),
                        EixoY = int.Parse(tamanhos[1]),

                        Mensagens = new List<string>(),
                        ValorLivre = 0,
                        ValorObstaculo = 1,
                        ValorProfundidadeMaxima = 3,
                        ValorMaximoMinaTerrestre = 100
                    };
                    dispositivo.MatrizAgua = new int[dispositivo.EixoX, dispositivo.EixoY];
                    dispositivo.MatrizObstaculo = new int[dispositivo.EixoX, dispositivo.EixoY];
                    dispositivo.MatrizMinaTerrestre = new int[dispositivo.EixoX, dispositivo.EixoY];

                    var random = new Random();

                    for (int i = 0; i < dispositivo.EixoX; i++)
                    {
                        for (int j = 0; j < dispositivo.EixoY; j++)
                        {
                            dispositivo.MatrizAgua[i, j] = random.Next(dispositivo.ValorLivre, dispositivo.ValorProfundidadeMaxima + 1);
                            dispositivo.MatrizObstaculo[i, j] = random.Next(dispositivo.ValorObstaculo + 1);
                            dispositivo.MatrizMinaTerrestre[i, j] = random.Next(dispositivo.ValorLivre, dispositivo.ValorMaximoMinaTerrestre + 1);
                        }
                    }
                    ProcessarDadosDasMatrizes(dispositivo);
                    CarregarTodasAsGrids(dispositivo);
                    dispositivo.Mensagens.ForEach(m => Console.WriteLine(m));
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

        private static void CarregarTodasAsGrids(Dispositivo d)
        {
            d.Mensagens.Add(DispositivoReconhecimentoTerrenoResource.MAPA_AGUA);
            CarregarGridsParaApresentacaoConsole(d.MatrizAgua, d);
            d.Mensagens.Add(DispositivoReconhecimentoTerrenoResource.MAPA_OBSTACULO);
            CarregarGridsParaApresentacaoConsole(d.MatrizObstaculo, d);
            d.Mensagens.Add(DispositivoReconhecimentoTerrenoResource.MAPA_MINA);
            CarregarGridsParaApresentacaoConsole(d.MatrizMinaTerrestre, d);
        }

        private static void ProcessarDadosDasMatrizes(Dispositivo d)
        {
            var percentualCobertoAguaOuObstaculos = new VerificaAreaIndisponivelService();
            var profundidadeMediaAreaCobertaPorAgua = new VerificaAreaProfundidadeService();
            var leituraLinhasColunasQuePossamSerUltrapassadas = new VerificaAreaTravessiaService();
            var localizacaoIlhota = new VerificaAreaIlhotaService();
            var nivelDeSeguranca = new VerificaAreaSegurancaService();

            percentualCobertoAguaOuObstaculos.AguaOuObstaculos(d);
            profundidadeMediaAreaCobertaPorAgua.ProfundidadeMedia(d);
            localizacaoIlhota.TemIlhota(d);
            nivelDeSeguranca.NivelDeSeguranca(d);
            leituraLinhasColunasQuePossamSerUltrapassadas.PodePassar(d);
        }
        private static void CarregarGridsParaApresentacaoConsole(int[,] grid, Dispositivo d)
        {
            var resultado = new StringBuilder();
            for (int i = 0; i < d.EixoX; i++)
            {
                for (int j = 0; j < d.EixoY; j++)
                {
                    string formatacao;
                    switch (grid[i, j].ToString().Length)
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
                    resultado.Append(string.Format(formatacao + "{0} ", grid[i, j]));
                }
                resultado.AppendLine();
            }
            d.Mensagens.Add(resultado.ToString());
        }
    }
}
