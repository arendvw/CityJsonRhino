using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CityJSON
{
    public partial class Metadata
    {
        [JsonProperty("abstract", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Abstract { get; set; }

        [JsonProperty("cityfeatureMetadata", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, CityfeatureMetadatum> CityfeatureMetadata { get; set; }

        [JsonProperty("citymodelIdentifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string CitymodelIdentifier { get; set; }

        [JsonProperty("constraints", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Constraints Constraints { get; set; }

        [JsonProperty("datasetCharacterSet", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DatasetCharacterSet { get; set; }

        [JsonProperty("datasetLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DatasetLanguage { get; set; }

        [JsonProperty("datasetPointOfContact", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DatasetPointOfContact DatasetPointOfContact { get; set; }

        [JsonProperty("datasetReferenceDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DatasetReferenceDate { get; set; }

        [JsonProperty("datasetTitle", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DatasetTitle { get; set; }

        /// <summary>
        /// from ISO19115 codelist
        /// </summary>
        [JsonProperty("datasetTopicCategory", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DatasetTopicCategory? DatasetTopicCategory { get; set; }

        [JsonProperty("distributionFormatVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DistributionFormatVersion { get; set; }

        [JsonProperty("fileIdentifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FileIdentifier { get; set; }

        [JsonProperty("geographicalExtent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<double> GeographicalExtent { get; set; }

        /// <summary>
        /// the name of the area for instance
        /// </summary>
        [JsonProperty("geographicLocation", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string GeographicLocation { get; set; }

        [JsonProperty("keywords", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Keywords { get; set; }

        [JsonProperty("lineage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Lineage> Lineage { get; set; }

        [JsonProperty("materials", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Materials? Materials { get; set; }

        [JsonProperty("metadataCharacterSet", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataCharacterSet { get; set; }

        [JsonProperty("metadataDateStamp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? MetadataDateStamp { get; set; }

        [JsonProperty("metadataLanguage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataLanguage { get; set; }

        [JsonProperty("metadataPointOfContact", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MetadataPointOfContact MetadataPointOfContact { get; set; }

        [JsonProperty("metadataStandard", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataStandard { get; set; }

        [JsonProperty("metadataStandardVersion", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string MetadataStandardVersion { get; set; }

        [JsonProperty("onlineResource", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uri OnlineResource { get; set; }

        [JsonProperty("presentLoDs", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MetadataPresentLoDs PresentLoDs { get; set; }

        [JsonProperty("referenceSystem", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceSystem { get; set; }

        /// <summary>
        /// from ISO19115 codelist
        /// </summary>
        [JsonProperty("spatialRepresentationType", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public SpatialRepresentationType? SpatialRepresentationType { get; set; }

        [JsonProperty("specificUsage", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SpecificUsage { get; set; }

        [JsonProperty("temporalExtent", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public TemporalExtent TemporalExtent { get; set; }

        [JsonProperty("textures", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Materials? Textures { get; set; }

        [JsonProperty("thematicModels", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ThematicModels { get; set; }
    }
}