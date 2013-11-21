using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Web;
using Newtonsoft.Json;

namespace MyGames.Contracts
{
    [ServiceContract(Name = "CalculatorService", Namespace = "http://www.syfri.cn")]
    public interface ICalculator
    {
        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        double Add(double x, double y);

        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        double Subtract(double x, double y);

        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        double Multiply(double x, double y);

        [OperationContract, WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        double Divide(double x, double y);
    }
}
