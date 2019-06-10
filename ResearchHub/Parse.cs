using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.IO;

namespace ResearchHub {
    public class Parse {
        SortedDictionary<string, Area> areas;
        SortedDictionary<string, string> namePair;

        public Parse() {
            areas = new SortedDictionary<string, Area>();
            namePair = new SortedDictionary<string, string>();
            // parse in the areas and their descriptions
            StreamReader reader = File.OpenText("C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\Descriptions.txt");
            string simplifiedTitle;
            while ((simplifiedTitle = reader.ReadLine()) != null) {
                string title = reader.ReadLine();
                namePair.Add(simplifiedTitle, title);
                areas.Add(title, new Area(simplifiedTitle, title, reader.ReadLine(), reader.ReadLine(), 
                    reader.ReadLine(), reader.ReadLine(), reader.ReadLine(), reader.ReadLine()));
            }
            // parse in the opportunities for each field
            using (TextFieldParser parser = new TextFieldParser("C:\\Users\\Student User\\source\\repos\\ResearchHub\\ResearchHub\\source file\\opportunityList.tsv")) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("\t");
                parser.ReadFields();
                while (!parser.EndOfData) {
                    Opportunity op = new Opportunity(parser.ReadFields());
                    foreach (string area in op.getAreas()) {
                        if (area.Length > 0) areas[area.ToUpper()].add(op);
                    }
                }
            }
        }

        public Area getArea(string title) { return areas[title]; }
        public string getTitleFromSimplified(string simplified) { return namePair[simplified]; }
    }
}
