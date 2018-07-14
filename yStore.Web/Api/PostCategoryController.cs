using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yStore.Model.Models;
using yStore.Services;
using yStore.Web.Infrastructure.Core;
using yStore.Web.Models;
using yStore.Web.Infrastructure.Extensions;

namespace yStore.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : APIControllerBase
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorLogService errorLogService, IPostCategoryService postCategoryService) :
            base(errorLogService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                var listCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategoryVM);


                return response;
            });
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request,PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (ModelState.IsValid)
                 {
                     response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     PostCategory newPostCategory = new PostCategory();
                     newPostCategory.UpdatePostCategory(postCategoryVM);

                     var category = _postCategoryService.Add(newPostCategory);
                     _postCategoryService.SaveChanges();

                     response = request.CreateResponse(HttpStatusCode.Created, category);
                 }
                 return response;
             });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVM.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVM);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        
    }
}