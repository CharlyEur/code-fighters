using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using SPath = System.Tuple<string, System.Collections.Generic.List<int>>;
//using SPath = Tuple<string, List<int>>;

namespace CodeFighter
{
    public static class FighterHelper
    {
		#region Closed Challenges

		/* Using Numerics
		 * 
		using System.Numerics;
		public static long RandomNumerics(int seed, int n)
		{
			long result = seed;

			for (int i = 0; i < n; i++)
				result = NextNumerics(result);

			return result;
		}

		public static long NextNumerics(long seed)
		{
			BigInteger buffer = new BigInteger(seed);

			int seedSize = ((int)Math.Log10(seed)) + 1;
			int midSize = seedSize / 2;

			BigInteger intermediary = BigInteger.Pow(buffer, 2);
			string fullNumber = intermediary.ToString();

			return long.Parse(fullNumber.Substring(midSize, seedSize));
		}
		*/

		public static long Random1(int seed, int n)
		{
			int[] result = seed.ToString().Select(x => int.Parse(x.ToString())).Reverse().ToArray() ;

			for (int i = 0; i < n; i++)
				result = Next(result);

			return long.Parse(string.Concat(result.Select(x=> x.ToString()).Reverse()));
		}

		public static int[] Next(int[] seed)
		{
			int seedSize = seed.Length;

			var intermediary = Square(seed);

			return ExtractArray(intermediary, seedSize);			
		}

		public static int[] Square(int[] input)
		{
			var result = new int[2 * input.Length];

			for (int i = 0; i < input.Length; i++)
			{
				for (int j = 0; j < input.Length; j++)
				{
					var digitProduct = input[i] * input[j];

					var currentDigit = result[i + j];

					var sum = digitProduct + currentDigit;

					result[i + j] = sum % 10;
					result[i + j + 1] += sum / 10;
				}
			}

			return result;
		}

		private static int[] ExtractArray(int[] intermediary, int seedSize)
		{
			var midSize = (int) Math.Ceiling( seedSize / 2.0);
			var result = new int[seedSize];

			for (int i = 0; i < seedSize; i++)
				result[i] = intermediary[i + midSize];

			return result;
		}

		public static int KthBoring(int k)
		{
			var max = 3 * k + 2;

			bool[] isBoring = new bool[max];
			
			for (int i = 2; i < max; i++)
			{
				if (!isBoring[i])
				{
					var counter = 2;
					while (counter * i < max)
					{
						isBoring[counter * i] = true;
						counter++;
					}
				}
			}

			int fim = 1;
			int fi = 2;

			while (fi < max)
			{
				isBoring[fi] = false;
				var inter = fi;
				fi = fi + fim;
				fim = inter;
			}

			int t = 0;
			while(k>0)
			{
				if (isBoring[t])
					k--;
				t++;
			}

			return t-1;
		}
		
		// 0 = U, 1 = R, 2 = D, 3 = L
		// go = remove end then
		// go up = add(h, h+1) if free
		// go left = add(h+1, h) if free
		// go down = add(h, h-1) if free
		// go right = add(h-1, h) if free
		public static long CountValidSnakePaths(int[] board, int[][] snake, int n)
		{
			var cache = new SortedList<string, long>();
			var snakeModern = snake.Select(p => 10 * p[0] + p[1]).ToList();

			return FullCountValidSnakePaths(board, snakeModern, n, cache);
		}

		public static long FullCountValidSnakePaths(int[] board, List<int> snake, int n, SortedList<string, long> cache)
		{
			if (n == 0)
				return 1;

			var key = string.Format("{0}-{1}", GetUniqueId(snake), n);
			long result = 0;

			if (cache.ContainsKey(key))
				result = cache[key];
			else
			{
				var next = TryMoves(board, snake);
				foreach (var item in next)
				{ 
					result += FullCountValidSnakePaths(board, item.Item2, n - 1, cache);
				}

				cache.Add(key, result);
			}

			return result;
		}

		private static string GetUniqueId(List<int> snake)
		{
			return string.Join("", snake.Select(x => ((x < 10) ? "0" : "") + x.ToString()));
		}

		private static SortedList<int, string> directions = new SortedList<int, string> { { -10, "L" }, { -1, "D" }, { 1, "U" }, { 10, "R" } };

