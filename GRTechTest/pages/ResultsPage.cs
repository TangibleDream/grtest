namespace GRTechTest.steps
{
    internal class ResultsPage
    {       
        public string lblResults    = ".//span[@id=\"s-result-count\"]";
        public string getItem(string item)
        {
            return $".//h2[contains(text(),\"{item}\")]";
        }
    }
}