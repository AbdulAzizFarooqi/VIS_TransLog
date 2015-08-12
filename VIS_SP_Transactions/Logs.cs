using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for Logs
/// </summary>
public class Logs
{
    public Logs()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void LogExceptions(Exception Ex, string Page, string method)
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "Exceptions.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.Append("***********************************" + DateTime.Now.ToString() + "***********************************");
        _BuilderException.AppendLine();
        _BuilderException.Append(Ex.Message.ToString());
        _BuilderException.AppendLine();
        _BuilderException.AppendLine();
        //page
        _BuilderException.Append("Page :" + Page);
        _BuilderException.AppendLine();

        _BuilderException.AppendLine();
        //mehotd
        _BuilderException.Append("Method :" + method);
        _BuilderException.AppendLine();
        if (Ex.InnerException != null)
        {
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.InnerException.ToString());
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.Message.ToString());
            _BuilderException.AppendLine();
        }

        _BuilderException.Append("*****************************************************************************************************");
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }
    public static void LogExceptionsBulkUpload(Exception Ex, string Page, string method)
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "Bulk_Exceptions.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.Append("***********************************" + DateTime.Now.ToString() + "***********************************");
        _BuilderException.AppendLine();
        _BuilderException.Append(Ex.Message.ToString());
        _BuilderException.AppendLine();
        _BuilderException.AppendLine();
        //page
        _BuilderException.Append("Page :" + Page);
        _BuilderException.AppendLine();

        _BuilderException.AppendLine();
        //mehotd
        _BuilderException.Append("Method :" + method);
        _BuilderException.AppendLine();
        if (Ex.InnerException != null)
        {
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.InnerException.ToString());
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.Message.ToString());
            _BuilderException.AppendLine();
        }

        _BuilderException.Append("*****************************************************************************************************");
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }
    public static void LogExceptionsBulkUploadFunction(Exception Ex, string Page, string method)
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "Bulk_ExceptionsFuncation.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.Append("***********************************" + DateTime.Now.ToString() + "***********************************");
        _BuilderException.AppendLine();
        _BuilderException.Append(Ex.Message.ToString());
        _BuilderException.AppendLine();
        _BuilderException.AppendLine();
        //page
        _BuilderException.Append("Page :" + Page);
        _BuilderException.AppendLine();

        _BuilderException.AppendLine();
        //mehotd
        _BuilderException.Append("Method :" + method);
        _BuilderException.AppendLine();
        if (Ex.InnerException != null)
        {
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.InnerException.ToString());
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.Message.ToString());
            _BuilderException.AppendLine();
        }

        _BuilderException.Append("*****************************************************************************************************");
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }
    public static void LogExceptionsBulkUploadFunctionStepLogsStart()
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "Bulk_ExceptionsFuncationStep.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.Append("***********************************" + DateTime.Now.ToString() + "***********************************");
        _BuilderException.Append("***********************************Start Processing File Bulk Upload***********************************");
        _BuilderException.AppendLine();
        _BuilderException.AppendLine();
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }
    public static void LogExceptionsBulkUploadFunctionStepLogs(string Step, string method)
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "Bulk_ExceptionsFuncationStep.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.Append(Step.ToString() + ":" + method);
        _BuilderException.AppendLine();
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }
    public static void LogExceptionsBulkUploadFunctionStepLogsEnd()
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "Bulk_ExceptionsFuncationStep.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.AppendLine();
        _BuilderException.Append("*****************************************************************************************************");
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }
    public static void LogExceptionsBulkUploadFunctionStepLogsTransaction(string RowNumber, string _Status, string Status)
    {

        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "EachTransactionPosting.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.AppendLine();
        if (_Status == "10000")
        {
            _BuilderException.Append("*********************");
            _BuilderException.Append(DateTime.Now.ToString() + "FileName" + RowNumber);
            _BuilderException.Append("*********************");
            StreamWriter _Sche_Log_ = new StreamWriter(_SchLogs, true, Encoding.Default);
            _Sche_Log_.WriteLine(_BuilderException);
            _Sche_Log_.Close();
        }
        else
        {
            if (_Status == "5000")
            {
                _BuilderException.Append("*********************");
                _BuilderException.Append("*********************");
                StreamWriter _Sche_Log_500 = new StreamWriter(_SchLogs, true, Encoding.Default);
                _Sche_Log_500.WriteLine(_BuilderException);
                _Sche_Log_500.Close();
            }
            if (_Status == "0") { _BuilderException.Append("Transaction for Rownumber " + RowNumber + "Status is Success"); }
            else
            {
                _BuilderException.Append("Transaction for Rownumber " + RowNumber + "Status is Failed");
            }
            StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
            _Sche_Log.WriteLine(_BuilderException);
            _Sche_Log.Close();
        }

        //else
        //{
        //    string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "EachTransactionPosting.txt";
        //    StringBuilder _BuilderException = new StringBuilder();
        //    _BuilderException.AppendLine();
        //    if (_Status == "0") { _BuilderException.Append("Transaction for Rownumber " + RowNumber + "Status is Success"); }
        //    else
        //    { _BuilderException.Append("Transaction for Rownumber " + RowNumber + "Status is Failed"); }
        //    StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        //    _Sche_Log.WriteLine(_BuilderException);
        //    _Sche_Log.Close();
        //}
    }

    public static void LogExceptionsEmails(Exception Ex, string Page, string method)
    {
        string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "EamilExceptions.txt";
        StringBuilder _BuilderException = new StringBuilder();
        _BuilderException.Append("***********************************" + DateTime.Now.ToString() + "***********************************");
        _BuilderException.AppendLine();
        _BuilderException.Append(Ex.Message.ToString());
        _BuilderException.AppendLine();
        _BuilderException.AppendLine();
        //page
        _BuilderException.Append("Page :" + Page);
        _BuilderException.AppendLine();

        _BuilderException.AppendLine();
        //mehotd
        _BuilderException.Append("Method :" + method);
        _BuilderException.AppendLine();
        if (Ex.InnerException != null)
        {
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.InnerException.ToString());
            _BuilderException.AppendLine();
            _BuilderException.Append(Ex.Message.ToString());
            _BuilderException.AppendLine();
        }

        _BuilderException.Append("*****************************************************************************************************");
        StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
        _Sche_Log.WriteLine(_BuilderException);
        _Sche_Log.Close();
    }

    public static void EmailStepLoggin(string Step, string method)
    {
        string LogginEmalCheck = System.Configuration.ConfigurationSettings.AppSettings["LogForEmailIsGoingorNot"].ToString();
        if (LogginEmalCheck == "YES")
        {
            string _SchLogs = System.Configuration.ConfigurationSettings.AppSettings["ServiceLogFolder"].ToString() + "EmailStepLogging.txt";
            StringBuilder _BuilderException = new StringBuilder();
            _BuilderException.Append(Step.ToString() + ":" + method);
            _BuilderException.AppendLine();
            StreamWriter _Sche_Log = new StreamWriter(_SchLogs, true, Encoding.Default);
            _Sche_Log.WriteLine(_BuilderException);
            _Sche_Log.Close();
        }
    }


}
