using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextExchange.Interaction
{
    public class Interpreter
    {
        protected Dictionary<string, string> NounMap;
        protected Dictionary<string, string> VerbMap;
        public Dictionary<string, Subject> SubjectMap = new Dictionary<string, Subject>();
        public Dictionary<string, Action> ActionMap = new Dictionary<string, Action>();

        public Interpreter(
            Dictionary<string,string> nounMap,
            Dictionary<string,string> verbMap
            )
        {
            NounMap = nounMap;
            VerbMap = verbMap;

            string[] subjects = Enum.GetNames(typeof(Subject));
            var values = Enum.GetValues(typeof(Subject));

            //***********************************************
            //Need a way to map a text string to an enum easily...
            //***********************************************

            //Create a word-to-subject mapping...
            foreach(var noun in NounMap.Keys)
            {
                Subject sub;
                if (Enum.TryParse(noun, true, out sub))
                {
                    SubjectMap[noun] = sub;
                }
                else
                {
                    Console.WriteLine($"Info: Noun '{noun}' did not map.");
                }
            }

            //Create a verb-noun mapping...
            foreach(var verb in VerbMap.Keys)
            {
                foreach(var noun in NounMap.Keys)
                {
                    Action act;
                    string actionName = verb + noun;
                    if (Enum.TryParse(actionName,true, out act))
                    {
                        ActionMap[actionName] = act;
                    }
                    else
                    {
                        Console.WriteLine($"Info: Action '{actionName}' did not map.");
                    }
                }
            }
        }

        //Not sure we need this...
        //public Dictionary<string, Action> Actions;

        public Command InterpretCommand(string writtenWords)
        {
            Command command = new Command();

            string[] words = writtenWords.Split(' ');
            string[] nouns = MatchTerms(words, NounMap);
            string[] verbs = MatchTerms(words, VerbMap);
            var verb = verbs[0];
            Action action = Action.Unknown;

            if (nouns.Length == 2)
            {
                var subject = nouns[0];
                command.Subject = SubjectMap[subject];
                var objectPart = nouns[1];
                var actionName = verb + objectPart;
                if (ActionMap.TryGetValue(actionName, out action))
                {
                    command.Action = action;
                }
            }
            else if (nouns.Length == 1)
            {
                var objectPart = nouns[0];
                var actionName = verb + objectPart;
                if (ActionMap.TryGetValue(actionName, out action))
                {
                    command.Action = action;
                }
            }

            return command;
        }

        public string[] MatchTerms(string[] words, Dictionary<string,string> dictionary)
        {
            List<string> foundTerms = new List<string>();

            foreach(var entry in dictionary)
            {
                foreach(var word in words)
                {
                    var delimitedWord = "," + word + ",";
                    if (entry.Value.Contains(delimitedWord))
                    {
                        foundTerms.Add(entry.Key);
                    }
                }
            }

            return foundTerms.ToArray();
        }
    }
}
