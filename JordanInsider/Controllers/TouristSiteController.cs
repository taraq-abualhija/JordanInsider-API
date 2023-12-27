using JordanInsider.Core.Models;
using JordanInsider.Core.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristSiteController : ControllerBase
    {
        private readonly ITouristSiteService touristSiteService;

        public TouristSiteController(ITouristSiteService touristSiteService)
        {
            this.touristSiteService = touristSiteService;
        }

        [HttpGet]
        [Route("GetAllTouristSites")]
        public List<Touristsite> GetAllTouristSites()
        {
            return touristSiteService.GetAllTouristSites();
        }

        [HttpGet]
        [Route("GetTouristSiteById/{id}")]
        public Touristsite GetTouristSiteById(int id)
        {
            return touristSiteService.GetTouristSiteById(id);
        }

        [HttpPost]
        [Route("CreateTouristSite")]
        public IActionResult CreateTouristSite(Touristsite touristSite)
        {
            touristSite.status = "pending";
            touristSiteService.CreateTouristSite(touristSite);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("UpdateTouristSite")]
        public IActionResult UpdateTouristSite(Touristsite touristSite)
        {
            touristSiteService.UpdateTouristSite(touristSite);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteTouristSite/{id}")]
        public IActionResult DeleteTouristSite(int id)
        {
            touristSiteService.DeleteTouristSite(id);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteTouristSite/{id}")]
        public IActionResult AcceptTouristSite(int id)
        {
            touristSiteService.AcceptTouristSite(id);
            return Ok();
        }
        [Route("uploadImage")]
        [HttpPost]
 
        public IActionResult UploadImage()
        {
            try
            {
                var formFiles = Request.Form.Files;
                List<string> images = new List<string>();

                foreach (var file in Request.Form.Files)
                {
                    var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var fullPath = Path.Combine("Images", fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    images.Add(fileName);
                }

                Touristsite item = new Touristsite();
                item.SetImages(images);

                return Ok(item); // Assuming everything is successful, return 200 OK with the item
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while uploading the image: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("api/images/{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            var imagePath = Path.Combine("Images", imageName);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);
            return File(imageBytes, "image/jpeg");
        }

    }
}
