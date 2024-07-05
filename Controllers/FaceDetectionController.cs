using Microsoft.AspNetCore.Mvc;
using FaceDetectionAPI.Services;
using FaceDetectionAPI.Models;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models; // Add this line
using System.Threading.Tasks;
using System.Linq;

namespace FaceDetectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaceDetectionController : ControllerBase
    {
        private readonly FaceDetectionService _faceDetectionService;

        public FaceDetectionController(FaceDetectionService faceDetectionService)
        {
            _faceDetectionService = faceDetectionService;
        }

        [HttpPost("detect")]
        public async Task<IActionResult> DetectFaces([FromBody] ImageUrlRequest request)
        {
            var detectedFaces = await _faceDetectionService.DetectFacesAsync(request.Url);

            if (detectedFaces == null || !detectedFaces.Any())
            {
                return Ok(new { message = "No faces detected or an error occurred while processing the image." });
            }

            var formattedFaces = detectedFaces.Select(FormatFaceAttributes);

            return Ok(new
            {
                message = $"{detectedFaces.Count} face(s) detected.",
                faces = formattedFaces
            });
        }

        private static object FormatFaceAttributes(DetectedFace face) // Update type here
        {
            return new
            {
                face.FaceRectangle,
                Glasses = face.FaceAttributes?.Glasses.ToString(),
                HeadPose = new
                {
                    face.FaceAttributes?.HeadPose.Roll,
                    face.FaceAttributes?.HeadPose.Yaw,
                    face.FaceAttributes?.HeadPose.Pitch
                },
                Blur = new
                {
                    BlurLevel = face.FaceAttributes?.Blur.BlurLevel.ToString(),
                    face.FaceAttributes?.Blur.Value
                },
                Exposure = new
                {
                    ExposureLevel = face.FaceAttributes?.Exposure.ExposureLevel.ToString(),
                    face.FaceAttributes?.Exposure.Value
                },
                Noise = new
                {
                    NoiseLevel = face.FaceAttributes?.Noise.NoiseLevel.ToString(),
                    face.FaceAttributes?.Noise.Value
                }
            };
        }
    }

    public class ImageUrlRequest
    {
        public string Url { get; set; }
    }
}
