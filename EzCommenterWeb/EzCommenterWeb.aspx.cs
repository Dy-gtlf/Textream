using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfWebInterface;

namespace EzCommenterWeb
{
    public partial class EzCommenterWeb : System.Web.UI.Page
    {
        private ChannelFactory<IWcfWebInterface> channelFactory;
        private string uri;
        private IWcfWebInterface service;

        protected void Page_Load(object sender, EventArgs e)
        {
            uri = $@"http://{Request.Url.Host}/Textream";
            channelFactory = new ChannelFactory<IWcfWebInterface>(new WebHttpBinding(), uri);
            channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            service = channelFactory.CreateChannel();
        }

        protected void TransmissionButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Comment.Text))
            {
                service.MakeTextStream(Comment.Text);
            }
            Comment.Text = "";
        }
    }
}