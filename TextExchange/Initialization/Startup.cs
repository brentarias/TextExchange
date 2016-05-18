using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextExchange.Interaction;

namespace TextExchange.Initialization
{
    public class Startup
    {
        private string gameDirectory;
        private readonly string areaPath = "Areas";
        private readonly string vocabPath = "Vocab";

        public Startup(string dir)
        {
            gameDirectory = dir;
        }

        public GameParts Load()
        {
            var areaFolder = Path.Combine(gameDirectory, areaPath);
            var areaDefs = new AreaDefs(areaFolder);
            var areas = areaDefs.LoadAreas();

            var vocabFolder = Path.Combine(gameDirectory, vocabPath);
            var vocabDefs = new VocabDefs(vocabFolder);
            var interpreter = vocabDefs.LoadVocab();

            var gameParts = new GameParts(interpreter, areas);
            return gameParts;
        }


    }
}
