using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Enum com as opções válidas de rotação
    /// </summary>
    public enum EnumRotacao
    {
        [Description("Rotação -90º")]
        RotacaoMenos90 = 1,

        [Description("Rotação -45º")]
        RotacaoMenos45 = 2,

        [Description("Em Repouso")]
        EmRepouso = 3,

        [Description("Rotação 45º")]
        Rotacao45 = 4,

        [Description("Rotação 90º")]
        Rotacao90 = 5,
    }
}
