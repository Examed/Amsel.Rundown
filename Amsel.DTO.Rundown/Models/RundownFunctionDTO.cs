using System;
using System.Collections.Generic;
using System.Reflection;
using Amsel.Enums.Rundown.Enums;
using Newtonsoft.Json;

namespace Amsel.DTO.Rundown.Models
{
    public class RundownFunctionDTO
    {
        public virtual Guid Id { get; set; }
        public virtual string Description { get; set; }
        public virtual EHandlerType HandlerName { get; set; }
        public virtual string Icon { get; set; }
        //public virtual RundownFunctionDTO RevertFunction { get; set; }
        public virtual string Title { get; set; }
        public virtual List<ValueDTO> Values { get; set; }
        public virtual List<RundownParameterDTO> Parameters { get; set; }

        public class ValueDTO
        {
            public virtual string Parameter { get; set; }
            public virtual string Value { get; set; }

            public class Converter : JsonConverter
            {
                /// <inheritdoc />
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    if (serializer == null)
                        return;

                    serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    serializer.Serialize(writer, value);
                }

                /// <inheritdoc />
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    RundownFunctionDTO target = serializer.Deserialize<RundownFunctionDTO>(reader);


                    return target;

                }

                /// <inheritdoc />
                public override bool CanConvert(Type objectType)
                {
                    return typeof(ValueDTO).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
                }
            }

        }
    }
}
