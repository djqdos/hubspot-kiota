// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace True.Services.HubSpot.Tickets.Models {
    public class CollectionResponseWithTotalSimplePublicObjectForwardPaging : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The paging property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ForwardPaging? Paging { get; set; }
#nullable restore
#else
        public ForwardPaging Paging { get; set; }
#endif
        /// <summary>The results property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SimplePublicObject>? Results { get; set; }
#nullable restore
#else
        public List<SimplePublicObject> Results { get; set; }
#endif
        /// <summary>The total property</summary>
        public int? Total { get; set; }
        /// <summary>
        /// Instantiates a new CollectionResponseWithTotalSimplePublicObjectForwardPaging and sets the default values.
        /// </summary>
        public CollectionResponseWithTotalSimplePublicObjectForwardPaging() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static CollectionResponseWithTotalSimplePublicObjectForwardPaging CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CollectionResponseWithTotalSimplePublicObjectForwardPaging();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"paging", n => { Paging = n.GetObjectValue<ForwardPaging>(ForwardPaging.CreateFromDiscriminatorValue); } },
                {"results", n => { Results = n.GetCollectionOfObjectValues<SimplePublicObject>(SimplePublicObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"total", n => { Total = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ForwardPaging>("paging", Paging);
            writer.WriteCollectionOfObjectValues<SimplePublicObject>("results", Results);
            writer.WriteIntValue("total", Total);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}