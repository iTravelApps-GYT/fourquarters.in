using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using FourQuarterMVC;

namespace FourQuarterMVC.Controllers
{
    public class IndexController : Controller
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int result;
        
        #endregion

        [HttpGet]
        public ActionResult View1()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objDdlHomes = new Models.DropDownHome().GetDDlHomeData();
            objFourQuater.objListClientM = new Models.Client().GetClientData();
            objFourQuater.objListDigitalM = new Models.Digital().GetDigitalData();
            objFourQuater.objListPrintM = new Models.FilePrintImages().GetPrintData();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
            objFourQuater.objListThink = new Models.DesignThink().GetDesingThink();
            objFourQuater.objListSpeakM = new Models.Speak().GetSpeakData();
            objFourQuater.objListThinkerBody = new Models.ThinkerBody().GetThinkerData();
            return View(objFourQuater);
        }

        [HttpPost]
        public ActionResult Index(FourQuarterMVC.Models.FQClass obj)
        {
            return View();
        }

        [HttpPost]
        public JsonResult Mailer(string id)
        {
            try
            {
                cmd = new SqlCommand("spSubsrciber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", id);
                cmd.Parameters.AddWithValue("@Qtype", "Save");
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();

                FourQuarterMVC.Models.HomePage  obj=new Models.HomePage().GetMasterData(); 
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Timeout = 100000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(obj.MailFrom, "07320734799");
                MailMessage Loginfo = new MailMessage();
                Loginfo.To.Add(obj.MailFrom);
                Loginfo.From = new MailAddress(obj.MailFrom);
                Loginfo.Subject =obj.MailSubject;
                Loginfo.Body = obj.MailBody1+id;
                Loginfo.IsBodyHtml = true;
                Loginfo.To.Add(id);
                Loginfo.From = new MailAddress(obj.MailFrom);
                Loginfo.Subject = obj.MailSubject;
                Loginfo.Body = obj.MailBody2;
                Loginfo.IsBodyHtml = true;
                smtp.Send(Loginfo);
                return Json("Mail is Sent");
            }
            catch(Exception ex)
            {
                return Json("Invalid Email Id...!");
            }
        }
    }
}
