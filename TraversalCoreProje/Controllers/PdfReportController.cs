using EntityLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	public class PdfReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult StaticPdfReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya1.pdf");
			var stream=new FileStream(path, FileMode.Create);
			Document document=new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();
			Paragraph paragraph=new Paragraph("Traversal Rezervasyon Pdf Raporu");
			document.Add(paragraph);
			document.Close();
			return File("/PdfReport/dosya1.pdf","application/pdf","dosya1.pdf");
		}
		public IActionResult StaticCustomerReport(Destination destination)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya2.pdf");
			var stream = new FileStream(path, FileMode.Create);
			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();
			PdfPTable pdfPTable = new PdfPTable(3);

			pdfPTable.AddCell("Misafir Adı");
			pdfPTable.AddCell("Misafir Soyadı");
			pdfPTable.AddCell("Misafir Tc");

			pdfPTable.AddCell("Ravza");
			pdfPTable.AddCell("Bayıroğlu");
			pdfPTable.AddCell("1111111110");

			pdfPTable.AddCell("Ulaş");
			pdfPTable.AddCell("Aktaş");
			pdfPTable.AddCell("1234567891011");

			pdfPTable.AddCell("Murat");
			pdfPTable.AddCell("Yücedağ");
			pdfPTable.AddCell("11012511010110");
			document.Add(pdfPTable);
			document.Close();
			return File("/PdfReport/dosya2.pdf", "application/pdf", "dosya2.pdf");
		}
		
		}
}
