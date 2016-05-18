using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextExchange.Interaction
{
    public class Area
    {
        public Dictionary<string, string> DescriptionMap;
        public string Name;
        public string DescriptionKey;

        public string Describe()
        {
            string description = DescriptionMap[DescriptionKey];

            string text = Name + Environment.NewLine + description;
            return text;
        }
    }
}