		public static IEnumerable<Tuple<string, List<int>>> TryMoves(int[] board, List<int> snake)
		{
			foreach(var dir in directions)
			{
				var newSnake = snake.ToList();
				if (Move(board, newSnake, dir.Key))
					yield return new SPath(dir.Value, newSnake);
			}
		}

		public static bool Move(int[] board, List<int> snake, int direction)
		{
			var head = snake[0];
			var tail = snake[snake.Count-1];

			var headX = head % 10;
			var headY = head / 10;

			if (   headX == 0 && direction == -1
				|| headX == (board[1] - 1) && direction == +1
				|| headY == (board[0] - 1) && direction == 10
				|| headY == 0 && direction == -10)
				return false;

			var newHead = head + direction;

			var valid = (!snake.Contains(newHead) || newHead == tail);

			if (valid)
			{
				snake.Insert(0, newHead);
				snake.Remove(tail);
			}

			return valid;
		}

		public static int iScream(int flavors, int scoops)
		{
			double n = flavors-1;
			var r = 1.0;
			
			while(scoops>=1)
				r *= ++n / scoops--;

			return (int) (r+.5);
		}

		#endregion

		public static int DanceSteps(string dancefloor)
		{
			int[] stepTable = dancefloor.Select(x=>int.Parse(""+x)).ToArray();

			int size = stepTable.Length;

			int index = 0;
			int count = 0;

			bool[] walked = new bool[size];

			bool staysIn = true;

			while (staysIn)
			{
				if (walked[index])
					return -1;

				walked[index] = true;
				var steps = stepTable[index];
				var newIdx = index;

				if (steps == 0)
					break;

				if (steps % 2 == 0)
					newIdx += steps;
				else
					newIdx -= steps;

				staysIn = newIdx >= 0 && newIdx < size;

				if (staysIn)
					count += steps;
				else
					count += (newIdx < 0 ? index : size - index - 1);

				index = newIdx;
			}

			return count;
		}

		public static string NumberSystem(int[] digits, int n)
		{
			var buffer = new List<int>();

			if (digits[0] == 0)
			{
				buffer = Decompose(n - 1, digits.Length);
				return string.Concat(buffer.Select(x => digits[x] + ""));
			}
			else
			{
				buffer = OtherDecompose(n, digits.Length);
				return string.Concat(buffer.Select(x => digits[x-1] + ""));
			}			
		}

		public static List<int> OtherDecompose(int input, int numericalBase)
		{
			var inter = Decompose(input, numericalBase);

			while (inter.Contains(0))
			{
				int zx = inter.IndexOf(0);
				if (zx == 0)
					inter.RemoveAt(0);
				else
				{
					inter[zx - 1] -= 1;
					inter[zx] = numericalBase;
				}
			}
			
			return inter;
		}

		public static List<int> Decompose(int input, int numericalBase)
		{
			var digits = new List<int>();

			if (input < numericalBase)
			{
				digits.Add(input);
				return digits;
			}

			var powerDouble = Math.Log(input) / Math.Log(numericalBase);
			var power = (int)Math.Ceiling(powerDouble);

			for (var i = power; i >= 0; i--)
			{
				var curtPower = (int)Math.Pow(numericalBase, i);
				var digit = input / curtPower;
				digits.Add(digit);

				input -= digit * curtPower;
			}

			while (digits[0] == 0)
				digits.RemoveAt(0);

			return digits;
		}

		public static string Decode(string input)
		{
			var result = "";
			var size = input.Length;
			int j = size - 1;

			for (int i = 0; i < size; i++)
			{
				if (input[i] == ' ')
				{
					result += ' ';
				}
				else
				{
					while (input[j] == ' ')
						j--;

					result += char.ConvertFromUtf32('a' + 25 - input[j] + 'a');
					j--;
				}
			}
			
			return result;
		}

		//public static string Decode(string input)
		//{
		//	var spaces = new List<int>();

		//	for (int i = 0; i < input.Length; i++)
		//	{
		//		if (input[i] == ' ')
		//			spaces.Add(i);
		//	}

		//	string otherInput = input.Replace(" ", "");

		//	var shifter = Enumerable.Range(0, otherInput.Length).Reverse();

		//	string newString = string.Concat(shifter.Select(x => Reverse(otherInput[x])));

		//	foreach (var item in spaces)
		//	{
		//		newString = newString.Insert(item, " ");
		//	}

		//	return newString;
		//}

		public static string Reverse(char v)
		{
			return char.ConvertFromUtf32('a' + 25 - v + 'a'); 
		}

