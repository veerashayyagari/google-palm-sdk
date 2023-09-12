using LLMSharp.Google.Palm.Common;
using LLMSharp.Google.Palm.DiscussService;
using System.Collections.Generic;
using System.Linq;
using gav = Google.Ai.Generativelanguage.V1Beta2;

namespace LLMSharp.Google.Palm.Helpers
{
    /// <summary>
    /// Extension class for mapping SDK classes to Protobuf messages
    /// </summary>
    internal static class ModelMapperExtensions
    {
        /// <summary>
        /// Converts <see cref="PalmChatExample"/> to <see cref="gav::Example"/>
        /// </summary>
        /// <param name="example">PalmChatExample object</param>
        /// <returns>Protobuf Example object</returns>
        internal static gav::Example ToGavExample(this PalmChatExample example)
        {
            return new gav::Example
            {
                Input = example.Input.ToGavMessage(),
                Output = example.Output.ToGavMessage()
            };
        }

        /// <summary>
        /// Converts <see cref="PalmChatMessage"/> to <see cref="gav::Message"/>
        /// </summary>
        /// <param name="message">PalmChatMessage object</param>
        /// <returns>Protobuf Message object</returns>
        internal static gav::Message ToGavMessage(this PalmChatMessage message)
        {
            return new gav::Message { Author = message.Author, Content = message.Content };
        }

        /// <summary>
        /// Converts <see cref="PalmTextCompletionRequest"/> to <see cref="gav::GenerateTextRequest"/>
        /// </summary>
        /// <param name="request">PalmTextCompletionRequest object</param>
        /// <returns>GenerateTextRequest protobuf object</returns>
        internal static gav::GenerateTextRequest ToGavGenerateTextRequest(this PalmTextCompletionRequest request)
        {
            gav::GenerateTextRequest generateTextRequest = new()
            {
                CandidateCount = request.CandidateCount,
                Model = request.Model,
                Prompt = new gav::TextPrompt { Text = request.Prompt },                           
            };

            if(request.Temperature.HasValue)
            {
                generateTextRequest.Temperature = request.Temperature.Value;
            }

            if(request.TopK.HasValue)
            {
                generateTextRequest.TopK = request.TopK.Value;
            }

            if(request.TopP.HasValue)
            {
                generateTextRequest.TopP = request.TopP.Value;
            }

            if(request.MaxOuptputTokens.HasValue)
            {
                generateTextRequest.MaxOutputTokens = request.MaxOuptputTokens.Value;
            }

            if(request.SafetySettings != null)
            {
                generateTextRequest.SafetySettings.AddRange(request.SafetySettings.Select(s => s.ToGavSafetySetting()));
            }

            if (request.StopSequences != null)
            {
                generateTextRequest.StopSequences.AddRange(request.StopSequences);
            }

            return generateTextRequest;
        }

        /// <summary>
        /// Converts <see cref="PalmChatCompletionRequest"/> to <see cref="gav::GenerateMessageRequest"/>
        /// </summary>
        /// <param name="request">PalmChatCompletionRequest object</param>
        /// <returns>GenerateMessageRequest protobuf object</returns>
        internal static gav::GenerateMessageRequest ToGavGenerateMessageRequest(this PalmChatCompletionRequest request)
        {
            gav::GenerateMessageRequest generateMessageRequest = new()
            {
                CandidateCount = request.CandidateCount,
                Model = request.Model,                
                Prompt = request.Messages.GetMessagePrompt(request.Context, request.Examples)
            };

            if(request.Temperature.HasValue)
            {
                generateMessageRequest.Temperature = request.Temperature.Value;
            }

            if(request.TopK.HasValue)
            {
                generateMessageRequest.TopK = request.TopK.Value;
            }

            if(request.TopP.HasValue)
            {
                generateMessageRequest.TopP = request.TopP.Value;
            }

            return generateMessageRequest;
        }

        /// <summary>
        /// Creates <see cref="gav::MessagePrompt"/> from Messages, context, examples
        /// </summary>
        /// <param name="messages">Iterable of PalmChatMessage objects</param>
        /// <param name="context">context string</param>
        /// <param name="examples">Iterable of PalmChatExample objects</param>
        /// <returns>MessagePrompt protobuf object</returns>
        internal static gav::MessagePrompt GetMessagePrompt(
            this IEnumerable<PalmChatMessage> messages, string? context, IEnumerable<PalmChatExample>? examples)
        {
            gav::MessagePrompt messagePrompt = new()
            {
                Context = context
            };
            messagePrompt.Messages.AddRange(messages.Select(m => m.ToGavMessage()));
            messagePrompt.Examples.AddRange(examples.Select(e => e.ToGavExample()));
            return messagePrompt;
        }

        /// <summary>
        /// Converts <see cref="PalmSafetySetting"/> to <see cref="gav::SafetySetting"/>
        /// </summary>
        /// <param name="safetySetting">PalmSafetySetting object</param>
        /// <returns>SafetySetting protobuf object</returns>
        private static gav::SafetySetting ToGavSafetySetting(this PalmSafetySetting safetySetting)
        {
            return new gav::SafetySetting { Category = safetySetting.Category, Threshold = safetySetting.Threshold };
        }        
    }
}
