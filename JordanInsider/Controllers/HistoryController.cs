using JordanInsider.Core.Models;
using JordanInsider.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JordanInsider.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService ?? throw new ArgumentNullException(nameof(historyService));
        }


        [HttpGet]
        [Route("GetHistoryByUserId/{userId}")]
        public IActionResult GetHistoryByUserId(int userId)
        {
            try
            {
                var history = _historyService.GetHistoryByUserId(userId);
                if (history == null || history.Count == 0)
                    return StatusCode(200, "No history found for the specified user ID.");

                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving history by user ID: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("GetHistoryById/{id}")]
        public IActionResult GetHistoryById(int id)
        {
            try
            {
                var history = _historyService.GetHistoryById(id);
                if (history == null)
                    return StatusCode(200, "No history found for the specified history ID.");

                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the history: " + ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateHistory")]
        public IActionResult CreateHistory(History historyData)
        {
            try
            {
                _historyService.CreateHistory(historyData);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the history: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateHistory")]
        public IActionResult UpdateHistory(History historyData)
        {
            try
            {
                _historyService.UpdateHistory(historyData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the history: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteHistory/{id}")]
        public IActionResult DeleteHistory(int id)
        {
            try
            {
                _historyService.DeleteHistory(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the history: " + ex.Message);
            }
        }
    }
}
