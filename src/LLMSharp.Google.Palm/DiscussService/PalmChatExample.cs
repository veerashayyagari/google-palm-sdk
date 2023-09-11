using System;
using System.Collections.Generic;
using System.Text;

namespace LLMSharp.Google.Palm
{
    public class PalmChatExample
    {
        /// <summary>
        /// An example of an input Message from the user.
        /// </summary>
        public PalmChatMessage? Input { get; set; }

        /// <summary>
        /// An example of what the model should output given the input.
        /// </summary>
        public PalmChatMessage? Output { get; set; }
    }
}
