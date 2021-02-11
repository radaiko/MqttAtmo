using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Netatmo
{
    public class Response<T>
    {
        #region Properties
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string ErrorMsg { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        #endregion

        #region Constructors
        public static Response<T> CreateEmpty()
        {
            return new Response<T>();
        }
        #endregion

        #region Public
        public static Response<T> CreateSuccessful(T result, HttpStatusCode httpStatusCode)
        {
            return new Response<T> { IsSuccess = true, Result = result, HttpStatusCode = httpStatusCode };
        }

        public static Response<T> CreateUnsuccessful(string errorMessage, HttpStatusCode httpStatusCode)
        {
            return new Response<T> { IsSuccess = false, ErrorMsg = errorMessage, HttpStatusCode = httpStatusCode };
        }
        #endregion
    }
}
