using HossyDk.Library.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace HossyDk.SPA.Models.Providers
{
    public class CustomMultiPartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultiPartFormDataStreamProvider(string rootPath) : base(rootPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            if(headers == null || headers.ContentDisposition == null)
            {
                throw new NullReferenceException("Headers or ContentDisposition-header is NULL");
            }

            string inputFilename = headers.ContentDisposition.FileName;

            inputFilename = PathUtilities.RemoveIllegalPathCharacters(inputFilename);

            if (!PathUtilities.IsLegalFileExtension(inputFilename))
            {
                throw new Exception("Invalid file extension");
            }

            string fileName = !string.IsNullOrWhiteSpace(inputFilename) ?
                inputFilename : Guid.NewGuid().ToString();

            return fileName;
        }
    }
}