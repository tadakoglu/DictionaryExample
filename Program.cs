using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InterviewPerfect
{
    class Maliyet
    {
        public int i { get; set; }
        public int j { get; set; }
        public int maliyet { get; set; }
    }
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    class Program
    {
        public int solution(int[] A, int K)
        {
            int n = A.Length;
            int best = 0;
            int count = 1;
            for (int i = 0; i < n - K + 1; i++)
            { // <=8
                if (A[i] == A[i + 1])
                    count = count + 1;
                else
                    count = 0;
                if (count > best)
                    best = count;
            }
            int result = best + K;

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.count(new[] { 1, 1, 1 , 4, 2, 5, 5, 5, 5 });

        }
        public void count(int[] dizi) // Dictionary, find maximum number of repeating numbers and return
        {
            Dictionary<int, object> countsDic = new Dictionary<int, object>();
            foreach (int item in dizi)
            {
                object val;
                if (countsDic.TryGetValue(item, out val))
                {
                    int numberOfItems = int.Parse(countsDic[item].ToString()) + 1; // increase by 1
                    countsDic[item] = numberOfItems;
                }
                else
                {
                    countsDic.Add(item, 1);
                }
            }
            KeyValuePair<int, object> result = countsDic.OrderByDescending(dic => dic.Value).First();
            System.Console.WriteLine(result.Key + " element is the maximum number of recurring with " + result.Value);
            Console.Read();
        }
        static bool isAlmostPalindrome(string word)
        {
            // true : if allready palindrome ||  one letter change is enough to make it palindrome

            string left = "";
            string right = "";
            if (word.Length % 2 == 1) // if odd, remove middle
            {
                word = word.Remove(word.Length / 2, 1);
            }
            left = word.Substring(0, word.Length / 2); // cut left
            right = word.Substring(word.Length / 2, word.Length / 2); // cut right

            right = right.Reverse().ToString(); // right is normalized
            int diffCounter = 0;

            for (int i = 0; i < left.Length; i++) // left.Length equals to right.Length
            {
                if (left[i] == right[i])
                {
                    continue;
                }
                else
                {
                    diffCounter++;
                }
            }

            if (diffCounter == 0 || diffCounter == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        static double findDistanceAvg(Point[] points)
        {
            int counter = 0;
            double distance = 0;
            for (int p1 = 0; p1 < points.Length; p1++)
            {
                for (int p2 = p1 + 1; p2 < points.Length; p2++)
                {
                    distance = Math.Sqrt(Math.Pow((points[p2].x - points[p1].x), 2) + Math.Pow((points[p2].y - points[p1].y), 2));
                    counter++;
                }
            }
            return distance / counter;

        }
        static void Sozluk()
        {
            Dictionary<string, string> sozluk = new Dictionary<string, string>();

            sozluk.Add("txt", "notepad.exe");
            sozluk.Add("bmp", "paint.exe");
            sozluk.Add("dib", "paint.exe");
            sozluk.Add("rtf", "wordpad.exe");

            //erişerek değer değiştirme
            sozluk["txt"] = "word2020.exe";


            string deger = "";
            if (sozluk.TryGetValue("txt", out deger))
            {
                Console.WriteLine("txt id'li ifadenin değeri şudur", deger);
            }
            else
            {
                Console.WriteLine("txt id'i bulunamadı");
            }

        }

        static void LinqVeDiziler()
        {
            int[] scores = new int[] { 97, 92, 81, 60 };
            IEnumerable<int> sayilar80denKucuk = scores.Where(sayi => sayi > 80).ToList(); // 80'den küçük olanları filtreler
            string[] dizi = { "dfd", "dfdfd", "vdfdfd" };
            double[] sayiDizi = { 229.3434D, 4.223D, 3 };
            Array.Sort(scores);
        }
        public static List<int> oddNumbers(int l, int r)
        {
            // for (int i = 0; i < length; i++)
            // {

            // }
            List<int> tekSayilar = new List<int>();

            for (int sayimiz = l; sayimiz <= r; sayimiz++)
            {
                if (sayimiz % 2 == 1) // eğer sayimiz tek ise
                {
                    tekSayilar.Add(sayimiz);
                }

            }

            return tekSayilar;
        }

        public int solution2(int[] A)
        {
            List<Maliyet> maliyetDizisi = new List<Maliyet>();
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A.Length; j++)
                {
                    if (i == j) // aynı dizi indisi karşılaştırılıyorsa ise sonrakine geç.
                        continue;

                    if (j - i > 1) // iki indis komşu değilse
                    {
                        Maliyet x = new Maliyet { i = i, j = j, maliyet = A[j] + A[i] };
                        maliyetDizisi.Add(x);
                    }

                }
            }

            int maliyet = maliyetDizisi.OrderBy(m => m.maliyet).Min(m => m.maliyet); // order asc
            return maliyet;
        }
    }
}
