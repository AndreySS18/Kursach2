
namespace Kursach2
{
    public class Document
    {
        public Document(string label, string text)
        {
            Label = label;
            Text = text;
        }
        public string Label { get; set; }
        public string Text { get; set; }
    }
}