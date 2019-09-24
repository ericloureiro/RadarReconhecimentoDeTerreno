using Dispositivo.Resource;
using System;

namespace Dispositivo
{
    public class VerificaAreaSegurancaService
    {
        private double PorcentagemSeguranca { get; set; }
        public void NivelDeSeguranca(Dispositivo d)
        {
            var total = d.MatrizMinaTerrestre.Length;
            var perigo = 0;
            for (int i = 0; i < d.MatrizMinaTerrestre.GetLength(0); i++)
            {
                for (int j = 0; j < d.MatrizMinaTerrestre.GetLength(1); j++)
                {
                    if (d.MatrizMinaTerrestre[i, j] >= Convert.ToInt32(EnumNivelSeguranca.Perigosa))
                    {
                        perigo += d.MatrizMinaTerrestre[i, j];
                    }
                }
            }
            PorcentagemSeguranca = perigo / total;
            var resultado = PorcentagemSeguranca == Convert.ToDouble(EnumNivelSeguranca.Segura)   ? DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_SEGURA :
                            PorcentagemSeguranca <= Convert.ToDouble(EnumNivelSeguranca.Atencao)  ? DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_ATENCAO :
                            PorcentagemSeguranca <= Convert.ToDouble(EnumNivelSeguranca.Perigosa) ? DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_PERIGOSA :
                                                                                                    DispositivoReconhecimentoTerrenoResource.MENSAGEM_AREA_NAO_RECOMENDADA;
            d.Mensagens.Add(String.Format(DispositivoReconhecimentoTerrenoResource.MENSAGEM_PERIGO_TERRENO, PorcentagemSeguranca.ToString("F2"), resultado));
        }
    }
}