		public static bool IsValidNumber(string test, bool negativeAllowed, bool commaAllowed, bool decimalAllowed)
		{
			NumberFormatInfo provider = new NumberFormatInfo();
			provider.NumberDecimalSeparator = ".";
			provider.NumberGroupSeparator = ",";
			provider.NumberGroupSizes = new int[] { 3 };

			double result;
			var success = double.TryParse(test, NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, provider, out result);

			if (!negativeAllowed && result < 0)
				return false;

			return success;
		}

		public static int[] ToBeContinued(int[] f)
		{
			var result = new List<int>();
			int quotient = f[0];
			int divisor = f[1];

			while (divisor != 0)
			{
				result.Add(quotient / divisor);
				int modulo = quotient % divisor;
				quotient = divisor;
				divisor = modulo;
			}

			return result.ToArray();
		}

		public static int PNiceNumbers(int n, int p)
		{
			int buffer = ConvertToBaseP(n, p).Aggregate(1, (x,y) => x * (y+1));
			
			return n - buffer + 1;
		}

		public static IEnumerable<int> ConvertToBaseP(int candidate, int numBase)
		{
			int power = (int) (Math.Log(candidate) / Math.Log(numBase));

			for (int i = power; i >= 0; i--)
			{
				int pPower = ((int)Math.Pow(numBase, i));
				int digit = candidate / pPower;
				candidate -= digit * pPower;
				yield return digit;
			}
		}

		public static int[] AFM_numbers(int bits)
		{
			int[] buffer = new int[] { 0, 1 };

			while (bits > 0)
			{
				int local = buffer[0];
				buffer[0] = buffer[1];
				buffer[1] = 2 * buffer[0] + local % 2;
				bits--;
			}

			return buffer;
		}

		public static int LongestConsecutive(int[] array)
		{
			var source = ExtractLength(array).ToList();
			int max = source.Max();
			return source.IndexOf(max);
		}

		public static IEnumerable<int> ExtractLength(int[] array)
		{
			foreach (var item in array)
				yield return Consecutive(ToBinary(item).ToList());
		}

		public static int Consecutive(IEnumerable<int> array)
		{
			int max = 0;
			int buffer = 0;

			foreach (var item in array)
			{
				if (item == 1)
				{
					buffer++;
					if (buffer > max)
						max = buffer;
				}
				else
					buffer = 0;
			}

			return max;
		}

		public static IEnumerable<int> ToBinary(int candidate)
		{
			while(candidate > 0)
			{
				int digit = candidate % 2;
				candidate /= 2;
				yield return digit;
			}
		}

		public static long pairSumOr(int[] arr)
		{
			long sum = 0;
			long size = arr.Length;
			long total = CountPairs(size);

			if (size == 0)
				return 0;

			var arrMod = arr.Select(x => ToBinary(x).ToList()).ToList();

			var maxSize = arrMod.Select(x => x.Count).Max();

			for (int i = 0; i < maxSize; i++)
			{
				int nb0 = 0;

				for (int j = 0; j < arr.Length; j++)
				{
					if (arrMod[j].Count <= i)
					{
						nb0++;
					}
					else
					{
						if (arrMod[j][i] == 0)
							nb0++;
					}
				}

				sum += ((int)Math.Pow(2, i)) * (total - CountPairs(nb0));
			}

			return sum;
		}

		public static long CountPairs(long nb)
		{
			if (nb < 2)
				return 0;

			return (nb * (nb - 1)) / 2; ;
		}

		public static long meaningOfLife(string n)
		{
			string table = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdef";

			long buffer = 0;
			int l = n.Length;

			for (int i = 0; i < l; i++)
				buffer += table.IndexOf(n[l - i - 1]) * ((long)Math.Pow(l, i));

			return buffer;
		}

		public static long leftOver(string n)
		{
			long s = 0;
			
			for (int i = 0; i < n.Length; i++)
				s += n[i] - 97;

			return Math.Abs(s) % n.Length;
		}

		public static string changeOfVowelsInCycle(int cycle, string text)
		{
			var voyels = "aeiouAEIOU";

			var reversedText = text.Reverse().ToArray();
			var textVoyels = new List<int[]>();

			for (int i = 0; i < text.Length; i++)
			{
				int test = voyels.IndexOf(reversedText[i]);

				if (test >= 0)
				{
					textVoyels.Add( new int[] { i, test } );
				}
			}

			int size = textVoyels.Count;

			if (size > 0)
			{
				int newCycle = cycle % size;

				for (int i = 0; i < textVoyels.Count; i++)
						reversedText[textVoyels[i][0]] = voyels[textVoyels[(i - newCycle + size) % size][1]];
			}

			return string.Concat(reversedText);
		}

