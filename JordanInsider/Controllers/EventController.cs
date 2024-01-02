using JordanInsider.Core.Models;
using JordanInsider.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JordanInsider.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        [Route("GetAllEvents")]
        public IActionResult GetAllEvents()
        {
            try
            {
                var events = eventService.GetAllEvents();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving events: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEventById/{id}")]
        public IActionResult GetEventById(int id)
        {
            try
            {
                var eventItem = eventService.GetEventById(id);
                if (eventItem == null)
                    return NotFound();

                return Ok(eventItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the event: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateEvent")]
        public IActionResult CreateEvent(Event eventData)
        {
            try
            {
                eventService.CreateEvent(eventData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the event: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateEvent")]
        public IActionResult UpdateEvent(Event eventData)
        {
            try
            {
                eventService.UpdateEvent(eventData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the event: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                eventService.DeleteEvent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the event: " + ex.Message);
            }
        }

        [HttpPost]

        [Route("uploadImage")]

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

                Event item = new Event();
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
