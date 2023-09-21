[![Build and Test Solution](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/build-and-test.yml)[![Publish Nugets](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/publish-nuget.yml)[![CodeQL](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/codeql.yml/badge.svg)](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/codeql.yml)
# google-palm-sdk
C# Client SDK (Unofficial) for [Google Palm Large Language Models](https://developers.generativeai.google/guide)
- Currently Google does not provide a dotnet client library for accessing Google Palm Models.
- Inspired by the official [Google Palm Python Client SDK](https://developers.generativeai.google/api/python/google/generativeai)
- Goal is to provide performant, efficient and flexible SDK for dotnet developers building LLM Apps using Google Palm
- SDK is built on top of the Grpc endpoints for PALM2 models (v1beta2/models)

## Install 💽

```
dotnet add package LLMSharp.Google.Palm
```

## Usage

### Quickstart 🚀

- Copy your Google Palm API key from https://makersuite.google.com/app/apikey

- Create Google Palm Client Instance

```csharp
using LLMSharp.Google.Palm;

// if you want to explicitly pass the api key
GooglePalmClient client = new GooglePalmClient(<your palm api key>);
```

OR

```csharp
using LLMSharp.Anthropic;

// set API key as an environment variable with key 'GOOGLE_API_KEY'
GooglePalmClient client = new GooglePalmClient();
```

- Get Text Completions for your prompt

```csharp
var response = await client.GenerateTextAsync("what is a large language model?");
```

- Get Chat Completions for your messages

```csharp
List<PalmChatMessage> messages = new()
{
    new("hello world!", "0"),
};

var response = await client.ChatAsync(messages, null, null);
```

- Get Chat Completions for your  messages with some context

```csharp
List<PalmChatMessage> messages = new()
{
    new("hello world!", "0"),
};

string context = @"You are Tim, a friendly alien that lives on Europa, one of
Jupiter's moons.";

var response = await _client.ChatAsync(messages, context, null);
```

- Get Chat Completions for your messages with some context and examples
```csharp
List<PalmChatExample> examples = new()
{
    new PalmChatExample
    {
        Input = new("Hi!", "0"),
        Output = new("Hi! My name is Tim and I live on Europa, one of Jupiter's moons. Brr! It's cold down here!", "1")
    }
};

string context = @"You are Tim, a friendly alien that lives on Europa, one of
Jupiter's moons.";

List<PalmChatMessage> messages = new()
{
    new("What's the weather like?", "0"),
};

var response = await _client.ChatAsync(messages, context, examples);
```



### Available Features 🎯

#### GooglePalmClient Methods :

- **ChatAsync** : Get chat completions, returns a PalmChatCompletionResponse object with possible completion candidates. It has two overloaded methods :
    - takes Chronological conversation history of the messages, Optional context included in the message, Optional examples included as part of the message.
    - takes PalmChatCompletionRequest that has more options like choosing temperature, TopP, TopK in addition to messages, context and examples.
- **GenerateTextAsync** : Generate Text Completions, returns a PalmTextCompletionResponse object with possible completion candidates. It has two overloaded methods:
    - takes the text prompt for generating completion
    - takes the PalmTextCompletionRequest that has additional options like Temperature, TopP, TopK , SafetySettings in addition to the text prompt.
- **CountMessageTokensAsync** : Counts total number of message tokens given a message with optional context and examples.
- **GenerateEmbeddingsAsync** : Generates embeddings for a given text using 'embedding-gecko-001' model.
- **ListModels** : Fetches the list of supported PalmModels by page.
- **ListModelsAsync** : Fetches the list of supported PalmModels as a stream.
- **GetModelAsync** : Gets the Palm Model info for the given model name.

### Advanced Usage 📋

- I want to control additional attributes like 'Temperature', 'TopP', 'TopK' and 'SafetySettings' use 'PalmTextCompletionRequest' and 'PalmChatCompletionRequest' for TextCompletions and ChatCompletions respectively.

```csharp
/*
* Text Completion Request
*/
PalmTextCompletionRequest request = new()
{
    Prompt = "Can you suggest me a prescription for headache?",
    Temperature = 0.8f,
    TopK = 40,
    CandidateCount = 2,
    MaxOutputTokens = 1024,                
    SafetySettings = new List<PalmSafetySetting> {
        new(HarmCategory.Medical, SafetySetting.Types.HarmBlockThreshold.BlockNone)
    }
};

var response = await _client.GenerateTextAsync(request);


/*
* Chat Completion Request
*/

List<PalmChatExample> examples = new()
{
    new PalmChatExample
    {
        Input = new("Hi!", "0"),
        Output = new("Hi! My name is Tim and I live on Europa, one of Jupiter's moons. Brr! It's cold down here!", "1")
    }
};

string context = @"You are Tim, a friendly alien that lives on Europa, one of
Jupiter's moons.";

List<PalmChatMessage> messages = new()
{
    new("What's the weather like?", "0"),
};

var response = await client.ChatAsync(new PalmChatCompletionRequest
{
    Messages = messages,
    Examples = examples,
    Context = context,
    Temperature = 0.8f,
    TopK = 40
});

```

- I want more control when creating GooglePalmClient => customize **ClientOptions**

```csharp
using LLMSharp.Google.Palm;

ClientOptions options = new ClientOptions
{
    ApiKey = "<apikey>",
    BaseUrl = "a different baseurl other than default",
    CustomHeaders = new Dictionary<string, IEnumerable<string>>
    {
        "header1", new string[]{"val1", "val2"}
    },
    Logger = new CustomImplementedLogger(), // your own custom implementation of ILogger
    UserAgent = "myapp-useragent", // A custom user agent to specify in the channel metadata
    Scopes = new string[]{"scope1"} // The scopes to use, or null to use the default scopes.
    QuotaProject = "projectid" // The GCP project ID that should be used for quota and billing purposes.
};

GooglePalmClient client = new GooglePalmClient(options);
```

- I want to override 'Timeout' or 'MaxRetries' on a per request basis => use **RequestOptions**

```csharp
GooglePalmClient client = new(); 
string text = $"Explain an Large Language Model to a 5 year old";
var reqOptions = new RequestOptions{ Timeout = TimeSpan.FromMilliseconds(1)};
var response = await client.GenerateTextAsync(
                text,
                reqOptions); // timeout in request options will override the default timeout
```

## Contribute 🤝

Got a pull request? Open it, and I'll review it as soon as possible.