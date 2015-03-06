﻿using JmdictFurigana.Helpers;
using JmdictFurigana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmdictFurigana.Business
{
    public class SingleCharacterSolver : FuriganaSolver
    {
        /// <summary>
        /// Attempts to solve furigana when the kanji reading only has one character.
        /// </summary>
        protected override IEnumerable<FuriganaSolution> DoSolve(FuriganaResourceSet r, VocabEntry v)
        {
            if (v.KanjiReading.Length == 1 && !KanaHelper.IsAllKana(v.KanjiReading))
            {
                yield return new FuriganaSolution(v, new FuriganaPart(v.KanaReading, 0, 0));
            }
        }
    }
}
