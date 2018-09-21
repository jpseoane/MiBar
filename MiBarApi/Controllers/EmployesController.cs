using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiBarAccessData;


namespace MiBarApi.Controllers
{

    //[EnableCorsAttribute("*", "*", "*")]
    public class EmployesController : ApiController
    {

        //[BasicAuthentication] -->              // Valida que solo podra ejecutar este metodo usuarios logueados utilizando Seguridad basica donde necesito pasarle al controlador en la peticion el
        // usuario:password codificado en base64 en el tag del header junto con la palabra especial BASIC y un espacio
        // Es decir con un ejemplo seria:
        //Host: localhost:53977
        //Authorization: Basic YW5keTpwYXNzd29yZA== (---->>>> Esto seria el usuario y la contraseña separada por ":" pero pasado en base64  )
        //Content-Length: 0

        //public HttpResponseMessage Get(string gender = "All")
        //{
        //    string username = Thread.CurrentPrincipal.Identity.Name;
        //    using (MiBarEntities entities = new MiBarEntities())
        //    {
        //        switch (username.ToLower())
        //        {   
        //            case "male":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
        //            case "female":
        //                return Request.CreateResponse(HttpStatusCode.OK,
        //                    entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
        //            default:
        //                return Request.CreateResponse(HttpStatusCode.BadRequest);

        //        }
        //    }
        //}

        //[HttpGet]

        [Authorize]
        public IEnumerable<Employees> Get()
        {
            using (MiBarEntities entities = new MiBarEntities())
            {
                return entities.Employees.ToList();
            }
        }



        //public HttpResponseMessage Get(int id)
        //{
        //    using (MiBarEntities entities = new MiBarEntities())
        //    {

        //       var entity= entities.Employees.FirstOrDefault(e => e.ID == id);

        //        if (entity != null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"La entidad numero " + entity.ID + " no se encontro");
        //        }

        //    }
        //}


        public HttpResponseMessage Post([FromBody] Employees employees)
        {
            try
            {
                using (MiBarEntities MiBarEntities = new MiBarEntities())
                {
                    MiBarEntities.Employees.Add(employees);
                    MiBarEntities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employees);

                    message.Headers.Location = new Uri(Request.RequestUri + "/" + employees.ID.ToString());
                    return message;

                }
            }
            catch (Exception ex) {
              return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
              
            }
        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (MiBarEntities dBEntities = new MiBarEntities())
                {
                    var entity = dBEntities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El empleado numero " + id + " no se encontro");
                    }
                    else
                    {
                        dBEntities.Employees.Remove(entity);
                        dBEntities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }

        public HttpResponseMessage Put(int id, [FromBody] Employees employees)
        {
            try
            {
                using (MiBarEntities dBEntities = new MiBarEntities())
                {
                    var entity = dBEntities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El empleado numero " + id + " no se encontro para ser actualizado");
                    }
                    else
                    {
                        entity.FirstName = employees.FirstName;
                        entity.LastName = employees.LastName;
                        entity.Gender = employees.Gender;
                        entity.Salary = employees.Salary;
                        dBEntities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }


    }
   
}
