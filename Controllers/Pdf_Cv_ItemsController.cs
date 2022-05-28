using Microsoft.AspNetCore.Mvc;
using PdfService.Models;
using PdfService.Services;

namespace PdfService.Controllers
{
    [Route("api/[controller]")] // the path of this controller
    [ApiController]  // mapping calls to be served by the correct function in the controller

    public class Pdf_Cv_ItemsController : Controller
    {
        private readonly IPdf_Cv_Items_Service _Pdf_Cv_ItemsService;
        // injecting Pdf_Cv_ItemsService
        public Pdf_Cv_ItemsController(IPdf_Cv_Items_Service Pdf_Cv_ItemsService)
        {
            _Pdf_Cv_ItemsService = Pdf_Cv_ItemsService;
        }
        // This pseudo function and its pseudo parameter due to extract pdf file.
        // I still don't know how to pass a file and how to parse it.
        public Pdf_Cv_Items PseudoExtracting(PseudoFile pdfFile)
        {
            Pdf_Cv_Items pdf_cv_items = new Pdf_Cv_Items();
            pdf_cv_items = (Pdf_Cv_Items)pdfFile.pseudoExtracted;
            return pdf_cv_items;
        }
        //public IActionResult Create(FileStream pdffile)
        //{
        //   // System.IO.File.ReadLines
        //    //pdffile.//Seek(0, SeekOrigin.Begin);
        //    return RedirectToAction();
        //}
        //This function is needed only for '201' result of the CreatedAtAction (in next function)
        [HttpGet("{id}")]
        public ActionResult<Pdf_Cv_Items> Get(string id)
        {
            var pdf_cv_items = _Pdf_Cv_ItemsService.Get(id);

            if (pdf_cv_items == null)
            {
                return NotFound($"Pdf_cv_items with Id = {id} not found");
            }

            return pdf_cv_items;
        }
        // To land on this function we need to address 'https://<host>Pdf_Cv_Items/AddItiemsRow'
        [HttpPost]                           //, the new added record is posted by a form or other tool.
        public ActionResult<Pdf_Cv_Items> AddItiemsRow([FromBody] PseudoFile pdfFile)
        {                                         // FromBody is used to bound the parameter to  the posted record    
            try
            {
                Pdf_Cv_Items pdf_cv_items = PseudoExtracting(pdfFile);
                if (pdf_cv_items == null)
                    return BadRequest();

                _Pdf_Cv_ItemsService.Create(pdf_cv_items);
                // returning the path of the new created record , also returning the record itself
                return CreatedAtAction(nameof(Get), new { id = pdf_cv_items.Id }, pdf_cv_items);
            }                        //nameof the above function('Get') ,is used for building up the path 
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new Pdf_Cv_Items record");
            }
        }
    }
}
