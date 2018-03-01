using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flexlive.CQP.CSharpPlugins.Demo.Mode
{
    public class Essay
    {
        public int Status { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime IntDT { get; set; }
        public string Content { get; set; }
    }
}
