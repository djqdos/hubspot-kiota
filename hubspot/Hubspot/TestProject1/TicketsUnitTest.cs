using FluentAssertions;
using True.Services.HubSpot.Tickets;
using True.Services.HubSpot.Tickets.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;


namespace TestProject1
{
    public class TicketsUnitTest
    {
        private readonly HubSpotTicketsClient _client; 

        public TicketsUnitTest()
        {
            ApiKeyAuthenticationProvider authProvider = new ApiKeyAuthenticationProvider("Bearer pat-eu1-d4a84933-387a-48ac-afb8-d3ccc8a5245d", "Authorization", ApiKeyAuthenticationProvider.KeyLocation.Header);
            HttpClientRequestAdapter requestAdapter = new HttpClientRequestAdapter(authProvider);
            _client = new HubSpotTicketsClient(requestAdapter);
        }




        [Fact]
        public async Task Test1()
        {
            // ARRANGE

            // ACT
            var tickets = await _client.Crm.V3.Objects.Tickets.GetAsync();
            var subject = tickets.Results.FirstOrDefault().Properties.AdditionalData["subject"];

            // ASSERT
            tickets.Should().NotBeNull();
        }

        [Theory]
        [InlineData("2272511418")]
        public async Task GetTicketById(string ticketId)
        {
            var ticket = await _client.Crm.V3.Objects.Tickets[ticketId].GetAsync();

            ticket.Should().NotBeNull();
            ticket.Properties.AdditionalData["subject"].Should().Be("Test Ticket");
        }


        [Theory]
        [InlineData("2272511418")]
        public async Task GetTicketById2(string ticketId)
        {
            try
            {
                var ticket = await _client.Crm.V3.Objects.Tickets[ticketId].GetAsync();

                ticket.Should().NotBeNull();
                
                ticket.Properties.AdditionalData["subject"].Should().Be("Test Ticket");

            }
            catch (Exception ex)
            {

            }
        }


        [Theory]
        [InlineData("Test Ticket2")]
        public async Task GetTicketByFilter(string query)
        {

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
                                PropertyName = "subject",
                                Value = query
                            }
                        }
                    }
                }
            };
            var response = await _client.Crm.V3.Objects.Tickets.Search.PostAsync(searchRequest);

            response.Should().NotBeNull(); 

        }


    }
}