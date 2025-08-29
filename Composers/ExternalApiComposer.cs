using Umbraco.Cms.Core.Composing;
using Umbraco_Azure_test.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Umbraco_Azure_test.Composers
{
    public class ExternalApiComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>();
        }
    }
}
