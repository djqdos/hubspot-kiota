// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace True.Services.HubSpot.Properties.Models {
    public class PropertyModificationMetadata : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The archivable property</summary>
        public bool? Archivable { get; set; }
        /// <summary>The readOnlyDefinition property</summary>
        public bool? ReadOnlyDefinition { get; set; }
        /// <summary>The readOnlyOptions property</summary>
        public bool? ReadOnlyOptions { get; set; }
        /// <summary>The readOnlyValue property</summary>
        public bool? ReadOnlyValue { get; set; }
        /// <summary>
        /// Instantiates a new PropertyModificationMetadata and sets the default values.
        /// </summary>
        public PropertyModificationMetadata() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static PropertyModificationMetadata CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PropertyModificationMetadata();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"archivable", n => { Archivable = n.GetBoolValue(); } },
                {"readOnlyDefinition", n => { ReadOnlyDefinition = n.GetBoolValue(); } },
                {"readOnlyOptions", n => { ReadOnlyOptions = n.GetBoolValue(); } },
                {"readOnlyValue", n => { ReadOnlyValue = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("archivable", Archivable);
            writer.WriteBoolValue("readOnlyDefinition", ReadOnlyDefinition);
            writer.WriteBoolValue("readOnlyOptions", ReadOnlyOptions);
            writer.WriteBoolValue("readOnlyValue", ReadOnlyValue);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}