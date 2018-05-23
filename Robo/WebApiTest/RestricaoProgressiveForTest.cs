using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiTest
{
    [TestClass]
    public class RestricaoProgressiveForTest
    {
        [TestMethod]
        public void TestIntExtension()
        {
            Assert.IsNotNull(IntExtension.IsProgressiveFor(0, 0));
        }

        [TestMethod]
        public void TestProgressiveForEnumCotovelos()
        {
            Assert.IsFalse(((int)EnumCotovelo.EmRepouso).IsProgressiveFor((int)EnumCotovelo.EmRepouso));
            Assert.IsFalse(((int)EnumCotovelo.EmRepouso).IsProgressiveFor((int)EnumCotovelo.Contraido));
            Assert.IsFalse(((int)EnumCotovelo.EmRepouso).IsProgressiveFor((int)EnumCotovelo.FortementeContraido));
            Assert.IsTrue(((int)EnumCotovelo.EmRepouso).IsProgressiveFor((int)EnumCotovelo.LevementeContraido));
            Assert.IsFalse(((int)EnumCotovelo.LevementeContraido).IsProgressiveFor((int)EnumCotovelo.FortementeContraido));
            Assert.IsTrue(((int)EnumCotovelo.LevementeContraido).IsProgressiveFor((int)EnumCotovelo.Contraido));
            Assert.IsFalse(((int)EnumCotovelo.Contraido).IsProgressiveFor((int)EnumCotovelo.EmRepouso));
        }
    }
}
