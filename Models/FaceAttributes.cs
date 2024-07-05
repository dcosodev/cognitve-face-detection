using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceDetectionAPI.Models
{
    public class FaceAttributes
    {
        public HeadPose HeadPose { get; set; }
        public Blur Blur { get; set; }
        public Exposure Exposure { get; set; }
        public Noise Noise { get; set; }
        public string Glasses { get; set; }
    }
}
