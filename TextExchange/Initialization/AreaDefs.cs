using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextExchange.Interaction;

namespace TextExchange.Initialization
{
    public class AreaDefs
    {
        private const string initMarker = "-init";
        private string path;

        public AreaDefs(string folderPath)
        {
            path = folderPath;
        }

        public Area[] LoadAreas()
        {
            List<Area> areas = new List<Area>();

            var subFolders = Directory.GetDirectories(path);
            foreach (var folder in subFolders)
            {
                var descriptionMap = new Dictionary<string, string>();

                //Convert folder names into area/room titles.
                string folderName = Path.GetFileName(folder);
                var name = folderName.Replace('-', ' ');

                //We do not yet know the starting description,
                //so assign to null, but we'll figure it out in 
                //a moment.
                string initialDescription = null;

                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var description = File.ReadAllText(file);
                    descriptionMap[fileName] = description;

                    if (fileName.ToLowerInvariant().Contains(initMarker))
                    {
                        initialDescription = fileName;
                    }
                }

                var area = new Area();
                area.DescriptionKey = initialDescription;
                area.Name = name;
                area.DescriptionMap = descriptionMap;

                areas.Add(area);
            }

            return areas.ToArray();
        }
    }
}
