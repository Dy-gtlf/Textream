using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfWebInterface
{
    [ServiceContract]
    public interface IWcfWebInterface
    {
        [OperationContract]
        [WebInvoke]
        void MakeTextStream(string str);
    }
}
