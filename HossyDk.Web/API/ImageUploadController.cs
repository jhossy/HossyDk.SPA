using HossyDk.Web.Models.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HossyDk.Web.API
{
    public class ImageUploadController : ApiController
    {
        [HttpGet]
        public string[] HelloWorld()
        {
            return new string[] { "1", "2", "3"};
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UploadImage()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath(GetImageRoot());
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
        public string GetImageRoot()
        {
            string configSetting = ConfigurationManager.AppSettings["imageUploadFolder"];

            if (string.IsNullOrEmpty(configSetting))
            {
                throw new NullReferenceException("imageUploadFolder not set in appSettings");
            }

            return configSetting;
        }
    }
}
