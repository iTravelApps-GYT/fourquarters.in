using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

namespace FourQuarterMVC.Controllers
{

    public class AdminController : Controller
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int result;
        string imgUrl;
        string VideoUrl;
        string PdfUrl;
        string NewImgName;
        string NewVideoName;
        string PdfFileName;

        #endregion

        [HttpGet]
        public ActionResult Home()
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
            //objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
            return View(objFourQuater);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Home(FourQuarterMVC.Models.FourQuaterClass obj)
        {
            try
            {
                if (Request.Files.Count > 0)
                {

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var upload1 = Request.Files[i];
                        if (i == 0)
                        {
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                        else if (i == 1)
                        {
                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                NewVideoName = Guid.NewGuid().ToString() + fileName;
                                VideoUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewVideoName);
                                upload1.SaveAs(VideoUrl);
                            }
                        }
                    }
                }
                if (NewImgName != null && NewVideoName != null)
                {
                    cmd = new SqlCommand("spMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogoUrl", NewImgName);
                    cmd.Parameters.AddWithValue("@LogoTitle1", obj.objMaster.LogoTitle1);
                    cmd.Parameters.AddWithValue("@LogoTitle2", obj.objMaster.LogoTitle2);
                    cmd.Parameters.AddWithValue("@WelcomeTitle", obj.objMaster.WelcomeTitle);
                    cmd.Parameters.AddWithValue("@WelcomeBody", obj.objMaster.WelcomeBody);
                    cmd.Parameters.AddWithValue("@VideoURL", NewVideoName);
                    cmd.Parameters.AddWithValue("@FooterDescline1", obj.objMaster.FooterDescline1);
                    cmd.Parameters.AddWithValue("@FooterDescline2", obj.objMaster.FooterDescLine2);
                    cmd.Parameters.AddWithValue("@FourQuarterMailId", obj.objMaster.FourQuarterMailId);
                    cmd.Parameters.AddWithValue("@SubscribText", obj.objMaster.SubscribText);
                    cmd.Parameters.AddWithValue("@SayHelloText", obj.objMaster.SayHello);
                    cmd.Parameters.AddWithValue("@Address", obj.objMaster.Address);
                    cmd.Parameters.AddWithValue("@FacebookURL", obj.objMaster.FacebookURL);
                    cmd.Parameters.AddWithValue("@TwiterURL", obj.objMaster.TwiterURL);
                    cmd.Parameters.AddWithValue("@inURL", obj.objMaster.inURL);
                    cmd.Parameters.AddWithValue("@Qtype", "Update");
                    cmd.Parameters.AddWithValue("@ID", "1");
                }
                else
                {
                    cmd = new SqlCommand("spMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogoTitle1", obj.objMaster.LogoTitle1);
                    cmd.Parameters.AddWithValue("@LogoTitle2", obj.objMaster.LogoTitle2);
                    cmd.Parameters.AddWithValue("@WelcomeTitle", obj.objMaster.WelcomeTitle);
                    cmd.Parameters.AddWithValue("@WelcomeBody", obj.objMaster.WelcomeBody);
                    cmd.Parameters.AddWithValue("@FooterDescline1", obj.objMaster.FooterDescline1);
                    cmd.Parameters.AddWithValue("@FooterDescline2", obj.objMaster.FooterDescLine2);
                    cmd.Parameters.AddWithValue("@FourQuarterMailId", obj.objMaster.FourQuarterMailId);
                    cmd.Parameters.AddWithValue("@SubscribText", obj.objMaster.SubscribText);
                    cmd.Parameters.AddWithValue("@SayHelloText", obj.objMaster.SayHello);
                    cmd.Parameters.AddWithValue("@Address", obj.objMaster.Address);
                    cmd.Parameters.AddWithValue("@FacebookURL", obj.objMaster.FacebookURL);
                    cmd.Parameters.AddWithValue("@TwiterURL", obj.objMaster.TwiterURL);
                    cmd.Parameters.AddWithValue("@inURL", obj.objMaster.inURL);
                    cmd.Parameters.AddWithValue("@Qtype", "Update2");
                    cmd.Parameters.AddWithValue("@ID", "1");
                }
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();

                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objMaster = new Models.HomePage().GetMasterData();
                

