using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Microsoft.Practices.Unity;
using UR_Talking.Resolver;
using UR_Talking.DAO;
using UR_Talking.DAO_Impl;
using Iveonik.Stemmers;

namespace UR_Talking.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            UnityContainer container = new UnityContainer();

            AnswerDAO answerDAO = new AnswerDAOImpl();
            IStemmer germanStemmer = new GermanStemmer();

            container.RegisterInstance(answerDAO);
            container.RegisterInstance(germanStemmer);

            config.DependencyResolver = new UnityResolver(container);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}