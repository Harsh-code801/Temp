using Aspose.Pdf;
internal class Program
{
    public static void Main(string[] args)
    {
        using (Document pdfDocument = new Document())
        {
            int i = 1;
            foreach(var n in Directory.GetFiles(@"C:\Users\harsh\Desktop\Logs\Images"))
            {
            pdfDocument.Pages.Add();
                Aspose.Pdf.Image image = new Aspose.Pdf.Image();

                // Load sample BMP image file
                image.File = n;
                pdfDocument.Pages[i].Paragraphs.Add(image);
                i++;
            }
            // Save output PDF document
            pdfDocument.Save(@"C:\Users\harsh\Desktop\Logs\Images\marge.pdf");
        }


    }
}