using ApiSdk;
using ApiSdk.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace Hubspot
{
    public class Class1
    {
        public async Task stuff()
        {

            var authProvider = new AnonymousAuthenticationProvider();
            var requestAdapter = new HttpClientRequestAdapter(authProvider);
            ApiClient c = new ApiClient(requestAdapter);


            BatchReadInputSimplePublicObjectId inputs = new BatchReadInputSimplePublicObjectId
            {
                IdProperty = "udi_guid",
                Properties = new List<string> { "dsfsdjf" }
            };

            c.Crm.V3.Objects.Tickets.Batch.Read.ToPostRequestInformation(inputs);


            PublicObjectSearchRequest searchRequest = new PublicObjectSearchRequest()
            {
                FilterGroups = new List<FilterGroup> 
                { 
                    new FilterGroup 
                    {
                        Filters = new List<Filter>
                        {
                            new Filter
                            {
                                Operator = Filter_operator.EQ,
                                PropertyName = "associations.company",
                                Value = "123"
                            }
                        }
                    }
                }
            };
            var response = await c.Crm.V3.Objects.Tickets.Search.PostAsync(searchRequest);
            


            var specificTicket = await c.Crm.V3.Objects.Tickets["12321"].GetAsync();
            var bob = specificTicket!.Properties.AdditionalData["bob"];
        }



    }
}