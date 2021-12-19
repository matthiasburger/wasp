﻿using System.Collections.Generic;

using Newtonsoft.Json;

namespace wasp.WebApi.Data.Mts
{
    public class MtsRecord
    {
        [JsonProperty("data-fields")] public List<MtsDataField> DataFields { get; set; } = new List<MtsDataField>();

        [JsonProperty("data-areas")] public List<MtsDataArea> DataAreas { get; set; } = new List<MtsDataArea>();
    }
}