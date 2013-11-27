using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Web;
using Newtonsoft.Json;

using MyGames.Model;
namespace MyGames.Contracts
{
    [ServiceContract(Name = "MasterService", Namespace = "http://www.syfri.cn")]
    public interface IMaster
    {
        [OperationContract]
        [WebGet(UriTemplate = "Master/Register/{Account}/{Pwd}/{Email}", ResponseFormat = WebMessageFormat.Json)]
        //int Register(string account, string pwd, string email);
        OprResult Register(string account, string pwd, string email);

        [OperationContract]
        [WebGet(UriTemplate = "Master/Create/{AccountId}/{MasterName}/{Race}/{Professional}/{Sex}", ResponseFormat = WebMessageFormat.Json)]
        //int Create(string accountId, string masterName, string race, string professional, string sex);
        OprResult Create(string accountId, string masterName, string race, string professional, string sex);

        [OperationContract]
        [WebGet(UriTemplate = "Master/GetById/{MasterId}", ResponseFormat = WebMessageFormat.Json)]
        Master GetMasterById(string masterid);

        [OperationContract]
        [WebGet(UriTemplate = "Master/Logon/{AccountName}/{Password}", ResponseFormat = WebMessageFormat.Json)]
        //bool Logon(string accountName, string password);
        OprResult Logon(string accountName, string password);

        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        //double Multiply(double x, double y);

        //[OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        //double Divide(double x, double y);
    }
}