                if (result > 0)
                {
                    ViewBag.Message = "Data Is Successfully Updated...!";
                    return View(objFourQuater);
                }
                else
                {
                    ViewBag.Message = "Data Is Not Successfully Updated...!";
                    return View(objFourQuater);
                }
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        [HttpGet]
        public ActionResult FilePrintImages() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objPrint = new Models.FilePrintImages();
            objFourQuater.objListPrintM = new Models.FilePrintImages().GetPrintData();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
            // objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
            return View(objFourQuater);
        }

        [HttpPost]
        public JsonResult DeleterPrintImage(string id)
        {
           
                new Models.FilePrintImages().DeletePrintImage(Convert.ToInt32(id));
                ViewBag.Message = "Data is Successfully Deleted...!";
                System.Text.StringBuilder sbPrintImage = new System.Text.StringBuilder();
                List<Models.FilePrintImages> objPrintImageList = new List<Models.FilePrintImages>();
                objPrintImageList = new Models.FilePrintImages().GetPrintData();
                sbPrintImage.Append("<table width='100%' id='tblData' border='1'> <tr><th>Project Title</th><th>Project Date</th><th>Project Description</th><th>Thumbnail Image</th><th>Orignal Image</th><th>Action</th>");
                foreach (Models.FilePrintImages obj in objPrintImageList)
                {
                    sbPrintImage.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-Protitle='" + obj.ProjectTitle + "' data-ProDate='" + obj.ProjectDate + "' data-ProDesc='" + obj.ProjectDesc + "' data-ThumIMG='" + obj.ThumbnailImagePath + "' data-OrigIMG='" + obj.OrignalImagePath + "'/> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>" + obj.ProjectTitle + "</a> </td>");
                    sbPrintImage.Append("<td><span>" + obj.ProjectDate + "</span></td>");
                    sbPrintImage.Append("<td><span>" + obj.ProjectDesc + "</span></td>");
                    sbPrintImage.Append("<td><span><img src=" + Url.Content("~/Uploads/" + obj.ThumbnailImagePath) + " width='" + 100 + "' heigth='" + 100 + "'/></span></td>");
                    sbPrintImage.Append("<td><span><img src=" + Url.Content("~/Uploads/" + obj.OrignalImagePath) + " width='" + 100 + "' heigth='" + 100 + "'/></span></td>");
                    sbPrintImage.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");

                }

                return Json(sbPrintImage.ToString());
           
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FilePrintImages(FourQuarterMVC.Models.FourQuaterClass obj, string hdd, string FilePrint) // Calling on http post (on Submit)
        {
            try
            {

                if (FilePrint == "Save Master Panel")
                {

                    cmd = new SqlCommand("spFile_PrintMasterUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@filmPrintTitle", obj.objMaster.FilmPrintTitle);
                    cmd.Parameters.AddWithValue("@filmPrintHeading", obj.objMaster.FilmPrintHeading);
                    cmd.Parameters.AddWithValue("@filmPrintDesc", obj.objMaster.FilmPrintDesc);
                    
                    cmd.Parameters.AddWithValue("@filmPrintBottomHeading1", obj.objMaster.FilmPrintBottomHeading1 );
                    cmd.Parameters.AddWithValue("@filmPrintBottomHeading2", obj.objMaster.FilmPrintBottomHeading2 );
                    cmd.Parameters.AddWithValue("@filmPrintBottomHeading3", obj.objMaster.FilmPrintBottomHeading3 );                    

                    cmd.Parameters.AddWithValue("@filmPrintBottomDesc1", obj.objMaster.FilmPrintBottomDesc1);
                    cmd.Parameters.AddWithValue("@filmPrintBottomDesc2", obj.objMaster.FilmPrintBottomDesc2);
                    cmd.Parameters.AddWithValue("@filmPrintBottomDesc3", obj.objMaster.FilmPrintBottomDesc3);
                    
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Saved...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Saved...!";

                    }
                  



                   
                    FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                    objFourQuater.objPrint = new Models.FilePrintImages();
                    objFourQuater.objListPrintM = new Models.FilePrintImages().GetPrintData();
                    objFourQuater.objMaster = new Models.HomePage().GetMasterData();
                    // objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
                    return View(objFourQuater);
                }
                else
                {

                    if (hdd == "0")
                    {
                        if (Request.Files.Count > 0)
                        {

                            for (int i = 0; i < Request.Files.Count; i++)
                            {
                                var upload1 = Request.Files[i];
                                if (i == 0)
                                {
                                    if (upload1 != null && upload1.ContentLength > 0)
                                    {
                                        var fileName = Path.GetFileName(upload1.FileName);
                                        NewImgName = Guid.NewGuid().ToString() + fileName;
                                        imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                        upload1.SaveAs(imgUrl);
                                    }
                                }
                                else if (i == 1)
                                {
                                    if (upload1 != null && upload1.ContentLength > 0)
                                    {
                                        var fileName = Path.GetFileName(upload1.FileName);
                                        NewVideoName = Guid.NewGuid().ToString() + fileName;
                                        VideoUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewVideoName);
                                        upload1.SaveAs(VideoUrl);
                                    }
                                }
                            }
                        }
                        cmd = new SqlCommand("spFile_PrintImage", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectTitle", obj.objPrint.ProjectTitle);
                        cmd.Parameters.AddWithValue("@ProjectDate", obj.objPrint.ProjectDate);
                        cmd.Parameters.AddWithValue("@ProjectDesc", obj.objPrint.ProjectDesc);
                        cmd.Parameters.AddWithValue("@ThumbnailURL", NewImgName);
                        cmd.Parameters.AddWithValue("@OrignalImageURL", NewVideoName == null ? obj.objPrint.OrignalImagePath : NewVideoName);
                       
                        //cmd.Parameters.AddWithValue("@filmPrintTitle", obj.objMaster.FilmPrintTitle);
                        //cmd.Parameters.AddWithValue("@filmPrintHeading", obj.objMaster.FilmPrintHeading);
                        //cmd.Parameters.AddWithValue("@filmPrintDesc", obj.objMaster.FilmPrintDesc);
                        //cmd.Parameters.AddWithValue("@filmPrintBottomDesc1", obj.objMaster.FilmPrintBottomDesc1);
                        //cmd.Parameters.AddWithValue("@filmPrintBottomDesc2", obj.objMaster.FilmPrintBottomDesc2);
                        //cmd.Parameters.AddWithValue("@filmPrintBottomDesc3", obj.objMaster.FilmPrintBottomDesc3);
                        cmd.Parameters.AddWithValue("@Qtype", "InsertinPrintImage");
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                        if (result > 0)
                        {
                            ViewBag.Message = "Data Is Successfully Saved...!";

                        }
                        else
                        {
                            ViewBag.Message = "Data Is Not Successfully Saved...!";

                        }
                    }
                    else
                    {
                        if (Request.Files.Count > 0)
                        {

                            for (int i = 0; i < Request.Files.Count; i++)
                            {
                                var upload1 = Request.Files[i];
                                if (i == 0)
                                {
                                    if (upload1 != null && upload1.ContentLength > 0)
                                    {
                                        var fileName = Path.GetFileName(upload1.FileName);
                                        NewImgName = Guid.NewGuid().ToString() + fileName;
                                        imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                        upload1.SaveAs(imgUrl);
                                    }
                                }
                                else if (i == 1)
                                {
                                    if (upload1 != null && upload1.ContentLength > 0)
                                    {
                                        var fileName = Path.GetFileName(upload1.FileName);
                                        NewVideoName = Guid.NewGuid().ToString() + fileName;
                                        VideoUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewVideoName);
                                        upload1.SaveAs(VideoUrl);
                                    }
                                }
                            }
                        }
                        if (NewImgName != null)
                        {
                            cmd = new SqlCommand("spFile_PrintImage", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProjectTitle", obj.objPrint.ProjectTitle);
                            cmd.Parameters.AddWithValue("@ProjectDate", obj.objPrint.ProjectDate);
                            cmd.Parameters.AddWithValue("@ProjectDesc", obj.objPrint.ProjectDesc);
                            cmd.Parameters.AddWithValue("@ThumbnailURL", NewImgName);
                            cmd.Parameters.AddWithValue("@OrignalImageURL", NewVideoName == null ? obj.objPrint.OrignalImagePath : NewVideoName);
                            //cmd.Parameters.AddWithValue("@filmPrintTitle", obj.objMaster.FilmPrintTitle);
                            //cmd.Parameters.AddWithValue("@filmPrintHeading", obj.objMaster.FilmPrintHeading);
                            //cmd.Parameters.AddWithValue("@filmPrintDesc", obj.objMaster.FilmPrintDesc);
                            //cmd.Parameters.AddWithValue("@filmPrintBottomDesc1", obj.objMaster.FilmPrintBottomDesc1);
                            //cmd.Parameters.AddWithValue("@filmPrintBottomDesc2", obj.objMaster.FilmPrintBottomDesc2);
                            //cmd.Parameters.AddWithValue("@filmPrintBottomDesc3", obj.objMaster.FilmPrintBottomDesc3);
                            cmd.Parameters.AddWithValue("@Id", hdd);
                            cmd.Parameters.AddWithValue("@Qtype", "UpdateinPrintImage");
                        }
                        else
                        {
                            cmd = new SqlCommand("spFile_PrintImage", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProjectTitle", obj.objPrint.ProjectTitle);
                            cmd.Parameters.AddWithValue("@ProjectDate", obj.objPrint.ProjectDate);
                            cmd.Parameters.AddWithValue("@ProjectDesc", obj.objPrint.ProjectDesc);
                            cmd.Parameters.AddWithValue("@OrignalImageURL", NewVideoName == null ? obj.objPrint.OrignalImagePath : NewVideoName);
                            //cmd.Parameters.AddWithValue("@filmPrintTitle", obj.objMaster.FilmPrintTitle);
                            //cmd.Parameters.AddWithValue("@filmPrintHeading", obj.objMaster.FilmPrintHeading);
                            //cmd.Parameters.AddWithValue("@filmPrintDesc", obj.objMaster.FilmPrintDesc);
                            //cmd.Parameters.AddWithValue("@filmPrintBottomDesc1", obj.objMaster.FilmPrintBottomDesc1);
                            //cmd.Parameters.AddWithValue("@filmPrintBottomDesc2", obj.objMaster.FilmPrintBottomDesc2);
                            //cmd.Parameters.AddWithValue("@filmPrintBottomDesc3", obj.objMaster.FilmPrintBottomDesc3);
                            cmd.Parameters.AddWithValue("@Id", hdd);
                            cmd.Parameters.AddWithValue("@Qtype", "UpdateinPrintImage2");
                        }
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                        if (result > 0)
                        {
                            ViewBag.Message = "Data Is Successfully Updated...!";

                        }
                        else
                        {
                            ViewBag.Message = "Data Is Not Successfully Updated...!";

                        }
                    }
                    FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                    objFourQuater.objPrint = new Models.FilePrintImages();
                    objFourQuater.objListPrintM = new Models.FilePrintImages().GetPrintData();
                    objFourQuater.objMaster = new Models.HomePage().GetMasterData();
                    // objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
                    return View(objFourQuater);

                }
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        [HttpGet]
        public ActionResult CleintMaster() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objClient = new Models.Client();
            objFourQuater.objListClientM = new Models.Client().GetClientData();
            return View(objFourQuater);
        }

        [HttpPost]
        public JsonResult DeleterCLient(string id)
        {

            new Models.Client().DeleteClientMaster(Convert.ToInt32(id));
            ViewBag.Message = "Data is Successfully Deleted...!";
            System.Text.StringBuilder sbClient = new System.Text.StringBuilder();
            List<Models.Client> objClientList = new List<Models.Client>();
            objClientList = new Models.Client().GetClientData();
            sbClient.Append("<table width='100%' id='tblData' border='1'>  <tr><th>Logo ID</th><th>Logo Image</th><th>Logo Description</th><th>Action</th>");
            foreach (Models.Client obj in objClientList)
            {
                sbClient.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-LogoPath='" + obj.LogoPath + "' data-LogoDesc='" + obj.LogoDesc + "' /> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>" + obj.Id + "</a> </td>");
                sbClient.Append("<td><span><img src=" + Url.Content("~/Uploads/" + obj.LogoPath) + " width='" + 100 + "' heigth='" + 100 + "'/></span></td>");
                sbClient.Append("<td><span>" + obj.LogoDesc + "</span></td>");
                sbClient.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");

            }

            return Json(sbClient.ToString());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CleintMaster(FourQuarterMVC.Models.FourQuaterClass obj,string hdd) // Calling on http post (on Submit)
        {
            try
            {
                if (hdd == "0" || hdd==null)
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    cmd = new SqlCommand("spClient", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LogoUrl", NewImgName);
                    cmd.Parameters.AddWithValue("@LogoDesc",obj.objClient.LogoDesc);
                    cmd.Parameters.AddWithValue("@Qtype", "InsertInClient");
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Saved...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Saved...!";

                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    if (NewImgName != null)
                    {
                        cmd = new SqlCommand("spClient", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LogoUrl", NewImgName);
                        cmd.Parameters.AddWithValue("@LogoDesc", obj.objClient.LogoDesc);
                        cmd.Parameters.AddWithValue("@ID", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInClient");
                    }
                    else
                    {
                        cmd = new SqlCommand("spClient", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LogoDesc", obj.objClient.LogoDesc);
                        cmd.Parameters.AddWithValue("@ID", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInClient2");
                    }
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Updated...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Updated...!";

                    }
                }

                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objClient = new Models.Client();
                objFourQuater.objListClientM = new Models.Client().GetClientData();

               
                    return View(objFourQuater);
                
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        [HttpGet]
        public ActionResult DDDigital() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objDigital = new Models.Digital();
            objFourQuater.objListDigitalM = new Models.Digital().GetDigitalData();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
            //objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
            return View(objFourQuater);
        }

        [HttpPost]
        public JsonResult DeleterDigital(string id)
        {

            new Models.Digital().DeleteDigital(Convert.ToInt32(id));
            ViewBag.Message = "Data is Successfully Deleted...!";
            System.Text.StringBuilder sbDigital = new System.Text.StringBuilder();
            List<Models.Digital> objDigitalList = new List<Models.Digital>();
            objDigitalList = new Models.Digital().GetDigitalData();
            sbDigital.Append("<table width='100%' id='tblData' border='1'> <tr><th>Drop Down Value</th><th>Popup Body</th><th>Action</th></tr>");
            foreach (Models.Digital obj in objDigitalList)
            {
                sbDigital.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-DDL='" + obj.DDlValue + "' data-PopupBody='" + obj.PopupBody + "'/> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>" + obj.DDlValue + "</a> </td>");
                sbDigital.Append("<td><span>" + obj.PopupBody + "</span></td>");
                sbDigital.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");
            }
            return Json(sbDigital.ToString());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DDDigital(FourQuarterMVC.Models.FourQuaterClass obj, string hdd) // Calling on http post (on Submit)
        {
            try
            {
                if (hdd == "0")
                {
                    if (Request.Files.Count > 0)
                    {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    NewImgName = Guid.NewGuid().ToString() + fileName;
                                    imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                    upload1.SaveAs(imgUrl);
                                }
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    PdfFileName = Guid.NewGuid().ToString() + fileName;
                                    PdfUrl = Path.Combine(Server.MapPath("~/Uploads/"), PdfFileName);
                                    upload1.SaveAs(PdfUrl);
                                }
                            }
                        }
                    }
                    if (NewImgName != null && PdfFileName != null)
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@DigitalImageURL", NewImgName);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@PopupBody", PdfFileName);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Qtype", "InsertInDigital");
                    }
                    else if (NewImgName != null && PdfFileName ==null)
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@DigitalImageURL", NewImgName);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Qtype", "InsertInDigital2");
                    }
                    else if (NewImgName == null && PdfFileName !=null)
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@PopupBody", PdfFileName);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Qtype", "InsertInDigital3");
                    }
                    else 
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Qtype", "InsertInDigital4");
                    }
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Saved...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Saved...!";

                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];
                            if (i == 0)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    NewImgName = Guid.NewGuid().ToString() + fileName;
                                    imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                    upload1.SaveAs(imgUrl);
                                }
                            }
                            else if (i == 1)
                            {
                                if (upload1 != null && upload1.ContentLength > 0)
                                {
                                    var fileName = Path.GetFileName(upload1.FileName);
                                    PdfFileName = Guid.NewGuid().ToString() + fileName;
                                    PdfUrl = Path.Combine(Server.MapPath("~/Uploads/"), PdfFileName);
                                    upload1.SaveAs(PdfUrl);
                                }
                            }
                        }
                    }
                    if (NewImgName != null && PdfFileName!=null)
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@DigitalImageURL", NewImgName);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@PopupBody", PdfFileName);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Id", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateinDigital");
                    }
                    else if (NewImgName != null && PdfFileName == null)
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@DigitalImageURL", NewImgName);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Id", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateinDigital2");
                    }
                    else if (PdfFileName != null && NewImgName == null)
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@PopupBody", PdfFileName);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Id", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateinDigital3");
                    }
                    else
                    {
                        cmd = new SqlCommand("spDigitalModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objDigital.DDlValue);
                        cmd.Parameters.AddWithValue("@Head1", obj.objMaster.Head1);
                        cmd.Parameters.AddWithValue("@Head2", obj.objMaster.Head2);
                        cmd.Parameters.AddWithValue("@Head3", obj.objMaster.Head3);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objMaster.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objMaster.Desc2);
                        cmd.Parameters.AddWithValue("@Desc3", obj.objMaster.Desc3);
                        cmd.Parameters.AddWithValue("@DigitalTitle", obj.objMaster.DigitalTitle);
                        cmd.Parameters.AddWithValue("@DigitalHeading", obj.objMaster.DigitalHeading);
                        cmd.Parameters.AddWithValue("@DigitalDescription", obj.objMaster.DigitalDesc);
                        cmd.Parameters.AddWithValue("@Id", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateinDigital4");
                    }
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Updated...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Updated...!";

                    }
                }

                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objDigital = new Models.Digital();
                objFourQuater.objListDigitalM = new Models.Digital().GetDigitalData();
                objFourQuater.objMaster = new Models.HomePage().GetMasterData();
                //objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();


               
                    return View(objFourQuater);
               
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        [HttpGet]
        public ActionResult InsertDesignThink() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objThink = new Models.DesignThink();
            objFourQuater.objListThink = new Models.DesignThink().GetDesingThink();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
           // objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
            return View(objFourQuater);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult InsertDesignThink(FourQuarterMVC.Models.FourQuaterClass obj, string hdd) // Calling on http post (on Submit)
        {
            try
            {
                if (hdd == "0")   //  Insert New Records......
                {
                    if (Request.Files.Count > 0)
                    {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {

                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    cmd = new SqlCommand("SpThinkModule", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DDLValue", obj.objThink.DDlValue);
                    cmd.Parameters.AddWithValue("@ImageUrl", NewImgName);
                    cmd.Parameters.AddWithValue("@SectionTitle", obj.objThink.SectionTitle);
                    cmd.Parameters.AddWithValue("@SectionBody", obj.objThink.SectionBody);
                    cmd.Parameters.AddWithValue("@ThinkTitle", obj.objMaster.ThinkingTitle);
                    cmd.Parameters.AddWithValue("@ChiefThinkTitle1", obj.objMaster.ChiefThinkTitle1);
                    cmd.Parameters.AddWithValue("@Qtype", "InsertInThink");
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Saved...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Saved...!";

                    }
                }
                else     //  Update Old Records By ID......
                {
                    if (Request.Files.Count > 0)
                    {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {

                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    if (NewImgName != null)
                    {
                        cmd = new SqlCommand("SpThinkModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objThink.DDlValue);
                        cmd.Parameters.AddWithValue("@ImageUrl", NewImgName);
                        cmd.Parameters.AddWithValue("@SectionTitle", obj.objThink.SectionTitle);
                        cmd.Parameters.AddWithValue("@SectionBody", obj.objThink.SectionBody);
                        cmd.Parameters.AddWithValue("@ThinkTitle", obj.objMaster.ThinkingTitle);
                        cmd.Parameters.AddWithValue("@ChiefThinkTitle1", obj.objMaster.ChiefThinkTitle1);
                        cmd.Parameters.AddWithValue("@ID", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInThink");
                    }
                    else
                    {
                        cmd = new SqlCommand("SpThinkModule", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DDLValue", obj.objThink.DDlValue);
                        cmd.Parameters.AddWithValue("@SectionTitle", obj.objThink.SectionTitle);
                        cmd.Parameters.AddWithValue("@SectionBody", obj.objThink.SectionBody);
                        cmd.Parameters.AddWithValue("@ThinkTitle", obj.objMaster.ThinkingTitle);
                        cmd.Parameters.AddWithValue("@ChiefThinkTitle1", obj.objMaster.ChiefThinkTitle1);
                        
                        cmd.Parameters.AddWithValue("@ID", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInThink2");
                    }
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Updated...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Updated...!";

                    }
                }

                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objThink = new Models.DesignThink();
                objFourQuater.objListThink = new Models.DesignThink().GetDesingThink();
                objFourQuater.objMaster = new Models.HomePage().GetMasterData();
                // objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();

                
                    return View(objFourQuater);
               
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        [HttpPost]
        public JsonResult DeleterDesignThink(string id)
        {

            new Models.DesignThink().DeleteDsignThink(Convert.ToInt32(id));
            ViewBag.Message = "Data is Successfully Deleted...!";
            System.Text.StringBuilder sbThink = new System.Text.StringBuilder();
            List<Models.DesignThink> objThinkList = new List<Models.DesignThink>();
            objThinkList = new Models.DesignThink().GetDesingThink();
            sbThink.Append("<table width='100%' id='tblData' border='1'><tr><th>DropDownValue</th><th>Image</th><th>Section Title</th><th>Section Body</th> <th>Action</th></tr>");
            foreach (Models.DesignThink obj in objThinkList)
            {

                sbThink.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-title='" + obj.SectionTitle + "' data-ddl='" + obj.DDlValue + "' data-body='" + obj.SectionBody + "'/> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>" + obj.DDlValue + "</a> </td>");
                sbThink.Append("<td><span><img src=" + Url.Content("~/Uploads/" + obj.ImagePath) + " width='" + 100 + "' height='" + 100 + "' /></span></td>");
                sbThink.Append("<td><span>" + obj.SectionTitle + "</span></td>");
                sbThink.Append("<td><span>" + obj.SectionBody + "</span></td>");
                sbThink.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");

            }

            return Json(sbThink.ToString());
        }

        [HttpGet]
        public ActionResult ThinkerBody() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objThinker = new Models.ThinkerBody();
            objFourQuater.objListThinkerBody = new Models.ThinkerBody().GetThinkerData();
            return View(objFourQuater);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThinkerBody(FourQuarterMVC.Models.FourQuaterClass obj, string hdd) // Calling on http post (on Submit)
        {
            try
            {
                if (hdd == "0")   //  Insert New Records......
                {
                    if (Request.Files.Count > 0)
                    {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {

                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    cmd = new SqlCommand("spThinkerBody", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ImageUrl", NewImgName);
                    cmd.Parameters.AddWithValue("@ThinkerBody", obj.objThinker.ThinkersBody);
                    cmd.Parameters.AddWithValue("@Align", obj.objThinker.Align=="Right"?'1':'0');
                    cmd.Parameters.AddWithValue("@Qtype", "InsertInThinkerBody");
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Saved...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Saved...!";

                    }
                }
                else     //  Update Old Records By ID......
                {
                    if (Request.Files.Count > 0)
                    {

                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {

                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    if (NewImgName != null)
                    {
                        cmd = new SqlCommand("spThinkerBody", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ImageUrl", NewImgName);
                        cmd.Parameters.AddWithValue("@ThinkerBody", obj.objThinker.ThinkersBody);
                        cmd.Parameters.AddWithValue("@Align", obj.objThinker.Align == "Right" ? '1' : '0');
                        cmd.Parameters.AddWithValue("@ID", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInThinkerBody");
                    }
                    else
                    {
                        cmd = new SqlCommand("spThinkerBody", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ThinkerBody", obj.objThinker.ThinkersBody);
                        cmd.Parameters.AddWithValue("@Align", obj.objThinker.Align == "Right" ? '1' : '0');
                        cmd.Parameters.AddWithValue("@ID", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInThinkerBody2");
                    }
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Updated...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Updated...!";

                    }
                }

                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objThinker = new Models.ThinkerBody();
                objFourQuater.objListThinkerBody = new Models.ThinkerBody().GetThinkerData();

                
                    return View(objFourQuater);
                
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        [HttpPost]
        public JsonResult DeleterThinkerBody(string id)
        {

            new Models.ThinkerBody().DeleteThinkerBody(Convert.ToInt32(id));
            ViewBag.Message = "Data is Successfully Deleted...!";
            System.Text.StringBuilder sbThink = new System.Text.StringBuilder();
            List<Models.ThinkerBody> objThinkerList = new List<Models.ThinkerBody>();
            objThinkerList = new Models.ThinkerBody().GetThinkerData();
            sbThink.Append("<table width='100%' id='tblData' border='1'><tr><th>Image</th><th>Section Body</th><th>Action</th></tr>");
            foreach (Models.ThinkerBody obj in objThinkerList)
            {

                sbThink.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-body='" + obj.ThinkersBody + "'/> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>Update</a> </td>");
                sbThink.Append("<td><span><img src=" + Url.Content("~/Uploads/" + obj.ImageURL) + " width='" + 100 + "' height='" + 100 + "' /></span></td>");
                sbThink.Append("<td><span>" + obj.ThinkersBody + "</span></td>");
                sbThink.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");

            }

            return Json(sbThink.ToString());
        }


        [HttpGet]
        public ActionResult SpeakMaster() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objspeak = new Models.Speak();
            objFourQuater.objListSpeakM = new Models.Speak().GetSpeakData();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
            //objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();
            return View(objFourQuater);
        }

        [HttpPost]
        public JsonResult DeleterSpeakMaster(string id)
        {

            new Models.Speak().DeleteSpeakMaster(Convert.ToInt32(id));
            ViewBag.Message = "Data is Successfully Deleted...!";
            System.Text.StringBuilder sbSpeak = new System.Text.StringBuilder();
            List<Models.Speak> objSpeakList = new List<Models.Speak>();
            objSpeakList = new Models.Speak().GetSpeakData();
            sbSpeak.Append("<table width='100%' id='tblData' border='1'><tr><th>Description 1</th><th>Description 2</th><th>Logo</th><th>Logo Description</th><th>Action</th></tr>");
            foreach (Models.Speak obj in objSpeakList)
            {
                sbSpeak.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-Desc1='" + obj.Desc1 + "' data-Desc2='" + obj.Desc2 + "' data-LogoPath='" + obj.LogoPath + "' data-LogoDesc='"+obj.LogoDesc+"'/> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>" + obj.Desc1 + "</a> </td>");
                sbSpeak.Append("<td><span>" + obj.Desc2 + "</span></td>");
                sbSpeak.Append("<td><span><img src=" + Url.Content("~/Uploads/" + obj.LogoPath) + " width='" + 100 + "' height='" + 100 + "' /></span></td>");
                sbSpeak.Append("<td><span>" + obj.LogoDesc + "</span></td>");
                sbSpeak.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");

            }

            return Json(sbSpeak.ToString());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SpeakMaster(FourQuarterMVC.Models.FourQuaterClass obj, string hdd) // Calling on http post (on Submit)
        {
            try
            {
                if (hdd == "0")
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    cmd = new SqlCommand("spSpeakMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SpeakTitle", obj.objMaster.SpeakTitle);
                    cmd.Parameters.AddWithValue("@SpeakHeading", obj.objMaster.SpeakHeading);
                    cmd.Parameters.AddWithValue("@SpeakDesc", obj.objMaster.SpeakDesc);
                    cmd.Parameters.AddWithValue("@Desc1", obj.objspeak.Desc1);
                    cmd.Parameters.AddWithValue("@Desc2", obj.objspeak.Desc2);
                    cmd.Parameters.AddWithValue("@LogoUrl", NewImgName);
                    cmd.Parameters.AddWithValue("@LogoDesc", obj.objspeak.LogoDesc);
                    cmd.Parameters.AddWithValue("@Qtype", "InsertInSpeakMaster");
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Saved...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Saved...!";

                    }
                }
                else
                {
                    if (Request.Files.Count > 0)
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var upload1 = Request.Files[i];

                            if (upload1 != null && upload1.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(upload1.FileName);
                                NewImgName = Guid.NewGuid().ToString() + fileName;
                                imgUrl = Path.Combine(Server.MapPath("~/Uploads/"), NewImgName);
                                upload1.SaveAs(imgUrl);
                            }
                        }
                    }
                    if (NewImgName != null)
                    {
                        cmd = new SqlCommand("spSpeakMaster", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SpeakTitle", obj.objMaster.SpeakTitle);
                        cmd.Parameters.AddWithValue("@SpeakHeading", obj.objMaster.SpeakHeading);
                        cmd.Parameters.AddWithValue("@SpeakDesc", obj.objMaster.SpeakDesc);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objspeak.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objspeak.Desc2);
                        cmd.Parameters.AddWithValue("@LogoUrl", NewImgName);
                        cmd.Parameters.AddWithValue("@LogoDesc", obj.objspeak.LogoDesc);
                        cmd.Parameters.AddWithValue("@Id", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInSpeakMaster");
                    }
                    else
                    {
                        cmd = new SqlCommand("spSpeakMaster", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SpeakTitle", obj.objMaster.SpeakTitle);
                        cmd.Parameters.AddWithValue("@SpeakHeading", obj.objMaster.SpeakHeading);
                        cmd.Parameters.AddWithValue("@SpeakDesc", obj.objMaster.SpeakDesc);
                        cmd.Parameters.AddWithValue("@Desc1", obj.objspeak.Desc1);
                        cmd.Parameters.AddWithValue("@Desc2", obj.objspeak.Desc2);
                        cmd.Parameters.AddWithValue("@LogoDesc", obj.objspeak.LogoDesc);
                        cmd.Parameters.AddWithValue("@Id", hdd);
                        cmd.Parameters.AddWithValue("@Qtype", "UpdateInSpeakMaster2");
                    }
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                    if (result > 0)
                    {
                        ViewBag.Message = "Data Is Successfully Updated...!";

                    }
                    else
                    {
                        ViewBag.Message = "Data Is Not Successfully Updated...!";

                    }
                }
                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objspeak = new Models.Speak();
                objFourQuater.objListSpeakM = new Models.Speak().GetSpeakData();
                objFourQuater.objMaster = new Models.HomePage().GetMasterData();
                // objFourQuater.objListMasterM = new Models.HomePage().GetMasterData();

               
                    return View(objFourQuater);
               
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }

        }

        [HttpGet]
        public ActionResult SubscriberMailZone() //Calling When We First Hit Controller
        {
            FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
            objFourQuater.objSubscriber = new Models.Subscribers();
            objFourQuater.objListSubscriber = new Models.Subscribers().GetSubscriberData();
            objFourQuater.objMaster = new Models.HomePage().GetMasterData();
            return View(objFourQuater);
        }

        [HttpPost]
        public JsonResult DeleterSubscriber(string id)
        {

            new Models.Subscribers().DeleteSubscriber(Convert.ToInt32(id));
            ViewBag.Message = "Data is Successfully Deleted...!";
            System.Text.StringBuilder sbSubscrib = new System.Text.StringBuilder();
            List<Models.Subscribers> objSubscriberList = new List<Models.Subscribers>();
            objSubscriberList = new Models.Subscribers().GetSubscriberData();
            sbSubscrib.Append("<table width='100%' id='tblData' border='1'> <tr><th>S.NO.</th><th>Email Id</th><th>Subscription Date</th><th>Action</th></tr>");
            foreach (Models.Subscribers obj in objSubscriberList)
            {
                sbSubscrib.Append("<tr> <td> <input type='hidden' value='" + obj.Id + "' data-Emailid='" + obj.Emailid + "' /> <a href='#' onclick='FillEdit(" + obj.Id + "); return false;'>Update</a> </td>");
                sbSubscrib.Append("<td><span>" + obj.Emailid + "</span></td>");
                sbSubscrib.Append("<td><span>" + obj.Date + "</span></td>");
                sbSubscrib.Append("<td><span><a href='#' onclick='Deleterecord(" + obj.Id + " ); return false;'>Delete</a></span></td></tr>");
            }

            return Json(sbSubscrib.ToString());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubscriberMailZone(FourQuarterMVC.Models.FourQuaterClass obj, string hdd) // Calling on http post (on Submit)
        {
            try
            {
                if (hdd == "0")
                {
                    cmd = new SqlCommand("spMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MailTO", obj.objMaster.MailTO);
                    cmd.Parameters.AddWithValue("@CC", obj.objMaster.CC);
                    cmd.Parameters.AddWithValue("@MailSubject", obj.objMaster.MailSubject);
                    cmd.Parameters.AddWithValue("@MailBody1", obj.objMaster.MailBody1);
                    cmd.Parameters.AddWithValue("@MailBody2", obj.objMaster.MailBody2);
                    cmd.Parameters.AddWithValue("@MailFrom", obj.objMaster.MailFrom);
                    cmd.Parameters.AddWithValue("@Qtype", "Update3");
                    cmd.Parameters.AddWithValue("@ID", "1");
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();

                }
                else
                {
                    cmd = new SqlCommand("spMaster", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MailTO", obj.objMaster.MailTO);
                    cmd.Parameters.AddWithValue("@CC", obj.objMaster.CC);
                    cmd.Parameters.AddWithValue("@MailSubject", obj.objMaster.MailSubject);
                    cmd.Parameters.AddWithValue("@MailBody1", obj.objMaster.MailBody1);
                    cmd.Parameters.AddWithValue("@MailBody2", obj.objMaster.MailBody2);
                    cmd.Parameters.AddWithValue("@MailFrom", obj.objMaster.MailFrom);
                    cmd.Parameters.AddWithValue("@Qtype", "Update3");
                    cmd.Parameters.AddWithValue("@ID", "1");
                    con.Open();
                    result = cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                }
                FourQuarterMVC.Models.FourQuaterClass objFourQuater = new Models.FourQuaterClass();
                objFourQuater.objSubscriber = new Models.Subscribers();
                objFourQuater.objListSubscriber = new Models.Subscribers().GetSubscriberData();
                objFourQuater.objMaster = new Models.HomePage().GetMasterData();

                if (result > 0)
                {
                    ViewBag.Message = "Data Is Successfully Updated...!";
                    return View(objFourQuater);
                }
                else
                {
                    ViewBag.Message = "Data Is Not Successfully Updated...!";
                    return View(objFourQuater);
                }
                
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
