using MySurfboardsMVP.Models;
using MySurfboardsMVP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MySurfboardsMVP.Controllers
{
    [RoutePrefix("api/surfboard")]
    public class SurfboardsController : ApiController
    {

        readonly ISurfboardDataService surfboardDataService;

        public SurfboardsController(ISurfboardDataService surfboardDataService)
        {
            this.surfboardDataService = surfboardDataService;
        }







        [Route, HttpGet]
        public HttpResponseMessage GetMessage()
        {

            //if (!ModelState.IsValid)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}

            var response = new SurfboardDataService().GetAllSurfboards();

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }



        [Route, HttpPost]
        public HttpResponseMessage Post(Surfboard surfboard)
        {

         //if (!ModelState.IsValid)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}

           int id = surfboardDataService.Post(surfboard);

           return Request.CreateResponse(HttpStatusCode.OK, id);
        }



        // api/surfboards/{id}
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}
            var response = new SurfboardDataService().Get(id); 

            return Request.CreateResponse(HttpStatusCode.OK, response); 
        }





        // api/surfboards/{id}
        [HttpGet]
        [Route("Search")]
        public HttpResponseMessage Search([FromUri]BoardSearchParams bsm)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}
            var response = new SurfboardDataService().Search(bsm);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

















        [HttpPut]
        [Route()]
        public HttpResponseMessage Update(Surfboard surfboard)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            //}


            new SurfboardDataService().Update(surfboard);

            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }




        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            new SurfboardDataService().Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }





    }
}


  
