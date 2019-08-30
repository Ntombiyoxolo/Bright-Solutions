using System;
using System.Collections.Generic;
using System.Linq;
using API.Model;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class MasterAPIController : Controller
    {
        // GET: MasterAPI

        [System.Web.Http.Route("MasterAPI/GetEmployee")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetEmployee()
        {
            UTRANSPORTDATABASEEntities2 db = new UTRANSPORTDATABASEEntities2();
            db.Configuration.ProxyCreationEnabled = false;
            return GetEmployeeMethod(db.EMPLOYEEs.ToList());
        }
        public List<dynamic> GetEmployeeMethod(List<EMPLOYEE> eMPLOYEEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (EMPLOYEE eMPLOYEE in eMPLOYEEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.EMPLOYEE_ID = eMPLOYEE.EMPLOYEE_ID;
                dynamic.TITLE_ID = eMPLOYEE.TITLE_ID;
                dynamic.EMPLOYEE_NAME = eMPLOYEE.EMPLOYEE_NAMES;
                dynamic.EMPLOYEE_SURNAME = eMPLOYEE.EMPLOYEE_SURNAME;
                dynamic.EMPLOYEE_EMAIL_ADDRESS = eMPLOYEE.EMPLOYEE_EMAIL_ADDRESS;
                dynamic.EMPLOYEE_CONTACT_NO = eMPLOYEE.EMPLOYEE_CONTACT_NO;
                dynamic.IDENTITY_NO = eMPLOYEE.IDENTITY_NO;
                dynamic.EMPLOYEE_CONTRACT_ID = eMPLOYEE.EMPLOYEE_CONTRACT_ID;
                dynamic.EMPLOYEE_TYPE_ID = eMPLOYEE.EMPLOYEE_TYPE_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("API/AddorEdit/Employee")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditEmployee([FromBody] EMPLOYEE eMPLOYEE)
        {
            UTRANSPORTDATABASEEntities2 db = new UTRANSPORTDATABASEEntities2();
            db.Configuration.ProxyCreationEnabled = false;

            if (eMPLOYEE.EMPLOYEE_ID == 0)
            {
                db.EMPLOYEEs.Add(eMPLOYEE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(eMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
            }

            return GetEmployee();
        }

        [System.Web.Http.Route("API/Delete/Employee")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteEmployee([FromBody] EMPLOYEE eMPLOYEE)
        {
            UTRANSPORTDATABASEEntities2 db = new UTRANSPORTDATABASEEntities2();
            db.Configuration.ProxyCreationEnabled = false;
            db.EMPLOYEEs.Remove(db.EMPLOYEEs.Find(eMPLOYEE.EMPLOYEE_ID));
            db.SaveChanges();
            return GetEmployee();
        }
    }
}