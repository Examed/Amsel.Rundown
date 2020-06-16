using JetBrains.Annotations;

namespace Amsel.Models.Rundown.Models {
    public class RundownValue {
        protected RundownValue() { }

        public RundownValue([NotNull] string parameterName, string value)
        {
            ParameterName = parameterName;
            Value = value;
        }

        public string ParameterName { get; set; }
        public string Value { get; set; }
    }
}