using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Enum com as opções válidas de cotovelo
    /// </summary>
    public enum EnumCotovelo
    {
        [Description("Em Repouso")]
        EmRepouso = 0,

        [Description("Levemente Contraído")]
        LevementeContraido = 1,

        [Description("Contraído")]
        Contraido = 2,

        [Description("Fortemente Contraído")]
        FortementeContraido = 3
    }
}
