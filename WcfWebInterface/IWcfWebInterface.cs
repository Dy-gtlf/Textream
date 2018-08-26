using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfWebInterface
{
    [ServiceContract]
    public interface IWcfWebInterface
    {
        [OperationContract]
        [WebGet]
        void MakeTextStream(string str);
    }
}
