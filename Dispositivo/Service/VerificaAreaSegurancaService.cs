using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaSegurancaService
    {
        private double PorcentagemSeguranca { get; set; }
        public string NivelDeSeguranca(int[,] matrizMinaTerrestre)
        {
            var total = matrizMinaTerrestre.Length;
            var perigo = 0;
            for (int i = 0; i < matrizMinaTerrestre.GetLength(0); i++)
            {
                for (int j = 0; j < matrizMinaTerrestre.GetLength(1); j++)
                {
                    if (matrizMinaTerrestre[i, j] >= Convert.ToInt32(EnumNivelSeguranca.Perigosa))
                    {
                        perigo += matrizMinaTerrestre[i, j];
                    }
                }
            }
            PorcentagemSeguranca = perigo / total;
            var resultado = PorcentagemSeguranca == Convert.ToDouble(EnumNivelSeguranca.Segura)   ? DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_SEGURA :
                            PorcentagemSeguranca <= Convert.ToDouble(EnumNivelSeguranca.Atencao)  ? DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_ATENCAO :
                            PorcentagemSeguranca <= Convert.ToDouble(EnumNivelSeguranca.Perigosa) ? DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_PERIGOSA :
                                                                                                    DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_NAO_RECOMENDADA;
            return String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_PERIGO_TERRENO, PorcentagemSeguranca.ToString("F2"), resultado);
        }
    }
}
