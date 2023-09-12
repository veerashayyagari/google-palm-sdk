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

        internal PalmModel(
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

        internal PalmModel(gav::Model model)
        {
            if (model == null) return;

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

        /// <summary>
        /// The resource name of the `Model`.
        /// Format: `models/{model}` with a `{model}` naming convention of:
        ///
        /// * "{base_model_id}-{version}"
        ///
        /// Examples:
        ///
        /// * `models/chat-bison-001`
        /// </summary>
        public string? Name { get; private set; }

        /// <summary>
        /// The name of the base model.
        /// Examples:
        ///
        /// * `chat-bison`
        /// </summary>
        public string? BaseModelId { get; private set; }

        /// <summary>
        /// The version number of the model.
        /// </summary>
        public string? Version { get; private set; }

        /// <summary>
        /// The human-readable name of the model. E.g. "Chat Bison".
        /// </summary>
        public string? DisplayName { get; private set; }

        /// <summary>
        /// A short description of the model.
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Maximum number of input tokens allowed for this model.
        /// </summary>
        public int InputTokenLimit { get; private set; }

        /// <summary>
        /// Maximum number of output tokens available for this model.
        /// </summary>
        public int OutputTokenLimit { get; private set; }

        /// <summary>
        /// The model's supported generation methods.
        ///
        /// The method names are defined as Pascal case
        /// strings, such as `generateMessage` which correspond to API methods.
        /// </summary>
        public IEnumerable<string>? SupportedGenerationMethods { get; private set; }

        /// <summary>
        /// This value specifies default temperature to be used by the backend while making the
        /// call to the model.
        /// </summary>
        public float? Temperature { get; private set; }

        /// <summary>
        /// Nucleus sampling considers the smallest set of tokens whose probability
        /// sum is at least `top_p`.
        /// This value specifies default to be used by the backend while making the
        /// call to the model.
        /// </summary>
        public float? TopP { get; private set; }

        /// <summary>
        /// Top-k sampling considers the set of `top_k` most probable tokens.
        /// This value specifies default to be used by the backend while making the
        /// call to the model.
        /// </summary>
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
