using BLL.DTOs;
using BLL.Services.FeedbackServices;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetAll()
        {
            var feedbacks = await _feedbackService.GetAllAsync();

            return Ok(feedbacks);
        }

        [HttpPost]
        public async Task<ActionResult<FeedbackDTO>> CreateFeedback(FeedbackDTO request)
        {
            var feedbacks = await _feedbackService.AddAsync(request);

            return Ok(feedbacks);
        }
    }
}
