using Nancy;
using Nancy.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NancyLibraryAPI
{
    public class ErrorPipeline : IApplicationStartup
    {
        public void Initialize(IPipelines pipelines)
        {
            pipelines.OnError += (context, exception)=>
            {
                if (exception is BookNotFoundException)
                    return new Response
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ContentType = "text/html",
                        Contents = (stream) =>
                        {
                            var errorMessage =
                            Encoding.UTF8.GetBytes(exception.Message);
                            stream.Write(errorMessage, 0, errorMessage.Length);
                        }
                    };
                return HttpStatusCode.InternalServerError;
            };
        }

        private class BookNotFoundException
        {
        }
    }
}