using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextExchange.Interaction;

namespace TextExchange.Initialization
{
    public class VocabDefs
    {
        private string path;
        private readonly string nounFile = "Nouns.txt";
        private readonly string verbFile = "Verbs.txt";

        public VocabDefs(string folderPath)
        {
            path = folderPath;
        }

        public Interpreter LoadVocab()
        {
            var nounMap = LoadTerms(nounFile);
            var verbMap = LoadTerms(verbFile);
            var interpreter = new Interpreter(nounMap, verbMap);
            return interpreter;
        }

        protected Dictionary<string, string> LoadTerms(string partOfSpeech)
        {
            Dictionary<string, string> termMap = new Dictionary<string, string>();
            //The above declaration could have been written more simply as...
            //var nounMap = new Dictionary<string,string>();

            var termsFile = Path.Combine(path, partOfSpeech);
            foreach(var line in File.ReadLines(termsFile))
            {
                string[] synonyms = line.Split(',');
                //The first word in the comma-separated list
                //is the central term the game works with.
                string primaryTerm = synonyms[0];
                string dressedTerms = "," + line + ",";
                termMap[primaryTerm] = dressedTerms;
            }
            return termMap;
        }
    }
}
