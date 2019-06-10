using System.Collections.Generic;

namespace ResearchHub {
    public class Area {
        private string simplifiedTitle;
        private string title;
        private string description;
        private string quote;
        private string quoteBy;
        private string quoteByWho;
        private string exampleProjectName;
        private string exampleProjectDescription;
        private List<Opportunity> opportunities;

        public Area(string simplifiedTitle, string title, string description, string exampleProjectName, string exampleProjectDescription,
            string quote, string quoteBy, string quoteByWho) {
            this.simplifiedTitle = simplifiedTitle;
            this.title = title;
            this.description = description;
            this.quote = quote;
            this.quoteBy = quoteBy;
            this.quoteByWho = quoteByWho;
            this.exampleProjectName = exampleProjectName;
            this.exampleProjectDescription = exampleProjectDescription;
            this.opportunities = new List<Opportunity>();
        }

        public void add(Opportunity opp) { opportunities.Add(opp); }

        public string getSimplifiedTitle() { return simplifiedTitle; }
        public string getTitle() { return title; }
        public string getDescription() { return description; }
        public string getQuote() { return quote; }
        public string getQuoteBy() { return quoteBy; }
        public string getQuoteByWho() { return quoteByWho; }
        public string getExampleProjectName() { return exampleProjectName; }
        public string getExampleProjectDescription() { return exampleProjectDescription; }
        public List<Opportunity> getOpportunityList() { return new List<Opportunity>(opportunities); }
    }
}