using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Enum com as opções válidas de cotovelo
    /// </summary>
    public enum EnumCotovelo
    {
        [Description("Em Repouso")]
        EmRepouso = 1,

        [Description("Levemente Contraído")]
        LevementeContraido = 2,

        [Description("Contraído")]
        Contraido = 3,

        [Description("Fortemente Contraído")]
        FortementeContraido = 4
    }
}
