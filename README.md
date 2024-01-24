
## What is Microsoft Kiota?
Microsoft Kiota is a commandline-based API generator. You can generate multiple languages of code from the one tool (obviously, we'd use C#)

### Where to get Kiota?
Kiota can be downloaded from https://github.com/microsoft/kiota. Download the Win-x64.zip from the releases page in on windows, or osx-x64 if on a mac, and extract into a directory.
Open a terminal/command window and navigate to that directory.

### How do I generate an API?
Kiota can generate an API from an OpenAPI specification. For example, the HubSpot OpenAPI's are defined here: https://api.hubspot.com/api-catalog-public/v1/apis

Let's take the Tickets api as an example:

```json
   "Tickets": {
		"openAPI": "https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/objects/tickets",
		"stage": "LATEST"
	},
```

The OpenAPI url is defined above. Let's take that url, and generate our API:

```
kiota generate -d <OpenAPI URL HERE> -o <OUTPUT DIRECTORY HERE> -l CSharp
```
so, for example:

```
kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/objects/tickets -o c:\dev\hubspot-api\ -l CSharp
```
To generate the api client for tickets.


### Pre-requisites for using the generated code

In order to be able to use the generated code, there are a few Nuget packages that should be installed before carrying on:

```
Microsoft.Kiota.Abstractions
Microsoft.Kiota.Http.HttpClientLibrary
Microsoft.Kiota.Serialization.Form
Microsoft.Kiota.Serialization.Json
Microsoft.Kiota.Serialization.Text
Microsoft.Kiota.Serialization.Multipart
```


### How to use this generated client

Kiota-generated API's require a little setup, but nothing too complicated (when you know what to do, that is!)
First, you need to create an authentication provider.

```CSharp
	var authProvider = new ApiKeyAuthenticationProvider("Bearer <your bearer token here>", "Authorization", KeyLocation.Header);
``` 
(There are other authentication providers, or you can create your own if there's nothing suitable out of the box)

Then, you define the Request Adapter, passing in the authentication provider
```CSharp
	var requestAdapter = new HttpClientRequestAdapter(authProvider);
```
Finally, you can define your client
```CSharp
	var _client = new ApiClient(requestAdapter);
```

So a fully-defined api client would be:

```CSharp
	var authProvider = new ApiKeyAuthenticationProvider("Bearer <your bearer token here>", "Authorization", KeyLocation.Header);
	var requestAdapter = new HttpClientRequestAdapter(authProvider);
	var _client = new ApiClient(requestAdapter);
```

This should be all you need to get a basic api client working.



### How to use this generated client - continued

It appears that any sub-paths in a url will end up being an object/heirachy when generated.
For example, the HubSpot url to get a Ticket would be `/crm/v3/objects/tickets'.

This ends up being generated as:

```var tickets = await _client.Crm.V3.Objects.Tickets.GetAsync();```



## HubSpot-Specific elements

To be able to retrieve a `Ticket` from hubspot, when you _know_ the ticket id, you can pass that Id into the `Tickets` property.

```CSharp
	var knownTicketResponse = await _client.Crm.V3.Objects.Tickets["<YOUR_TICKET_ID>"].GetAsync();
```
This will make a call for your ticket Id, and return it.

The HubSpot API's are defined in such a way that there's not a defined list of properties for a ticket, or company, or note etc. They all have a generic list of responses that can vary between calls.

For example, a ticket response might have a response of:

```json
	"Results": [
		{
		"Id": "TicketId",
		"CreatedDate": "xxxx",
		"UpdatedDate": "xxxx",
		"Properties": [
				{
					"hs_body": "Body text of ticket",
					"hs_html_content": "Some HTML Body content in HTML",
					"subject": "This is the Ticket Subject"
				}
			]
		}
	]
```

Whereas a Company might have:

```json
	"Results": [
		{
		"Id": "CompanyId",
		"CreatedDate": "xxxx",
		"UpdatedDate": "xxxx",
		"Properties": [
			{
				"hs_body_content" : "Body text of ticket",
				"hs_company_name" : "Company Name",
				"hs_company_address" : "Some Address"
			}
			]
		}
	]
```

The `Properties` element is where 90% of the data you'd need will live.
Luckily, you can just access the generic data from the `AdditionalData` array when you have returned your object:

```CSharp
	var tickets = await _client.Crm.V3.Objects.Tickets.GetAsync();
	var subject = tickets.Results.FirstOrDefault().Properties.AdditionalData["subject"];      // Gets the Subject from the ticket properties
```


### Searching
You can do searches in HubSpot. This requires the use of a Filter, and is down via a `POST`

```CSharp
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
```
 

## Notes

This is early days for my investigations with Kiota, but it seems to be quite easy to use, once you understand how things work. (and I've only tried with the HubSpot api at present, so YMMV)

One thing I've not figured out as of yet, is error handing. If, for example, you do a search for a ticket id that doesn't exist, this will thrown an exception, rather than return an Http error response.
You can do Middleware things to catch these, but I've not tried those as of this writing.


The HubSpot api is split up into it's constituent parts, with an OpenAPI spec for each part (one for Tickets, one for Companies, one for Notes etc). I haven't found a way of being able to combine these, without manually modifying the OpenAPI spec. This currently would generate a client for each section - which may not be what we want.


### Error Responses
Kiota will generate error responses, if they have been defined in the OpenAPI specification.
if an error is returned from HubSpot, such as a 400, or 500 error, then an exception will be thrown - so any calls will need to be try/caught.

What _doesn't_ appear to happen currently, is that if a 'default' error catch-all has been defined, then it won't generate a specific error model, and will have the standard kiota error.
This standard error does _not_ give any indication on what has actually gone wrong - it will just return that it's the standard error response, because no error factories have been registered. I couldn't find any info on what/how to register your own.

What I _have_ found, is that the OpenAPI spec for HubSpot, contains the 'StandardError' response, which looks like this:

```json
{
  "subCategory": {},
  "context": {
    "additionalProp1": [
      "string"
    ],
    "additionalProp2": [
      "string"
    ],
    "additionalProp3": [
      "string"
    ]
  },
  "links": {
    "additionalProp1": "string",
    "additionalProp2": "string",
    "additionalProp3": "string"
  },
  "id": "string",
  "category": "string",
  "message": "string",
  "errors": [
    {
      "subCategory": "string",
      "code": "string",
      "in": "string",
      "context": {
        "missingScopes": [
          "scope1",
          "scope2"
        ]
      },
      "message": "string"
    }
  ],
  "status": "string"
}
```
is present in the OpenAPI spec. If you modify the specification, and add in the specifics that you want to catch for, for example:

```json
"post": {
        "tags": [
          "Basic"
        ],
        "summary": "Create",
        "description": "Create a ticket with the given properties and return a copy of the object, including the ID. Documentation and examples for creating standard tickets is provided.",
        "operationId": "post-/crm/v3/objects/tickets_create",
        "parameters": [],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/SimplePublicObjectInputForCreate"
              }
            }
          },
          "required": true
        },
        "responses": {
          "201": {
            "description": "successful operation",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/SimplePublicObject"
                }
              }
            }
          },

          // this is the new bit
          "400": {
            "description": "400 error",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/StandardError"
                }
              }
            }
          },
          // end of the new bit

          "default": {
            "$ref": "#/components/responses/Error"
          }
        }
      }
