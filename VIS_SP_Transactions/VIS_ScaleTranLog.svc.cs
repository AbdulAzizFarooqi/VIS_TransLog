using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Data.Odbc;
using DBHelper;
using System.ServiceModel.Activation;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections;

namespace VIS_SP_Transactions
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VIS_ScaleTranLog" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VIS_ScaleTranLog.svc or VIS_ScaleTranLog.svc.cs at the Solution Explorer and start debugging.
    public class VIS_ScaleTranLog : IVIS_ScaleTranLog
    {
        public void DoWork()
        {
        }


        #region WebTo Create SCale Test, Task, Receipt
        public string FinallyAddingScales(Scale Scale)
        {

            string Result = "-1";
            //   JavaScriptSerializer jscript = new JavaScriptSerializer();
            //  Scale Scale = jscript.Deserialize<Scale>(composite);
            string url = "http://sp-app2-dev:35897/VIS-DEV/";
            //using (ClientContext clientContext = new ClientContext(url))
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("QCCScales");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    oListItem["Title"] = "VIS-Inspection-Scales";
                    oListItem["ScManufacturer"] = Scale.ScManufacturer;
                    oListItem["ScSerialNo"] = Scale.ScSerialNo;
                    oListItem["ScTypeApproval"] = Scale.ScTypeApproval;
                    oListItem["ScNumberofDisplay"] = Scale.ScNumberofDisplay;
                    oListItem["ScMax"] = Scale.ScMax;
                    oListItem["ScMin"] = Scale.ScMin;
                    oListItem["ScalVe"] = Scale.ScalVe;
                    oListItem["ScalVd"] = Scale.ScalVd;
                    oListItem["ScaleClass"] = Scale.ScaleClass;
                    oListItem["QCCTagNumber"] = Scale.QCCTagNumber;
                    oListItem["BusinessCategory"] = Scale.BusinessCategory;
                    oListItem["ScaleRangeUsed"] = Scale.ScaleRangeUsed;
                    oListItem["ScaleCategory"] = Scale.ScaleCategory;
                    oListItem["ScaleMiniMum"] = Scale.ScaleMiniMum;
                    oListItem["ScModel"] = Scale.ScModel;
                    oListItem["CalculationType"] = Scale.CalculationType;
                    oListItem["CompanyId"] = Scale.CompanyId;
                    oListItem["Maximum2"] = Scale.Maximum2;
                    oListItem["eval2"] = Scale.eval2;
                    oListItem["ScalVd2"] = Scale.ScalVd2;
                    oListItem["E_Unit"] = Scale.E_Unit;
                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string CreateManuFacturer(Manufacturere Manufacturere, string url)
        {
            string Result = "";
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("ScaleManufacturers");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    oListItem["Title"] = Manufacturere.Name;
                    oListItem["CompanyCountry"] = Manufacturere.Country;
                    oListItem["AddedBy"] = Manufacturere.AddedBy;
                    oListItem["Manu_Type"] = Manufacturere.Manu_Type;
                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string CreateScaleMainTask(ScaleMainTask Task)
        {

            // JavaScriptSerializer jscript = new JavaScriptSerializer();
            // ScaleMainTask Task = jscript.Deserialize<ScaleMainTask>(composite);
            //newComp.StringValue += " NEW!";
            //          return newComp;

            string url = "http://sp-app2-dev:35897/VIS-DEV/";

            string Result = "";
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("ScaleMainTask");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    oListItem["Title"] = "VIS-Inspection-Scales";
                    oListItem["ScaleTaskId"] = "VIS-Inspection-Scales";
                    oListItem["Description"] = Task.Description;
                    oListItem["TradeLiecense"] = Task.TradeLiecense;
                    oListItem["Stage"] = Task.Stage;
                    oListItem["ReqType"] = Task.ReqType;
                    oListItem["VerificationType"] = Task.VerificationType;
                    oListItem["EntityName"] = Task.EntityName;
                    oListItem["ContactN"] = Task.ContactN;
                    oListItem["Contactp"] = Task.Contactp;
                    oListItem["Task_Location"] = Task.Task_Location;
                    oListItem["QCCTagNumber"] = Task.QCCTagNumber;
                    oListItem["AssignedTo"] = Task.AssignedTo;
                    //oListItem["CRM_SLADATE"] = "2";
                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string CreateQabannahScale(QabanahScales QabScale, string url)
        {
            string Result = "";
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("QabanahScales");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);

                    oListItem["Title"] = "";
                    oListItem["ScManufacturer"] = QabScale.ScManufacturer;
                    oListItem["ScSerialNo"] = QabScale.ScSerialNo;
                    //  oListItem["ScTypeApproval"] = QabScale.ScTypeApproval;
                    // oListItem["ScNumberofDisplay"] = QabScale.nu
                    oListItem["ScMax"] = QabScale.ScMax;
                    oListItem["ScMin"] = QabScale.ScMin;
                    oListItem["ScalVe"] = QabScale.ScalVe;
                    oListItem["ScalVd"] = QabScale.ScalVd;
                    oListItem["ScaleClass"] = QabScale.ScaleClass;
                    oListItem["QCCTagNumber"] = QabScale.QCCTagNumber;
                    oListItem["BusinessCategory"] = QabScale.BusinessCategory;
                    oListItem["ScaleRangeUsed"] = QabScale.ScaleRangeUsed;
                    oListItem["ScaleCategory"] = QabScale.ScaleCategory;
                    oListItem["ScaleMiniMum"] = QabScale.ScaleMiniMum;
                    oListItem["ScModel"] = QabScale.ScModel;
                    oListItem["CalculationType"] = QabScale.CalculationType;
                    oListItem["CompanyId"] = QabScale.CompanyId;
                    oListItem["Maximum2"] = QabScale.Maximum2;
                    oListItem["eval2"] = QabScale.eval2;
                    oListItem["ScalVd2"] = QabScale.ScalVd2;
                    oListItem["E_Unit"] = QabScale.E_Unit;
                    oListItem["InformatoinType"] = QabScale.InformatoinType;
                    oListItem["Informationtypes"] = QabScale.Informationtypes;
                    oListItem["Publics"] = QabScale.Publics;
                    oListItem["Suitable"] = QabScale.Suitable;
                    oListItem["Exposed"] = QabScale.Exposed;
                    oListItem["Shocks"] = QabScale.Shocks;
                    oListItem["SizeLengt"] = QabScale.SizeLengt;
                    oListItem["SizeWidth"] = QabScale.SizeWidth;
                    oListItem["Supporters"] = QabScale.Supporters;
                    oListItem["WeighhingType"] = QabScale.WeighhingType;
                    oListItem["WeighingTypeManufacturere"] = QabScale.WeighingTypeManufacturere;
                    oListItem["WeighingNomLoad"] = QabScale.WeighingNomLoad;
                    oListItem["ScaleInterval"] = QabScale.ScaleInterval;
                    oListItem["PrepairdBy"] = QabScale.PrepairdBy;
                    oListItem["ScaleNotes"] = QabScale.ScaleNotes;
                    oListItem["Notes"] = QabScale.Notes;

                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string SavethWholeTest(ScaleTest TestScale)
        {

            //  JavaScriptSerializer jscript = new JavaScriptSerializer();
            // ScaleTest TestScale = jscript.Deserialize<ScaleTest>(composite);
            // TestScale, string url
            string Result = "";
            try
            {
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("QCCScalesTests");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    //oListItem["Title"] = TestScale.Title;
                    // oListItem["TaskId"] = TestScale.TaskId;
                    oListItem["CompanyId"] = TestScale.CompanyId;
                    oListItem["MPEFrom1"] = TestScale.MPEFrom1;
                    oListItem["MPETo1"] = TestScale.MPETo1;
                    oListItem["MPEror1"] = TestScale.MPEror1;
                    oListItem["MPEFrom2"] = TestScale.MPEFrom2;
                    oListItem["MPETo2"] = TestScale.MPETo2;
                    oListItem["MPEror2"] = TestScale.MPEror2;
                    oListItem["MPEFrom3"] = TestScale.MPEFrom3;
                    oListItem["MPETo3"] = TestScale.MPETo3;
                    oListItem["MPEror3"] = TestScale.MPEror3;
                    oListItem["MPEFrom4"] = TestScale.MPEFrom4;
                    oListItem["MPETo4"] = TestScale.MPETo4;
                    oListItem["MPEror4"] = String.IsNullOrEmpty(TestScale.MPEror4) ? "Not Applied" : TestScale.MPEror4;
                    oListItem["MPEFrom5"] = TestScale.MPEFrom5;
                    oListItem["MPETo5"] = TestScale.MPETo5;
                    oListItem["MPEFrom6"] = TestScale.MPEFrom6;
                    oListItem["MPETo6"] = TestScale.MPETo6;
                    oListItem["MPEror6"] = String.IsNullOrEmpty(TestScale.MPEror6) ? "Not Applied" : TestScale.MPEror6;// TestScale.MPEror6;
                    oListItem["LinFwdV1"] = TestScale.LinFwdV1;
                    oListItem["LinFwdRes1"] = String.IsNullOrEmpty(TestScale.LinFwdRes1) ? "Not Applied" : TestScale.LinFwdRes1; //TestScale.LinFwdRes1;
                    oListItem["LinFwdError1"] = TestScale.LinFwdError1;
                    oListItem["LinFwdV2"] = TestScale.LinFwdV2;
                    oListItem["LinFwdRes2"] = String.IsNullOrEmpty(TestScale.LinFwdRes2) ? "Not Applied" : TestScale.LinFwdRes2; //TestScale.LinFwdRes2;
                    oListItem["LinFwdError2"] = TestScale.LinFwdError2;
                    oListItem["LinFwdV3"] = TestScale.LinFwdV3;
                    oListItem["LinFwdRes3"] = TestScale.LinFwdRes3;
                    oListItem["LinFwdError3"] = TestScale.LinFwdError3;
                    oListItem["LinFwdV4"] = TestScale.LinFwdV4;
                    oListItem["LinFwdRes4"] = TestScale.LinFwdRes4;
                    oListItem["LinFwdError4"] = TestScale.LinFwdError4;
                    oListItem["LinFwdV5"] = TestScale.LinFwdV5;
                    oListItem["LinFwdRes5"] = TestScale.LinFwdRes5;
                    oListItem["LinFwdError5"] = TestScale.LinFwdError5;
                    oListItem["LinFwdV6"] = TestScale.LinFwdV6;
                    oListItem["LinFwdRes6"] = TestScale.LinFwdRes6;
                    oListItem["LinFwdError6"] = TestScale.LinFwdError6;
                    oListItem["LinFwdV7"] = TestScale.LinFwdV7;
                    oListItem["LinFwdRes7"] = String.IsNullOrEmpty(TestScale.LinFwdRes7) ? "Not Applied" : TestScale.LinFwdRes7; //TestScale.LinFwdRes7;
                    oListItem["LinFwdError7"] = TestScale.LinFwdError7;
                    oListItem["RptReading1"] = TestScale.RptReading1;
                    oListItem["RptError1"] = TestScale.RptError1;
                    oListItem["RptReading2"] = TestScale.RptReading2;
                    oListItem["RptError2"] = TestScale.RptError2;
                    oListItem["RptReading3"] = TestScale.RptReading3;
                    oListItem["RptError3"] = TestScale.RptError3;
                    oListItem["RptReading4"] = TestScale.RptReading4;
                    oListItem["RptError4"] = TestScale.RptError4;
                    oListItem["RptReading5"] = TestScale.RptReading5;
                    oListItem["RptError5"] = TestScale.RptError5;
                    oListItem["RptReading6"] = TestScale.RptReading6;
                    oListItem["RptError6"] = TestScale.RptError6;
                    oListItem["EccPos1"] = TestScale.EccPos1;
                    oListItem["EccRead1"] = TestScale.EccRead1;
                    oListItem["EccErr1"] = TestScale.EccErr1;
                    oListItem["EccPos2"] = TestScale.EccPos2;
                    oListItem["EccRead2"] = TestScale.EccRead2;
                    oListItem["EccErr2"] = TestScale.EccErr2;
                    oListItem["EccPos3"] = TestScale.EccPos3;
                    oListItem["EccRead3"] = TestScale.EccRead3;
                    oListItem["EccErr3"] = TestScale.EccErr3;
                    oListItem["EccPos4"] = TestScale.EccPos4;
                    oListItem["EccRead4"] = TestScale.EccRead4;
                    oListItem["EccErr4"] = TestScale.EccErr4;
                    oListItem["EccPos5"] = TestScale.EccPos5;
                    oListItem["EccRead5"] = TestScale.EccRead5;
                    oListItem["EccErr5"] = TestScale.EccErr5;
                    oListItem["EccPos6"] = String.IsNullOrEmpty(TestScale.EccPos6) ? "Not Applied" : TestScale.EccPos6; //TestScale.EccPos6;
                    oListItem["EccRead6"] = TestScale.EccRead6;
                    oListItem["EccErr6"] = TestScale.EccErr6;
                    oListItem["MarkNumber"] = TestScale.MarkNumber;
                    oListItem["Remarks"] = TestScale.Remarks;
                    oListItem["VerificationConductedBy"] = TestScale.VerificationConductedBy;
                    oListItem["VerficatoinReport"] = TestScale.VerficatoinReport;
                    oListItem["ScaleCalss"] = TestScale.ScaleCalss;
                    oListItem["TestRevisitDate"] = TestScale.TestRevisitDate;
                    oListItem["TestStage"] = String.IsNullOrEmpty(TestScale.TestStage) ? "3" : TestScale.TestStage; // TestScale.TestStage;
                    oListItem["TestStageDesc"] = TestScale.TestStageDesc;
                    oListItem["TestFine"] = TestScale.TestFine;
                    oListItem["CalculationType"] = TestScale.CalculationType;
                    oListItem["QCCTagNumber"] = TestScale.QCCTagNumber;
                    oListItem["ScaleCategory"] = TestScale.ScaleCategory;
                    oListItem["ScaleManufacturer"] = TestScale.ScaleManufacturer;
                    oListItem["ScaleMaximumVal"] = TestScale.ScaleMaximumVal;
                    oListItem["ScaleMiniMum"] = TestScale.ScaleMiniMum;
                    oListItem["DValueNoted"] = TestScale.DValueNoted;
                    oListItem["EvalueNoted"] = TestScale.EvalueNoted;
                    oListItem["ScaleRangeUsed"] = TestScale.ScaleRangeUsed;
                    oListItem["ScaleTestReceiptId"] = TestScale.ScaleTestReceiptId;
                    //oListItem["PaymentReportStatus"] = TestScale.PaymentReportStatus;
                    //oListItem["PaymentUpdateBy"] = TestScale.PaymentUpdateBy;
                    //oListItem["ArModuleSync"] = TestScale.ArModuleSync;
                    oListItem["TradingLiecense"] = TestScale.TradingLiecense;
                    oListItem["ScaleId"] = TestScale.ScaleId;
                    oListItem["EccentricityIsApplicable"] = TestScale.EccentricityIsApplicable;
                    oListItem["EccentricityReason"] = String.IsNullOrEmpty(TestScale.EccentricityReason) ? "Not Applicable" : TestScale.EccentricityReason;
                    oListItem["MaxiMum2"] = String.IsNullOrEmpty(TestScale.MaxiMum2) ? "Not Applied" : TestScale.MaxiMum2;// TestScale.MaxiMum2;
                    oListItem["EvalueNoted2"] = String.IsNullOrEmpty(TestScale.EvalueNoted2) ? "Not Applied" : TestScale.EvalueNoted2; //TestScale.EvalueNoted2;
                    oListItem["IsNewCustomer"] = String.IsNullOrEmpty(TestScale.IsNewCustomer) ? "Not Applied" : TestScale.IsNewCustomer; // TestScale.IsNewCustomer;
                    oListItem["TestType"] = TestScale.TestType;
                    oListItem["SecureMark"] = TestScale.SecureMark;
                    oListItem["VerifiedMarck"] = TestScale.VerifiedMarck;
                    oListItem["VerfiedMarckFail"] = TestScale.VerfiedMarckFail;
                    oListItem["VisualClean"] = String.IsNullOrEmpty(TestScale.VisualClean) ? "Not Applied" : TestScale.VisualClean;// TestScale.VisualClean;
                    oListItem["VisualWorkingFine"] = String.IsNullOrEmpty(TestScale.VisualWorkingFine) ? " Applied" : TestScale.VisualWorkingFine;//TestScale.VisualWorkingFine;
                    oListItem["VisualUnBroken"] = String.IsNullOrEmpty(TestScale.VisualUnBroken) ? " Applied" : TestScale.VisualUnBroken;//TestScale.VisualUnBroken;
                    oListItem["VisaulCorretSurfceLvl"] = String.IsNullOrEmpty(TestScale.VisaulCorretSurfceLvl) ? " Applied" : TestScale.VisaulCorretSurfceLvl;// TestScale.VisaulCorretSurfceLvl;
                    oListItem["SimpleTest"] = TestScale.SimpleTest;
                    oListItem["FinalTestResults"] = TestScale.FinalTestResults;
                    oListItem["VerificationCharges"] = TestScale.VerificationCharges;
                    oListItem["OldQccTagNumber"] = TestScale.OldQccTagNumber;
                    oListItem["MPEror5"] = String.IsNullOrEmpty(TestScale.MPEror5) ? " Not Applied" : TestScale.MPEror5;// TestScale.MPEror5;
                    oListItem["DValueNoted2"] = String.IsNullOrEmpty(TestScale.DValueNoted2) ? "Not Applied" : TestScale.DValueNoted2;// TestScale.DValueNoted2;
                    //oListItem["BankTransactionID"] = TestScale.BankTransactionID;
                    // oListItem["InvoiceSystem"] = TestScale.InvoiceSystem;
                    //oListItem["InvSysInvoiceNumber"] = TestScale.InvSysInvoiceNumber;
                    // oListItem["InvSysReceipNumber"] = TestScale.InvSysReceipNumber;
                    // oListItem["InvSysReceiptAmount"] = TestScale.InvSysReceiptAmount;
                    // oListItem["BankTransactionDate"] =String.IsNullOrEmpty(TestScale.BankTransactionDate) ? "Not Applied" : TestScale.BankTransactionDate; TestScale.BankTransactionDate;
                    oListItem["TestDate"] = TestScale.TestDate;
                    // oListItem["TestApprovedBy"] = TestScale.TestApprovedBy;
                    //oListItem["TestApprovalDate"] = TestScale.TestApprovalDate;
                    // oListItem["MohthlyGroupColumn"] = TestScale.MohthlyGroupColumn;
                    oListItem["BusinessCategory"] = TestScale.BusinessCategory;
                    oListItem["ReVisited"] = TestScale.ReVisited;

                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string SavetheWholeTestQabannah(Qabannah Qabannah, string url)
        {
            string Result = "";
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("Qabannah");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    // oListItem["Title "] = Qabannah.Title;
                    oListItem["TaskId"] = Qabannah.TaskId;
                    oListItem["CompanyId"] = Qabannah.CompanyId;
                    oListItem["MPEFrom1"] = Qabannah.MPEFrom1;
                    oListItem["MPETo1"] = Qabannah.MPETo1;
                    oListItem["MPEror1"] = Qabannah.MPEror1;
                    oListItem["MPEFrom2"] = Qabannah.MPEFrom2;
                    oListItem["MPETo2"] = Qabannah.MPETo2;
                    oListItem["MPEror2"] = Qabannah.MPEror2;
                    oListItem["MPEFrom3"] = Qabannah.MPEFrom3;
                    oListItem["MPETo3"] = Qabannah.MPETo3;
                    oListItem["MPEror3"] = Qabannah.MPEror3;
                    oListItem["MPEFrom4"] = Qabannah.MPEFrom4;
                    oListItem["MPETo4"] = Qabannah.MPETo4;
                    oListItem["MPEror4"] = Qabannah.MPEror4;
                    oListItem["MPEFrom5"] = Qabannah.MPEFrom5;
                    oListItem["MPETo5"] = Qabannah.MPETo5;
                    oListItem["MPEFrom6"] = Qabannah.MPEFrom6;
                    oListItem["MPETo6"] = Qabannah.MPETo6;
                    oListItem["MPEror6"] = Qabannah.MPEror6;
                    oListItem["LinFwdV1"] = Qabannah.LinFwdV1;
                    oListItem["LinFwdRes1"] = Qabannah.LinFwdRes1;
                    oListItem["LinFwdError1"] = Qabannah.LinFwdError1;
                    oListItem["LinFwdV2"] = Qabannah.LinFwdV2;
                    oListItem["LinFwdRes2"] = Qabannah.LinFwdRes2;
                    oListItem["LinFwdError2"] = Qabannah.LinFwdError2;
                    oListItem["LinFwdV3"] = Qabannah.LinFwdV3;
                    oListItem["LinFwdRes3"] = Qabannah.LinFwdRes3;
                    oListItem["LinFwdError3"] = Qabannah.LinFwdError3;
                    oListItem["LinFwdV4"] = Qabannah.LinFwdV4;
                    oListItem["LinFwdRes4"] = Qabannah.LinFwdRes4;
                    oListItem["LinFwdError4"] = Qabannah.LinFwdError4;
                    oListItem["LinFwdV5"] = Qabannah.LinFwdV5;
                    oListItem["LinFwdRes5"] = Qabannah.LinFwdRes5;
                    oListItem["LinFwdError5"] = Qabannah.LinFwdError5;
                    oListItem["LinFwdV6"] = Qabannah.LinFwdV6;
                    oListItem["LinFwdRes6"] = Qabannah.LinFwdRes6;
                    oListItem["LinFwdError6"] = Qabannah.LinFwdError6;
                    oListItem["LinFwdV7"] = Qabannah.LinFwdV7;
                    oListItem["LinFwdRes7"] = Qabannah.LinFwdRes7;
                    oListItem["LinFwdError7"] = Qabannah.LinFwdError7;
                    oListItem["RptReading1"] = Qabannah.RptReading1;
                    oListItem["RptError1"] = Qabannah.RptError1;
                    oListItem["RptReading2"] = Qabannah.RptReading2;
                    oListItem["RptError2"] = Qabannah.RptError2;
                    oListItem["RptReading3"] = Qabannah.RptReading3;
                    oListItem["RptError3"] = Qabannah.RptError3;
                    oListItem["RptReading4"] = Qabannah.RptReading4;
                    oListItem["RptError4"] = Qabannah.RptError4;
                    oListItem["RptReading5"] = Qabannah.RptReading5;
                    oListItem["RptError5"] = Qabannah.RptError5;
                    oListItem["RptReading6"] = Qabannah.RptReading6;
                    oListItem["RptError6"] = Qabannah.RptError6;
                    oListItem["EccPos1"] = Qabannah.EccPos1;
                    oListItem["EccRead1"] = Qabannah.EccRead1;
                    oListItem["EccErr1"] = Qabannah.EccErr1;
                    oListItem["EccPos2"] = Qabannah.EccPos2;
                    oListItem["EccRead2"] = Qabannah.EccRead2;
                    oListItem["EccErr2"] = Qabannah.EccErr2;
                    oListItem["EccPos3"] = Qabannah.EccPos3;
                    oListItem["EccRead3"] = Qabannah.EccRead3;
                    oListItem["EccErr3"] = Qabannah.EccErr3;
                    oListItem["EccPos4"] = Qabannah.EccPos4;
                    oListItem["EccRead4"] = Qabannah.EccRead4;
                    oListItem["EccErr4"] = Qabannah.EccErr4;
                    oListItem["EccPos5"] = Qabannah.EccPos5;
                    oListItem["EccRead5"] = Qabannah.EccRead5;
                    oListItem["EccErr5"] = Qabannah.EccErr5;
                    oListItem["EccPos6"] = Qabannah.EccPos6;
                    oListItem["EccRead6"] = Qabannah.EccRead6;
                    oListItem["EccErr6"] = Qabannah.EccErr6;
                    oListItem["MarkNumber"] = Qabannah.MarkNumber;
                    oListItem["Remarks"] = Qabannah.Remarks;
                    oListItem["VerificationConductedBy"] = Qabannah.VerificationConductedBy;
                    oListItem["VerficatoinReport"] = Qabannah.VerficatoinReport;
                    oListItem["ScaleCalss"] = Qabannah.ScaleCalss;
                    oListItem["TestRevisitDate"] = Qabannah.TestRevisitDate;
                    oListItem["TestStage"] = Qabannah.TestStage;
                    oListItem["TestStageDesc"] = Qabannah.TestStageDesc;
                    oListItem["TestFine"] = Qabannah.TestFine;
                    oListItem["CalculationType"] = Qabannah.CalculationType;
                    oListItem["QCCTagNumber"] = Qabannah.QCCTagNumber;
                    oListItem["ScaleCategory"] = Qabannah.ScaleCategory;
                    oListItem["ScaleManufacturer"] = Qabannah.ScaleManufacturer;
                    oListItem["ScaleMaximumVal"] = Qabannah.ScaleMaximumVal;
                    oListItem["ScaleMiniMum"] = Qabannah.ScaleMiniMum;
                    oListItem["DValueNoted"] = Qabannah.DValueNoted;
                    oListItem["EvalueNoted"] = Qabannah.EvalueNoted;
                    oListItem["ScaleRangeUsed"] = Qabannah.ScaleRangeUsed;
                    oListItem["ScaleTestReceiptId"] = Qabannah.ScaleTestReceiptId;
                    oListItem["PaymentReportStatus"] = Qabannah.PaymentReportStatus;
                    oListItem["PaymentUpdateBy"] = Qabannah.PaymentUpdateBy;
                    oListItem["ArModuleSync"] = Qabannah.ArModuleSync;
                    oListItem["TradingLiecense"] = Qabannah.TradingLiecense;
                    oListItem["ScaleId"] = Qabannah.ScaleId;
                    oListItem["EccentricityIsApplicable"] = Qabannah.EccentricityIsApplicable;
                    oListItem["EccentricityReason"] = Qabannah.EccentricityReason;
                    oListItem["MaxiMum2"] = Qabannah.MaxiMum2;
                    oListItem["EvalueNoted2"] = Qabannah.EvalueNoted2;
                    oListItem["IsNewCustomer"] = Qabannah.IsNewCustomer;
                    oListItem["TestType"] = Qabannah.TestType;
                    oListItem["SecureMark"] = Qabannah.SecureMark;
                    oListItem["VerifiedMarck"] = Qabannah.VerifiedMarck;
                    oListItem["VerfiedMarckFail"] = Qabannah.VerfiedMarckFail;
                    oListItem["VisualClean"] = Qabannah.VisualClean;
                    oListItem["VisualWorkingFine"] = Qabannah.VisualWorkingFine;
                    oListItem["VisualUnBroken"] = Qabannah.VisualUnBroken;
                    oListItem["VisaulCorretSurfceLvl"] = Qabannah.VisaulCorretSurfceLvl;
                    oListItem["SimpleTest"] = Qabannah.SimpleTest;
                    oListItem["FinalTestResults"] = Qabannah.FinalTestResults;
                    oListItem["VerificationCharges"] = Qabannah.VerificationCharges;
                    oListItem["OldQccTagNumber"] = Qabannah.OldQccTagNumber;
                    oListItem["MPEror5"] = Qabannah.MPEror5;
                    oListItem["DValueNoted2"] = Qabannah.DValueNoted2;
                    oListItem["BankTransactionID"] = Qabannah.BankTransactionID;
                    oListItem["InvoiceSystem"] = Qabannah.InvoiceSystem;
                    oListItem["InvSysInvoiceNumber"] = Qabannah.InvSysInvoiceNumber;
                    oListItem["InvSysReceipNumber"] = Qabannah.InvSysReceipNumber;
                    oListItem["InvSysReceiptAmount"] = Qabannah.InvSysReceiptAmount;
                    oListItem["BankTransactionDate"] = Qabannah.BankTransactionDate;
                    oListItem["TestDate"] = Qabannah.TestDate;
                    oListItem["TestApprovedBy"] = Qabannah.TestApprovedBy;
                    oListItem["TestApprovalDate"] = Qabannah.TestApprovalDate;
                    oListItem["MohthlyGroupColumn"] = Qabannah.MohthlyGroupColumn;
                    oListItem["BusinessCategory"] = Qabannah.BusinessCategory;
                    oListItem["ReVisited"] = Qabannah.ReVisited;

                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string CreateQabannahDetail(QabannahDetails QabannahDetail, string url)
        {
            string Result = "";
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("QabannahDetails");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    oListItem["Title"] = "VIS-Inspection-Scales";

                    // oListItem["Title"] = QabannahDetail.Title;
                    oListItem["TestID"] = QabannahDetail.TestID;
                    oListItem["InspectionType"] = QabannahDetail.InspectionType;
                    oListItem["MaxiMumLoad"] = QabannahDetail.MaxiMumLoad;
                    oListItem["LinLoad_1"] = QabannahDetail.LinLoad_1;
                    oListItem["LinLoad_2"] = QabannahDetail.LinLoad_2;
                    oListItem["LinLoad_3"] = QabannahDetail.LinLoad_3;
                    oListItem["LinLoad_4"] = QabannahDetail.LinLoad_4;
                    oListItem["LinLoad_5"] = QabannahDetail.LinLoad_5;
                    oListItem["LinLoad_6"] = QabannahDetail.LinLoad_6;
                    oListItem["LinLoad_7"] = QabannahDetail.LinLoad_7;
                    oListItem["LinLoad_8"] = QabannahDetail.LinLoad_8;
                    oListItem["LinLoad_9"] = QabannahDetail.LinLoad_9;
                    oListItem["LinLoad_10"] = QabannahDetail.LinLoad_10;
                    oListItem["LinLoad_11"] = QabannahDetail.LinLoad_11;
                    oListItem["LinLoad_12"] = QabannahDetail.LinLoad_12;
                    oListItem["LinLoad_13"] = QabannahDetail.LinLoad_13;
                    oListItem["LinLoad_14"] = QabannahDetail.LinLoad_14;
                    oListItem["LinLoad_15"] = QabannahDetail.LinLoad_15;
                    oListItem["LinError1_BeforeCal_1"] = QabannahDetail.LinError1_BeforeCal_1;
                    oListItem["LinError1_BeforeCal_2"] = QabannahDetail.LinError1_BeforeCal_2;
                    oListItem["LinError1_BeforeCal_3"] = QabannahDetail.LinError1_BeforeCal_3;
                    oListItem["LinError1_BeforeCal_4"] = QabannahDetail.LinError1_BeforeCal_4;
                    oListItem["LinError1_BeforeCal_5"] = QabannahDetail.LinError1_BeforeCal_5;
                    oListItem["LinError1_BeforeCal_6"] = QabannahDetail.LinError1_BeforeCal_6;
                    oListItem["LinError1_BeforeCal_7"] = QabannahDetail.LinError1_BeforeCal_7;
                    oListItem["LinError1_BeforeCal_8"] = QabannahDetail.LinError1_BeforeCal_8;
                    oListItem["LinError1_BeforeCal_9"] = QabannahDetail.LinError1_BeforeCal_9;
                    oListItem["LinError1_BeforeCal_10"] = QabannahDetail.LinError1_BeforeCal_10;
                    oListItem["LinError1_BeforeCal_11"] = QabannahDetail.LinError1_BeforeCal_11;
                    oListItem["LinError1_BeforeCal_12"] = QabannahDetail.LinError1_BeforeCal_12;
                    oListItem["LinError1_BeforeCal_13"] = QabannahDetail.LinError1_BeforeCal_13;
                    oListItem["LinError1_BeforeCal_15"] = QabannahDetail.LinError1_BeforeCal_15;
                    oListItem["LinError2_AfterVer_1"] = QabannahDetail.LinError2_AfterVer_1;
                    oListItem["LinError2_AfterVer_2"] = QabannahDetail.LinError2_AfterVer_2;
                    oListItem["LinError2_AfterVer_3"] = QabannahDetail.LinError2_AfterVer_3;
                    oListItem["LinError2_AfterVer_4"] = QabannahDetail.LinError2_AfterVer_4;
                    oListItem["LinError2_AfterVer_5"] = QabannahDetail.LinError2_AfterVer_5;
                    oListItem["LinError2_AfterVer_6"] = QabannahDetail.LinError2_AfterVer_6;
                    oListItem["LinError2_AfterVer_7"] = QabannahDetail.LinError2_AfterVer_7;
                    oListItem["LinError2_AfterVer_8"] = QabannahDetail.LinError2_AfterVer_8;
                    oListItem["LinError2_AfterVer_9"] = QabannahDetail.LinError2_AfterVer_9;
                    oListItem["LinError2_AfterVer_10"] = QabannahDetail.LinError2_AfterVer_10;
                    oListItem["LinError2_AfterVer_11"] = QabannahDetail.LinError2_AfterVer_11;
                    oListItem["LinError2_AfterVer_12"] = QabannahDetail.LinError2_AfterVer_12;
                    oListItem["LinError2_AfterVer_13"] = QabannahDetail.LinError2_AfterVer_13;
                    oListItem["LinError2_AfterVer_14"] = QabannahDetail.LinError2_AfterVer_14;
                    oListItem["LinError2_AfterVer_15"] = QabannahDetail.LinError2_AfterVer_15;
                    oListItem["LinError3_AfterVer_1"] = QabannahDetail.LinError3_AfterVer_1;
                    oListItem["LinError3_AfterVer_2"] = QabannahDetail.LinError3_AfterVer_2;
                    oListItem["LinError3_AfterVer_3"] = QabannahDetail.LinError3_AfterVer_3;
                    oListItem["LinError3_AfterVer_4"] = QabannahDetail.LinError3_AfterVer_4;
                    oListItem["LinError3_AfterVer_5"] = QabannahDetail.LinError3_AfterVer_5;
                    oListItem["LinError3_AfterVer_6"] = QabannahDetail.LinError3_AfterVer_6;
                    oListItem["LinError3_AfterVer_7"] = QabannahDetail.LinError3_AfterVer_7;
                    oListItem["LinError3_AfterVer_8"] = QabannahDetail.LinError3_AfterVer_8;
                    oListItem["LinError3_AfterVer_9"] = QabannahDetail.LinError3_AfterVer_9;
                    oListItem["LinError3_AfterVer_10"] = QabannahDetail.LinError3_AfterVer_10;
                    oListItem["LinError3_AfterVer_11"] = QabannahDetail.LinError3_AfterVer_11;
                    oListItem["LinError3_AfterVer_12"] = QabannahDetail.LinError3_AfterVer_12;
                    oListItem["LinError3_AfterVer_13"] = QabannahDetail.LinError3_AfterVer_13;
                    oListItem["LinError3_AfterVer_14"] = QabannahDetail.LinError3_AfterVer_14;
                    oListItem["LinError3_AfterVer_15"] = QabannahDetail.LinError3_AfterVer_15;
                    oListItem["Dis_LoadApplied_Min"] = QabannahDetail.Dis_LoadApplied_Min;
                    oListItem["Dis_LoadApplied_Half"] = QabannahDetail.Dis_LoadApplied_Half;
                    oListItem["Dis_LoadApplied_Max"] = QabannahDetail.Dis_LoadApplied_Max;
                    oListItem["Dis_MPE_Min"] = QabannahDetail.Dis_MPE_Min;
                    oListItem["Dis_MPE_Half"] = QabannahDetail.Dis_MPE_Half;
                    oListItem["Dis_MPE_Max"] = QabannahDetail.Dis_MPE_Max;
                    oListItem["Rpt_Max_Load"] = QabannahDetail.Rpt_Max_Load;
                    oListItem["Rpt_Load_1"] = QabannahDetail.Rpt_Load_1;
                    oListItem["Rpt_Load_2"] = QabannahDetail.Rpt_Load_2;
                    oListItem["Rpt_Load_3"] = QabannahDetail.Rpt_Load_3;
                    oListItem["RPT_Error"] = QabannahDetail.RPT_Error;
                    oListItem["MarkNumber"] = QabannahDetail.MarkNumber;
                    oListItem["Eccent_Load_Max"] = QabannahDetail.Eccent_Load_Max;
                    oListItem["Eccent_Load_1"] = QabannahDetail.Eccent_Load_1;
                    oListItem["Eccent_Load_2"] = QabannahDetail.Eccent_Load_2;
                    oListItem["Eccent_Load_3"] = QabannahDetail.Eccent_Load_3;
                    oListItem["Eccent_Load_4"] = QabannahDetail.Eccent_Load_4;
                    oListItem["Eccent_Load_5"] = QabannahDetail.Eccent_Load_5;
                    oListItem["Eccent_Load_6"] = QabannahDetail.Eccent_Load_6;
                    oListItem["Eccent_Load_7"] = QabannahDetail.Eccent_Load_7;
                    oListItem["Eccent_Load_8"] = QabannahDetail.Eccent_Load_8;
                    oListItem["Eccent_Load_9"] = QabannahDetail.Eccent_Load_9;
                    oListItem["Eccent_Load_10"] = QabannahDetail.Eccent_Load_10;
                    oListItem["Eccent_Error_1"] = QabannahDetail.Eccent_Error_1;
                    oListItem["Eccent_Error_2"] = QabannahDetail.Eccent_Error_2;
                    oListItem["Eccent_Error_3"] = QabannahDetail.Eccent_Error_3;
                    oListItem["Eccent_Error_4"] = QabannahDetail.Eccent_Error_4;
                    oListItem["Eccent_Error_5"] = QabannahDetail.Eccent_Error_5;
                    oListItem["Eccent_Error_6"] = QabannahDetail.Eccent_Error_6;
                    oListItem["Eccent_Error_7"] = QabannahDetail.Eccent_Error_7;
                    oListItem["Eccent_Error_8"] = QabannahDetail.Eccent_Error_8;
                    oListItem["Eccent_Error_9"] = QabannahDetail.Eccent_Error_9;
                    oListItem["Eccent_Error_10"] = QabannahDetail.Eccent_Error_10;
                    oListItem["LinLoad_1"] = QabannahDetail.LinLoad_1;
                    oListItem["LinLoad_2"] = QabannahDetail.LinLoad_2;
                    oListItem["LinLoad_3"] = QabannahDetail.LinLoad_3;
                    oListItem["LinLoad_4"] = QabannahDetail.LinLoad_4;
                    oListItem["LinLoad_5"] = QabannahDetail.LinLoad_5;
                    oListItem["LinLoad_6"] = QabannahDetail.LinLoad_6;
                    oListItem["LinLoad_7"] = QabannahDetail.LinLoad_7;
                    oListItem["LinLoad_8"] = QabannahDetail.LinLoad_8;
                    oListItem["LinLoad_9"] = QabannahDetail.LinLoad_9;
                    oListItem["LinLoad_10"] = QabannahDetail.LinLoad_10;
                    oListItem["LinError1_BeforeCal_14"] = QabannahDetail.LinError1_BeforeCal_14;


                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }
        public string CreateFinalReceipet(QCCScalesReceipts Receipt)
        {

            //use the JavaScriptSerializer to convert the string to a CompositeType instance
            // JavaScriptSerializer jscript = new JavaScriptSerializer();
            //QCCScalesReceipts Receipt = jscript.Deserialize<QCCScalesReceipts>(composite);
            //newComp.StringValue += " NEW!";
            //          return newComp;

            string url = "http://sp-app2-dev:35897/VIS-DEV/";

            string Result = "";
            try
            {
                using (ClientContext clientContext = new ClientContext(url))
                {
                    NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                    clientContext.Credentials = credentials;
                    List oList = clientContext.Web.Lists.GetByTitle("QCCScalesReceipts");
                    ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                    ListItem oListItem = oList.AddItem(itemCreateInfo);
                    oListItem["Title"] = Receipt.Title;
                    oListItem["Company_Name"] = Receipt.Company_Name;
                    oListItem["CompanyId"] = Receipt.CompanyId;
                    oListItem["FinalTestResults"] = Receipt.FinalTestResults;
                    oListItem["VerificationDate"] = Receipt.VerificationDate;
                    oListItem["WeightSetClass"] = Receipt.WeightSetClass;
                    oListItem["TradingLiecense"] = Receipt.TradingLiecense;
                    oListItem["TaskId"] = Receipt.TaskId;
                    oListItem["MarkNumber"] = Receipt.MarkNumber;
                    oListItem["QCCTestId"] = Receipt.QCCTestId;
                    oListItem["VerificationCharges"] = Receipt.VerificationCharges;


                    oListItem.Update();
                    clientContext.ExecuteQuery();
                    Result = Convert.ToString(oListItem.Id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Result;
        }

        public string CommitTransactoins(string ScaleObject, string TaskObject, string ScaleTestObject, string ReceiptObjct, string ManufacturerObject, string TestCheck, string ListName, string ReceiptFlag,
            string Qabannahobj, string QabannahDetailsobj, string QabannahSCaleobj, string ISNewManufacturere)
        {
            string TestGenerateID = "";
            string ReceiptGeneratedID = "";
            string Transactions = string.Empty;
            string[] Temp = TestCheck.Split(',');
            string VerficationType = Temp[0];
            string IsReVerificaiton = Temp[1];
            string TaskIDtoUpdate = Temp[2];
            string TestIDtoUpdate = Temp[3];
            string TaskIdGenerated = "";
            string url = "http://sp-app2-dev:35897/VIS-DEV/";

            string VerificationConductedBy = "";
            string CompanyId = "";
            string QCCTagNumber = "";
            string TradingLiecense = "";
            string TestType = "";

            string FinalTestResults = "";
            string ScaleManufacturer = "";
            string MarkNumber = "";
            string VerificationCharges = "";
            string TestDate = "";
            string ScaleClass = "";



            string VerificationTestID = string.Empty;
            JavaScriptSerializer jscript = new JavaScriptSerializer();
            string TestScaleIGenerated = "";





            try
            {



                ScaleTest ScaleTest = null;
                Qabannah Qabannah = null;
                jscript = new JavaScriptSerializer();
                if (ScaleTestObject.Length > 10)
                {
                    ScaleTest = jscript.Deserialize<ScaleTest>(ScaleTestObject);
                    VerificationConductedBy = ScaleTest.VerificationConductedBy;
                    CompanyId = ScaleTest.CompanyId;
                    QCCTagNumber = ScaleTest.QCCTagNumber;
                    TradingLiecense = ScaleTest.TradingLiecense;
                    TestType = ScaleTest.TestType;
                    VerificationCharges = ScaleTest.VerificationCharges;
                    TestDate = ScaleTest.TestDate;
                    ScaleClass = ScaleTest.ScaleCalss;
                    FinalTestResults = ScaleTest.FinalTestResults;
                    // if (FinalTestResult=="Pass" || FinalTestResult=="PASS")
                    // {
                    //  MarkNumber = ScaleTest.VerifiedMarck;
                    // }
                    // else
                    MarkNumber = ScaleTest.MarkNumber;
                }


                jscript = new JavaScriptSerializer();
                if (Qabannahobj.Length > 10)
                {
                    Qabannah = jscript.Deserialize<Qabannah>(Qabannahobj);
                    VerificationConductedBy = Qabannah.VerificationConductedBy;
                    CompanyId = Qabannah.CompanyId;
                    QCCTagNumber = Qabannah.QCCTagNumber;
                    TradingLiecense = Qabannah.TradingLiecense;
                    TestType = Qabannah.TestType;
                    VerificationCharges = Qabannah.VerificationCharges;
                    TestDate = Qabannah.TestDate;
                    ScaleClass = Qabannah.ScaleCalss;
                    MarkNumber = Qabannah.MarkNumber;
                    FinalTestResults = Qabannah.FinalTestResults;
                }




                if (ScaleObject.Length > 10)
                {
                    jscript = new JavaScriptSerializer();
                    Scale Scale = jscript.Deserialize<Scale>(ScaleObject);
                    if (IsReVerificaiton != "YES")
                    {
                        TestScaleIGenerated = FinallyAddingScales(Scale);
                    }
                    else
                    {
                        TestScaleIGenerated = Scale.ScaleOldId;
                    }
                }

                jscript = new JavaScriptSerializer();
                ScaleMainTask ScaleMainTask = jscript.Deserialize<ScaleMainTask>(TaskObject);

                jscript = new JavaScriptSerializer();
                if (ScaleTestObject.Length > 10)
                {
                    //ScaleTest ScaleTest = jscript.Deserialize<ScaleTest>(ScaleTestObject);
                    if (VerficationType == "YES")
                    {
                        // ScaleTest.TestType = "Re-Verification";


                    }
                    if (IsReVerificaiton == "YES")
                    {
                        // ScaleTest.TestType = "Re-Verification";

                    }
                    ScaleTest.TaskId = TaskIdGenerated;
                    ScaleTest.ScaleId = TestScaleIGenerated;
                    ScaleTest.ReVisited = "NO";
                    VerificationTestID = SavethWholeTest(ScaleTest);
                }

                jscript = new JavaScriptSerializer();
                Manufacturere Manufacturere = jscript.Deserialize<Manufacturere>(ManufacturerObject);


                if (QabannahSCaleobj.Length > 10)
                {
                    jscript = new JavaScriptSerializer();
                    QabanahScales QabanahScales = jscript.Deserialize<QabanahScales>(QabannahSCaleobj);
                    if (IsReVerificaiton != "YES")
                    {
                        TestScaleIGenerated = CreateQabannahScale(QabanahScales, url);
                    }
                    else
                    {
                        TestScaleIGenerated = QabanahScales.OldScaleId;
                    }


                }

                if (TaskIDtoUpdate == "NO" || TaskIDtoUpdate == "undefined")
                {
                    ScaleMainTask ms = new ScaleMainTask();
                    ms.AssignedTo = VerificationConductedBy;
                    ms.ContactN = "d";
                    ms.Contactp = "s";
                    ms.Description = "d";
                    ms.EntityName = CompanyId;
                    ms.QCCTagNumber = QCCTagNumber;
                    ms.Task_Location = "s";
                    ms.TradeLiecense = TradingLiecense;
                    ms.VerificationType = TestType;
                    TaskIdGenerated = CreateScaleMainTask(ms);
                }
                else
                {
                    //WE NEED TO UPDATE
                    TaskIdGenerated = TestScaleIGenerated;
                    UpdateScaleMainTask(TestScaleIGenerated);

                }



                if (Qabannahobj.Length > 10)
                {
                    //jscript = new JavaScriptSerializer();
                    // Qabannah = jscript.Deserialize<Qabannah>(Qabannahobj);
                    if (VerficationType == "YES")
                    {
                        //Qabannah.TestType = "Re-Verification";


                    }
                    if (IsReVerificaiton == "YES")
                    {
                        // Qabannah.TestType = "Re-Verification";

                    }
                    Qabannah.TaskId = TaskIdGenerated;
                    Qabannah.ScaleId = TestScaleIGenerated;
                    Qabannah.ReVisited = "NO";
                    VerificationTestID = SavetheWholeTestQabannah(Qabannah, url);


                }

                if (QabannahDetailsobj.Length > 10)
                {
                    jscript = new JavaScriptSerializer();
                    QabannahDetails QabannahDetails = jscript.Deserialize<QabannahDetails>(QabannahDetailsobj);
                    QabannahDetails.TestID = VerificationTestID;
                    string _qban = CreateQabannahDetail(QabannahDetails, url);
                }




                if (VerificationTestID != "")
                {

                    if (TaskIDtoUpdate == "NO" || TaskIDtoUpdate == "undefined")
                    {
                        ScaleMainTask ms = new ScaleMainTask();
                        ms.AssignedTo = VerificationConductedBy;
                        ms.ContactN = "d";
                        ms.Contactp = "s";
                        ms.Description = "d";
                        ms.EntityName = CompanyId;
                        ms.QCCTagNumber = QCCTagNumber;
                        ms.Task_Location = "s";
                        ms.TradeLiecense = TradingLiecense;
                        ms.VerificationType = TestType;
                        // TaskIdGenerated = CreateScaleMainTask(ms);
                    }
                    else
                    {
                        //WE NEED TO UPDATE
                        TaskIdGenerated = TestScaleIGenerated;
                        UpdateScaleMainTask(TestScaleIGenerated);

                    }



                    if (ISNewManufacturere == "YES")
                    {
                        Manufacturere.AddedBy = VerificationConductedBy;
                        // Manufacturere.Name = ScaleManufacturer;
                        url = "http://sp-app2-dev:35897/VIS-DEV/";
                        CreateManuFacturer(Manufacturere, url);
                    }

                    if (VerificationTestID != "")
                    {

                        if (IsReVerificaiton == "YES")
                        {

                            string ListNameDynamic = "";
                            if (VerficationType == "QABANAH")
                            {
                                ListNameDynamic = "Qabannah";
                            }
                            else
                            {
                                ListNameDynamic = "QCCScalesTests";
                            }
                            UpdateScaleTestAsReVisited(TestIDtoUpdate, ListNameDynamic);

                        }
                        QCCScalesReceipts _rcp = new QCCScalesReceipts();
                        _rcp.Company_Name = CompanyId;
                        _rcp.CompanyId = CompanyId;
                        _rcp.FinalTestResults = FinalTestResults;
                        _rcp.MarkNumber = MarkNumber;
                        _rcp.QCCTestId = TestScaleIGenerated;
                        _rcp.TaskId = "will be provide";
                        _rcp.Title = "s";
                        _rcp.TradingLiecense = TradingLiecense;
                        _rcp.VerificationCharges = VerificationCharges;
                        _rcp.VerificationDate = TestDate;
                        _rcp.WeightSetClass = ScaleClass;
                        ReceiptGeneratedID = CreateFinalReceipet(_rcp);
                    }

                }


            }
            catch (Exception ex)
            {

                throw;
            }
            Transactions = VerificationTestID + "," + ReceiptGeneratedID;
            return Transactions;
        }
        protected void UpdateScaleTestAsReVisited(string ID, string ListName)
        {
            try
            {
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                List oList = clientContext.Web.Lists.GetByTitle(ListName);
                ListItem oListItem = oList.GetItemById(Convert.ToInt32(ID));
                oListItem["ReVisited"] = "YES";
                oListItem.Update();
                clientContext.ExecuteQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void UpdateScaleMainTask(string ID)
        {
            try
            {

                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                List oList = clientContext.Web.Lists.GetByTitle("ScaleMainTask");
                ListItem oListItem = oList.GetItemById(Convert.ToInt32(ID));
                oListItem["Stage"] = "Complete";
                oListItem.Update();
                clientContext.ExecuteQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Scale GetScaleDetailInformatoin(string ScaleID)
        {
            Scale _MainObject = new Scale();
            string Result = string.Empty;
            try
            {
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle("QCCScales");
                clientContext.Load(spList);
                clientContext.ExecuteQuery();
                if (spList != null && spList.ItemCount > 0)
                {
                    Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml = @"<View> <Query>  <Where><Eq><FieldRef Name='ID' />    <Value Type='Counter'>" + ScaleID + "</Value></Eq></Where>  "
                     + "</Query>"
                     + "<ViewFields>"
                    + "<FieldRef Name= 'ScMax' />< FieldRef Name='ScalVe' /><FieldRef Name = 'ScalVd' /> "
                     + "<FieldRef Name='Maximum2' /><FieldRef Name='eval2' /><FieldRef Name='ScaleRangeUsed' /><FieldRef Name='ScaleClass' />"
                     + "<FieldRef Name='CalculationType' /><FieldRef Name='QCCTagNumber' /><FieldRef Name='ScaleCategory' /><FieldRef Name='ScMin' /></ViewFields>  "
                     + "</View>";
                    ListItemCollection listItems = spList.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
                    foreach (ListItem item in listItems)
                    {
                        _MainObject.ScMax = Convert.ToString(item["ScMax"]);
                        _MainObject.BusinessCategory = Convert.ToString(item["BusinessCategory"]);
                        _MainObject.CalculationType = Convert.ToString(item["CalculationType"]);
                        _MainObject.CompanyId = Convert.ToString(item["CompanyId"]);
                        _MainObject.E_Unit = Convert.ToString(item["E_Unit"]);
                        _MainObject.eval2 = Convert.ToString(item["eval2"]);
                        _MainObject.Maximum2 = Convert.ToString(item["Maximum2"]);
                        _MainObject.QCCTagNumber = Convert.ToString(item["QCCTagNumber"]);
                        _MainObject.ScaleCategory = Convert.ToString(item["ScaleCategory"]);
                        _MainObject.ScaleClass = Convert.ToString(item["ScaleClass"]);
                        _MainObject.ScaleMiniMum = Convert.ToString(item["ScaleMiniMum"]);
                        _MainObject.ScaleOldId = Convert.ToString(item["ScaleOldId"]);
                        _MainObject.ScaleRangeUsed = Convert.ToString(item["ScaleRangeUsed"]);
                        _MainObject.ScalVd = Convert.ToString(item["ScalVd"]);
                        _MainObject.ScalVd2 = Convert.ToString(item["ScalVd2"]);
                        _MainObject.ScalVe = Convert.ToString(item["ScalVe"]);
                        _MainObject.ScManufacturer = Convert.ToString(item["ScManufacturer"]);
                        _MainObject.ScMin = Convert.ToString(item["ScMin"]);
                        _MainObject.ScModel = Convert.ToString(item["ScModel"]);
                        _MainObject.ScNumberofDisplay = Convert.ToString(item["ScNumberofDisplay"]);
                        _MainObject.ScSerialNo = Convert.ToString(item["ScSerialNo"]);
                        _MainObject.ScTypeApproval = Convert.ToString(item["ScTypeApproval"]);

                    }
                }
            }
            catch (Exception Ex)
            {

                // throw;

            }
            return _MainObject;

        }

        public ScaleTest GetDetailsofTestFromTagNumberScale(string TestId, string Check)
        {
            if (TestId == "" || TestId == null) TestId = "2738";
            if (Check == "" || Check == null) Check = "QCCScalesTests";
            ScaleTest _Object = new ScaleTest();
            try
            {
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle(Check);
                clientContext.Load(spList);
                clientContext.ExecuteQuery();
                if (spList != null && spList.ItemCount > 0)
                {
                    Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml = @"<View> <Query>  <Where><Eq><FieldRef Name='ID' />    <Value Type='Counter'>" + TestId + "</Value></Eq></Where>  "
                        + "</Query><ViewFields>"
                              + "<FieldRef Name=\"ID\"/>" + "<FieldRef Name=\"QCCTagNumber\"/>"
                              + "<FieldRef Name=\"ScaleMaximumVal\"/>" + "<FieldRef Name=\"MaxiMum2\"/>"
                              + "<FieldRef Name=\"EvalueNoted2\"/>" + "<FieldRef Name=\"EvalueNoted\"/>"
                              + "<FieldRef Name=\"ScaleId\"/>" + "<FieldRef Name=\"DValueNoted\"/>"
                             + "<FieldRef Name=\"DValueNoted2\"/>" + "<FieldRef Name=\"ScaleMiniMum\"/>"
                              + "<FieldRef Name=\"ScaleCalss\"/>"
                             + "<FieldRef Name=\"FinalTestResults\"/>" + "<FieldRef Name=\"EvalueNoted2\"/>"
                             + "<FieldRef Name=\"EvalueNoted\"/>" + "<FieldRef Name=\"ScaleId\"/>" + "<FieldRef Name=\"TradingLiecense\"/>" +
                             "<FieldRef Name=\"ScaleCategory\"/>" + "<FieldRef Name=\"TestType\"/>" + "<FieldRef Name=\"CalculationType\"/>" +
                             "<FieldRef Name=\"ScaleRangeUsed\"/>" + "<FieldRef Name=\"ScaleCalss\"/>" +
                              "<FieldRef Name=\"FinalTestResults\"/><FieldRef Name=\"CompanyId\"/><FieldRef Name=\"BusinessCategory\"/><FieldRef Name=\"ScaleCategory\"/>" +


                                         "</ViewFields></View>";
                    ListItemCollection listItems = spList.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
                    foreach (ListItem item in listItems)
                    {
                        _Object.QCCTagNumber = Convert.ToString(item["QCCTagNumber"]);
                        _Object.MaxiMum2 = Convert.ToString(item["MaxiMum2"]);
                        _Object.ScaleMaximumVal = Convert.ToString(item["ScaleMaximumVal"]);
                        _Object.EvalueNoted2 = Convert.ToString(item["EvalueNoted2"]);
                        _Object.EvalueNoted = Convert.ToString(item["EvalueNoted"]);
                        _Object.ScaleId = Convert.ToString(item["ScaleId"]);
                        _Object.DValueNoted = Convert.ToString(item["DValueNoted"]);
                        _Object.DValueNoted2 = Convert.ToString(item["DValueNoted2"]);
                        _Object.ScaleMiniMum = Convert.ToString(item["ScaleMiniMum"]);

                        _Object.CompanyId = Convert.ToString(item["CompanyId"]);
                        _Object.ScaleCalss = Convert.ToString(item["ScaleCalss"]);
                        _Object.FinalTestResults = Convert.ToString(item["FinalTestResults"]);
                        _Object.EvalueNoted2 = Convert.ToString(item["EvalueNoted2"]);
                        _Object.TradingLiecense = Convert.ToString(item["TradingLiecense"]);
                        _Object.ScaleCategory = Convert.ToString(item["ScaleCategory"]);
                        _Object.TestType = Convert.ToString(item["TestType"]);
                        _Object.CalculationType = Convert.ToString(item["CalculationType"]);
                        _Object.ScaleRangeUsed = Convert.ToString(item["ScaleRangeUsed"]);
                        _Object.QCCTagNumber = Convert.ToString(item["QCCTagNumber"]);
                        _Object.ScaleCategory = Convert.ToString(item["ScaleCategory"]);
                        _Object.FinalTestResults = Convert.ToString(item["FinalTestResults"]);
                        _Object.BusinessCategory = Convert.ToString(item["BusinessCategory"]);






                    }
                }
            }
            catch (Exception Ex)
            {
            }
            return _Object;
        }




        #endregion


        #region Reverificaiton Details
        //First Create Class which Return Object
        //  ReVerification Class Name
        public DataTable FetchQCCCustomerAddress(string TradingLicense)
        {
            string Result = "";
            // return TradingLicense + "|" + TradingLicense;
            DataTable _EmployeeInfo = new DataTable();
            QCCCustomer _Obj = new QCCCustomer();
            try
            {
                MiddleWare _Onwire2 = new MiddleWare();
                _EmployeeInfo = _Onwire2.FechQccCustomerAdressWithID(TradingLicense);
            }
            catch (Exception ex)
            {
                string ErrorMessage = Convert.ToString(ex.Message.ToString());
                Common.LogSystemException("ScalesWebService-FetchQCCCustomer", ErrorMessage, ErrorMessage, "IQCCClients");
                //QCCCustomer _Obj = new QCCCustomer();
                _Obj.Email = ex.Message.ToString();

            }
            return _EmployeeInfo;
        }
        public List<string> ReadInspectorInformation(string InspectorName)
        {
            InspectorName = "Khalid Mohammed Ahmed Al Nuaimi";
            List<string> Inp = new System.Collections.Generic.List<string>();
            try
            {
                //ClientContext clientContext = new ClientContext("https://apps.qcc.abudhabi.ae/Inspections");
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                url = "https://apps.qcc.abudhabi.ae/Inspections";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle("MSInspectors");
                clientContext.Load(spList);
                clientContext.ExecuteQuery();
                if (spList != null && spList.ItemCount > 0)
                {
                    Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml =
                       @"<View>Query><Where><Eq><FieldRef Name='SeniorInspector' /><Value Type='Author'>" + InspectorName + "</Value></Eq></Where></Query><ViewFields><FieldRef Name='InspectorName' />  FieldRef Name='SeniorInspector' />  </ViewFields>                               </View>";
                    ListItemCollection listItems = spList.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();

                    foreach (ListItem item in listItems)
                    {
                        // if
                        FieldUserValue fuv1 = (FieldUserValue)item["SeniorInspector"];
                        string _SeniorInspector = fuv1.LookupValue.ToString();
                        if (_SeniorInspector == InspectorName)
                        {
                            FieldUserValue fuv = (FieldUserValue)item["InspectorName"];
                            string _Createdby = fuv.LookupValue.ToString();
                            Inp.Add(Convert.ToString(_Createdby));
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                //Result = ex.Message.ToString();
            }
            return Inp;
        }



        #endregion
        #region Table for Inspectors
        public InspectorReport FetchMyReport(string InspectorName)
        {
            InspectorReport _In = new InspectorReport();
            // InspectorName = "i:0#.w|adqcc\\q.alqutba";
            InspectorName = "i:0#.w|adqcc\\abdulla.hadi";
            InspectorName = "i:0#.w|adqcc\\a.albishr";
            string Result = string.Empty;
            try
            {
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                url = "https://apps.qcc.abudhabi.ae/Inspections";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle("QCCScalesTests");
                clientContext.Load(spList);
                clientContext.ExecuteQuery();
                string DateTimeofResult = "7/9/2015 1:54 PM";



                if (spList != null && spList.ItemCount > 0)
                {
                    Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                    //camlQuery.ViewXml =
                    //      @"<View>          <Query>      <Where>"
                    //       + "<Eq><FieldRef Name='VerificationConductedBy' /><Value Type='Text'>" + InspectorName + "</Value></Eq>"
                    //       + "</Where>           </Query>  <ViewFields>   <FieldRef Name='CompanyId' /> "
                    //      + " <FieldRef Name='ID' />  <FieldRef Name='TestFine' /> <FieldRef Name='TestDate' />"
                    //      + " <FieldRef Name='FinalTestResults' />  <FieldRef Name='VerfiedMarckFail' />"
                    //      + " <FieldRef Name='VerifiedMarck' />  <FieldRef Name='BusinessCategory' />"
                    //      + " <FieldRef Name='ScaleCategory' />  <FieldRef Name='VerificationConductedBy' /> <FieldRef Name='TestType' />"
                    //      + "</ViewFields>                               </View>";
                    DateTime nDaysAgo = DateTime.Today.AddDays(-3);
                    string startDateFx = nDaysAgo.ToString("yyyy-MM-ddTHH:mm:ssZ");

                    camlQuery.ViewXml =
                          @"<View>          <Query>      <Where><And>"
                          + "<Eq><FieldRef Name='TestDate' /><Value Type='DateTime'>2015-07-09</Value></Eq>"
                           + "<Eq><FieldRef Name='VerificationConductedBy' /><Value Type='Text'>" + InspectorName + "</Value></Eq>"
                           + "</And></Where> </Query>  <ViewFields>   <FieldRef Name='CompanyId' /> "
                          + " <FieldRef Name='ID' />  <FieldRef Name='TestFine' />"
                          + " <FieldRef Name='FinalTestResults' />  <FieldRef Name='VerfiedMarckFail' />"
                          + " <FieldRef Name='VerifiedMarck' />  <FieldRef Name='BusinessCategory' />"
                          + " <FieldRef Name='ScaleCategory' />  <FieldRef Name='VerificationConductedBy' /> <FieldRef Name='TestType' />"
                          + "</ViewFields>                               </View>";


                    ListItemCollection listItems = spList.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
                    int FeesTotal = 0;
                    foreach (ListItem item in listItems)
                    {
                        string TestTypes = Convert.ToString(item["TestType"]);
                        string BusinessCatagory = Convert.ToString(item["BusinessCategory"]);
                        string ResultofTest = Convert.ToString(item["FinalTestResults"]);
                        int fee = Convert.ToInt32(Convert.ToString(item["TestFine"]));
                        FeesTotal += fee;
                        if (TestTypes.Contains("Initial Verificaiton / التحقق الأولي") == true)
                        {
                            if (BusinessCatagory.Contains("ذهب / Gold") == true)
                            {
                                _In.EInitialGold += 1;
                                _In.SCInitialGold += 1;
                                if (ResultofTest == "Pass")
                                    _In.VInitialGold += 1;
                                else
                                    _In.RInitialGold += 1;
                            }
                            if (BusinessCatagory.Contains("عود /  Oud") == true)
                            {
                                _In.EInitialOut += 1;
                                _In.SCInitialOut += 1;
                                if (ResultofTest == "Pass")
                                    _In.VInitialOut += 1;
                                else
                                    _In.RInitialOut += 1;
                            }
                            if (BusinessCatagory.Contains("شحن / cargo") == true)
                            {
                                _In.EInitialCargo += 1;
                                _In.SCPerCargo += 1;

                                if (ResultofTest == "Pass")
                                    _In.VInitialCargo += 1;
                                else
                                    _In.RInitialCargo += 1;
                            }
                            if (BusinessCatagory.Contains("تجاري / retails") == true)
                            {
                                _In.EInitialTr += 1;
                                _In.SCInitialTr += 1;
                                if (ResultofTest == "Pass")
                                    _In.VInitialTr += 1;
                                else
                                    _In.RInitialTr += 1;
                            }

                        }
                        if (TestTypes.Contains("Periodic/ التحقق الدوري") == true)
                        {
                            if (BusinessCatagory.Contains("ذهب / Gold") == true)
                            {
                                _In.EnPerGold += 1;
                                _In.SCPerGold += 1;

                                if (ResultofTest == "Pass")
                                    _In.VPerGold += 1;
                                else
                                    _In.RPerGold += 1;
                            }
                            if (BusinessCatagory.Contains("عود /  Oud") == true)
                            {
                                _In.EPerOud += 1;
                                _In.SCPerOud += 1;

                                if (ResultofTest == "Pass")
                                    _In.VPerOud += 1;
                                else
                                    _In.RPerOud += 1;
                            }
                            if (BusinessCatagory.Contains("شحن / cargo") == true)
                            {
                                _In.EPerCargo += 1;
                                _In.SCPerCargo += 1;

                                if (ResultofTest == "Pass")
                                    _In.VPerCargo += 1;
                                else
                                    _In.RPerCargo += 1;
                            }
                            if (BusinessCatagory.Contains("تجاري / retails") == true)
                            {
                                _In.EPerTr += 1;
                                _In.SCPerTr += 1;
                                if (ResultofTest == "Pass")
                                    _In.VPerTr += 1;
                                else
                                    _In.RPerTr += 1;
                            }
                        }
                        if (TestTypes.Contains("Re-Verification/") == true)
                        {
                            if (BusinessCatagory == "ذهب / Gold")
                            {
                                _In.ERevGold += 1;
                                _In.SCRevGold += 1;

                                if (ResultofTest == "Pass")
                                    _In.VRevGold += 1;
                                else
                                    _In.RRevRGold += 1;
                            }
                            if (BusinessCatagory.Contains("عود /  Oud") == true || BusinessCatagory.Contains("PERFUMES") == true)
                            {
                                _In.ERevOud += 1;
                                _In.SCRevOud += 1;

                                if (ResultofTest == "Pass")
                                    _In.VRevOud += 1;

                                else
                                    _In.RRevROud += 1;
                            }
                            if (BusinessCatagory.Contains("شحن / cargo") == true)
                            {
                                _In.EReCargo += 1;
                                _In.SCReCargo += 1;

                                if (ResultofTest == "Pass")
                                    _In.VReCargo += 1;

                                else
                                    _In.RRevCargo += 1;
                            }
                            if (BusinessCatagory.Contains("تجاري / retails") == true)
                            {
                                _In.ERevTr += 1;
                                _In.SCRevTr += 1;

                                if (ResultofTest == "Pass")
                                    _In.VRevTr += 1;

                                else
                                    _In.RRevRTr += 1;
                            }
                        }




                    }

                }
            }

            catch (Exception ex)
            {
                Result = ex.Message.ToString();

            }
            return _In;
        }



        #endregion


        #region New Template to Test GIG
        #endregion

        public List<QCCConsumers> FetchPreviousRecordofConsumer(string TradeLicense, string ScaleCheck)
        {


            DataTable AllScales = new DataTable();

            //  TradeLicense = "CN-1268169";
            // ScaleCheck = "QABANAH9";
            string ListName = string.Empty;
            if (ScaleCheck == "QABANAH")
            { ListName = "Qabannah"; }
            else ListName = "QCCScalesTests";
            string Result = "Empty";

            string ListNameSCale = "";
            if (ScaleCheck == "QABANAH")
            { ListNameSCale = "QabanahScales"; }
            else { ListNameSCale = "QCCScales"; }
            AllScales = FetchScaleSerial(ListNameSCale);
            List<QCCConsumers> MainList = new List<QCCConsumers>();


            try
            {
                // ClientContext clientContext = new ClientContext("https://apps.qcc.abudhabi.ae/Inspections");
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                //  url = "https://apps.qcc.abudhabi.ae/Inspections";
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle(ListName);
                clientContext.Load(spList);
                clientContext.ExecuteQuery();
                if (spList != null && spList.ItemCount > 0)
                {
                    Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml =
                       @"<View>          <Query>     <Where><Eq><FieldRef Name='CompanyId' /><Value Type='Text'>" + TradeLicense + "</Value></Eq></Where>           </Query><ViewFields><FieldRef Name='NominalValueQn' />"
                    + "<FieldRef Name='ScaleId' /><FieldRef Name='Created' />"
                    + "<FieldRef Name='FinalTestResults' /><FieldRef Name='ScaleRangeUsed' />"
                    + "<FieldRef Name='ScaleMiniMum' /><FieldRef Name='QCCTagNumber' />"
                    + "<FieldRef Name='CompanyId' /><FieldRef Name='VerifiedMarck' />"
                    + "<FieldRef Name='VerfiedMarckFail' /><FieldRef Name='ID' />"
                    + "</ViewFields></View>";
                    ListItemCollection listItems = spList.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
                    foreach (ListItem item in listItems)
                    {

                        QCCConsumers _consumerObject = new QCCConsumers();
                        _consumerObject.CompanyId = Convert.ToString(item["CompanyId"]);
                        _consumerObject.FinalTestResults = Convert.ToString(item["FinalTestResults"]);
                        _consumerObject.ID = Convert.ToString(item["ID"]);
                        _consumerObject.QCCTagNumber = Convert.ToString(item["QCCTagNumber"]);
                        _consumerObject.ScaleId = Convert.ToString(item["ScaleId"]);
                        _consumerObject.ScaleMiniMum = Convert.ToString(item["ScaleMiniMum"]);
                        _consumerObject.ScaleRangeUsed = Convert.ToString(item["ScaleRangeUsed"]);
                        // _consumerObject.VerfiedMarckFail = Convert.ToString(item["VerfiedMarckFail"]);
                        // _consumerObject.VerifiedMarck = Convert.ToString(item["VerifiedMarck"]);
                        string TestCheck = Convert.ToString(item["FinalTestResults"]);
                        if (TestCheck == "Pass")
                        {
                            _consumerObject.VerfiedMarckFail = Convert.ToString(item["VerifiedMarck"]);
                        }
                        else
                        {
                            _consumerObject.VerfiedMarckFail = Convert.ToString(item["VerfiedMarckFail"]);
                        }
                        DataRow[] foundRows;
                        string x = _consumerObject.ScaleId;
                        foundRows = AllScales.Select("ID='696'");
                        foreach (DataRow row in foundRows)
                        {
                            //Console.WriteLine("{0}, {1}", row[0], row[1]);
                            _consumerObject.ScaleSerial = Convert.ToString(row[1]);
                        }
                        _consumerObject.Created = Convert.ToString(item["Created"]);

                        //                           
                        MainList.Add(_consumerObject);

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return MainList;
        }

        public DataTable FetchScaleSerial(string ListName)
        {

            int found = 0;
            string ScaleSerial = "NOT PROVIDED";
            string SecondaryListName = ListName;
            Hashtable hashtableexample = new Hashtable();
            DataTable dt = new DataTable();

            try
            {
                dt.Columns.Add("ID");
                dt.Columns.Add("Serial");
                string ColumnNameForScale = "ScSerialNo";
                string url = "http://sp-app2-dev:35897/VIS-DEV/";
                url = "https://apps.qcc.abudhabi.ae/Inspections";
                //ClientContext clientContext = new ClientContext("https://apps.qcc.abudhabi.ae/Inspections/");
                ClientContext clientContext = new ClientContext(url);
                NetworkCredential credentials = new NetworkCredential("bot1", "12345678", "ADQCC");
                clientContext.Credentials = credentials;
                //  ClientContext clientContext = new ClientContext("https://apps.qcc.abudhabi.ae/Inspections/");
                Microsoft.SharePoint.Client.List spList = clientContext.Web.Lists.GetByTitle(SecondaryListName);
                clientContext.Load(spList);
                clientContext.ExecuteQuery();
                if (spList != null && spList.ItemCount > 0)
                {
                    Microsoft.SharePoint.Client.CamlQuery camlQuery = new CamlQuery();
                    camlQuery.ViewXml =
                       @"<View>          <Query>      <Where><Gt><FieldRef Name='ID' /><Value Type='Counter'>0</Value></Gt></Where>           </Query>    <FieldRef Name='ID' />  <FieldRef Name='ScSerialNo' /></ViewFields>                               </View>";
                    ListItemCollection listItems = spList.GetItems(camlQuery);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
                    foreach (ListItem item in listItems)
                    {
                        ScaleSerial = Convert.ToString(item[ColumnNameForScale]);
                        if (ScaleSerial == "" || ScaleSerial == "000" || ScaleSerial == "-")
                        {
                            ScaleSerial = "Not Found";
                        }
                        //  hashtableexample[Convert.ToInt32(item["ID"])]=ScaleSerial;
                        // hashtableexample.Add(ScaleSerial, Convert.ToInt32(item["ID"]));

                        //dt.Clear();

                        DataRow _ravi = dt.NewRow();
                        _ravi["ID"] = Convert.ToInt32(item["ID"]);
                        _ravi["Serial"] = ScaleSerial;
                        dt.Rows.Add(_ravi);

                    }
                }


            }
            catch (Exception ex)
            {
                ScaleSerial = ex.Message.ToString();
            }
            //ScaleSerial = Convert.ToString(found.ToString());
            return dt;
        }
       

    }
}
