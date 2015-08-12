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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;


namespace VIS_SP_Transactions
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVIS_ScaleTranLog" in both code and config file together.
    [ServiceContract]
    public interface IVIS_ScaleTranLog
    {
        [OperationContract]
        void DoWork();


        #region New 24th May Development


    


        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        string CommitTransactoins(string ScaleObject, string TaskObject, string ScaleTestObject, string ReceiptObjct, string ManufacturerObject, string TestCheck, string ListName, string ReceiptFlag,
            string Qabannahobj, string QabannahDetailsobj, string QabannahSCaleobj, string ISNewManufacturere);



        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        List<QCCConsumers> FetchPreviousRecordofConsumer(string TradeLicense, string ScaleCheck);


    



        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        List<string> ReadInspectorInformation(string InspectorName);


        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        Scale GetScaleDetailInformatoin(string ScaleID);


        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        ScaleTest GetDetailsofTestFromTagNumberScale(string TestId, string Check);


        #endregion
        #region Inspector Page report
        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        InspectorReport FetchMyReport(string InspectorName);
        #endregion


    }

    #region Addition Code 24th May 2015

    [DataContract()]
    public class ScaleTestold
    {
        [DataMember]
        public string MPEFrom2 { get; set; }
        [DataMember]
        public string MPEFrom3 { get; set; }
        [DataMember]
        public string MPEFrom4 { get; set; }
        [DataMember]
        public string MPEFrom5 { get; set; }
        [DataMember]
        public string MPEFrom6 { get; set; }
        [DataMember]
        public string MPEror1 { get; set; }
        [DataMember]
        public string MPEror2 { get; set; }
        [DataMember]
        public string MPEror3 { get; set; }
        [DataMember]
        public string MPEror4 { get; set; }
        [DataMember]
        public string MPEror5 { get; set; }
        [DataMember]
        public string MPEror6 { get; set; }
        [DataMember]
        public string IsNewCustomer { get; set; }
        [DataMember]
        public string MPETo1 { get; set; }
        [DataMember]
        public string MPETo2 { get; set; }
        [DataMember]
        public string MPETo3 { get; set; }
        [DataMember]
        public string MPETo4 { get; set; }
        [DataMember]
        public string MPETo5 { get; set; }
        [DataMember]
        public string MPETo6 { get; set; }
        [DataMember]
        public string PaymentReportStatus { get; set; }
        [DataMember]
        public string PaymentUpdateBy { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string ReceiptId { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string RptError1 { get; set; }
        [DataMember]
        public string RptError2 { get; set; }
        [DataMember]
        public string RptError3 { get; set; }
        [DataMember]
        public string RptError4 { get; set; }
        [DataMember]
        public string RptError5 { get; set; }
        [DataMember]
        public string RptError6 { get; set; }
        [DataMember]
        public string RptReading1 { get; set; }
        [DataMember]
        public string RptReading2 { get; set; }
        [DataMember]
        public string RptReading3 { get; set; }
        [DataMember]
        public string RptReading4 { get; set; }
        [DataMember]
        public string RptReading5 { get; set; }
        [DataMember]
        public string RptReading6 { get; set; }
        [DataMember]
        public string ScaleCalss { get; set; }
        [DataMember]
        public string ScaleCategory { get; set; }
        [DataMember]
        public string ScaleId { get; set; }
        [DataMember]
        public string ScaleManufacturer { get; set; }
        [DataMember]
        public string ScaleMaximumVal { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScaleTestReceiptId { get; set; }
        [DataMember]
        public string TaskId { get; set; }
        [DataMember]
        public string TestFine { get; set; }
        [DataMember]
        public string TestDate { get; set; }
        [DataMember]
        public string TestRevisitDate { get; set; }
        [DataMember]
        public string TestStage { get; set; }
        [DataMember]
        public string TestType { get; set; }
        [DataMember]
        public string TestStageDesc { get; set; }
        [DataMember]
        public string TradingLiecense { get; set; }
        [DataMember]
        public string VerficatoinReport { get; set; }
        [DataMember]
        public string VerificationCharges { get; set; }
        [DataMember]
        public string VerificationConductedBy { get; set; }
        [DataMember]
        public string OldQccTagNumber { get; set; }
        [DataMember]
        public string ArModuleSync { get; set; }

    }
    [DataContract()]
    public class ScaleTest
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TaskId { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string MPEFrom1 { get; set; }
        [DataMember]
        public string MPETo1 { get; set; }
        [DataMember]
        public string MPEror1 { get; set; }
        [DataMember]
        public string MPEFrom2 { get; set; }
        [DataMember]
        public string MPETo2 { get; set; }
        [DataMember]
        public string MPEror2 { get; set; }
        [DataMember]
        public string MPEFrom3 { get; set; }
        [DataMember]
        public string MPETo3 { get; set; }
        [DataMember]
        public string MPEror3 { get; set; }
        [DataMember]
        public string MPEFrom4 { get; set; }
        [DataMember]
        public string MPETo4 { get; set; }
        [DataMember]
        public string MPEror4 { get; set; }
        [DataMember]
        public string MPEFrom5 { get; set; }
        [DataMember]
        public string MPETo5 { get; set; }
        [DataMember]
        public string MPEFrom6 { get; set; }
        [DataMember]
        public string MPETo6 { get; set; }
        [DataMember]
        public string MPEror6 { get; set; }
        [DataMember]
        public string LinFwdV1 { get; set; }
        [DataMember]
        public string LinFwdRes1 { get; set; }
        [DataMember]
        public string LinFwdError1 { get; set; }
        [DataMember]
        public string LinFwdV2 { get; set; }
        [DataMember]
        public string LinFwdRes2 { get; set; }
        [DataMember]
        public string LinFwdError2 { get; set; }
        [DataMember]
        public string LinFwdV3 { get; set; }
        [DataMember]
        public string LinFwdRes3 { get; set; }
        [DataMember]
        public string LinFwdError3 { get; set; }
        [DataMember]
        public string LinFwdV4 { get; set; }
        [DataMember]
        public string LinFwdRes4 { get; set; }
        [DataMember]
        public string LinFwdError4 { get; set; }
        [DataMember]
        public string LinFwdV5 { get; set; }
        [DataMember]
        public string LinFwdRes5 { get; set; }
        [DataMember]
        public string LinFwdError5 { get; set; }
        [DataMember]
        public string LinFwdV6 { get; set; }
        [DataMember]
        public string LinFwdRes6 { get; set; }
        [DataMember]
        public string LinFwdError6 { get; set; }
        [DataMember]
        public string LinFwdV7 { get; set; }
        [DataMember]
        public string LinFwdRes7 { get; set; }
        [DataMember]
        public string LinFwdError7 { get; set; }
        [DataMember]
        public string RptReading1 { get; set; }
        [DataMember]
        public string RptError1 { get; set; }
        [DataMember]
        public string RptReading2 { get; set; }
        [DataMember]
        public string RptError2 { get; set; }
        [DataMember]
        public string RptReading3 { get; set; }
        [DataMember]
        public string RptError3 { get; set; }
        [DataMember]
        public string RptReading4 { get; set; }
        [DataMember]
        public string RptError4 { get; set; }
        [DataMember]
        public string RptReading5 { get; set; }
        [DataMember]
        public string RptError5 { get; set; }
        [DataMember]
        public string RptReading6 { get; set; }
        [DataMember]
        public string RptError6 { get; set; }
        [DataMember]
        public string EccPos1 { get; set; }
        [DataMember]
        public string EccRead1 { get; set; }
        [DataMember]
        public string EccErr1 { get; set; }
        [DataMember]
        public string EccPos2 { get; set; }
        [DataMember]
        public string EccRead2 { get; set; }
        [DataMember]
        public string EccErr2 { get; set; }
        [DataMember]
        public string EccPos3 { get; set; }
        [DataMember]
        public string EccRead3 { get; set; }
        [DataMember]
        public string EccErr3 { get; set; }
        [DataMember]
        public string EccPos4 { get; set; }
        [DataMember]
        public string EccRead4 { get; set; }
        [DataMember]
        public string EccErr4 { get; set; }
        [DataMember]
        public string EccPos5 { get; set; }
        [DataMember]
        public string EccRead5 { get; set; }
        [DataMember]
        public string EccErr5 { get; set; }
        [DataMember]
        public string EccPos6 { get; set; }
        [DataMember]
        public string EccRead6 { get; set; }
        [DataMember]
        public string EccErr6 { get; set; }
        [DataMember]
        public string MarkNumber { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string VerificationConductedBy { get; set; }
        [DataMember]
        public string VerficatoinReport { get; set; }
        [DataMember]
        public string ScaleCalss { get; set; }
        [DataMember]
        public string TestRevisitDate { get; set; }
        [DataMember]
        public string TestStage { get; set; }
        [DataMember]
        public string TestStageDesc { get; set; }
        [DataMember]
        public string TestFine { get; set; }
        [DataMember]
        public string CalculationType { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string ScaleCategory { get; set; }
        [DataMember]
        public string ScaleManufacturer { get; set; }
        [DataMember]
        public string ScaleMaximumVal { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string DValueNoted { get; set; }
        [DataMember]
        public string EvalueNoted { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScaleTestReceiptId { get; set; }
        [DataMember]
        public string TradingLiecense { get; set; }
        [DataMember]
        public string ScaleId { get; set; }
        [DataMember]
        public string EccentricityIsApplicable { get; set; }
        [DataMember]
        public string EccentricityReason { get; set; }
        [DataMember]
        public string MaxiMum2 { get; set; }
        [DataMember]
        public string EvalueNoted2 { get; set; }
        [DataMember]
        public string IsNewCustomer { get; set; }
        [DataMember]
        public string TestType { get; set; }
        [DataMember]
        public string SecureMark { get; set; }
        [DataMember]
        public string VerifiedMarck { get; set; }
        [DataMember]
        public string VerfiedMarckFail { get; set; }
        [DataMember]
        public string VisualClean { get; set; }
        [DataMember]
        public string VisualWorkingFine { get; set; }
        [DataMember]
        public string VisualUnBroken { get; set; }
        [DataMember]
        public string VisaulCorretSurfceLvl { get; set; }
        [DataMember]
        public string SimpleTest { get; set; }
        [DataMember]
        public string FinalTestResults { get; set; }
        [DataMember]
        public string VerificationCharges { get; set; }
        [DataMember]
        public string OldQccTagNumber { get; set; }
        [DataMember]
        public string MPEror5 { get; set; }
        [DataMember]
        public string DValueNoted2 { get; set; }
        [DataMember]
        public string TestDate { get; set; }
        [DataMember]
        public string TestApprovedBy { get; set; }
        [DataMember]
        public string TestApprovalDate { get; set; }
        [DataMember]
        public string MohthlyGroupColumn { get; set; }
        [DataMember]
        public string BusinessCategory { get; set; }
        [DataMember]
        public string ReVisited { get; set; }

    }
    [DataContract]
    public class Scale
    {
        [DataMember]
        public string MyProperty { get; set; }
        [DataMember]
        public string BusinessCategory { get; set; }
        [DataMember]
        public string CalculationType { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string ScaleCategory { get; set; }
        [DataMember]
        public string ScaleClass { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScalVd { get; set; }
        [DataMember]
        public string ScalVd2 { get; set; }
        [DataMember]
        public string ScalVe { get; set; }
        [DataMember]
        public string eval2 { get; set; }
        //if (ScManufacturer == "Others") {
        [DataMember]
        public string ScManufacturer { get; set; }
        [DataMember]
        public string ScMax { get; set; }
        [DataMember]
        public string Maximum2 { get; set; }
        [DataMember]
        public string ScMin { get; set; }
        [DataMember]
        public string ScModel { get; set; }
        [DataMember]
        public string ScNumberofDisplay { get; set; }
        [DataMember]
        public string ScSerialNo { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string ScTypeApproval { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string E_Unit { get; set; }
        [DataMember]
        public string ScaleOldId { get; set; }
    }
    [DataContract()]
    public class Manufacturere
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string AddedBy { get; set; }
        [DataMember]
        public string Manu_Type { get; set; }

    }
    [DataContract()]
    public class Qabannah
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TaskId { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string MPEFrom1 { get; set; }
        [DataMember]
        public string MPETo1 { get; set; }
        [DataMember]
        public string MPEror1 { get; set; }
        [DataMember]
        public string MPEFrom2 { get; set; }
        [DataMember]
        public string MPETo2 { get; set; }
        [DataMember]
        public string MPEror2 { get; set; }
        [DataMember]
        public string MPEFrom3 { get; set; }
        [DataMember]
        public string MPETo3 { get; set; }
        [DataMember]
        public string MPEror3 { get; set; }
        [DataMember]
        public string MPEFrom4 { get; set; }
        [DataMember]
        public string MPETo4 { get; set; }
        [DataMember]
        public string MPEror4 { get; set; }
        [DataMember]
        public string MPEFrom5 { get; set; }
        [DataMember]
        public string MPETo5 { get; set; }
        [DataMember]
        public string MPEFrom6 { get; set; }
        [DataMember]
        public string MPETo6 { get; set; }
        [DataMember]
        public string MPEror6 { get; set; }
        [DataMember]
        public string LinFwdV1 { get; set; }
        [DataMember]
        public string LinFwdRes1 { get; set; }
        [DataMember]
        public string LinFwdError1 { get; set; }
        [DataMember]
        public string LinFwdV2 { get; set; }
        [DataMember]
        public string LinFwdRes2 { get; set; }
        [DataMember]
        public string LinFwdError2 { get; set; }
        [DataMember]
        public string LinFwdV3 { get; set; }
        [DataMember]
        public string LinFwdRes3 { get; set; }
        [DataMember]
        public string LinFwdError3 { get; set; }
        [DataMember]
        public string LinFwdV4 { get; set; }
        [DataMember]
        public string LinFwdRes4 { get; set; }
        [DataMember]
        public string LinFwdError4 { get; set; }
        [DataMember]
        public string LinFwdV5 { get; set; }
        [DataMember]
        public string LinFwdRes5 { get; set; }
        [DataMember]
        public string LinFwdError5 { get; set; }
        [DataMember]
        public string LinFwdV6 { get; set; }
        [DataMember]
        public string LinFwdRes6 { get; set; }
        [DataMember]
        public string LinFwdError6 { get; set; }
        [DataMember]
        public string LinFwdV7 { get; set; }
        [DataMember]
        public string LinFwdRes7 { get; set; }
        [DataMember]
        public string LinFwdError7 { get; set; }
        [DataMember]
        public string RptReading1 { get; set; }
        [DataMember]
        public string RptError1 { get; set; }
        [DataMember]
        public string RptReading2 { get; set; }
        [DataMember]
        public string RptError2 { get; set; }
        [DataMember]
        public string RptReading3 { get; set; }
        [DataMember]
        public string RptError3 { get; set; }
        [DataMember]
        public string RptReading4 { get; set; }
        [DataMember]
        public string RptError4 { get; set; }
        [DataMember]
        public string RptReading5 { get; set; }
        [DataMember]
        public string RptError5 { get; set; }
        [DataMember]
        public string RptReading6 { get; set; }
        [DataMember]
        public string RptError6 { get; set; }
        [DataMember]
        public string EccPos1 { get; set; }
        [DataMember]
        public string EccRead1 { get; set; }
        [DataMember]
        public string EccErr1 { get; set; }
        [DataMember]
        public string EccPos2 { get; set; }
        [DataMember]
        public string EccRead2 { get; set; }
        [DataMember]
        public string EccErr2 { get; set; }
        [DataMember]
        public string EccPos3 { get; set; }
        [DataMember]
        public string EccRead3 { get; set; }
        [DataMember]
        public string EccErr3 { get; set; }
        [DataMember]
        public string EccPos4 { get; set; }
        [DataMember]
        public string EccRead4 { get; set; }
        [DataMember]
        public string EccErr4 { get; set; }
        [DataMember]
        public string EccPos5 { get; set; }
        [DataMember]
        public string EccRead5 { get; set; }
        [DataMember]
        public string EccErr5 { get; set; }
        [DataMember]
        public string EccPos6 { get; set; }
        [DataMember]
        public string EccRead6 { get; set; }
        [DataMember]
        public string EccErr6 { get; set; }
        [DataMember]
        public string MarkNumber { get; set; }
        [DataMember]
        public string Remarks { get; set; }
        [DataMember]
        public string VerificationConductedBy { get; set; }
        [DataMember]
        public string VerficatoinReport { get; set; }
        [DataMember]
        public string ScaleCalss { get; set; }
        [DataMember]
        public string TestRevisitDate { get; set; }
        [DataMember]
        public string TestStage { get; set; }
        [DataMember]
        public string TestStageDesc { get; set; }
        [DataMember]
        public string TestFine { get; set; }
        [DataMember]
        public string CalculationType { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string ScaleCategory { get; set; }
        [DataMember]
        public string ScaleManufacturer { get; set; }
        [DataMember]
        public string ScaleMaximumVal { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string DValueNoted { get; set; }
        [DataMember]
        public string EvalueNoted { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScaleTestReceiptId { get; set; }
        [DataMember]
        public string PaymentReportStatus { get; set; }
        [DataMember]
        public string PaymentUpdateBy { get; set; }
        [DataMember]
        public string ArModuleSync { get; set; }
        [DataMember]
        public string TradingLiecense { get; set; }
        [DataMember]
        public string ScaleId { get; set; }
        [DataMember]
        public string EccentricityIsApplicable { get; set; }
        [DataMember]
        public string EccentricityReason { get; set; }
        [DataMember]
        public string MaxiMum2 { get; set; }
        [DataMember]
        public string EvalueNoted2 { get; set; }
        [DataMember]
        public string IsNewCustomer { get; set; }
        [DataMember]
        public string TestType { get; set; }
        [DataMember]
        public string SecureMark { get; set; }
        [DataMember]
        public string VerifiedMarck { get; set; }
        [DataMember]
        public string VerfiedMarckFail { get; set; }
        [DataMember]
        public string VisualClean { get; set; }
        [DataMember]
        public string VisualWorkingFine { get; set; }
        [DataMember]
        public string VisualUnBroken { get; set; }
        [DataMember]
        public string VisaulCorretSurfceLvl { get; set; }
        [DataMember]
        public string SimpleTest { get; set; }
        [DataMember]
        public string FinalTestResults { get; set; }
        [DataMember]
        public string VerificationCharges { get; set; }
        [DataMember]
        public string OldQccTagNumber { get; set; }
        [DataMember]
        public string MPEror5 { get; set; }
        [DataMember]
        public string DValueNoted2 { get; set; }
        [DataMember]
        public string BankTransactionID { get; set; }
        [DataMember]
        public string InvoiceSystem { get; set; }
        [DataMember]
        public string InvSysInvoiceNumber { get; set; }
        [DataMember]
        public string InvSysReceipNumber { get; set; }
        [DataMember]
        public string InvSysReceiptAmount { get; set; }
        [DataMember]
        public string BankTransactionDate { get; set; }
        [DataMember]
        public string TestDate { get; set; }
        [DataMember]
        public string TestApprovedBy { get; set; }
        [DataMember]
        public string TestApprovalDate { get; set; }
        [DataMember]
        public string MohthlyGroupColumn { get; set; }
        [DataMember]
        public string BusinessCategory { get; set; }
        [DataMember]
        public string ReVisited { get; set; }

    }
    [DataContract()]
    public class QabannahDetails
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TestID { get; set; }
        [DataMember]
        public string InspectionType { get; set; }
        [DataMember]
        public string MaxiMumLoad { get; set; }
        [DataMember]
        public string LinLoad_1 { get; set; }
        [DataMember]
        public string LinLoad_2 { get; set; }
        [DataMember]
        public string LinLoad_3 { get; set; }
        [DataMember]
        public string LinLoad_4 { get; set; }
        [DataMember]
        public string LinLoad_5 { get; set; }
        [DataMember]
        public string LinLoad_6 { get; set; }
        [DataMember]
        public string LinLoad_7 { get; set; }
        [DataMember]
        public string LinLoad_8 { get; set; }
        [DataMember]
        public string LinLoad_9 { get; set; }
        [DataMember]
        public string LinLoad_10 { get; set; }
        [DataMember]
        public string LinLoad_11 { get; set; }
        [DataMember]
        public string LinLoad_12 { get; set; }
        [DataMember]
        public string LinLoad_13 { get; set; }
        [DataMember]
        public string LinLoad_14 { get; set; }
        [DataMember]
        public string LinLoad_15 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_1 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_2 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_3 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_4 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_5 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_6 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_7 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_8 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_9 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_10 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_11 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_12 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_13 { get; set; }
        [DataMember]
        public string LinError1_BeforeCal_15 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_1 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_2 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_3 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_4 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_5 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_6 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_7 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_8 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_9 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_10 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_11 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_12 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_13 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_14 { get; set; }
        [DataMember]
        public string LinError2_AfterVer_15 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_1 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_2 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_3 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_4 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_5 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_6 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_7 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_8 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_9 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_10 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_11 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_12 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_13 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_14 { get; set; }
        [DataMember]
        public string LinError3_AfterVer_15 { get; set; }
        [DataMember]
        public string Dis_LoadApplied_Min { get; set; }
        [DataMember]
        public string Dis_LoadApplied_Half { get; set; }
        [DataMember]
        public string Dis_LoadApplied_Max { get; set; }
        [DataMember]
        public string Dis_MPE_Min { get; set; }
        [DataMember]
        public string Dis_MPE_Half { get; set; }
        [DataMember]
        public string Dis_MPE_Max { get; set; }
        [DataMember]
        public string Rpt_Max_Load { get; set; }
        [DataMember]
        public string Rpt_Load_1 { get; set; }
        [DataMember]
        public string Rpt_Load_2 { get; set; }
        [DataMember]
        public string Rpt_Load_3 { get; set; }
        [DataMember]
        public string RPT_Error { get; set; }
        [DataMember]
        public string MarkNumber { get; set; }
        [DataMember]
        public string Eccent_Load_Max { get; set; }
        [DataMember]
        public string Eccent_Load_1 { get; set; }
        [DataMember]
        public string Eccent_Load_2 { get; set; }
        [DataMember]
        public string Eccent_Load_3 { get; set; }
        [DataMember]
        public string Eccent_Load_4 { get; set; }
        [DataMember]
        public string Eccent_Load_5 { get; set; }
        [DataMember]
        public string Eccent_Load_6 { get; set; }
        [DataMember]
        public string Eccent_Load_7 { get; set; }
        [DataMember]
        public string Eccent_Load_8 { get; set; }
        [DataMember]
        public string Eccent_Load_9 { get; set; }
        [DataMember]
        public string Eccent_Load_10 { get; set; }
        [DataMember]
        public string Eccent_Error_1 { get; set; }
        [DataMember]
        public string Eccent_Error_2 { get; set; }
        [DataMember]
        public string Eccent_Error_3 { get; set; }
        [DataMember]
        public string Eccent_Error_4 { get; set; }
        [DataMember]
        public string Eccent_Error_5 { get; set; }
        [DataMember]
        public string Eccent_Error_6 { get; set; }
        [DataMember]
        public string Eccent_Error_7 { get; set; }
        [DataMember]
        public string Eccent_Error_8 { get; set; }
        [DataMember]
        public string Eccent_Error_9 { get; set; }
        [DataMember]
        public string Eccent_Error_10 { get; set; }

        [DataMember]
        public string LinError1_BeforeCal_14 { get; set; }

    }
    [DataContract()]
    public class ScaleMainTask
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string TradeLiecense { get; set; }
        [DataMember]
        public string Stage { get; set; }
        [DataMember]
        public string ReqType { get; set; }
        [DataMember]
        public string VerificationType { get; set; }
        [DataMember]
        public string EntityName { get; set; }
        [DataMember]
        public string ContactN { get; set; }
        [DataMember]
        public string Contactp { get; set; }
        [DataMember]
        public string Task_Location { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string AssignedTo { get; set; }
    }
    [DataContract()]
    public class QabanahScales
    {



        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ScManufacturer { get; set; }
        [DataMember]
        public string ScSerialNo { get; set; }
        [DataMember]
        public string ScTypeApproval { get; set; }
        [DataMember]
        public string ScNumberofDisplay { get; set; }
        [DataMember]
        public string ScMax { get; set; }
        [DataMember]
        public string ScMin { get; set; }
        [DataMember]
        public string ScalVe { get; set; }
        [DataMember]
        public string ScalVd { get; set; }
        [DataMember]
        public string ScaleClass { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string BusinessCategory { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScaleCategory { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string ScModel { get; set; }
        [DataMember]
        public string CalculationType { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string Maximum2 { get; set; }
        [DataMember]
        public string eval2 { get; set; }
        [DataMember]
        public string ScalVd2 { get; set; }
        [DataMember]
        public string E_Unit { get; set; }
        [DataMember]
        public string InformatoinType { get; set; }
        [DataMember]
        public string Informationtypes { get; set; }
        [DataMember]
        public string Publics { get; set; }
        [DataMember]
        public string Suitable { get; set; }
        [DataMember]
        public string Exposed { get; set; }
        [DataMember]
        public string Shocks { get; set; }
        [DataMember]
        public string SizeLengt { get; set; }
        [DataMember]
        public string SizeWidth { get; set; }
        [DataMember]
        public string Supporters { get; set; }
        [DataMember]
        public string WeighhingType { get; set; }
        [DataMember]
        public string WeighingTypeManufacturere { get; set; }
        [DataMember]
        public string WeighingNomLoad { get; set; }
        [DataMember]
        public string ScaleInterval { get; set; }
        [DataMember]
        public string PrepairdBy { get; set; }
        [DataMember]
        public string ScaleNotes { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public string OldScaleId { get; set; }

    }
    public class QCCScalesReceipts
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Company_Name { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string FinalTestResults { get; set; }
        [DataMember]
        public string VerificationDate { get; set; }
        [DataMember]
        public string WeightSetClass { get; set; }
        [DataMember]
        public string TradingLiecense { get; set; }
        [DataMember]
        public string TaskId { get; set; }
        [DataMember]
        public string MarkNumber { get; set; }
        [DataMember]
        public string QCCTestId { get; set; }
        [DataMember]
        public string VerificationCharges { get; set; }
    }
    [DataContract()]
    public class QCCConsumers
    {

        [DataMember]
        public string ScaleId { get; set; }
        [DataMember]
        public string Created { get; set; }
        [DataMember]
        public string FinalTestResults { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        public string VerifiedMarck { get; set; }
        [DataMember]
        public string VerfiedMarckFail { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string ScaleSerial { get; set; }
    }
    #endregion
    #region Inspector Report
    [DataContract()]
    public class InspectorReport
    {

        [DataMember]
        public int EInitialTr { get; set; }
        [DataMember]
        public int EInitialGold { get; set; }
        [DataMember]
        public int EInitialOut { get; set; }
        [DataMember]
        public int EInitialCargo { get; set; }
        [DataMember]
        public int EPerTr { get; set; }
        [DataMember]
        public int EnPerGold { get; set; }
        [DataMember]
        public int EPerOud { get; set; }
        [DataMember]
        public int EPerCargo { get; set; }
        [DataMember]
        public int ERevTr { get; set; }
        [DataMember]
        public int ERevGold { get; set; }
        [DataMember]
        public int ERevOud { get; set; }
        [DataMember]
        public int EReCargo { get; set; }
        [DataMember]
        public int ECRMTR { get; set; }
        [DataMember]
        public int ECRMGold { get; set; }
        [DataMember]
        public int ECRMOUd { get; set; }
        [DataMember]
        public int ECRMCargo { get; set; }


        [DataMember]
        public int SCInitialTr { get; set; }
        [DataMember]
        public int SCInitialGold { get; set; }
        [DataMember]
        public int SCInitialOut { get; set; }
        [DataMember]
        public int SCInitialCargo { get; set; }
        [DataMember]
        public int SCPerTr { get; set; }
        [DataMember]
        public int SCPerGold { get; set; }
        [DataMember]
        public int SCPerOud { get; set; }
        [DataMember]
        public int SCPerCargo { get; set; }
        [DataMember]
        public int SCRevTr { get; set; }
        [DataMember]
        public int SCRevGold { get; set; }
        [DataMember]
        public int SCRevOud { get; set; }
        [DataMember]
        public int SCReCargo { get; set; }
        [DataMember]
        public int SCCRMTR { get; set; }
        [DataMember]
        public int ScCRMGold { get; set; }
        [DataMember]
        public int ScCRMOUd { get; set; }
        [DataMember]
        public int SCCRMCargo { get; set; }
        [DataMember]
        public int TotalFees { get; set; }


        [DataMember]
        public int VInitialTr { get; set; }
        [DataMember]
        public int VInitialGold { get; set; }
        [DataMember]
        public int VInitialOut { get; set; }
        [DataMember]
        public int VInitialCargo { get; set; }
        [DataMember]
        public int VPerTr { get; set; }
        [DataMember]
        public int VPerGold { get; set; }
        [DataMember]
        public int VPerOud { get; set; }
        [DataMember]
        public int VPerCargo { get; set; }
        [DataMember]
        public int VRevTr { get; set; }
        [DataMember]
        public int VRevGold { get; set; }
        [DataMember]
        public int VRevOud { get; set; }
        [DataMember]
        public int VReCargo { get; set; }
        [DataMember]
        public int VCRMTR { get; set; }
        [DataMember]
        public int VCRMGold { get; set; }
        [DataMember]
        public int VCRMOUd { get; set; }
        [DataMember]
        public int VCRMCargo { get; set; }
        [DataMember]
        public int RInitialTr { get; set; }
        [DataMember]
        public int RInitialGold { get; set; }
        [DataMember]
        public int RInitialOut { get; set; }
        [DataMember]
        public int RInitialCargo { get; set; }
        [DataMember]
        public int RPerTr { get; set; }
        [DataMember]
        public int RPerGold { get; set; }
        [DataMember]
        public int RPerOud { get; set; }
        [DataMember]
        public int RPerCargo { get; set; }
        [DataMember]
        public int RRevRTr { get; set; }
        [DataMember]
        public int RRevRGold { get; set; }
        [DataMember]
        public int RRevROud { get; set; }
        [DataMember]
        public int RRevCargo { get; set; }
        [DataMember]
        public int RCRMTR { get; set; }
        [DataMember]
        public int RCRMGold { get; set; }
        [DataMember]
        public int RCRMOUd { get; set; }
        [DataMember]
        public int RCRMCargo { get; set; }
    }
    public class ReVerification
    {
        [DataMember]
        public string TestStage { get; set; }
        [DataMember]
        public string ScaleId { get; set; }
        [DataMember]
        public string TestDate { get; set; }
        [DataMember]
        public string FinalTestResults { get; set; }
        [DataMember]
        public string ScaleRangeUsed { get; set; }
        [DataMember]
        public string ScaleMiniMum { get; set; }
        [DataMember]
        public string QCCTagNumber { get; set; }
        [DataMember]
        public string CompanyId { get; set; }
        [DataMember]
        public string VerificationConductedBy { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string EntityAddress { get; set; }
        [DataMember]
        public string RevisitDate { get; set; }
        [DataMember]
        public string ContatNumber { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }


    }

    public class QCCCustomer
    {
        [DataMember]
        public string TradingLicense { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string ContactPerson { get; set; }
        [DataMember]
        public string Fax { get; set; }
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
    [DataContract()]
    public class QCCCustomer1
    {
        [DataMember]
        public string BusinessCategory { get; set; }
        [DataMember]
        public string CUSTOMER_TYPE { get; set; }
        [DataMember]
        public string CUSTOMER_NAME { get; set; }
        [DataMember]
        public string CUSTOMER_CATEGORY_CODE { get; set; }
        [DataMember]
        public string CUSTOMER_CATEGORY_NAME { get; set; }
        [DataMember]
        public string CUSTOMER_CLASS_ID { get; set; }
        [DataMember]
        public string CUSTOMER_CLASS_NAME { get; set; }
        [DataMember]
        public string COUNTRY_CODE { get; set; }
        [DataMember]
        public string COUNTRY_NAME { get; set; }
        [DataMember]
        public string CITY { get; set; }
        [DataMember]
        public string ADDRESS1 { get; set; }
        [DataMember]
        public string ADDRESS2 { get; set; }
        [DataMember]
        public string ADDRESS3 { get; set; }
        [DataMember]
        public string ADDRESS4 { get; set; }
        [DataMember]
        public string POSTAL_CODE { get; set; }
        [DataMember]
        public string ATTRIBUTE10 { get; set; }
        [DataMember]
        public string TRADE_LICENSE_NUM { get; set; }
        [DataMember]
        public string CUSTOMER_CODE { get; set; }
        [DataMember]
        public string SITE_CODE { get; set; }
        [DataMember]
        public string CONTACT_PERSON { get; set; }
        [DataMember]
        public string CONTACT_NUMBER { get; set; }
        [DataMember]
        public string EMAIL_ADDRESS { get; set; }
        [DataMember]
        public string FAX_NO { get; set; }
        [DataMember]
        public string COLLECTOR_NAME { get; set; }
        [DataMember]
        public string SOURCE_SYSTEM_REF { get; set; }
        [DataMember]
        public string SOURCE_SYSTEM { get; set; }
        [DataMember]
        public string GENDER { get; set; }
        [DataMember]
        public string PERSON_IDEN_TYPE { get; set; }
        [DataMember]
        public string PERSON_IDENTIFIER { get; set; }
        [DataMember]
        public string DATE_OF_BIRTH { get; set; }
        [DataMember]
        public string PLACE_OF_BIRTH { get; set; }
        [DataMember]
        public string MARITAL_STATUS { get; set; }
        [DataMember]
        public string ZARO_CUSTOMER { get; set; }
        [DataMember]
        public string Createdby { get; set; }
        [DataMember]
        public string IsNewCustomer { get; set; }


    }
    [DataContract()]
    public class Catagories
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string CatagoryName { get; set; }
    }
    #endregion


}
