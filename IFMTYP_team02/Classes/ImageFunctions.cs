using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace IFMTYP_team02.Classes
{
    public abstract class ImageFunctions
    {
        public static string validateImage(byte[] imageByteArray)
        {
            byte[] newCompressedImage = null;
            if (IsValidImage(imageByteArray) && checkVision(imageByteArray))
            {
                newCompressedImage = CompressImage(imageByteArray);
                return Convert.ToBase64String(newCompressedImage);
            }
            else
            {
                return "NOPIC";
            }
        }

        private static bool IsValidImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    System.Drawing.Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }


        private static byte[] CompressImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            MemoryStream tempMS = new MemoryStream();

            long size = ms.ToArray().Length;

            try
            {
                if (size > 512000)
                {
                    Bitmap bmp = (Bitmap)System.Drawing.Image.FromStream(ms);
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(Encoder.Quality, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp.Save(tempMS, jpgEncoder, myEncoderParameters);
                    size = tempMS.ToArray().Length;
                }
                else
                {
                    return ms.ToArray();
                }
            }

            catch (ObjectDisposedException e)
            { }
            catch (Exception ex) { }
            finally
            {
                ms.Dispose();
            }
            return tempMS.ToArray();
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        /// Creates the credentials.
        private static GoogleCredential CreateCredentials(string path)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var c = GoogleCredential.FromStream(stream);
                credential = c.CreateScoped(VisionService.Scope.CloudPlatform);
            }

            return credential;
        }

        /// Creates the service.
        private static VisionService CreateService(string applicationName, IConfigurableHttpClientInitializer credentials)
        {
            var service = new VisionService(new BaseClientService.Initializer()
            {
                ApplicationName = applicationName,
                HttpClientInitializer = credentials
            });

            return service;
        }

        private static VisionService CreateAuthorizedClient(string path)
        {
            GoogleCredential credential;
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream);
            }

            // Inject the Cloud Vision scopes
            if (credential.IsCreateScopedRequired)
            {
                credential = credential.CreateScoped(new[]
                {
                    VisionService.Scope.CloudPlatform
                });
            }
            return new VisionService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                GZipEnabled = false
            });
        }

        private static Boolean checkVision(byte[] imageByteArray)
        {
            string base64String = Convert.ToBase64String(imageByteArray);

            var visionService = CreateAuthorizedClient(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\IMF third year project-46cd5c28569b.json");


            Google.Apis.Vision.v1.Data.BatchAnnotateImagesRequest content = new Google.Apis.Vision.v1.Data.BatchAnnotateImagesRequest();

            content.Requests = new List<AnnotateImageRequest>();
            AnnotateImageRequest newRequest = new AnnotateImageRequest();
            newRequest.Image = new Google.Apis.Vision.v1.Data.Image();
            newRequest.Image.Content = base64String;
            newRequest.Features = new List<Feature>();
            newRequest.Features.Add(new Feature() { Type = "SAFE_SEARCH_DETECTION" });
            content.Requests.Add(newRequest);

            ImagesResource.AnnotateRequest request = visionService.Images.Annotate(content);
            Google.Apis.Vision.v1.Data.BatchAnnotateImagesResponse response = request.Execute();

            if (response.Responses.Count > 0)
            {
                string tempAdult = response.Responses[0].SafeSearchAnnotation.Adult.ToString();
                string tempSpoof = response.Responses[0].SafeSearchAnnotation.Spoof.ToString();
                if (tempAdult.Equals("LIKELY") || tempAdult.Equals("VERY_LIKELY"))
                {
                    return false;
                }
                if (tempSpoof.Equals("LIKELY") || tempSpoof.Equals("VERY_LIKELY"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}