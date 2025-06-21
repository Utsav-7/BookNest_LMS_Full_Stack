using LMS_Backend.LMS.Application.Interfaces.UserManagement;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS_Backend.LMS.Application.Interfaces.BookTransactions;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using LMS_Backend.LMS.Application.DTOs.BookTransaction;
using Microsoft.AspNetCore.JsonPatch;
using LMS_Backend.LMS.Domain.Entities;
using LMS_Backend.LMS.Common.Exceptions;

namespace LMS_Backend.LMS.API.Controllers
{
    [ApiController]
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/transactions")]
    [Produces("application/json")]
    public class BorrowRequestController : ControllerBase
    {
        private readonly IBorrowService _borrowService;
        private readonly ITransactionHistoryService _transactionHistoryService;

        public BorrowRequestController(IBorrowService borrowService, ITransactionHistoryService transactionHistoryService)
        {
            _transactionHistoryService = transactionHistoryService;
            _borrowService = borrowService;
        }

        private int GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return userIdClaim != null ? int.Parse(userIdClaim.Value) : 0;
        }

        [HttpGet("borrow-requests")]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<IActionResult> GetAllBorrowRequests()
        {
            try
            {
                var requests = await _borrowService.GetAllBorrowRequestsAsync();
                return Ok(requests);
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow requests: " + ex.Message);
            }
        }

        [HttpGet("borrow-requests-by-userId")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetBorrowRequestByUserId([FromQuery]int id)
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                var request = await _borrowService.GetBorrowRequestByUserIdAsync(loggedInUser);
                return Ok(request);
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow request: " + ex.Message);
            }
        }

        [HttpGet("borrow-requests-by-id")]
        [Authorize(Roles = "Administrator, Librarian, Student")]
        public async Task<IActionResult> GetBorrowRequestById([FromQuery] int id)
        {
            try
            {
                var request = await _borrowService.GetBorrowRequestByIdAsync(id);
                return Ok(request);
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow request: "+ ex.Message);
            }
        }

        [HttpPost("borrow-requests")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> CreateBorrowRequest([FromBody] BorrowRequestCreateDTO request)
        {
            try
            {
                var createdBy = GetLoggedInUserId();
                var success = await _borrowService.AddBorrowRequestAsync(request, createdBy);

                return success ? NoContent() : NotFound($"Borrow request is not created.");
            }
            catch (AlreadyExistsException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPatch("borrow-requests")]
        [Authorize(Roles = "Administrator, Librarian")]
        public async Task<IActionResult> UpdateBorrowRequest([FromQuery] int id, [FromBody] JsonPatchDocument<BorrowRequestUpdateStatusDTO> patchDoc)
        {
            try
            {
                if (patchDoc == null)
                {
                    return BadRequest("Patch document is required");
                }

                var updatedBy = GetLoggedInUserId();
                var success = await _borrowService.PatchBorrowRequestAsync(id, patchDoc, updatedBy);

                return success ? NoContent() : NotFound($"Borrow request with ID {id} not found");
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("borrow-requests")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteBorrowRequest([FromQuery]int id)
        {
            try
            {
                var deletedBy = GetLoggedInUserId();
                var success = await _borrowService.DeleteBorrowRequestAsync(id, deletedBy);

                return success ? NoContent() : NotFound($"Borrow request with ID {id} not found");
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            { 
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting borrow request: "+ ex.Message);
            }
        }


        [HttpGet("get-all")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetAllTransaction()
        {
            try
            {
                var transaction = await _transactionHistoryService.GetAllTransactionAsync();
                return transaction != null ? Ok(transaction) : NotFound("No Transaction found");
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow request: "+ex.Message);
            }
        }

        [HttpGet("get-by-userId")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetTransactionByUserId()
        {
            try
            {
                var loggedInUser = GetLoggedInUserId();
                var transaction = await _transactionHistoryService.GetAllTransactionByUserIdAsync(loggedInUser);
                return transaction != null ? Ok(transaction) : NotFound($"No Transaction found with {loggedInUser} id.");
            }
            catch (DataNotFoundException<string> ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving borrow request: "+ex.Message);
            }
        }
    }
}