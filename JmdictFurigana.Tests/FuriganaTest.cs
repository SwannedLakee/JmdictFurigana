﻿using JmdictFurigana.Etl;
using JmdictFurigana.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmdictFurigana.Tests
{
    [TestClass]
    public class FuriganaTest
    {
        [TestMethod]
        public void Test_Furigana_Ganbaru()
        {
            Test_Furigana("頑張る", "がんばる", "0:がん;1:ば");
        }

        [TestMethod]
        public void Test_Furigana_Ikkagetsu()
        {
            Test_Furigana("一ヶ月", "いっかげつ", "0:いっ;1:か;2:げつ");
        }

        [TestMethod]
        public void Test_Furigana_Obocchan()
        {
            Test_Furigana("御坊っちゃん", "おぼっちゃん", "0:お;1:ぼ");
        }

        [TestMethod]
        public void Test_Furigana_Ara()
        {
            // Will fail. This is a weird kanji. The string containing only the kanji is Length == 2.
            // Would be cool to find a solution but don't worry too much about it.
            Test_Furigana("𩺊", "あら", "0:あら");
        }

        [TestMethod]
        public void Test_Furigana_Ijirimawasu()
        {
            Test_Furigana("弄り回す", "いじりまわす", "0:いじ;2:まわ");
        }

        [TestMethod]
        public void Test_Furigana_Kassarau()
        {
            Test_Furigana("掻っ攫う", "かっさらう", "0:か;2:さら");
        }

        public void Test_Furigana(string kanjiReading, string kanaReading, string expectedFurigana)
        {
            VocabEntry v = new VocabEntry(kanjiReading, kanaReading);
            FuriganaBusiness business = new FuriganaBusiness();
            FuriganaSolutionSet result = business.Execute(v);

            if (result.GetSingleSolution() == null)
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(FuriganaSolution.Parse(expectedFurigana, v), result.GetSingleSolution());
            }
        }
    }
}
