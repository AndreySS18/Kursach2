using System.Text.RegularExpressions;
using Aspose.Cells;


namespace Kursach2
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Document> _trainCorpus = new List<Document> { new Document("1", "2") };
            Workbook wb = new Workbook("C:\\Users\\andre\\OneDrive\\Рабочий стол\\C#\\Kursach2\\Kursach2\\TrainData.xlsx");

            Worksheet worksheet = wb.Worksheets[0];

            int rows = worksheet.Cells.MaxDataRow;

            for (int i = 0; i < rows; i++)
            {
                _trainCorpus.Add(new Document(worksheet.Cells[i, 0].Value.ToString(), worksheet.Cells[i, 1].Value.ToString()));
            }
            var c = new Classifier(_trainCorpus);
            Console.WriteLine("Enter a text: ");
            string text = Console.ReadLine();
            while (!String.IsNullOrEmpty(text))
            {
                var res1 = c.IsInClassProbability("1", text);
                var res2 = c.IsInClassProbability("2", text);
                var res3 = c.IsInClassProbability("3", text);
                var res4 = c.IsInClassProbability("4", text);
                Console.WriteLine($"Вероятность, что данный текст относится к категории 'Мир' = + {res1:P2}");
                Console.WriteLine($"Вероятность, что данный текст относится к категории 'Спорт' = + {res2:P2}");
                Console.WriteLine($"Вероятность, что данный текст относится к категории 'Бизнес' = + {res3:P2}");
                Console.WriteLine($"Вероятность, что данный текст относится к категории 'Техника' = + {res4:P2}");

                Console.WriteLine("Enter more text: ");
                text = Console.ReadLine();
            }

        }
    }
    public static class Helpers
    {
        public static List<String> ExtractFeatures(this String text)
        {
            return Regex.Replace(text, "\\p{P}+", "").Split(' ').ToList();
        }
    }
}