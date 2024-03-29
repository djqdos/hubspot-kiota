// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace True.Services.HubSpot.Companies.Models {
    public class BatchReadInputSimplePublicObjectId : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The idProperty property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? IdProperty { get; set; }
#nullable restore
#else
        public string IdProperty { get; set; }
#endif
        /// <summary>The inputs property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SimplePublicObjectId>? Inputs { get; set; }
#nullable restore
#else
        public List<SimplePublicObjectId> Inputs { get; set; }
#endif
        /// <summary>The properties property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Properties { get; set; }
#nullable restore
#else
        public List<string> Properties { get; set; }
#endif
        /// <summary>The propertiesWithHistory property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? PropertiesWithHistory { get; set; }
#nullable restore
#else
        public List<string> PropertiesWithHistory { get; set; }
#endif
        /// <summary>
        /// Instantiates a new BatchReadInputSimplePublicObjectId and sets the default values.
        /// </summary>
        public BatchReadInputSimplePublicObjectId() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static BatchReadInputSimplePublicObjectId CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BatchReadInputSimplePublicObjectId();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"idProperty", n => { IdProperty = n.GetStringValue(); } },
                {"inputs", n => { Inputs = n.GetCollectionOfObjectValues<SimplePublicObjectId>(SimplePublicObjectId.CreateFromDiscriminatorValue)?.ToList(); } },
                {"properties", n => { Properties = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"propertiesWithHistory", n => { PropertiesWithHistory = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("idProperty", IdProperty);
            writer.WriteCollectionOfObjectValues<SimplePublicObjectId>("inputs", Inputs);
            writer.WriteCollectionOfPrimitiveValues<string>("properties", Properties);
            writer.WriteCollectionOfPrimitiveValues<string>("propertiesWithHistory", PropertiesWithHistory);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
