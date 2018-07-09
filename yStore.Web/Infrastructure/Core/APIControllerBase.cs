using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using yStore.Model.Models;
using yStore.Services;

namespace yStore.Web.Infrastructure.Core
{
    public class APIControllerBase : ApiController
    {
        private IErrorLogService _errorLogService;
        public APIControllerBase(IErrorLogService errorLogService)
        {
            this._errorLogService = errorLogService;
        }
        
        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                return function.Invoke();
            }catch(DbEntityValidationException VaEx)
            {
                foreach(var e in VaEx.EntityValidationErrors)
                {
                    Trace.WriteLine($"Co loi xay ra o bang \"{e.Entry.Entity.GetType().Name}\" tai truong \"{e.Entry.State}\": ");
                    foreach(var e1 in e.ValidationErrors)
                    {
                        Trace.WriteLine($"Truong: \"{e1.PropertyName}\", Loi: \"{e1.ErrorMessage}\"");
                    }
                }
                LogError(VaEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, VaEx.InnerException.Message);
            }
            catch(DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }


        private void LogError(Exception ex)
        {
            try
            {
                ErrorLog error = new ErrorLog();
                error.CreatedDate = DateTime.Now;
                error.Message = ex.Message;
                error.StackTrace = ex.StackTrace;
                _errorLogService.Create(error);
                _errorLogService.Save();
             }
            catch(Exception)
            {
             
            }
        }
    }
}