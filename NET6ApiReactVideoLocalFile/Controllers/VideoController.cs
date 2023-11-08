using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace NET6ApiReactVideoLocalFile.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class VideoController : ControllerBase
    {
        // Replace with the actual path to your video file.
        private readonly string videoFilePath = "D:\\Education\\Step\\0_urgent\\20221110_Pictures_ForHolywoodService\\Interstellar.mp4";

        //[HttpGet("{videoFileName}")]
        [HttpGet]
        //public IActionResult GetVideo(string videoFileName)
        public IActionResult GetVideo()
        {
            try
            {
                /*if (videoFileName != "your_video.mp4")
                {
                    return NotFound();
                }*/

                var stream = new FileStream(videoFilePath, FileMode.Open, FileAccess.Read);
                //var response = File(stream);
                //// return status code 200
                //var response = File(stream, "video/mp4");
                //// return status code 206
                var response = File(stream, "video/mp4", enableRangeProcessing: true);
                //var response = File(stream, "application/octet-stream", enableRangeProcessing: true);
                //var response = Results.File(stream, "application/octet-stream", enableRangeProcessing: true);

                //var response =  Results.File(stream, contentType: "video/mp4", enableRangeProcessing: true);
                return response;
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log the error or return a custom error response.
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
