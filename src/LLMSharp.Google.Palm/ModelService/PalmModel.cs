using System.Collections.Generic;
using System.Text.RegularExpressions;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm
{
    /// <summary>
    /// Class representation of a Google Palm Model
    /// </summary>
    public class PalmModel
    {
        private static readonly Regex bareModelName = new(@"^\w+-\w+-\d+$", RegexOptions.Compiled);

        public PalmModel(
            string name,
            string basedModelId,
            string version,
            string displayName,
            string description,
            int inputTokenLimit,
            int outputTokenLimit,
            IEnumerable<string> supportedGenMethods,
            float? temperature = null,
            float? topP = null,
            int? topK = null)
        {
            this.Name = MakeModelName(name);
            this.BaseModelId = basedModelId;
            this.Version = version;
            this.DisplayName = displayName;
            this.Description = description;
            this.InputTokenLimit = inputTokenLimit;
            this.OutputTokenLimit = outputTokenLimit;
            this.SupportedGenerationMethods = supportedGenMethods;
            this.Temperature = temperature;
            this.TopP = topP;
            this.TopK = topK;
        }

        public PalmModel(gav::Model model)
        {
            this.Name = model.Name;
            this.BaseModelId = model.BaseModelId;
            this.Version = model.Version;
            this.DisplayName = model.DisplayName;
            this.InputTokenLimit = model.InputTokenLimit;
            this.OutputTokenLimit = model.OutputTokenLimit;
            this.SupportedGenerationMethods = model.SupportedGenerationMethods;
            this.Temperature = model.Temperature;
            this.TopP = model.TopP;
            this.TopK = model.TopK;
        }

        public string? Name { get; private set; }
        public string? BaseModelId { get; private set; }
        public string? Version { get; private set; }
        public string? DisplayName { get; private set; }
        public string? Description { get; private set; }
        public int InputTokenLimit { get; private set; }
        public int OutputTokenLimit { get; private set; }
        public IEnumerable<string>? SupportedGenerationMethods { get; private set; }
        public float? Temperature { get; private set; }
        public float? TopP { get; private set; }
        public int? TopK { get; private set; }

        private static string MakeModelName(string name)
        {
            if (bareModelName.IsMatch(name))
            {
                return $"models/{name}";
            }

            return name;
        }
    }
}
