using System;
using System.Collections.Generic;

namespace SolutionProblem {
    public class MaxcodeLatinTranslator {

        public string Translate(string sentence) {
            string firstCh = "";

            String[] modify = sentence.Split(' ');

            for (int i = 0; i < modify.Length; ++i) {
                if (isVowel(modify[i])) {
                    if (modify[i].Length == 1) {
                        modify[i] = "ma" + modify[i];
                    }
                    else {
                        firstCh = modify[i].Remove(1);
                        modify[i] = "ma" + modify[i].Substring(1) + firstCh;
                    }
                }
                else {
                    if (modify[i].Length == 1) {
                        modify[i] = "ma" + modify[i];
                    }
                    else {
                        firstCh = modify[i].Remove(1);
                        modify[i] = modify[i].Substring(1) + firstCh + "ax";
                    }
                }
            }

            return string.Join(" ", modify);
        }
        
        public static bool isVowel(String word) => "aeiouAEIOU".IndexOf(word[0]) >= 0;
    }

}