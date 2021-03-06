﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Easy.Register.Application.Models.Relationship
{
    public class Relation
    {
        public Relation(string target,string source)
        {
            this.Source = source;
            this.Target = target;
        }
        [JsonProperty("source")]
        public string Source { get;private set; }
        [JsonProperty("target")]
        public string Target { get;private set; }
    }
}