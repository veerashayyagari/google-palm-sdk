[![Build and Test Solution](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/build-and-test.yml)[![Publish Nugets](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/publish-nuget.yml)[![CodeQL](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/codeql.yml/badge.svg)](https://github.com/veerashayyagari/google-palm-sdk/actions/workflows/codeql.yml)
# google-palm-sdk
C# Client SDK (Unofficial) for [Google Palm Large Language Models](https://developers.generativeai.google/guide)
- Inspired by the official [Google Palm Python Client SDK](https://developers.generativeai.google/api/python/google/generativeai)
- Goal is to provide performant, efficient and flexible SDK for dotnet developers building LLM Apps using Google Palm
- SDK is built on top of the Google Palm Grpc service endpoints.

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


