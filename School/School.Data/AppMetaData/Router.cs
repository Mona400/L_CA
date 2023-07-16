﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "Api";
        public const string vertion = "V1";
        public const string Rule=root+"/"+vertion+"/";

        public static class StudentRouting
        {
            public const string Prefix=Rule+"Student";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "/Create";

        }   
    
    
    }
}