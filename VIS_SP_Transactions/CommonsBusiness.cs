using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIS_SP_Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;
    using System.Configuration;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Data.Odbc;
    using System.Data;
    using DBHelper;

 


        /// <summary>
        /// Summary description for Common
        /// </summary>
        public class Common
        {


            private static string sql_conn_str = string.Empty;
            private static string mosaic_conn_str = string.Empty;

            private static string Iraqmosaic_conn_str = string.Empty;
            private static string Qatarmosaic_conn_str = string.Empty;
            private static string Ukmosaic_conn_str = string.Empty;
            private static string Egyptmosaic_conn_str = string.Empty;
            private static string Uaemosaic_conn_str = string.Empty;


            private static string prime_conn_str = string.Empty;

            public enum UserTypes
            {
                Requestor,

                HelpDesk,

                Legal,

                Admin,

                Approver,

                General,
            }

            public static string SQLConnectionString
            {
                get
                {
                    if (sql_conn_str == string.Empty)
                    {
                        sql_conn_str = GetSQLConnectionString();
                    }
                    return sql_conn_str;
                }
                set { sql_conn_str = value; }
            }


            private static string GetSQLConnectionString()
            {
                string connString = string.Empty;
                
               
                    //LIVE 
                //connString = "Server=QCCMSSQLCLUSTER\\QCCSQL01;Database=ClientsDB;Integrated Security=true; Pooling=False;";

                //DEVELOPMENT
                connString = "Data Source =  SP-APP1-DEV\\SQLSP2013; Initial Catalog = VIS; uid = sa; pwd = qcc@1234";
                return connString;
            }
            
            public static string SQLConnectionString_Employe
            {
                get
                {
                    if (sql_conn_str == string.Empty)
                    {
                        sql_conn_str = GetSQLConnectionString2();
                    }
                    return sql_conn_str;
                }
                set { sql_conn_str = value; }
            }


            private static string GetSQLConnectionString2()
            {
                string connString = string.Empty;
                // string Database = "";// ConfigurationManager.AppSettings["DB"];
                //string DBSErver = "QCCMSSQLCLUSTER\\QCCSQL01";// ConfigurationManager.AppSettings["SQLServer"];
                // StringBuilder sbCnnStr = new StringBuilder();
                // sbCnnStr.Append("Data Source=" + DBSErver + ";"); //+ ConfigurationManager.AppSettings["DBServer"] + ";");
                // sbCnnStr.Append("Initial Catalog=" +Database );// ConfigurationManager.AppSettings["DBSQL"] + ";");
                //sbCnnStr.Append(" uid = internet_install; pwd = qcc@12345");
                //connString = sbCnnStr.ToString();
                connString = "Server=QCCMSSQLCLUSTER\\QCCSQL01;Database=Securtimeweb;Integrated Security=true; Pooling=False;";
               // connString = "Server=QCCMSSQLCLUSTER\\QCCSQL01;Database=Securtimeweb; uid = intranet_install; pwd = Qcc@12345";
                return connString;
            }

            private static string GetClientDBConnectionString()
            {
                string connString = string.Empty;
                connString = "Server=QCCMSSQLCLUSTER\\QCCSQL01;Database=ClientsDB;Integrated Security=true; Pooling=False;";
                return connString;
            }

            public static string GetCustomerAccount(string TradeLicense)
            {
                string Result = string.Empty;
                try
                {
                    #region ODBC Method
                    string FF = "500";
                    object QccNumber = 0;
                    string app_name = "LIMS";
                    SqlHelper sqlHelper = new SqlHelper(Common.GetClientDBConnectionString().ToString(), SqlHelper.Providers.SqlServer);
                    for (int i = 0; i < 1; i++)
                    {
                        sqlHelper.AddParameter("@TRADELICENSE", TradeLicense, SqlDbType.NVarChar);
                    }
                    string cmd = string.Format("GETCUSTOMERACCOUNT", app_name);

                    DataTable _Response = new System.Data.DataTable();
                    _Response = sqlHelper.ExecuteDataTable("GETCUSTOMERACCOUNT", CommandType.StoredProcedure);
                    if (_Response != null)
                    {
                        FF = _Response.Rows.Count.ToString();
                        if (_Response.Rows.Count > 0)
                        {
                            Result = _Response.Rows[0][0].ToString();
                        }
                    }

                    #endregion
                }
                catch (System.Exception ex)
                {

                    throw;
                }
                return Result;
            }

            //public static DataTable FetchEmployeeInformatoinDB(string Employee, string Dt)
            //{
            //    #region ODBC Method
            //    SqlHelper sqlHelper = null;
            //    DataTable UserInfo = null;
            //    try
            //    {
            //        string app_name = "LIMS";//;ConfigurationManager.AppSettings["appname"].ToString();
            //        sqlHelper = new SqlHelper(Common.SQLConnectionString, SqlHelper.Providers.SqlServer);

            //        string cmd = string.Format("", app_name);

            //        UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
            //        return UserInfo;
            //    }

            //    catch (Exception ex)
            //    {
            //        //Logs.LogExceptions(ex, "Common.cs" + "Query=" + Query, "LoadDataTable");
            //        return null;
            //    }
            //    #endregion



            //}



            //Scales Client
            public static DataTable FetchCustomerInfoFromTradingLiecense(ArrayList _ParameterName, ArrayList Task_List, SqlDbType[] DbType)
            {
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                try
                {
                    string app_name = "LIMS";//;ConfigurationManager.AppSettings["appname"].ToString();
                    sqlHelper = new SqlHelper(Common.SQLConnectionString_Employe, SqlHelper.Providers.SqlServer);

                    string cmd = string.Format("Securtimeweb.dbo.QCC_WeeklyEmployeeExceptions", app_name);

                    for (int i = 0; i < _ParameterName.Count; i++)
                    {
                        sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                    }

                    UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
                    return UserInfo;
                }

                catch (Exception ex)
                {
                    throw new Exception("Exception" + ex.Message.ToString() + "You Enter Employe Id As :" + _ParameterName[0].ToString() + ":" + Task_List[0].ToString() + ":" + DbType[0].ToString() + "data as " + _ParameterName[1].ToString() + Task_List[1].ToString() + DbType[1].ToString());
                }
                #endregion
                return UserInfo;
            }

           


            public static DataTable FetchEmployeeInfoDB(ArrayList _ParameterName, ArrayList Task_List, SqlDbType[] DbType)
            {
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                try
                {
                    string app_name = "LIMS";//;ConfigurationManager.AppSettings["appname"].ToString();
                    sqlHelper = new SqlHelper(Common.SQLConnectionString_Employe, SqlHelper.Providers.SqlServer);

                    string cmd = string.Format("Securtimeweb.dbo.QCC_WeeklyEmployeeExceptions", app_name);

                    for (int i = 0; i < _ParameterName.Count; i++)
                    {
                            sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                    }

                    UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
                    return UserInfo;
                }

                catch (Exception ex)
                {
                    throw new Exception("Exception" + ex.Message.ToString() +"You Enter Employe Id As :" + _ParameterName[0].ToString() +":"+ Task_List[0].ToString() +":"+ DbType[0].ToString() + "data as " + _ParameterName[1].ToString() + Task_List[1].ToString() + DbType[1].ToString() );
                }
                #endregion
                return UserInfo;
            }




            public static DataTable FetchInforDBFromQCCClient(ArrayList _ParameterName, ArrayList Task_List, SqlDbType[] DbType,string ProceudreName)
            {
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                string Result = "";
                try
                {
                    string app_name = "QCCCS";//;ConfigurationManager.AppSettings["appname"].ToString();
                    sqlHelper = new SqlHelper(Common.SQLConnectionString, SqlHelper.Providers.SqlServer);

                    Result += _ParameterName.Count.ToString();
                    string cmd = string.Format(ProceudreName, app_name);
                    
                    for (int i = 0; i <_ParameterName.Count; i++)
                    {
                        sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                        Result += _ParameterName[i].ToString() + Task_List[i].ToString() + DbType[i] + "|";
                    }

                    UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
                    return UserInfo;
                }

                catch (Exception ex)
                {
                    //throw new Exception(ex.Message.ToString());
                    throw new Exception(ex.Message.ToString());
                }
                #endregion
                return UserInfo;


            }

            public static DataTable FetchInforDBFromQCCClientWithOutParam(ArrayList _ParameterName, ArrayList Task_List, SqlDbType[] DbType, string ProceudreName)
            {
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                try
                {
                    string app_name = "QCCCS";//;ConfigurationManager.AppSettings["appname"].ToString();
                    sqlHelper = new SqlHelper(Common.SQLConnectionString, SqlHelper.Providers.SqlServer);

                    string cmd = string.Format(ProceudreName, app_name);

                  //  for (int i = 0; i < _ParameterName.Count; i++)
                   // {
                      //  sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                   // }

                    UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
                    return UserInfo;
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
                #endregion
                return UserInfo;


            }

            public static int CreateTasks(string SpName, ArrayList Task_List, ArrayList _ParameterName, SqlDbType[] DbType)
            {
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                try
                {
                    string app_name = ConfigurationManager.AppSettings["appname"].ToString();
                    sqlHelper = new SqlHelper(Common.SQLConnectionString, SqlHelper.Providers.SqlServer);
                    //sqlHelper.AddParameter.AddParameter("@DocumentName", _List.DocumentName, SqlDbType.Text);
                    for (int i = 0; i < _ParameterName.Count; i++)
                    {
                        if (_ParameterName[i].ToString() == "@RequestIdGenerated")
                        {
                            sqlHelper.AddInputOutputParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                        }
                        else
                        {
                            sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                        }
                    }
                    string cmd = string.Format(SpName, app_name);
                    sqlHelper.ExecuteNonQuery(cmd, CommandType.StoredProcedure);
                    return 0;
                }
                catch (Exception ex)
                {

                    string _Param = string.Empty;
                    for (int i = 0; i < Task_List.Count; i++)
                    {
                        _Param = _Param + "," + Task_List[i];
                    }

                    string _getParameters = "Exec" + SpName + _Param;
                    Logs.LogExceptions(ex, "common Class", _getParameters);
                    throw ex;
                    return -1;
                }
                finally
                {
                    sqlHelper.Dispose();
                }
                #endregion





            }

            public static int ExecuteNonQueryWF(string SpName, object[] Task_List, object[] _ParameterName, SqlDbType[] DbType)
            {
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                object QccNumber = 0;
                try
                {
                    string app_name = "LIMNS";
                    sqlHelper = new SqlHelper(Common.SQLConnectionString, SqlHelper.Providers.SqlServer);
                    for (int i = 0; i < _ParameterName.Length; i++)
                    {
                        sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                    }
                    string cmd = string.Format(SpName, app_name);
                   // UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
                    QccNumber = sqlHelper.ExecuteScalar(cmd, CommandType.StoredProcedure);

                    //  DataTable _DNE = new System.Data.DataTable();
                    // _DNE = Common.LoadDataTable("ad2", "ad2");


                }
                catch (Exception ex)
                {
                    string _Param = string.Empty;
                    for (int i = 0; i < Task_List.Length; i++)
                    {
                        _Param = _Param + "," + Task_List[i];
                    }

                    string _getParameters = "Exec" + SpName + _Param;
                    Logs.LogExceptions(ex, "common Class", _getParameters);
                    throw new Exception("eRROR FORM DB");
                }
                finally
                {
                    sqlHelper.Dispose();
                }
                //QccNumber;
                int FF;
                if (QccNumber != null)
                {
                    FF = Int32.Parse(QccNumber.ToString());
                }
                else
                {
                    FF = -100;
                }
                return FF;
                #endregion
            }


            public static string ExecuteNonQueryWFScales(string SpName, object[] Task_List, object[] _ParameterName, SqlDbType[] DbType)
            {
                string Result = "";
                #region ODBC Method
                SqlHelper sqlHelper = null;
                DataTable UserInfo = null;
                object QccNumber = 0;
                try
                {
                    string app_name = "LIMNS";
                    sqlHelper = new SqlHelper(Common.SQLConnectionString, SqlHelper.Providers.SqlServer);
                    for (int i = 0; i < _ParameterName.Length; i++)
                    {
                        sqlHelper.AddParameter(_ParameterName[i].ToString(), Task_List[i], DbType[i]);
                    }
                    string cmd = string.Format(SpName, app_name);
                    // UserInfo = sqlHelper.ExecuteDataTable(cmd, CommandType.StoredProcedure);
                    QccNumber = sqlHelper.ExecuteScalar(cmd, CommandType.StoredProcedure);

                    //  DataTable _DNE = new System.Data.DataTable();
                    // _DNE = Common.LoadDataTable("ad2", "ad2");


                }
                catch (Exception ex)
                {
                    string _Param = string.Empty;
                    for (int i = 0; i < Task_List.Length; i++)
                    {
                        _Param = _Param + "," + Task_List[i];
                    }

                    string _getParameters = "Exec" + SpName + _Param;
                   // Logs.LogExceptions(ex, "common Class", _getParameters);
                    //throw new Exception("eRROR FORM DB");
                    Result += ex.Message.ToString();
                }
                finally
                {
                    sqlHelper.Dispose();
                }
                //QccNumber;
                int FF;
                if (QccNumber != null)
                {
                    Result += QccNumber.ToString();
                }
                else
                {
                    Result +=  "-100";
                }
                return Result;
                #endregion
            }



            public static void LogSystemException(string MedthodName, string Error, string ErrorDetails, string Classses)
            {
                try
                {
                    object[] param = new object[4];
                    object[] data = new object[4];
                    SqlDbType[] dbtype = new SqlDbType[4];
                    #region SettingDBTpe
                    dbtype[0] = SqlDbType.NVarChar;
                    dbtype[1] = SqlDbType.NVarChar;
                    dbtype[2] = SqlDbType.NVarChar;
                    dbtype[3] = SqlDbType.NVarChar;
                    #endregion
                    #region Setting Parameters
                    param[0] = "@METHODNAME";
                    param[1] = "@ERROR";
                    param[2] = "@ERRORDETAIL";
                    param[3] = "@CLAS";
                    #endregion
                    #region Setting Data
                    data[0] = MedthodName;
                    data[1] = Error;
                    data[2] = ErrorDetails;
                    data[3] = Classses;
                    #endregion
                    int QccIdentifier = Common.ExecuteNonQueryWF("[CREATEEXCEPTIONWEB]", data, param, dbtype);
                }
                catch (Exception ex)
                {
                    string ErrorMessage = Convert.ToString(ex.Message.ToString());
                    //Common.LogSystemException("LogSystemException", ErrorMessage, ErrorMessage, "Common");
                }
            }


        }

        public class EmailContentBody
        {
            #region public properties
            private string _Content = string.Empty;

            #endregion
        }

        public class MiddleWare
        {



            public string CreateCustomer_OnWire(string Company_Name, string bscatagorie,string buscatagorycode, string CompanyAddress, string loccity, string POBox, string FaxNumber, string ContactPerson,
                string ContactNumber,
                string EmailId, string TradingLiecense, string inspctor)
            {
                string Res = string.Empty;
                try
                {
                    //Array
                    object[] param = new object[35];
                    object[] data = new object[35];
                    SqlDbType[] dbtype = new SqlDbType[35];

                    #region SettingDBTpe
                    dbtype[0] = SqlDbType.NVarChar;
                    dbtype[1] = SqlDbType.NVarChar;
                    dbtype[2] = SqlDbType.NVarChar;
                    dbtype[3] = SqlDbType.NVarChar;
                    dbtype[4] = SqlDbType.NVarChar;
                    dbtype[5] = SqlDbType.NVarChar;
                    dbtype[6] = SqlDbType.NVarChar;
                    dbtype[7] = SqlDbType.NVarChar;
                    dbtype[8] = SqlDbType.NVarChar;
                    dbtype[9] = SqlDbType.NVarChar;
                    dbtype[10] = SqlDbType.NVarChar;
                    dbtype[11] = SqlDbType.NVarChar;
                    dbtype[12] = SqlDbType.NVarChar;
                    dbtype[13] = SqlDbType.NVarChar;
                    dbtype[14] = SqlDbType.NVarChar;
                    dbtype[15] = SqlDbType.NVarChar;
                    dbtype[16] = SqlDbType.NVarChar;
                    dbtype[17] = SqlDbType.NVarChar;
                    dbtype[18] = SqlDbType.NVarChar;
                    dbtype[19] = SqlDbType.NVarChar;
                    dbtype[20] = SqlDbType.NVarChar;
                    dbtype[21] = SqlDbType.NVarChar;
                    dbtype[22] = SqlDbType.NVarChar;
                    dbtype[23] = SqlDbType.NVarChar;
                    dbtype[24] = SqlDbType.NVarChar;
                    dbtype[25] = SqlDbType.NVarChar;
                    dbtype[26] = SqlDbType.NVarChar;
                    dbtype[27] = SqlDbType.NVarChar;
                    dbtype[28] = SqlDbType.NVarChar;
                    dbtype[29] = SqlDbType.NVarChar;
                    dbtype[30] = SqlDbType.NVarChar;
                    dbtype[31] = SqlDbType.NVarChar;
                    dbtype[32] = SqlDbType.NVarChar;
                    dbtype[33] = SqlDbType.NVarChar;
                    dbtype[34] = SqlDbType.NVarChar;

                    #endregion

                    #region Setting Parameters
                    param[0] = "@CUSTOMER_TYPE";
                    param[1] = "@CUSTOMER_NAME ";
                    param[2] = "@CUSTOMER_CATEGORY_CODE ";
                    param[3] = "@CUSTOMER_CATEGORY_NAME";
                    param[4] = "@CUSTOMER_CLASS_ID";
                    param[5] = "@CUSTOMER_CLASS_NAME";
                    param[6] = "@COUNTRY_CODE";
                    param[7] = "@COUNTRY_NAME";
                    param[8] = "@CITY";
                    param[9] = "@ADDRESS1";
                    param[10] = "@ADDRESS2";
                    param[11] = "@ADDRESS3";
                    param[12] = "@ADDRESS4";
                    param[13] = "@POSTAL_CODE";
                    param[14] = "@ATTRIBUTE10";
                    param[15] = "@TRADE_LICENSE_NUM";
                    param[16] = "@CUSTOMER_CODE ";
                    param[17] = "@SITE_CODE";
                    param[18] = "@CONTACT_PERSON";
                    param[19] = "@CONTACT_NUMBER";
                    param[20] = "@EMAIL_ADDRESS ";
                    param[21] = "@FAX_NO ";
                    param[22] = "@COLLECTOR_NAME";
                    param[23] = "@SOURCE_SYSTEM_REF";
                    param[24] = "@SOURCE_SYSTEM ";
                    param[25] = "@GENDER ";
                    param[26] = "@PERSON_IDEN_TYPE ";
                    param[27] = "@PERSON_IDENTIFIER";
                    param[28] = "@DATE_OF_BIRTH ";
                    param[29] = "@PLACE_OF_BIRTH";
                    param[30] = "@MARITAL_STATUS";
                    param[31] = "@ZARO_CUSTOMER";
                    param[32] = "@Createdby";
                    param[33] = "@IsNewCustomer";
                    param[34] = "@CustomerFlag";
                    #endregion

                    #region Setting Data
                    if (buscatagorycode == null)
                    {
                        buscatagorycode = "";
                    }

                    data[0] = "ORGANIZATION";
                    data[1] = Company_Name;
                    data[2] = bscatagorie;
                    data[3] = buscatagorycode;
                    data[4] = "";
                    data[5] = "";
                    data[6] = "AE";
                    data[7] = "United Arab Emirates";
                    data[8] = loccity;// "CITY";
                    data[9] = CompanyAddress;// "ADDRESS1";
                    data[10] = CompanyAddress;// "ADDRESS2";
                    data[11] = CompanyAddress;// "ADDRESS3";
                    data[12] = "";
                    data[13] = POBox;
                    data[14] = "";
                    data[15] = TradingLiecense; //"TRADE_LICENSE_NUM";
                    data[16] = "";//"CUSTOMER_CODE";
                    data[17] = "";
                    data[18] = ContactPerson;// "CONTACT_PERSON";
                    data[19] = ContactNumber;// "CONTACT_NUMBER";
                    data[20] = EmailId;// "EMAIL_ADDRESS";
                    data[21] = FaxNumber;// "FAX_NO";
                    data[22] = inspctor;// "COLLECTOR_NAME";
                    data[23] = "QCC";
                    data[24] = "QCC";
                    data[25] = "MALE";
                    data[26] = "";
                    data[27] = "";
                    data[28] = "";
                    data[29] = "";
                    data[30] = "";
                    data[31] = "N";
                    data[32] = inspctor;// "Createdby";
                    data[33] = "Yes";
                    data[34] = "Scale Customer";
                    #endregion

                    string QccIdentifier = Common.ExecuteNonQueryWFScales("ClientsDB.dbo.CreateCustomer", data, param, dbtype);
                    if (QccIdentifier.ToString() != null)
                    {
                        Res = QccIdentifier.ToString();
                    }
                    else
                    {
                        Res = "Null";
                    }

                }
                catch (Exception r)
                {

                    Res = r.Message.ToString();
                }
                return Res;
            }


            public DataTable FetchEmployeeInformatin(string EmployeeId, string Date)
            {
               // DataTable X = new DataTable();
                try
                {
                    ArrayList _Param = new ArrayList();
                    ArrayList data = new ArrayList();
                    SqlDbType[] dbtype = new SqlDbType[2];
                    dbtype[0] = SqlDbType.NVarChar;
                    dbtype[1] = SqlDbType.DateTime;
                   // string[] Tempx = EmployeeId.Split('=');

                    //if (EmployeeId.IndexOf('=') > 0)
                   // {

                   // }


                   
                  //  data.Add(Tempx[1]);
                    data.Add(EmployeeId);
                    //string[] Tempx1 = Date.Split('=');
                    data.Add(Date);
                    _Param.Add("@Emp_ID");
                    _Param.Add("@PDate");
                    DataTable _Result = Common.FetchEmployeeInfoDB(_Param, data, dbtype);
                    return _Result;
                }
                catch (Exception ex)
                {
                   throw;
                }


            }


           


            //FetchCustomer for Consumer Safety and Sales
            public DataTable FetchQCCEmployer(string TradingLiecense)
            {
                ArrayList _Param = new ArrayList();
                ArrayList data = new ArrayList();
                SqlDbType[] dbtype = new SqlDbType[1];
                dbtype[0] = SqlDbType.NVarChar;
                _Param.Add("@TradingLiecnese");
                data.Add(TradingLiecense);

                DataTable _Result = Common.FetchInforDBFromQCCClient(_Param, data, dbtype, "UserInformation");
                return _Result;

            }


            public DataTable FechQccCustomerAdressWithID(string TradingLiecense)
            {
                ArrayList _Param = new ArrayList();
                ArrayList data = new ArrayList();
                SqlDbType[] dbtype = new SqlDbType[1];
                dbtype[0] = SqlDbType.NVarChar;
                _Param.Add("@Check");
                data.Add(TradingLiecense);

                DataTable _Result = Common.FetchInforDBFromQCCClient(_Param, data, dbtype, "getCustomerAddress");
                return _Result;

            }
           

            public DataTable FetchBusinessCatagories()
            {
                ArrayList _Param = new ArrayList();
                ArrayList data = new ArrayList();
                SqlDbType[] dbtype = new SqlDbType[1];
                dbtype[0] = SqlDbType.NVarChar;
                _Param.Add("@TradingLiecnese");
                data.Add("");
                DataTable _Result = Common.FetchInforDBFromQCCClientWithOutParam(_Param, data, dbtype, "ClientsDB.dbo.GetBusinessCatagories");
                return _Result;

            }







        }



    


}