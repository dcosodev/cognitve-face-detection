using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FaceDetectionAPI.Services
{
    public class FaceDetectionService
    {
        private readonly IFaceClient _faceClient;

        public FaceDetectionService(string endpoint, string subscriptionKey)
        {
            _faceClient = new FaceClient(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };
        }

        public async Task<IList<DetectedFace>> DetectFacesAsync(string imageUrl)
        {
            var faceAttributes = new List<FaceAttributeType>
            {
                FaceAttributeType.Occlusion,
                FaceAttributeType.Accessories,
                FaceAttributeType.Blur,
                FaceAttributeType.Exposure,
                FaceAttributeType.Noise,
                FaceAttributeType.Glasses,
                FaceAttributeType.HeadPose
            };

            var detectedFaces = await _faceClient.Face.DetectWithUrlAsync(imageUrl, returnFaceAttributes: faceAttributes);
            return detectedFaces;
        }
    }
}
