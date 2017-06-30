using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeFighter.UnitTestProject
{
	[TestClass]
	public class UnitTests
	{
		[TestMethod]
		public void _Random_Generator_27_02_2017()
		{
			var test = FighterHelper.Random1(675248, 2);
			Assert.AreEqual(333139, test);

			test = FighterHelper.Random1(34, 1);
			Assert.AreEqual(15, test);

			test = FighterHelper.Random1(9592, 1);
			Assert.AreEqual(64, test);

			test = FighterHelper.Random1(881231, 23);
			Assert.AreEqual(575365, test);
			
			test = FighterHelper.Random1(123891, 15);
			Assert.AreEqual(564496, test);

			test = FighterHelper.Random1(1093, 81);
			Assert.AreEqual(4100, test);
			
			test = FighterHelper.Random1(10000000, 100000);
			Assert.AreEqual(0, test);

			test = FighterHelper.Random1(1934341, 1827);
			Assert.AreEqual(6250000, test);
		}
	}
}