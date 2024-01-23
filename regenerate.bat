kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/objects/tickets -o ./Hubspot/HubSpot/HubSpot.Tickets -l CSharp -c HubSpotTicketsClient -n True.Services.HubSpot.Tickets

kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/associations -o ./Hubspot/HubSpot/HubSpot.Associations -l CSharp -c HubSpotAssociationsClient -n True.Services.HubSpot.Associations

kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/objects/companies -o ./Hubspot/HubSpot/HubSpot.Companies -l CSharp -c HubSpotCompaniesClient -n True.Services.HubSpot.Companies

kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/objects/contacts -o ./Hubspot/HubSpot/HubSpot/HubSpot.Contacts -l CSharp -c HubSpotContactsClient -n True.Services.HubSpot.Contacts

kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/objects/quotes -o ./Hubspot/HubSpot/HubSpot.Quotes -l CSharp -c HubSpotQuotesClient -n True.Services.HubSpot.Quotes

kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/pipelines -o ./Hubspot/HubSpot/HubSpot.Pipelines -l CSharp -c HubSpotPipelinesClient -n True.Services.HubSpot.Pipelines

kiota generate -d https://api.hubspot.com/api-catalog-public/v1/apis/crm/v3/properties -o ./Hubspot/HubSpot/HubSpot.Properties -l CSharp -c HubSpotPropertiesClient -n True.Services.HubSpot.Properties