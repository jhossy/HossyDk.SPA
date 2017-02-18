using HossyDk.Library.Interfaces;
using HossyDk.Library.Repositories;
using HossyDk.Library.Utils;
using HossyDk.SPA.Models;
using HossyDk.SPA.Models.Providers;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HossyDk.SPA.API
{
    [RoutePrefix("api/imageupload")]
    public class ImageUploadController : ApiController
    {
        private IImageRepository _imageRepository;
        private string _imageRoot;
        //public ImageUploadController(IImageRepository imageRepository)
        //{
        //    _imageRepository = imageRepository ?? new ImageRepository(ConfigurationUtils.GetAppSetting("ImageRoot"));
        //}

        public ImageUploadController()
        {
            _imageRoot = ConfigurationUtils.GetAppSetting("ImageRoot");
            _imageRepository = new ImageRepository(_imageRoot);
        }

        [HttpGet]
        public ApiObject GetGalleries()
        {
            IImageDirectoryInfo[] galleryInfo = _imageRepository.GetImageDirectories(includeImageCount: true); //todo: add caching            
            return new ApiObject()
            {
                data = galleryInfo
            };
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<HttpResponseMessage> UploadImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath(_imageRoot);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            var provider = new CustomMultiPartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        Debug.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [NonAction]
        private string GetImageRootDir()
        {
            string configSetting = ConfigurationManager.AppSettings["imageUploadFolder"];

            if (string.IsNullOrEmpty(configSetting))
            {
                throw new NullReferenceException("imageUploadFolder not set in appSettings");
            }

            return HttpContext.Current.Server.MapPath(configSetting);
        }

        [HttpPost] 
        [Route("AddGallery")]       
        public HttpResponseMessage AddGallery(AddGalleryPostObject postData)
        {
            string galleryRoot = GetImageRootDir();

            if (string.IsNullOrEmpty(galleryRoot))
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (string.IsNullOrEmpty(postData.Name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "A galleryname has to be supplied");
            }

            string newDir = Path.Combine(galleryRoot, postData.Name);

            if (Directory.Exists(newDir))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Directory already exists");
            }

            Directory.CreateDirectory(newDir);

            return Request.CreateResponse(HttpStatusCode.OK, "Directory created");
        }

        public HttpResponseMessage RemoveGallery(string name)
        {
            string galleryRoot = GetImageRootDir();

            if (string.IsNullOrEmpty(galleryRoot))
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (string.IsNullOrEmpty(name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "A galleryname has to be supplied");
            }

            string newDir = Path.Combine(galleryRoot, name);

            if (!Directory.Exists(newDir))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Directory does not exist");
            }

            Directory.Delete(newDir);

            return Request.CreateResponse(HttpStatusCode.OK, "Directory deleted");
        }
    }
}
