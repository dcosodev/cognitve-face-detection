using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceDetectionAPI.Models
{
    public class Face
    {
        public FaceRectangle FaceRectangle { get; set; }
        public FaceAttributes FaceAttributes { get; set; }
    }
}
