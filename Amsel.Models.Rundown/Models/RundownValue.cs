using JetBrains.Annotations;

namespace Amsel.Models.Rundown.Models
{
    public class RundownValue
    {
        public string ParameterName { get; set; }

        public string Value { get; set; }

        protected RundownValue() { }

        public RundownValue([NotNull] string parameterName, string value)
        {
            ParameterName = parameterName;
            Value = value;
        }
    }
}