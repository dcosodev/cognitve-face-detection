# Cognitve Face Detection

This is a .NET API for detecting faces in images using Microsoft Azure Cognitive Services.

## Features

- Detects faces in images
- Retrieves face attributes such as occlusion, accessories, blur, exposure, noise, glasses, and head pose

## Technologies Used

- .NET Core
- Microsoft Azure Cognitive Services
- ASP.NET Core MVC

## Getting Started

### Prerequisites

- .NET Core SDK
- Azure Cognitive Services Face API subscription

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/face-detection-api.git
   cd face-detection-api

2. Set up your Azure Face API credentials in appsettings.json:

  "AzureFaceApi": {
    "Endpoint": "your_endpoint_here",
    "SubscriptionKey": "your_subscription_key_here"
  }
  
3. Build and run the project:

   dotnet build
   dotnet run

### Usage
- Endpoint: 'POST /api/FaceDetection/detect'
  
- Request Body:
  {
    "url": "https://example.com/image.jpg"
  }



  






