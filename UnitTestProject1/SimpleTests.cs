using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CodeFighter.UnitTestProject
{
	[TestClass]
	public class SimpleTests
	{
		[TestMethod]
		public void _Simple_Square()
		{
			var test = FighterHelper.Square(new int[] { 2 });
			Assert.AreEqual(4, test[0]);
			Assert.AreEqual(0, test[1]);

			test = FighterHelper.Square(new int[] { 4 });

			Assert.AreEqual(6, test[0]);
			Assert.AreEqual(1, test[1]);

			test = FighterHelper.Square(new int[] { 8 });

			Assert.AreEqual(4, test[0]);
			Assert.AreEqual(6, test[1]);

			test = FighterHelper.Square(new int[] { 0, 1 });

			Assert.AreEqual(0, test[0]);
			Assert.AreEqual(0, test[1]);
			Assert.AreEqual(1, test[2]);
			Assert.AreEqual(0, test[3]);

			test = FighterHelper.Square(new int[] { 6, 1 });

			Assert.AreEqual(6, test[0]);
			Assert.AreEqual(5, test[1]);
			Assert.AreEqual(2, test[2]);
			Assert.AreEqual(0, test[3]);

			test = FighterHelper.Square(new int[] { 8, 8 });

			Assert.AreEqual(4, test[0]);
			Assert.AreEqual(4, test[1]);
			Assert.AreEqual(7, test[2]);
			Assert.AreEqual(7, test[3]);

			test = FighterHelper.Square(new int[] { 8, 9, 6 });

			Assert.AreEqual(4, test[0]);
			Assert.AreEqual(0, test[1]);
			Assert.AreEqual(2, test[2]);
			Assert.AreEqual(7, test[3]);
			Assert.AreEqual(8, test[4]);
			Assert.AreEqual(4, test[5]);


			test = FighterHelper.Square(new int[] { 8, 4, 2, 5, 7, 6 });

			Assert.AreEqual(4, test[0]);
			Assert.AreEqual(0, test[1]);
			Assert.AreEqual(5, test[2]);
			Assert.AreEqual(1, test[3]);
			Assert.AreEqual(6, test[4]);
			Assert.AreEqual(8, test[5]);
			Assert.AreEqual(9, test[6]);
			Assert.AreEqual(5, test[7]);
			Assert.AreEqual(9, test[8]);
			Assert.AreEqual(5, test[9]);
			Assert.AreEqual(5, test[10]);
			Assert.AreEqual(4, test[11]);
		}

		[TestMethod]
		public void _Boring()
		{
			Assert.AreEqual(4, FighterHelper.KthBoring(1));
			Assert.AreEqual(9, FighterHelper.KthBoring(3));
			Assert.AreEqual(12, FighterHelper.KthBoring(5));
			Assert.AreEqual(22, FighterHelper.KthBoring(11));
			Assert.AreEqual(30, FighterHelper.KthBoring(17));
		}

		[TestMethod]
		public void _Snake_Move()
		{
			var board = new[] { 4, 3 };

			var snake = new List<int> { 22, 32, 31, 30, 20, 10, 00 };

			var newSnake = snake.ToList();

			Assert.AreEqual(false, FighterHelper.Move(board, newSnake, 10));
			Assert.AreEqual(false, FighterHelper.Move(board, newSnake, 01));

			Assert.AreEqual(22, newSnake[0]);
			Assert.AreEqual(00, newSnake[snake.Count - 1]);
		}

		//[TestMethod]
		//public void _Snake_Try_Moves()
		//{
		//	var board = new[] { 4, 3 };

		//	var snake = new List<int> { 22, 32, 31, 30, 20, 10, 00 };

		//	Assert.AreEqual(0, FighterHelper.TryMoves(board, snake).Count());			
		//}

		[TestMethod]
		public void _Snake_Count_Moves_A()
		{
			var board = new[] { 4, 3 };
			var snake = new int[][] { new[] { 2, 2 }, new[] { 3, 2 }, new[] { 3, 1 }, new[] { 3, 0 }, new[] { 2, 0 }, new[] { 1, 0 }, new[] { 0, 0 } };

			Assert.AreEqual(7, FighterHelper.CountValidSnakePaths(board, snake, 3));
		}

		[TestMethod]
		public void _Snake_Count_Moves_B()
		{
			var board = new[] { 2, 3 };
			var snake = new int[][] { new[] { 0, 2 }, new[] { 0, 1 }, new[] { 0, 0 }, new[] { 1, 0 }, new[] { 1, 1 }, new[] { 1, 2 } };

			Assert.AreEqual(1, FighterHelper.CountValidSnakePaths(board, snake, 10));
		}

		[TestMethod]
		public void _Snake_Count_Moves_C()
		{
			var board = new[] { 3, 4 };
			var snake = new int[][] { new[] { 1, 1 }, new[] { 1, 2 }, new[] { 1, 3 } };

			Assert.AreEqual(6, FighterHelper.CountValidSnakePaths(board, snake, 2));
		}

		[TestMethod]
		public void _Snake_Count_Moves_D()
		{
			var board = new[] { 10, 10 };
			var snake = new int[][] { new[] { 4, 4 }, new[] { 4, 5 } };

			Assert.AreEqual(577025190726, FighterHelper.CountValidSnakePaths(board, snake, 20));
		}

		[TestMethod]
		public void _Snake_Count_Moves_E()
		{
			var board = new[] { 10, 10 };
			var snake = new int[][] { new[] { 4, 4 }, new[] { 4, 5 } };

			Assert.AreEqual(4058, FighterHelper.CountValidSnakePaths(board, snake, 6));
		}

		[TestMethod]
		public void _I_Scream()
		{
			var toTest = FighterHelper.iScream(8, 15);

			Assert.AreEqual(170544, toTest);

			toTest = FighterHelper.iScream(12, 15);
			Assert.AreEqual(7726160, toTest);

			toTest = FighterHelper.iScream(15, 15);
			Assert.AreEqual(77558760, toTest);
		}

		[TestMethod]
		public void _Dance_Floor()
		{
			var toTest = 0;

			toTest = FighterHelper.DanceSteps("207");
			Assert.AreEqual(4, toTest);

			toTest = FighterHelper.DanceSteps("8");
			Assert.AreEqual(0, toTest);

			toTest = FighterHelper.DanceSteps("221");
			Assert.AreEqual(4, toTest);

			toTest = FighterHelper.DanceSteps("211");
			Assert.AreEqual(-1, toTest);

			toTest = FighterHelper.DanceSteps("42923");
			Assert.AreEqual(10, toTest);

			toTest = FighterHelper.DanceSteps("42023");
			Assert.AreEqual(10, toTest);

			toTest = FighterHelper.DanceSteps("83426394869237923");
			Assert.AreEqual(32, toTest);

			toTest = FighterHelper.DanceSteps("200");
			Assert.AreEqual(2, toTest);
		}

		[TestMethod]
		public void _Number_Tester()
		{
			var ploum = FighterHelper.NumberSystem(new int[] { 0, 3 }, 10);
			Assert.AreEqual("3003", ploum);

			ploum = FighterHelper.NumberSystem(new int[] { 2, 3 }, 10);
			Assert.AreEqual("233", ploum);

			ploum = FighterHelper.NumberSystem(new int[] { 4, 7, 8 }, 3274653);
			Assert.AreEqual("47788878774888", ploum);
		}

		[TestMethod]
		public void _Number_Tester_Alien_Decomp()
		{
			var plif = FighterHelper.OtherDecompose(11, 2);
			CollectionAssert.AreEqual(new List<int> { 2, 1, 1 }, plif);

			plif = FighterHelper.OtherDecompose(15, 2);
			CollectionAssert.AreEqual(new List<int> { 1, 1, 1, 1 }, plif);

			plif = FighterHelper.OtherDecompose(8, 2);
			CollectionAssert.AreEqual(new List<int> { 1, 1, 2 }, plif);

			plif = FighterHelper.OtherDecompose(11, 2);
			CollectionAssert.AreEqual(new List<int> { 2, 1, 1 }, plif);

			plif = FighterHelper.OtherDecompose(9, 3);
			CollectionAssert.AreEqual(new List<int> { 2, 3 }, plif);

			plif = FighterHelper.OtherDecompose(9, 4);
			CollectionAssert.AreEqual(new List<int> { 2, 1 }, plif);

			plif = FighterHelper.OtherDecompose(27, 4);
			CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, plif);

			plif = FighterHelper.OtherDecompose(27, 5);
			CollectionAssert.AreEqual(new List<int> { 5, 2 }, plif);
		}

		[TestMethod]
		public void _String_Decoder()
		{
			var toTest = FighterHelper.Decode("hello");
			Assert.AreEqual("loovs", toTest);

			toTest = FighterHelper.Decode(" challenge ");
			Assert.AreEqual(" vtmvoozsx ", toTest);

			toTest = FighterHelper.Decode("this is a test");
			Assert.AreEqual("ghvg zh r hrsg", toTest);

			toTest = FighterHelper.Decode("codefights");
			Assert.AreEqual("hgstruvwlx", toTest);
		}

		[TestMethod]
		public void _String_Reverter()
		{
			var toTest = FighterHelper.Reverse('a');

			Assert.AreEqual("rou", toTest);
		}

		[TestMethod]
		public void _Format_Tester()
		{
			var test = "100.001";
			var success = FighterHelper.IsValidNumber(test, false, false, true);
			Assert.AreEqual(success, true);

			test = "10.000.001";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, false);

			test = "0";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, true);

			test = "123";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, true);

			test = "012345678901234";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, true);

			test = "1000E0001";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, false);

			test = "10,0.001001";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, false);

			test = "100,00";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, false);

			test = ",111";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, false);

			test = "111,";
			success = FighterHelper.IsValidNumber(test, true, true, true);
			Assert.AreEqual(success, false);
		}

		[TestMethod]
		public void _Continuator()
		{
			var test = new int[] { 5, 2 };
			var success = FighterHelper.ToBeContinued(test);
			Assert.AreEqual(success.Length, 2);

			test = new int[] { 1234567, 891011 };
			success = FighterHelper.ToBeContinued(test);
			Assert.AreEqual(success.Length, 12);
		}

		[TestMethod]
		public void _PNicer()
		{
			var success = FighterHelper.PNiceNumbers(16, 2);
			Assert.AreEqual(15, success);

			success = FighterHelper.PNiceNumbers(22, 2);
			Assert.AreEqual(15, success);

			success = FighterHelper.PNiceNumbers(20, 19);
			Assert.AreEqual(17, success);

			success = FighterHelper.PNiceNumbers(38, 19);
			Assert.AreEqual(36, success);

			success = FighterHelper.PNiceNumbers(2017, 3);
			Assert.AreEqual(1856, success);

			success = FighterHelper.PNiceNumbers(999999999, 41);
			Assert.AreEqual(success, 802987210);
		}

		[TestMethod]
		public void _AFMs()
		{
			var ploum = FighterHelper.AFM_numbers(1);

			ploum = FighterHelper.AFM_numbers(3);

			ploum = FighterHelper.AFM_numbers(6);

			ploum = FighterHelper.AFM_numbers(15);
		}

		[TestMethod]
		public void _LongestConsecutives()
		{
			var max = FighterHelper.LongestConsecutive(new int[] { 1, 2, 3, 4, 5, 6 });
			Assert.AreEqual(2, max);

			max = FighterHelper.LongestConsecutive(new int[] { 1, 2, 3 });
			Assert.AreEqual(2, max);

			max = FighterHelper.LongestConsecutive(new int[] { 1 });
			Assert.AreEqual(0, max);

			max = FighterHelper.LongestConsecutive(new int[] { 1, 2, 15, 2147483647, 3 });
			Assert.AreEqual(3, max);

			max = FighterHelper.LongestConsecutive(new int[] { 103, 15, 31, 975, 245231, 126701 });
			Assert.AreEqual(2, max);
		}

		[TestMethod]
		public void _PairSumOr()
		{
			var test = new int[] { 1, 2, 3 };
			var result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(9, result);

			test = new int[] { 1, 2, 3, 4, 5 };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(51, result);

			test = new int[] { 2, 3, 18, 53 };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(205, result);

			test = new int[] { 5, 4, 3, 2, 1 };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(51, result);

			test = new int[] { 1, 1 };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(1, result);

			test = new int[] { };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(0, result);

			test = new int[] { 1, 0, 3, 45, 21, 8, 98, 1501, 2456, 45213, 1472435, 4565, 78, 321462 };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(23665130, result);

			test = new int[] { 1979, 1980, 1981, 1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017 };
			result = FighterHelper.pairSumOr(test);
			Assert.AreEqual(1495408, result);
		}

		[TestMethod]
		public void _MeaningOfLife()
		{
			long test = 0;

			test = FighterHelper.meaningOfLife("c"); Assert.AreEqual(38, test);

			test = FighterHelper.meaningOfLife("C"); Assert.AreEqual(12, test);

			test = FighterHelper.meaningOfLife("1"); Assert.AreEqual(1, test);

			test = FighterHelper.meaningOfLife("f"); Assert.AreEqual(41, test);

			test = FighterHelper.meaningOfLife("0"); Assert.AreEqual(0, test);

			test = FighterHelper.meaningOfLife("A"); Assert.AreEqual(10, test);

			test = FighterHelper.meaningOfLife("1A"); Assert.AreEqual(52, test);

			test = FighterHelper.meaningOfLife("10"); Assert.AreEqual(42, test);

			test = FighterHelper.meaningOfLife("ABC"); Assert.AreEqual(18114, test);

			test = FighterHelper.meaningOfLife("abc"); Assert.AreEqual(65096, test);

			test = FighterHelper.meaningOfLife("100"); Assert.AreEqual(1764, test);
		}

		[TestMethod]
		public void _Leftover()
		{
			long test = 0;

			test = FighterHelper.leftOver("antidisestablishmentarianism"); //Assert.AreEqual(27, test);
			test = FighterHelper.leftOver("supercalifragilisticexpialidocious");// Assert.AreEqual(5, test);

			test = FighterHelper.leftOver("appetite");// Assert.AreEqual(4, test);
			test = FighterHelper.leftOver("cavern"); //Assert.AreEqual(3, test);
			test = FighterHelper.leftOver("cb");// Assert.AreEqual(1, test);
			test = FighterHelper.leftOver("bc");// Assert.AreEqual(1, test);
			test = FighterHelper.leftOver("2017");// Assert.AreEqual(2, test);

			test = FighterHelper.leftOver("watcher"); //Assert.AreEqual(1, test);
			test = FighterHelper.leftOver("hello"); //Assert.AreEqual(2, test);
		}

		[TestMethod]
		public void _ChangeVoyelsInCycle()
		{
			string word;

			word = FighterHelper.changeOfVowelsInCycleTry(1, "potato");
			Assert.AreEqual("ototap", word);

			word = FighterHelper.changeOfVowelsInCycleTry(3, "this test is of potato");
			Assert.AreEqual("itetip fo sa tsot soht", word);

			word = FighterHelper.changeOfVowelsInCycleTry(350, "a true magic is a potato think");
			Assert.AreEqual("knaht otatip i sa cegum airt o", word);

			word = FighterHelper.changeOfVowelsInCycleTry(7, "N vwls hr");
			Assert.AreEqual("rh slwv N", word);

			word = FighterHelper.changeOfVowelsInCycleTry(10, "Ojf lsnelI UFlsn Eeiuo nnky Ynak jhA");
			Assert.AreEqual("ahj konY yknn uieEU nslFI elOnsl fjA", word);
		}

		[TestMethod]
		public void _OnesOrZeros()
		{
			int result;

			result = FighterHelper.orezRoEno(1);
			Assert.AreEqual(1, result);

			result = FighterHelper.orezRoEno(2);
			Assert.AreEqual(1, result);

			result = FighterHelper.orezRoEno(23);
			Assert.AreEqual(5, result);

			result = FighterHelper.orezRoEno(5);
			Assert.AreEqual(3, result);

			result = FighterHelper.orezRoEno(9);
			Assert.AreEqual(2, result);

			result = FighterHelper.orezRoEno(749);
			Assert.AreEqual(7, result);

			result = FighterHelper.orezRoEno(16718939);
			Assert.AreEqual(24, result);

			result = FighterHelper.orezRoEno(1082130431);
			Assert.AreEqual(31, result);

			result = FighterHelper.orezRoEno(2147483647);
			Assert.AreEqual(31, result);

			result = FighterHelper.orezRoEno(4226847);
			Assert.AreEqual(15, result);
		}

		[TestMethod]
		public void _AlienBitReading()
		{
			string input, test, expected;

			input = "0.116101115116035049";
			expected = "test#1";
			test = FighterHelper.ReadAlienBit(input);
			Assert.AreEqual(expected, test);

			input = "0.073110099111109105110103032084114097110115109105115105111110";
			expected = "Incoming Transmision";
			test = FighterHelper.ReadAlienBit(input);
			Assert.AreEqual(expected, test);

			input = "0.072101108108111032078101105103104098111114033032040060062046046060062041";
			expected = "Hello Neighbor! (<>..<>)";
			test = FighterHelper.ReadAlienBit(input);
			Assert.AreEqual(expected, test);

			input = "0.083111032116104105115032105115032104111119032121111117032115097121044032034073032110101101100032109111114101032099111102102101101046046046034032116111032097108105101110115046046046032108111108032060046060";
			expected = @"So this is how you say, ""I need more coffee..."" to aliens... lol <.<";
			test = FighterHelper.ReadAlienBit(input);
			Assert.AreEqual(expected, test);
		}

		[TestMethod]
		public void _dDelta()
		{
			int test = 0;

			test = FighterHelper.dDelta(12345, 6);
			Assert.AreEqual(5, test);

			test = FighterHelper.dDelta(67890, 13);
			Assert.AreEqual(9, test);

			test = FighterHelper.dDelta(12345, 6);
			Assert.AreEqual(5, test);
		}

		[TestMethod]
		public void _1000_Primes()
		{
			var input = new int[] { 143, 21, 2, 5, 14 };
			var toTest = FighterHelper.relativePrimes(input);

			Assert.AreEqual(2, toTest.Length);
			CollectionAssert.Contains(input, 143);
			CollectionAssert.Contains(input, 5);

			input = new int[] { 2, 4 };
			toTest = FighterHelper.relativePrimes(input);

			Assert.AreEqual(0, toTest.Length);

			input = new int[] { 135, 157, 440, 25, 600, 441, 833, 515, 740, 111, 948, 788, 219, 970, 409, 628, 779, 564, 795, 270, 356, 822, 446, 440, 699, 846, 662, 75, 388, 393, 52, 668, 108, 696, 383, 105, 123, 224, 172, 92, 571, 805 };
			toTest = FighterHelper.relativePrimes(input);

			Assert.AreEqual(3, toTest.Length);
			CollectionAssert.Contains(input, 409);
			CollectionAssert.Contains(input, 383);
			CollectionAssert.Contains(input, 571);

			input = new int[] { 933, 550, 259, 472, 913, 145, 577, 578, 121, 187, 396, 921, 680, 458, 962, 613, 682, 635, 662, 563, 472, 613, 682, 737, 690, 215, 951, 16, 962, 815, 671, 601, 812, 542, 15, 525, 454, 188, 872, 52, 941, 471, 910, 587, 691, 553, 914, 213, 867, 36, 456, 861, 977, 906, 39, 707, 912, 392, 720, 808, 731, 812, 876, 198, 625, 255, 623, 740 };
			toTest = FighterHelper.relativePrimes(input);

			Assert.AreEqual(7, toTest.Length);
			CollectionAssert.Contains(input, 577);
			CollectionAssert.Contains(input, 563);
			CollectionAssert.Contains(input, 601);
			CollectionAssert.Contains(input, 941);
			CollectionAssert.Contains(input, 587);
			CollectionAssert.Contains(input, 691);
			CollectionAssert.Contains(input, 977);
		}

		[TestMethod]
		public void _TernBaseSum()
		{
			var toTest = FighterHelper.weightYourTern(8);
			Assert.AreEqual(0, toTest);

			toTest = FighterHelper.weightYourTern(7);
			Assert.AreEqual(1, toTest);

			toTest = FighterHelper.weightYourTern(-7);
			Assert.AreEqual(-1, toTest);
		}

		[TestMethod]
		public void _PrimeClimber()
		{
			var toTest = FighterHelper.primeClimb(60);
			Assert.AreEqual("2235", toTest);

			toTest = FighterHelper.primeClimb(20);
			Assert.AreEqual("225", toTest);

			toTest = FighterHelper.primeClimb(2147483647);
			Assert.AreEqual("2147483647", toTest);

			toTest = FighterHelper.primeClimb(2147117569);
			Assert.AreEqual("463372", toTest);
		}

		[TestMethod]
		public void _IDontKnower()
		{
			string toTest = "";

			toTest = FighterHelper.iDontKnow(2);
			Assert.AreEqual("2", toTest);

			toTest = FighterHelper.iDontKnow(216);
			Assert.AreEqual("46440", toTest);

			toTest = FighterHelper.iDontKnow(999999);
			Assert.AreEqual("999997000002", toTest);

			toTest = FighterHelper.iDontKnow(147083927);
			Assert.AreEqual("21633681434657402", toTest);

			toTest = FighterHelper.iDontKnow(long.MaxValue);
			Assert.AreEqual("85070591730234615838173535747377725442", toTest);
		}
	}
}