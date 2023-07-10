﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {
            
        }
        public Response<T>Delete<T>()
        {
            return new Response<T>()
            {
                statusCode = System.Net.HttpStatusCode.OK,
                Successed = true,
                Message = "Deleted Successfully"
            };
        
        }
        public Response<T> Success<T>(T entity,object meta=null)
        {
            return new Response<T>()
            {
                Data=entity,
                statusCode=System.Net.HttpStatusCode.OK,
                Message="Add Successfully",
                Meta=meta
            };
        }
        public Response<T>Unauthorized<T>()
        {
            return new Response<T>()
            {
                statusCode=System.Net.HttpStatusCode.Unauthorized,  
                Successed=true,
                Message="UnAuthorized"
            };
        }
        public Response<T> BadRequest<T>(string Message=null)
        {
            return new Response<T>()
            {
                statusCode=System.Net.HttpStatusCode.BadRequest,
                Successed=false,
                Message=Message==null?"Bad Request":Message
            };
        }
        public Response<T> NotFound<T>(string message=null)
        {
            return new Response<T>()
            {
                statusCode=System.Net.HttpStatusCode.NotFound,
                Successed=false,
                Message=message==null?"Not Found":message

            };
        }

        public Response<T> Created<T>(T entity,object meta=null)
        {
            return new Response<T>()
            {
                Data=entity,
                statusCode=System.Net.HttpStatusCode.Created,
                Successed=true,
                Meta=meta
            };
        }
    }
}