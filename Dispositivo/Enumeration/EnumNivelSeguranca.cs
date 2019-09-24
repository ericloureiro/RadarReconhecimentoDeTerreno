using System.ComponentModel;

namespace Dispositivo
{
    public enum EnumNivelSeguranca
    {
        [Description("1 - Área de Segura")]
        Segura = 0,
        [Description("2 - Área de atenção")]
        Atencao = 10,
        [Description("3 - Área perigosa")]
        Perigosa = 50,
        [Description("4 - Área não recomendada")]
        NaoRecomendada
    }
}