```
Then the `StandardError` model will be created, and you will be able to try/catch for that StandardError.
Of course, this does mean that an edit of the OpenAPI spec is required - which, isn't great. One of the benefits of being able to generate everything, is that when changes happen, you can just re-generate your client.
if we have to then modify the specs to add error models in each time.. bleh.



### Sample Unit Test document to show example usage

```CSharp
using ApiSdk;
using ApiSdk.Models;
using FluentAssertions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly ApiClient _client;

        public UnitTest1()
        {
            ApiKeyAuthenticationProvider authProvider = new ApiKeyAuthenticationProvider("Bearer pat-eu1-d4a84933-387a-48ac-afb8-d3ccc8a5245d", "Authorization", ApiKeyAuthenticationProvider.KeyLocation.Header);
            HttpClientRequestAdapter requestAdapter = new HttpClientRequestAdapter(authProvider);
            _client = new ApiClient(requestAdapter);
        }



        /// <summary>
        /// Gets a list of tickets
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetTickets()
        {
            // ACT
            var tickets = await _client.Crm.V3.Objects.Tickets.GetAsync();

            // ASSERT
            tickets.Should().NotBeNull();
            tickets.Results.Should().HaveCountGreaterThan(0);
        }



        /// <summary>
        /// Gets a ticket with a known Id
        /// </summary>
        /// <param name="ticketId"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("2272511418")]
        public async Task GetTicketById(string ticketId)
        {
            var ticket = await _client.Crm.V3.Objects.Tickets[ticketId].GetAsync();

            ticket.Should().NotBeNull();
            ticket.Properties.AdditionalData["subject"].Should().Be("Test Ticket");
        }




        /// <summary>
        /// Finds a ticket with the [subject] of "Test Ticket"
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("Test Ticket")]
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
                                Operator = Filter_operator.EQ,	// the operator - EQ(uals), IN, BETWEEN etc.
                                PropertyName = "subject",		// the name of the property you want to search
                                Value = query					// the query value to search for
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
```




