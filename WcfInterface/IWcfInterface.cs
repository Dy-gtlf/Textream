using System.ServiceModel;

namespace WcfInterface
{
    [ServiceContract]
    public interface IWcfInterface
    {
        [OperationContract]
        void MakeTextStream(string str);
    }
}