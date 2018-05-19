using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Enum com as opções válidas de inclinação
    /// </summary>
    public enum EnumInclinacao
    {
        [Description("Para Cima")]
        ParaCima = 1,

        [Description("Em Repouso")]
        EmRepouso = 2,

        [Description("Para Baixo")]
        ParaBaixo = 3,
    }
}
