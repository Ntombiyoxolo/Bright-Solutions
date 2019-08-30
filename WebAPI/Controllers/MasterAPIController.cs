using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using BCrypt.Net;

namespace WebAPI.Controllers
{
    public class MasterAPIController : ApiController
    {

        // GET: MasterAPI
        static string id = null;

        [System.Web.Http.Route("MasterAPI/GetEmployee")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetEmployee()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
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
                dynamic.EMPLOYEE_IMAGE = eMPLOYEE.EMPLOYEE_IMAGE;
                dynamic.EMPLOYEE_IMAGE_NAME = eMPLOYEE.EMPLOYEE_IMAGE_NAME;
                dynamic.EMPLOYEE_NAMES = eMPLOYEE.EMPLOYEE_NAMES;
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

        [System.Web.Http.Route("MasterAPI/AddorEditEmployee")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditEmployee([FromBody] EMPLOYEE eMPLOYEE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
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

        [System.Web.Http.Route("MasterAPI/DeleteEmployee")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteEmployee([FromBody] EMPLOYEE eMPLOYEE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.EMPLOYEEs.Remove(db.EMPLOYEEs.Find(eMPLOYEE.EMPLOYEE_ID));
            db.SaveChanges();

            return GetEmployee();
        }

        [System.Web.Http.Route("MasterAPI/GetTitle")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetTitle()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetTitleMethod(db.TITLEs.ToList());
        }
        public List<dynamic> GetTitleMethod(List<TITLE> tITLEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (TITLE tITLE in tITLEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.TITLE_ID = tITLE.TITLE_ID;
                dynamic.TITLE_NAME = tITLE.TITLE_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }
        //-------------------------------------------------------------contract section----------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetContract")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetContract()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetContractMethod(db.EMPLOYEE_CONTRACT.ToList());
        }
        public List<dynamic> GetContractMethod(List<EMPLOYEE_CONTRACT> eMPLOYEE_CONTRACTs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (EMPLOYEE_CONTRACT eMPLOYEE_CONTRACT in eMPLOYEE_CONTRACTs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.EMPLOYEE_CONTRACT_ID = eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_ID;
                dynamic.EMPLOYEE_CONTRACT_SALARY = eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_SALARY;
                dynamic.EMPLOYEE_CONTRACT_START_DATE = eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_START_DATE;
                dynamic.EMPLOYEE_CONTRACT_END_DATE = eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_END_DATE;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditContract")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditContract([FromBody] EMPLOYEE_CONTRACT eMPLOYEE_CONTRACT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            if (eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_ID == null)
            {
                id = DateTime.Now.ToString();
                eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_ID = id;
                db.EMPLOYEE_CONTRACT.Add(eMPLOYEE_CONTRACT);
                db.SaveChanges();
            }
            else
            {
                db.Entry(eMPLOYEE_CONTRACT).State = EntityState.Modified;
                db.SaveChanges();
            }

            return GetContract();

        }

        [System.Web.Http.Route("MasterAPI/DeleteContract")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteContract([FromBody] EMPLOYEE_CONTRACT eMPLOYEE_CONTRACT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                db.EMPLOYEE_CONTRACT.Remove(db.EMPLOYEE_CONTRACT.Find(eMPLOYEE_CONTRACT.EMPLOYEE_CONTRACT_ID));
                db.SaveChanges();
            }
            catch
            {

            }
            return GetContract();
        }

        [System.Web.Http.Route("MasterAPI/AddorEditEmployeeContract")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditEmployeeContract([FromBody] EMPLOYEE eMPLOYEE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            var emp = db.EMPLOYEEs.Find(eMPLOYEE.EMPLOYEE_ID);
            if (emp.EMPLOYEE_CONTRACT_ID == null)
            {
                emp.EMPLOYEE_CONTRACT_ID = id;
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                id = null;

            }
            return GetEmployee();
        }

        //----------------------------------------------------------employee section-----------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetEmployeeType")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetEmployeeType()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetEmployeeTypeMethod(db.EMPLOYEE_TYPE.ToList());
        }
        public List<dynamic> GetEmployeeTypeMethod(List<EMPLOYEE_TYPE> eMPLOYEE_TYPEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (EMPLOYEE_TYPE eMPLOYEE_TYPE in eMPLOYEE_TYPEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.EMPLOYEE_TYPE_ID = eMPLOYEE_TYPE.EMPLOYEE_TYPE_ID;
                dynamic.EMPLOYEE_TYPE_NAME = eMPLOYEE_TYPE.EMPLOYEE_TYPE_NAME;
                dynamic.EMPLOYEE_TYPE_DESCRIPTION = eMPLOYEE_TYPE.EMPLOYEE_TYPE_DESCRIPTION;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditEmployeeType")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditEmployeeType([FromBody] EMPLOYEE_TYPE eMPLOYEE_TYPE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (eMPLOYEE_TYPE.EMPLOYEE_TYPE_ID == 0)
            {
                db.EMPLOYEE_TYPE.Add(eMPLOYEE_TYPE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(eMPLOYEE_TYPE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetEmployeeType();
        }

        [System.Web.Http.Route("MasterAPI/DeleteEmployeeType")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteEmployeeType([FromBody] EMPLOYEE_TYPE eMPLOYEE_TYPE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.EMPLOYEE_TYPE.Remove(db.EMPLOYEE_TYPE.Find(eMPLOYEE_TYPE.EMPLOYEE_TYPE_ID));
            db.SaveChanges();

            return GetEmployeeType();
        }

        //------------------------------------------------------------user-----------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetUser")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetUser()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetUserMethod(db.USERS.ToList());
        }
        public List<dynamic> GetUserMethod(List<USER> uSERs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (USER sER in uSERs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.USERS_ID = sER.USERS_ID;
                dynamic.USERS_PASSWORD = sER.USERS_PASSWORD;
                dynamic.USERS_USERNAME = sER.USERS_USERNAME;
                dynamic.EMPLOYEE_ID = sER.EMPLOYEE_ID;
                dynamics.Add(dynamic);
            }

            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditUser")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditUser([FromBody] USER uSER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (uSER.USERS_ID == 0)
            {
                db.USERS.Add(uSER);
                db.SaveChanges();
            }
            else
            {
                db.Entry(uSER).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetUser();
        }

        [System.Web.Http.Route("MasterAPI/DeleteUser")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteUser([FromBody] USER uSER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.USERS.Remove(db.USERS.Find(uSER.USERS_ID));
            db.SaveChanges();
            return GetUser();
        }
        //---------------------------------------------------------------Log In-------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/LogIn")]
        [System.Web.Http.HttpGet]
        public int LogIn([FromBody] USER uSER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<USER> uSERs = db.USERS.ToList();
            for (int i = 0; i < uSERs.Count(); i++)
            {
                if (uSERs[i].USERS_USERNAME == uSER.USERS_USERNAME && uSERs[i].USERS_PASSWORD == uSER.USERS_PASSWORD)
                {
                    return (int)uSERs[i].EMPLOYEE_ID;
                }
            }
            return -1;
        }
        //---------------------------------------------------------------Vehicles------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetVehicle")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetVehicle()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetVehicleMethod(db.VEHICLEs.ToList());
        }
        public List<dynamic> GetVehicleMethod(List<VEHICLE> vEHICLEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (VEHICLE vEHICLE in vEHICLEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.VEHICLE_ID = vEHICLE.VEHICLE_ID;
                dynamic.VEHICLE_REGISTRATIONNUMBER = vEHICLE.VEHICLE_REGISTRATIONNUMBER;
                dynamic.VEHICLE_PLATENUMBER = vEHICLE.VEHICLE_PLATENUMBER;
                dynamic.VEHICLE_BRAND = vEHICLE.VEHICLE_BRAND;
                dynamic.VEHICLE_NAME = vEHICLE.VEHICLE_NAME;
                dynamic.VEHICLE_IMAGE_NAME = vEHICLE.VEHICLE_IMAGE_NAME;
                dynamic.VEHICLE_IMAGE = vEHICLE.VEHICLE_IMAGE;
                dynamic.VEHICLE_STATUS_ID = vEHICLE.VEHICLE_STATUS_ID;
                dynamic.VEHICLE_WEIGHT = vEHICLE.VEHICLE_WEIGHT;
                dynamic.TRAILER_ID = vEHICLE.TRAILER_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditVehicle")]
        [System.Web.Http.HttpPost]
        public List<dynamic> ADdorEditVehicle([FromBody] VEHICLE vEHICLE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (vEHICLE.VEHICLE_ID == 0)
            {
                db.VEHICLEs.Add(vEHICLE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(vEHICLE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetVehicle();
        }

        [System.Web.Http.Route("MasterAPI/DeleteVehicle")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteVehicle([FromBody] VEHICLE vEHICLE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            db.VEHICLEs.Remove(db.VEHICLEs.Find(vEHICLE.VEHICLE_ID));
            db.SaveChanges();
            return GetVehicle();
        }

        [System.Web.Http.Route("MasterAPI/GetVehicleStatus")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetVehicleStatus()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            return GetVehicleStatusMethod(db.VEHICLE_STATUS.ToList());
        }
        public List<dynamic> GetVehicleStatusMethod(List<VEHICLE_STATUS> vEHICLE_STATUSes)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (VEHICLE_STATUS vEHICLE_STATUS in vEHICLE_STATUSes)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.VEHICLE_STATUS_ID = vEHICLE_STATUS.VEHICLE_STATUS_ID;
                dynamic.VEHICLE_STATUS_NAME = vEHICLE_STATUS.VEHICLE_STATUS_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        //------------------------------------------------------------------------Trailer-----------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetTrailer")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetTrailer()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetTrailerMethod(db.TRAILERs.ToList());
        }
        public List<dynamic> GetTrailerMethod(List<TRAILER> tRAILERs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (TRAILER tRAILER in tRAILERs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.TRAILER_ID = tRAILER.TRAILER_ID;
                dynamic.TRAILER_REGISTRATIONNUMBER = tRAILER.TRAILER_REGISTRATIONNUMBER;
                dynamic.TRAILER_NAME = tRAILER.TRAILER_NAME;
                dynamic.TRAILER_BRAND = tRAILER.TRAILER_BRAND;
                dynamic.TRAILER_IMAGE = tRAILER.TRAILER_IMAGE;
                dynamic.TRAILER_IMAGE_NAME = tRAILER.TRAILER_IMAGE_NAME;
                dynamic.TRAILER_STATUS_ID = tRAILER.TRAILER_STATUS_ID;
                dynamic.TRAILER_WEIGHT = tRAILER.TRAILER_WEIGHT;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditTrailer")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditTrailer([FromBody] TRAILER tRAILER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            if (tRAILER.TRAILER_ID == 0)
            {
                db.TRAILERs.Add(tRAILER);
                db.SaveChanges();

            }
            else
            {
                db.Entry(tRAILER).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetTrailer();
        }

        [System.Web.Http.Route("MasterAPI/DeleteTrailer")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteTrailer([FromBody] TRAILER tRAILER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            db.TRAILERs.Remove(db.TRAILERs.Find(tRAILER.TRAILER_ID));
            db.SaveChanges();
            return GetTrailer();
        }


        [System.Web.Http.Route("MasterAPI/GetTrailerStatus")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetTRailerStatus()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetTrailerStatusMethod(db.TRAILER_STATUS.ToList());
        }
        public List<dynamic> GetTrailerStatusMethod(List<TRAILER_STATUS> tRAILER_STATUSes)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (TRAILER_STATUS tRAILER_STATUS in tRAILER_STATUSes)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.TRAILER_STATUS_ID = tRAILER_STATUS.TRAILER_STATUS_ID;
                dynamic.TRAILER_STATUS_NAME = tRAILER_STATUS.TRAILER_STATUS_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        //---------------------------------------------------------DealerShip---------------------------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetDealership")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetDealership()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetDealershipMethod(db.DEALERSHIPs.ToList());
        }
        public List<dynamic> GetDealershipMethod(List<DEALERSHIP> dEALERSHIPs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (DEALERSHIP dEALERSHIP in dEALERSHIPs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.DEALERSHIP_ID = dEALERSHIP.DEALERSHIP_ID;
                dynamic.DEALERSHIP_NAME = dEALERSHIP.DEALERSHIP_NAME;
                dynamic.DEALERSHIP_REGISTRATION_NUMBER = dEALERSHIP.DEALERSHIP_REGISTRATION_NUMBER;
                dynamic.DEALERSHIP_CONTACT_NUMBER = dEALERSHIP.DEALERSHIP_CONTACT_NUMBER;
                dynamic.DEALERSHIP_LOCATION = dEALERSHIP.DEALERSHIP_LOCATION;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditDealership")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditDealership([FromBody] DEALERSHIP dEALERSHIP)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (dEALERSHIP.DEALERSHIP_ID == 0)
            {
                db.DEALERSHIPs.Add(dEALERSHIP);
                db.SaveChanges();
            }
            else
            {
                db.Entry(dEALERSHIP).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetDealership();
        }

        [System.Web.Http.Route("MasterAPI/DeleteDealership")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteDealership([FromBody] DEALERSHIP dEALERSHIP)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.DEALERSHIPs.Remove(db.DEALERSHIPs.Find(dEALERSHIP.DEALERSHIP_ID));
            db.SaveChanges();
            return GetDealership();
        }

        //---------------------------------------------------------------Dealership and services-----------------------------------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetServices")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetServices()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetServicesMethod(db.VEHICLE_DEALERSHIP_SERVICE.ToList());
        }
        public List<dynamic> GetServicesMethod(List<VEHICLE_DEALERSHIP_SERVICE> vEHICLE_DEALERSHIP_SERVICEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (VEHICLE_DEALERSHIP_SERVICE vEHICLE_DEALERSHIP_SERVICE in vEHICLE_DEALERSHIP_SERVICEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.VEHICLE_SERVICE_ID = vEHICLE_DEALERSHIP_SERVICE.VEHICLE_SERVICE_ID;
                dynamic.VEHICLE_SERVICE_DATE = vEHICLE_DEALERSHIP_SERVICE.VEHICLE_SERVICE_DATE;
                dynamic.VEHICLE_SERVICE_NEXT_DATE = vEHICLE_DEALERSHIP_SERVICE.VEHICLE_SERVICE_NEXT_DATE;
                dynamic.VEHICLE_ID = vEHICLE_DEALERSHIP_SERVICE.VEHICLE_ID;
                dynamic.DEALERSHIP_ID = vEHICLE_DEALERSHIP_SERVICE.DEALERSHIP_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }


        [System.Web.Http.Route("MasterAPI/AddorEditServices")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditServices([FromBody] VEHICLE_DEALERSHIP_SERVICE vEHICLE_DEALERSHIP_SERVICE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            if (vEHICLE_DEALERSHIP_SERVICE.VEHICLE_SERVICE_ID == 0)
            {
                db.VEHICLE_DEALERSHIP_SERVICE.Add(vEHICLE_DEALERSHIP_SERVICE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(vEHICLE_DEALERSHIP_SERVICE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetServices();

        }

        [System.Web.Http.Route("MasterAPI/DeleteServices")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteServices([FromBody] VEHICLE_DEALERSHIP_SERVICE vEHICLE_DEALERSHIP_SERVICE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.VEHICLE_DEALERSHIP_SERVICE.Remove(db.VEHICLE_DEALERSHIP_SERVICE.Find(vEHICLE_DEALERSHIP_SERVICE.VEHICLE_SERVICE_ID));
            db.SaveChanges();
            return GetServices();
        }

        ///--------------------------------------------------------------Product---------------------------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetProduct")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetProduct()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetProductMethod(db.PRODUCTs.ToList());
        }
        public List<dynamic> GetProductMethod(List<PRODUCT> pRODUCTs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (PRODUCT pRODUCT in pRODUCTs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.PRODUCT_ID = pRODUCT.PRODUCT_ID;
                dynamic.PRODUCT_NAME = pRODUCT.PRODUCT_NAME;
                dynamic.PRODUCT_DESCRIPTION = pRODUCT.PRODUCT_DESCRIPTION;
                dynamic.PRODUCT_QUANTITY = pRODUCT.PRODUCT_QUANTITY;
                dynamic.PRODUCT_TYPE_ID = pRODUCT.PRODUCT_TYPE_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditProduct")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AdorEditProduct([FromBody] PRODUCT pRODUCT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            if (pRODUCT.PRODUCT_ID == 0)
            {
                db.PRODUCTs.Add(pRODUCT);
                db.SaveChanges();
            }
            else
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetProduct();
        }

        [System.Web.Http.Route("MasterAPI/DeleteProduct")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteProduct([FromBody] PRODUCT pRODUCT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.PRODUCTs.Remove(db.PRODUCTs.Find(pRODUCT.PRODUCT_ID));
            db.SaveChanges();
            return GetProduct();
        }

        [System.Web.Http.Route("MasterAPI/GetProductType")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetProductType()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetProductTypeMethod(db.PRODUCT_TYPE.ToList());
        }
        public List<dynamic> GetProductTypeMethod(List<PRODUCT_TYPE> pRODUCT_TYPEs)
        {
            List<dynamic> dynamics = new List<dynamic>();

            foreach (PRODUCT_TYPE pRODUCT_TYPE in pRODUCT_TYPEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.PRODUCT_TYPE_ID = pRODUCT_TYPE.PRODUCT_TYPE_ID;
                dynamic.PRODUCT_TYPE_NAME = pRODUCT_TYPE.PRODUCT_TYPE_NAME;
                dynamic.PRODUCT_TYPE_DESCRIPTION = pRODUCT_TYPE.PRODUCT_TYPE_DESCRIPTION;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditProductType")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditProductType([FromBody] PRODUCT_TYPE pRODUCT_TYPE)
        {

            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            if (pRODUCT_TYPE.PRODUCT_TYPE_ID == 0)
            {
                db.PRODUCT_TYPE.Add(pRODUCT_TYPE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(pRODUCT_TYPE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetProductType();
        }

        [System.Web.Http.Route("MasterAPI/DeleteProductType")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteProductType([FromBody] PRODUCT_TYPE pRODUCT_TYPE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            db.PRODUCT_TYPE.Remove(db.PRODUCT_TYPE.Find(pRODUCT_TYPE.PRODUCT_TYPE_ID));
            db.SaveChanges();

            return GetProductType();
        }

        //------------------------------------------SUPPLIER--------------------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetSupplier")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetSupplier()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetSupplierMethod(db.SUPPLIERs.ToList());
        }
        public List<dynamic> GetSupplierMethod(List<SUPPLIER> sUPPLIERs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (SUPPLIER sUPPLIER in sUPPLIERs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.SUPPLIER_ID = sUPPLIER.SUPPLIER_ID;
                dynamic.SUPPLIER_NAME = sUPPLIER.SUPPLIER_NAME;
                dynamic.SUPPLIER_EMAIL = sUPPLIER.SUPPLIER_EMAIL;
                dynamic.SUPPLIER_CONTACT_NO = sUPPLIER.SUPPLIER_CONTACT_NO;
                dynamic.SUPPLIER_ADDRESS_BOX = sUPPLIER.SUPPLIER_ADDRESS_BOX;
                dynamic.SUPPLIER_ADDRESS_STREET = sUPPLIER.SUPPLIER_ADDRESS_STREET;
                dynamic.SUPPLIER_ADDRESS_TOWN = sUPPLIER.SUPPLIER_ADDRESS_TOWN;
                dynamic.SUPPLIER_ADDRESS_CODE = sUPPLIER.SUPPLIER_ADDRESS_CODE;
                dynamic.SUPPLIER_REGISTRATION_NUMBER = sUPPLIER.SUPPLIER_REGISTRATION_NUMBER;
                dynamic.SUPPLIER_BANK_DETAILS = sUPPLIER.SUPPLIER_BANK_DETAILS;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AdorEditSupplier")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditSupplier([FromBody]SUPPLIER sUPPLIER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            if (sUPPLIER.SUPPLIER_ID == 0)
            {
                db.SUPPLIERs.Add(sUPPLIER);
                db.SaveChanges();
            }
            else
            {
                db.Entry(sUPPLIER).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetSupplier();
        }

        [System.Web.Http.Route("MasterAPI/DeleteSupplier")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteSupplier([FromBody] SUPPLIER sUPPLIER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.SUPPLIERs.Remove(db.SUPPLIERs.Find(sUPPLIER.SUPPLIER_ID));
            db.SaveChanges();
            return GetSupplier();
        }

        //-----------------------------------------------------place order--------------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetOrder")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetOrder()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetOrderMethod(db.ORDERS.ToList());
        }
        public List<dynamic> GetOrderMethod(List<ORDER> oRDERs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (ORDER oRDER in oRDERs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.ORDERS_ID = oRDER.ORDERS_ID;
                dynamic.ORDERS_STATUS_ID = oRDER.ORDERS_STATUS_ID;
                dynamic.SUPPLIER_ID = oRDER.SUPPLIER_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditOrder")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditOrder([FromBody] ORDER oRDER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                db.ORDERS.Add(oRDER);
                db.SaveChanges();
            }
          
            return GetOrder();
        }

        [System.Web.Http.Route("MasterAPI/DeleteOrder")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteOrder([FromBody] ORDER oRDER)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.ORDERS.Remove(db.ORDERS.Find(oRDER.ORDERS_ID));
            db.SaveChanges();
            return GetOrder();
        }

        [System.Web.Http.Route("MasterAPI/GetOrderStatus")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetOrderStatus()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetOrderStatusMethod(db.ORDERS_STATUS.ToList());
        }
        public List<dynamic> GetOrderStatusMethod(List<ORDERS_STATUS> oRDERS_STATUSes)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (ORDERS_STATUS oRDERS_STATUS in oRDERS_STATUSes)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.ORDERS_STATUS_ID = oRDERS_STATUS.ORDERS_STATUS_ID;
                dynamic.ORDERS_STATUS_NAME = oRDERS_STATUS.ORDERS_STATUS_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/GetOrderLine")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetOrderLine()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetOrderLineMethod(db.ORDERS_LINE.ToList());
        }
        public List<dynamic> GetOrderLineMethod(List<ORDERS_LINE> oRDERS_LINEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (ORDERS_LINE oRDERS_LINE in oRDERS_LINEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.ORDERS_LINE_ID = oRDERS_LINE.ORDERS_LINE_ID;
                dynamic.ORDERS_ID = oRDERS_LINE.ORDERS_ID;
                dynamic.ORDERS_LINE_QUANTITY = oRDERS_LINE.ORDERS_LINE_QUANTITY;
                dynamic.PRODUCT_ID = oRDERS_LINE.PRODUCT_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditOrderLine")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditOrderLine([FromBody] ORDERS_LINE oRDERS_LINE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            if (oRDERS_LINE.ORDERS_LINE_ID == 0)
            {
                db.ORDERS_LINE.Add(oRDERS_LINE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(oRDERS_LINE).State = EntityState.Modified;
                db.SaveChanges();
            }

            return GetOrderLine();
        }

        [System.Web.Http.Route("MasterAPI/DeleteOrderLine")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteOrderLine([FromBody] ORDERS_LINE oRDERS_LINE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;

            db.ORDERS_LINE.Remove(db.ORDERS_LINE.Find(oRDERS_LINE.ORDERS_LINE_ID));
            db.SaveChanges();
            return GetOrderLine();
        }

        //--------------------------------------------------------Province-----------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetProvince")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetProvince()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetProvinceMethod(db.PROVINCEs.ToList());
        }
        public List<dynamic> GetProvinceMethod(List<PROVINCE> pROVINCEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (PROVINCE pROVINCE in pROVINCEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.PROVINCE_ID = pROVINCE.PROVINCE_ID;
                dynamic.PROVINCE_NAME = pROVINCE.PROVINCE_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        //---------------------------------------------------------------Client-----------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetClient")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetClient()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetClientMethod(db.CLIENTs.ToList());
        }
        public List<dynamic> GetClientMethod(List<CLIENT> cLIENTs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (CLIENT lIENT in cLIENTs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.CLIENT_ID = lIENT.CLIENT_ID;
                dynamic.CLIENT_NAME = lIENT.CLIENT_NAME;
                dynamic.CLIENT_EMAIL_ADDRESS = lIENT.CLIENT_EMAIL_ADDRESS;
                dynamic.CLIENT_ADDRESS_BOX = lIENT.CLIENT_ADDRESS_BOX;
                dynamic.CLIENT_ADDRESS_STREET = lIENT.CLIENT_ADDRESS_STREET;
                dynamic.CLIENT_ADDRESS_TOWN = lIENT.CLIENT_ADDRESS_TOWN;
                dynamic.CLIENT_ADDRESS_CODE = lIENT.CLIENT_ADDRESS_CODE;
                dynamic.CLIENT_CONTACT_NUMBER = lIENT.CLIENT_CONTACT_NUMBER;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditClient")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditClient([FromBody] CLIENT cLIENT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (cLIENT.CLIENT_ID == 0)
            {
                db.CLIENTs.Add(cLIENT);
                db.SaveChanges();
            }
            else
            {
                db.Entry(cLIENT).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetClient();
        }

        [System.Web.Http.Route("MasterAPI/DeleteClient")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteClient([FromBody] CLIENT cLIENT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.CLIENTs.Remove(db.CLIENTs.Find(cLIENT.CLIENT_ID));
            db.SaveChanges();
            return GetClient();
        }

        //------------------------------------------------------------------------------ROUTE-------------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetClientRoute")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetClientRoute()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetClientRouteMethod(db.CLIENT_ROUTE.ToList());
        }
        public List<dynamic> GetClientRouteMethod(List<CLIENT_ROUTE> cLIENT_ROUTEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (CLIENT_ROUTE rOUTE in cLIENT_ROUTEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.CLIENT_ROUTE_ID = rOUTE.CLIENT_ROUTE_ID;
                dynamic.CLIENT_MINE_ID = rOUTE.CLIENT_MINE_ID;
                dynamic.LOCATIONS = rOUTE.LOCATIONS;
                dynamic.DESIGNATED_ROUTE = rOUTE.DESIGNATED_ROUTE;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditClientRoute")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditClientRoute([FromBody] CLIENT_ROUTE rOUTE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (rOUTE.CLIENT_ROUTE_ID == 0)
            {
                db.CLIENT_ROUTE.Add(rOUTE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(rOUTE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetClientRoute();
        }
        //------------------------------------------------------------------------------------MINE--------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetMine")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetMine()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetMineMethod(db.MINE.ToList());
        }
        public List<dynamic> GetMineMethod(List<MINE> mINEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(MINE iNE in mINEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.MINE_ID = iNE.MINE_ID;
                dynamic.MINE_NAME = iNE.MINE_NAME;
                dynamic.PROVINCE_ID = iNE.PROVINCE_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditMine")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditMine([FromBody] MINE mINE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (mINE.MINE_ID==0)
            {
                db.MINE.Add(mINE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(mINE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetMine();
        }

        [System.Web.Http.Route("MasterAPI/DeleteMine")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteMine([FromBody] MINE iNE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.MINE.Remove(db.MINE.Find(iNE.MINE_ID));
            db.SaveChanges();
            return GetMine();
        }

        //-------------------------------------------------------------------cLIENT MINE--------------------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetClientMine")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetClientMine()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetClientMineMethod(db.CLIENT_MINE.ToList());
        }
        public List<dynamic> GetClientMineMethod(List<CLIENT_MINE> cLIENT_MINEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(CLIENT_MINE lIENT_MINE in cLIENT_MINEs)
            {
                dynamic dynamic =new ExpandoObject();
                dynamic.CLIENT_MINE_ID = lIENT_MINE.CLIENT_MINE_ID;
                dynamic.MINE_ID = lIENT_MINE.MINE_ID;
                dynamic.CLIENT_ID = lIENT_MINE.CLIENT_ID;
                dynamic.DESTINATION_ID = lIENT_MINE.DESTINATION_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditClientMine")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditClientMine([FromBody] CLIENT_MINE cLIENT_MINE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (cLIENT_MINE.CLIENT_MINE_ID==0)
            {
                db.CLIENT_MINE.Add(cLIENT_MINE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(cLIENT_MINE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetClientMine();
        }

        [System.Web.Http.Route("MasterAPI/DeleteClientMine")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteClient([FromBody] CLIENT_MINE lIENT_MINE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.CLIENT_MINE.Remove(db.CLIENT_MINE.Find(lIENT_MINE.CLIENT_MINE_ID));
            db.SaveChanges();
            return GetClientMine();
        }

        //-------------------------------------------------------------------------------dESTINATION---------------------------------------------------------//

        [System.Web.Http.Route("MasterAPI/GetDestination")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetDestination()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetDestinationMethod(db.DESTINATIONs.ToList());
        }
        public List<dynamic> GetDestinationMethod(List<DESTINATION> dESTINATIONs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(DESTINATION eSTINATION in dESTINATIONs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.DESTINATION_ID = eSTINATION.DESTINATION_ID;
                dynamic.DESTINATION_NAME = eSTINATION.DESTINATION_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditDestination")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditDestination([FromBody] DESTINATION dESTINATION)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (dESTINATION.DESTINATION_ID==0)
            {
                db.DESTINATIONs.Add(dESTINATION);
                db.SaveChanges();
            }
            else
            {
                db.Entry(dESTINATION).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetClientMine();
        }

        [System.Web.Http.Route("MasterAPI/DeleteDestination")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteDestination([FromBody] DESTINATION dESTINATION)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.DESTINATIONs.Remove(db.DESTINATIONs.Find(dESTINATION.DESTINATION_ID));
            db.SaveChanges();
            return GetDestination();
        }

        //-------------------------------------------------------------------------------audit tail----------------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetAuditTrailType")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetAuditType()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetAuditTypeMethod(db.AUDIT_TRAIL_TYPE.ToList());
        }
        public List<dynamic> GetAuditTypeMethod(List<AUDIT_TRAIL_TYPE> aUDIT_TRAIL_TYPEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(AUDIT_TRAIL_TYPE aUDIT_TRAIL_TYPE in aUDIT_TRAIL_TYPEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.AUDIT_TRAIL_TYPE_ID = aUDIT_TRAIL_TYPE.AUDIT_TRAIL_TYPE_ID;
                dynamic.AUDIT_TRAIL_TYPE_NAME = aUDIT_TRAIL_TYPE.AUDIT_TRAIL_TYPE_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/GetAuditTrail")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetAudit()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetAuditMethod(db.AUDIT_TRAIL.ToList());
        }
        public List<dynamic> GetAuditMethod(List<AUDIT_TRAIL> aUDIT_s)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach (AUDIT_TRAIL aUDIT_ in aUDIT_s)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.AUDIT_TRAIL_ID = aUDIT_.AUDIT_TRAIL_ID;
                dynamic.EMPLOYEE_ID = aUDIT_.EMPLOYEE_ID;
                dynamic.AUDIT_TRAIL_DATE = aUDIT_.AUDIT_TRAIL_DATE;
                dynamic.AUDIT_TRAIL_TYPE_ID = aUDIT_.AUDIT_TRAIL_TYPE_ID;
                dynamic.AUDIT_TRAIL_DEVICE = aUDIT_.AUDIT_TRAIL_DEVICE;
                dynamic.AUDIT_TRAIL_DESCRIPTION = aUDIT_.AUDIT_TRAIL_DESCRIPTION;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddAuditTrail")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddAuditTrail([FromBody] AUDIT_TRAIL aUDIT_TRAIL)
        {
            try{

                UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
                db.Configuration.ProxyCreationEnabled = false;
                db.AUDIT_TRAIL.Add(aUDIT_TRAIL);
                db.SaveChanges();
               
            }
            catch { }
            return GetAudit();
        }

        //-------------------------------------------Maintenance--------------------------------------------------------//
        [System.Web.Http.Route("MasterAPI/GetMaintenanceStatus")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetMaintenanceStatus()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetMaintenanceStatusMethod(db.MAINTENANCE_STATUS.ToList());
        }
        public List<dynamic> GetMaintenanceStatusMethod(List<MAINTENANCE_STATUS> mAINTENANCE_STATUSes)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(MAINTENANCE_STATUS mAIn_STATUS in mAINTENANCE_STATUSes)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.MAINTENANCE_STATUS_ID = mAIn_STATUS.MAINTENANCE_STATUS_ID;
                dynamic.MAINTENANCE_STATUS_NAME = mAIn_STATUS.MAINTENANCE_STATUS_NAME;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/GetMaintenance")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetMaintenance()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetMaintenanceMethod(db.MAINTENANCEs.ToList());
        }
        public List<dynamic> GetMaintenanceMethod(List<MAINTENANCE> mAINTENANCEs)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(MAINTENANCE aINTENANCE in mAINTENANCEs)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.MAINTENANCE_ID = aINTENANCE.MAINTENANCE_ID;
                dynamic.VEHICLE_ID = aINTENANCE.VEHICLE_ID;
                dynamic.EMPLOYEE_ID = aINTENANCE.EMPLOYEE_ID;
                dynamic.MAINTENANCE_STATUS_ID = aINTENANCE.MAINTENANCE_STATUS_ID;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }

        [System.Web.Http.Route("MasterAPI/AddorEditMaintenance")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditMaintenance([FromBody] MAINTENANCE mAINTENANCE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            if (mAINTENANCE.EMPLOYEE_ID==0)
            {
                db.MAINTENANCEs.Add(mAINTENANCE);
                db.SaveChanges();
            }
            else
            {
                db.Entry(mAINTENANCE).State = EntityState.Modified;
                db.SaveChanges();
            }
            return GetMaintenance();

        }
        [System.Web.Http.Route("MasterAPI/DeleteMaintenance")]
        [System.Web.Http.HttpPost]
        public List<dynamic> DeleteMaintenance([FromBody] MAINTENANCE mAINTENANCE)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.MAINTENANCEs.Remove(db.MAINTENANCEs.Find(mAINTENANCE.MAINTENANCE_ID));
            db.SaveChanges();
            return GetMaintenance();
        }

        [System.Web.Http.Route("MasterAPI/GetMaintenanceProduct")]
        [System.Web.Http.HttpGet]
        public List<dynamic> GetMaintenanceProduct()
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            return GetMaintenanceProduct(db.MAINTENANCE_PRODUCT.ToList());
        }
        public List<dynamic> GetMaintenanceProduct(List<MAINTENANCE_PRODUCT> mAINTENANCE_s)
        {
            List<dynamic> dynamics = new List<dynamic>();
            foreach(MAINTENANCE_PRODUCT ms in mAINTENANCE_s)
            {
                dynamic dynamic = new ExpandoObject();
                dynamic.MAINTENANCE_PRODUCT1 = ms.MAINTENANCE_PRODUCT1;
                dynamic.MAINTENANCE_ID = ms.MAINTENANCE_ID;
                dynamic.PRODUCT_ID = ms.PRODUCT_ID;
                dynamic.MAINTENANCE_PRODUCT_QUANTITY = ms.MAINTENANCE_PRODUCT_QUANTITY;
                dynamics.Add(dynamic);
            }
            return dynamics;
        }
        [System.Web.Http.Route("MasterAPI/AddorEditMaintenanceProduct")]
        [System.Web.Http.HttpPost]
        public List<dynamic> AddorEditMaintenenaceProduct([FromBody] MAINTENANCE_PRODUCT mAINTENANCE_PRODUCT)
        {
            UTRANSPORTDATABASEEntities db = new UTRANSPORTDATABASEEntities();
            db.Configuration.ProxyCreationEnabled = false;
            db.MAINTENANCE_PRODUCT.Add(mAINTENANCE_PRODUCT);
            db.SaveChanges();
            return GetMaintenanceProduct();
        }

    }

}
