using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

namespace FourQuarterMVC.Models
{


    public class FourQuaterClass
    {
        public List<DropDownHome> objDdlHomes { get; set; }
        public int objDesingThink { get; set; }
        public DesignThink objThink { get; set; }
        public FilePrintImages objPrint { get; set; }
        public Digital objDigital { get; set; }
        public HomePage objMaster { get; set; }
        public Speak objspeak { get; set; }
        public Client objClient { get; set; }
        public ThinkerBody objThinker { get; set; }
        public Subscribers objSubscriber { get; set; }
        public List<DesignThink> objListThink { get; set; }
        public List<HomePage> objListMasterM { get; set; }
        public List<FilePrintImages> objListPrintM { get; set; }
        public List<Digital> objListDigitalM { get; set; }
        public List<Speak> objListSpeakM { get; set; }
        public List<Client> objListClientM { get; set; }
        public List<ThinkerBody> objListThinkerBody { get; set; }
        public List<Subscribers> objListSubscriber { get; set; }

    }

    public class DropDownHome
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string DDlValue { get; set; }
        public List<DropDownHome> GetDDlHomeData()
        {
            cmd = new SqlCommand("SpThinkModule", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "Select");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            List<DropDownHome> objDdlHomes = new List<DropDownHome>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownHome objddlHome = new DropDownHome();
                    objddlHome.Id = Convert.ToInt32(dt.Rows[i][0]);
                    objddlHome.DDlValue = dt.Rows[i][1].ToString();
                    objDdlHomes.Add(objddlHome);
                }
            }
            return objDdlHomes;
        }


    }

    public class HomePage
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string logoPath { get; set; }
        public string LogoTitle1 { get; set; }
        public String LogoTitle2 { get; set; }
        public String WelcomeTitle { get; set; }
        public String WelcomeBody { get; set; }
        public String VideoUrl { get; set; }
        public String ThinkingTitle { get; set; }
        public String ChiefThinkTitle1 { get; set; }
        public String FilmPrintTitle { get; set; }
        public String FilmPrintHeading { get; set; }
        public String FilmPrintDesc { get; set; }

        public String FilmPrintBottomHeading1 { get; set; }
        public String FilmPrintBottomHeading2 { get; set; }
        public String FilmPrintBottomHeading3 { get; set; }

        public String FilmPrintBottomDesc1 { get; set; }
        public String FilmPrintBottomDesc2 { get; set; }
        public String FilmPrintBottomDesc3 { get; set; }
        public String DigitalTitle { get; set; }
        public String DigitalHeading { get; set; }
        public String DigitalDesc { get; set; }
        public string ImagePath { get; set; }
        public String Head1 { get; set; }
        public String Desc1 { get; set; }
        public String Head2 { get; set; }
        public String Desc2 { get; set; }
        public String Head3 { get; set; }
        public String Desc3 { get; set; }
        public String SpeakTitle { get; set; }
        public String SpeakHeading { get; set; }
        public String SpeakDesc { get; set; }
        public String MailTO { get; set; }
        public String CC { get; set; }
        public String MailSubject { get; set; }
        public String MailBody1 { get; set; }
        public String MailBody2 { get; set; }
        public String MailFrom { get; set; }
        public String FooterDescline1 { get; set; }
        public String FooterDescLine2 { get; set; }
        public String FourQuarterMailId { get; set; }
        public String SubscribText { get; set; }
        public String SayHello { get; set; }
        public String Address { get; set; }
        public String FacebookURL { get; set; }
        public String TwiterURL { get; set; }
        public String inURL { get; set; }
        public String Youtube { get; set; }

        public HomePage GetMasterData()
        {
            cmd = new SqlCommand("spMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "Select");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            HomePage ObjMaster = new HomePage();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ObjMaster.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    ObjMaster.logoPath = dt.Rows[i]["logoPath"].ToString();
                    ObjMaster.LogoTitle1 = dt.Rows[i]["logoTitle1"].ToString();
                    ObjMaster.LogoTitle2 = dt.Rows[i]["logoTitle2"].ToString();
                    ObjMaster.WelcomeTitle = dt.Rows[i]["welcomeTitle"].ToString();
                    ObjMaster.WelcomeBody = dt.Rows[i]["welcomeBody"].ToString();
                    ObjMaster.VideoUrl = dt.Rows[i]["videoURL"].ToString();
                    ObjMaster.ThinkingTitle = dt.Rows[i]["thinkingTitle"].ToString();
                    ObjMaster.ChiefThinkTitle1 = dt.Rows[i]["chiefThinkTitle1"].ToString();
                    ObjMaster.FilmPrintTitle = dt.Rows[i]["filmPrintTitle"].ToString();
                    ObjMaster.FilmPrintHeading = dt.Rows[i]["filmPrintHeading"].ToString();
                    ObjMaster.FilmPrintDesc = dt.Rows[i]["filmPrintDesc"].ToString();

                    ObjMaster.FilmPrintBottomHeading1 = dt.Rows[i]["filmPrintBottomHeading1"].ToString();
                    ObjMaster.FilmPrintBottomHeading2 = dt.Rows[i]["filmPrintBottomHeading2"].ToString();
                    ObjMaster.FilmPrintBottomHeading3 = dt.Rows[i]["filmPrintBottomHeading3"].ToString();

                    ObjMaster.FilmPrintBottomDesc1 = dt.Rows[i]["filmPrintBottomDesc1"].ToString();
                    ObjMaster.FilmPrintBottomDesc2 = dt.Rows[i]["filmPrintBottomDesc2"].ToString();
                    ObjMaster.FilmPrintBottomDesc3 = dt.Rows[i]["filmPrintBottomDesc3"].ToString();
                    ObjMaster.DigitalTitle = dt.Rows[i]["digitalTitle"].ToString();
                    ObjMaster.DigitalHeading = dt.Rows[i]["digitalHeading"].ToString();
                    ObjMaster.DigitalDesc = dt.Rows[i]["digitalDesc"].ToString();
                    ObjMaster.ImagePath = dt.Rows[i]["DigitalImageURL"].ToString();
                    ObjMaster.Head1 = dt.Rows[i]["Head1"].ToString();
                    ObjMaster.Head2 = dt.Rows[i]["Head2"].ToString();
                    ObjMaster.Head3 = dt.Rows[i]["Head3"].ToString();
                    ObjMaster.Desc1 = dt.Rows[i]["Desc1"].ToString();
                    ObjMaster.Desc2 = dt.Rows[i]["Desc2"].ToString();
                    ObjMaster.Desc3 = dt.Rows[i]["Desc3"].ToString();
                    ObjMaster.SpeakTitle = dt.Rows[i]["speakTitle"].ToString();
                    ObjMaster.SpeakHeading = dt.Rows[i]["speakHeading"].ToString();
                    ObjMaster.SpeakDesc = dt.Rows[i]["speakDesc"].ToString();
                    ObjMaster.MailTO = dt.Rows[i]["MailTO"].ToString();
                    ObjMaster.CC = dt.Rows[i]["CC"].ToString();
                    ObjMaster.MailSubject = dt.Rows[i]["MailSubject"].ToString();
                    ObjMaster.MailBody1 = dt.Rows[i]["MailBody1"].ToString();
                    ObjMaster.MailBody2 = dt.Rows[i]["MailBody2"].ToString();
                    ObjMaster.MailFrom = dt.Rows[i]["MailFrom"].ToString();
                    ObjMaster.FooterDescline1 = dt.Rows[i]["footerDescline1"].ToString();
                    ObjMaster.FooterDescLine2 = dt.Rows[i]["footerDescline2"].ToString();
                    ObjMaster.FourQuarterMailId = dt.Rows[i]["FourQuarterMailid"].ToString();
                    ObjMaster.SubscribText = dt.Rows[i]["Subscribtext"].ToString();
                    ObjMaster.SayHello = dt.Rows[i]["SayHello"].ToString();
                    ObjMaster.Address = dt.Rows[i]["Address"].ToString();
                    ObjMaster.FacebookURL = dt.Rows[i]["FacebookURL"].ToString();
                    ObjMaster.TwiterURL = dt.Rows[i]["TwiterURL"].ToString();
                    ObjMaster.inURL = dt.Rows[i]["inURL"].ToString();
                    ObjMaster.Youtube = dt.Rows[i]["Youtube"].ToString();
               
                }
            }
            return ObjMaster;
        }
    }

    public class Subscribers
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string Emailid { get; set; }
        public string Date { get; set; }

        public List<Subscribers> GetSubscriberData()
        {
            cmd = new SqlCommand("spSubsrciber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "Select");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            List<Subscribers> objListSubscriber = new List<Subscribers>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Subscribers objSubscriber = new Subscribers();
                    objSubscriber.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objSubscriber.Emailid = dt.Rows[i]["Email_Id"].ToString();
                    objSubscriber.Date = dt.Rows[i]["Subscription Date"].ToString();
                    objListSubscriber.Add(objSubscriber);
                }
            }
            return objListSubscriber;
        }

        public void DeleteSubscriber(int id)
        {
            try
            {
                cmd = new SqlCommand("update Subscriber set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    //ViewBag.Message = "Data Is Successfully Deleted...!";

                }
                else
                {
                    //ViewBag.Message = "Data Is Not Successfully Deleted...!";

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class Client
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string LogoPath { get; set; }
        public String LogoDesc { get; set; }

        public List<Client> GetClientData()
        {
            cmd = new SqlCommand("spClient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "SelectFromClient");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            List<Client> objListClient = new List<Client>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Client objClient = new Client();
                    objClient.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objClient.LogoPath = dt.Rows[i]["logoUrl"].ToString();
                    objClient.LogoDesc = dt.Rows[i]["logoDesc"].ToString();
                    objListClient.Add(objClient);
                }
            }
            return objListClient;
        }

        public void DeleteClientMaster(int id)
        {
            try
            {
                cmd = new SqlCommand("update clientMaster set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class ThinkerBody
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string ImageURL { get; set; }
        public String ThinkersBody { get; set; }
        public String Align { get; set; }

        public List<ThinkerBody> GetThinkerData()
        {
            cmd = new SqlCommand("spThinkerBody", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "SelectFromThinkerBody");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            List<ThinkerBody> objListThinkerBody = new List<ThinkerBody>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThinkerBody objThinkerBody = new ThinkerBody();
                    objThinkerBody.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objThinkerBody.ImageURL = dt.Rows[i]["ImageURL"].ToString();
                    objThinkerBody.ThinkersBody = dt.Rows[i]["ThinkerBody"].ToString();
                    objListThinkerBody.Add(objThinkerBody);
                }
            }
            return objListThinkerBody;
        }

        public void DeleteThinkerBody(int id)
        {
            try
            {
                cmd = new SqlCommand("update ThinkerBody set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class DesignThink
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string DDlValue { get; set; }
        public string ImagePath { get; set; }
        public String SectionTitle { get; set; }
        public String SectionBody { get; set; }

        public List<DesignThink> GetDesingThink()
        {
            cmd = new SqlCommand("SpThinkModule", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "SelectFromThink");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            List<DesignThink> objListThink = new List<DesignThink>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DesignThink objDesignThink = new DesignThink();
                    objDesignThink.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objDesignThink.DDlValue = dt.Rows[i]["ddlValue"].ToString();
                    objDesignThink.ImagePath = dt.Rows[i]["imgPath"].ToString();
                    objDesignThink.SectionTitle = dt.Rows[i]["sectionTitle"].ToString();
                    objDesignThink.SectionBody = dt.Rows[i]["sectionbody"].ToString();
                    objListThink.Add(objDesignThink);
                }
            }
            return objListThink;
        }

        public void DeleteDsignThink(int id)
        {
            try
            {
                cmd = new SqlCommand("update DropDownThinking set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class Digital
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string DDlValue { get; set; }
        public String PopupBody { get; set; }

        public List<Digital> GetDigitalData()
        {
            cmd = new SqlCommand("spDigitalModule", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "SelectFromDigital");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            List<Digital> objListDigital = new List<Digital>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Digital objDigital = new Digital();
                    objDigital.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objDigital.DDlValue = dt.Rows[i]["ddlValue"].ToString();
                    objDigital.PopupBody = dt.Rows[i]["PopupBody"].ToString();
                    objListDigital.Add(objDigital);
                }
            }
            return objListDigital;
        }
        public void DeleteDigital(int id)
        {
            try
            {
                cmd = new SqlCommand("update DropDownDigital set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }

    }

    public class FilePrintImages
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public String ProjectDate { get; set; }
        public String ProjectDesc { get; set; }
        public String ThumbnailImagePath { get; set; }
        public String OrignalImagePath { get; set; }
        public String IsActive { get; set; }

        public List<FilePrintImages> GetPrintData()
        {
            cmd = new SqlCommand("spFile_PrintImage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "SelectFromPrintImage");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            List<FilePrintImages> objListprint = new List<FilePrintImages>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FilePrintImages objPrintData = new FilePrintImages();
                    objPrintData.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objPrintData.ProjectTitle = dt.Rows[i]["projectTitle"].ToString();
                    objPrintData.ProjectDate = dt.Rows[i]["projectDate"].ToString();
                    objPrintData.ProjectDesc = dt.Rows[i]["ProjectDesc"].ToString();
                    objPrintData.ThumbnailImagePath = dt.Rows[i]["thumbnailUrl"].ToString();
                    objPrintData.OrignalImagePath = dt.Rows[i]["OriginalImageUrl"].ToString();
                    objListprint.Add(objPrintData);
                }
            }
            return objListprint;
        }

        public void DeletePrintImage(int id)
        {
            try
            {
                cmd = new SqlCommand("update FileAndPrintImageMaster set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class Speak
    {

        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        public int Id { get; set; }
        public string Desc1 { get; set; }
        public String Desc2 { get; set; }
        public String LogoPath { get; set; }
        public String LogoDesc { get; set; }
        public String IsActive { get; set; }

        public List<Speak> GetSpeakData()
        {
            cmd = new SqlCommand("spSpeakMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Qtype", "SelectfromSpeak");
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            List<Speak> objspeakList = new List<Speak>();

            if(dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Speak objspeak=new Speak();
                    objspeak.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    objspeak.Desc1 = dt.Rows[i]["Desc1"].ToString();
                    objspeak.Desc2 = dt.Rows[i]["Desc2"].ToString();
                    objspeak.LogoPath = dt.Rows[i]["LogoUrl"].ToString();
                    objspeak.LogoDesc = dt.Rows[i]["LogoDesc"].ToString();
                    objspeakList.Add(objspeak);
                }
            }
            return objspeakList;
        }

        public void DeleteSpeakMaster(int id)
        {
            try
            {
                cmd = new SqlCommand("update speakMaster set IsActive=0 where id=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                int result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }

}