﻿using System.Collections.Generic;

using Newtonsoft.Json;

namespace wasp.WebApi.Data.Mts
{
    public class MtsRecord
    {
        [JsonProperty("data-fields")] public List<MtsDataField> DataFields { get; set; } = new();

        [JsonProperty("data-areas")] public List<MtsDataArea> DataAreas { get; set; } = new();

        public string? DataTableId { get; set; }
        public bool UnsavedChanges { get; set; }
        public bool NewRecord { get; set; }
    }
}