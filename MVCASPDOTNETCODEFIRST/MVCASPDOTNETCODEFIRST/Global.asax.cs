using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MVCASPDOTNETCODEFIRST.Repository;
using System.Data.SqlClient;
using System.Configuration;
namespace MVCASPDOTNETCODEFIRST
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
            using (var context = new MyDbContext())
            {
                context.Database.Initialize(force: true);
            }
        }

    }
}
