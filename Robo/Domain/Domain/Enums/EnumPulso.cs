using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Enum com as opções válidas de pulso
    /// </summary>
    public enum EnumPulso
    {
        [Description("Rotação para -90º")]
        RotacaoMenos90 = 1,

        [Description("Rotação para -45º")]
        RotacaoMenos45 = 2,

        [Description("Em Repouso")]
        EmRepouso = 3,

        [Description("Rotação para 45º")]
        Rotacao45 = 4,

        [Description("Rotação para 90º")]
        Rotacao90 = 5,

        [Description("Rotação para 135º")]
        Rotacao135 = 6,

        [Description("Rotação para 180º")]
        Rotacao180 = 7,
    }
}
