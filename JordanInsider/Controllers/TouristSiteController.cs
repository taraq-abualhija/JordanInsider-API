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
        public IActionResult GetAllTouristSites()
        {
            try
            {
                var result = touristSiteService.GetAllTouristSites();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching all tourist sites: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTouristSiteById/{id}")]
        public IActionResult GetTouristSiteById(int id)
        {
            try
            {
                var result = touristSiteService.GetTouristSiteById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching tourist site by ID: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateTouristSite")]
        public IActionResult CreateTouristSite(Touristsite touristSite)
        {
            try
            {
                touristSite.Status = "pending";
                touristSiteService.CreateTouristSite(touristSite);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating a tourist site: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTouristSite")]
        public IActionResult UpdateTouristSite(Touristsite touristSite)
        {
            try
            {
                touristSiteService.UpdateTouristSite(touristSite);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating a tourist site: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTouristSite/{id}")]
        public IActionResult DeleteTouristSite(int id)
        {
            try
            {
                touristSiteService.DeleteTouristSite(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting a tourist site: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("AcceptTouristSite/{id}")]
        public IActionResult AcceptTouristSite(int id)
        {
            try
            {
                touristSiteService.AcceptTouristSite(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while accepting a tourist site: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("SearchTouristSiteByName/{name}")]
        public IActionResult SearchTouristSiteByName(string name)
        {
            try
            {
                var result = touristSiteService.SearchTouristSiteByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching for tourist sites by name: " + ex.Message);
            }
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

                return Ok(item); 
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
