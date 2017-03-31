using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using tvn_cosine.api.Models;

namespace tvn_cosine.api.Controllers
{
    public class OcrController : ApiController
    {
        private const string tessDataPath = "C:/tesseract/tessdata";

        private readonly object syncLock = new object();
        private readonly Tesseract.TessBaseAPI tessBaseApi = new Tesseract.TessBaseAPI(tessDataPath);

        // GET: api/Ocr
        public IHttpActionResult Get()
        {
            return Ok(string.Format("Tesseract Version: {0}", tessBaseApi.GetVersion()));
        }

        // POST: api/Ocr
        public IHttpActionResult Post([FromBody]ImageModel image)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (image != null)
            {
                try
                {
                    var localImage = createLocalImage(image);

                    lock (syncLock)
                    {
                        tessBaseApi.Process(localImage);
                        stopWatch.Stop();
                        File.Delete(localImage);

                        var response = new OcrResponseModel()
                        {
                            Id = Guid.NewGuid(),
                            RequestDuration = stopWatch.Elapsed,
                            Text = tessBaseApi.GetUTF8Text()
                        };

                        return Ok(response);
                    }
                }
                catch { }
            }

            stopWatch.Stop();
            var exception = new ExceptionModel()
            {
                DateCreated = DateTime.Now,
                ExceptionMessage = "Image object could not be deserialised or ocr process failed.",
                RequestDuration = stopWatch.Elapsed
            };

            return BadRequest(exception.ToString());
        }

        private string createLocalImage(ImageModel image)
        {
            var filename = $@"images/{Guid.NewGuid()}.jpg";

            using (var im = Image.FromStream(new MemoryStream(image.Bytes)))
            {
                string path = HttpContext.Current.Server.MapPath("~/") + filename;
                im.Save(path, ImageFormat.Jpeg);
                return path;
            }
        }
    }
}