		public static string changeOfVowelsInCycleTry(int cycle, string text)
		{
			var voyels = "aeiouAEIOU";
			var result = "";

			var textVoyels = text.Where(x => voyels.Contains(x)).ToArray();
			int size = textVoyels.Count();

			int counter = 0;
			int index = text.Length;

			while (index > 0)
			{
				index--;
				int test = voyels.IndexOf(text[index]);
				int realCycle = 0;

				if (size > 0)
					realCycle = cycle % size;

				if (test >= 0)
				{
					result += textVoyels[(size - 1 - counter + realCycle) % size];
					counter++;
				}
				else
					result += text[index];
			}

			return result;
		}

		public static int orezRoEno(int k)
		{
			int resultZero = 0;
			int resultOne = 0;
			while (k > 0)
			{
				resultZero += k % 2 == 0 ? 1 : 0;
				resultOne += k % 2 == 0 ? 0 : 1;
				k /= 2;
			}

			return resultOne | resultZero;
		}

		public static string ReadAlienBit(string abit)
		{
			string result = "";
			for (int i = 2; i < abit.Length;)
			{
				int hundred = abit[i++] - 48;
				int tenths = abit[i++] - 48;
				int units = abit[i++] - 48;
				result += (char)( hundred*100 + tenths*10 + units );
			}

			return result;
		}

		public static int dDelta(int number, int b)
		{
			int min = b, max = 0;

			while (number > 0)
			{
				int d = number % b;

				if (min > d)
					min = d;

				if (max < d)
					max = d;

				number /= b;
			}

			return max - min;
		}

		public static int[] relativePrimes(int[] v)
		{
			var result = new List<int>();
			var rc = new bool[v.Length];

			for (int i = 0; i < v.Length; i++)
			{
				for (int j = 0; j < v.Length; j++)
				{
					if (rc[i])
						break;

					if (j == i)
						continue;

					if (!ArePrimes(v[i], v[j]))
					{
						rc[i] = true;
						rc[j] = true;
						break;
					}
				}

				if (!rc[i])
					result.Add(v[i]);
			}

			return result.ToArray();
		}

		public static bool ArePrimes(int x, int y)
		{
			int a = Math.Max(x, y), b = Math.Min(x, y);

			while (b > 0)
			{
				int l = a % b;
				a = b;
				b = l;
			}

			return a == 1 || a > 1000;
		}

		public static int weightYourTern(long t)
		{
			long a = Math.Sign(t), s = 0, r = 0, n = a * t;

			while (n > 0)
			{
				r += n % 3;
				s += r > 2 ? 0 : r < 2 ? r : -1;
				r = r > 1 ? 1 : 0;

				n /= 3;
			}

			s += r;

			return (int)(s * a);
		}

		public static string primeClimb(int n)
		{
			int i = 2, u = (int)Math.Sqrt(n), j, p, e;
			//var c = new bool[u + 1];

			var r = "";

			while (n > 1 && i <= u)
			{
				e = 0;

				while (n % i == 0)
				{
					n /= i;
					e++;
				}

				r += (e > 0) ? i + "" : "";
				r += (e > 1) ? e + "" : "";

				j = 2; p = i * j;
				//while (p < u)
				//{
				//	c[p] = true;
				//	p = i * j++;
				//}

				i++;

				//while (c[i])
				//	i++;
			}

			if (n > 1)
				r += n;

			return r;
		}

		public static string iDontKnow(long n)
		{
			var a = new List<long>();
			var b = new List<long>();

			long m = n - 1, p, d, s, z = 10;
			
			while (n > 0) {

				a.Add(n % z);
				b.Add(m % z);

				n /= z;
				m /= z;
			}
			
			var r = new long[2 * a.Count];

			for (int i = 0; i < a.Count; i++)
			{
				for (int j = 0; j < b.Count; j++)
				{
					p = a[i] * b[j];

					d = r[i + j];

					s = p + d;

					r[i + j] = s % z;
					r[i + j + 1] += s / z;
				}
			}

			string o = string.Concat(r.Reverse());

			while (o[0] == '0')
				o = o.Remove(0, 1);

			return o;
		}
	}
}
