using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OpenAIController : MonoBehaviour
{
    private const string apiKey = "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";
    private const string openAIEndpoint = "https://api.openai.com/v1/engines/davinci-codex/completions";

    private string generatedText = "";

    private void Start()
    {
        StartCoroutine(GenerateText());
    }

    private IEnumerator GenerateText()
    {
        string prompt = "Generate a text prompt for your game here.";

        // Prepare the request to OpenAI's GPT-3 API.
        WWWForm form = new WWWForm();
        form.AddField("prompt", prompt);
        form.AddField("max_tokens", 50); // Adjust as needed.

        UnityWebRequest www = UnityWebRequest.Post(openAIEndpoint, form);
        www.SetRequestHeader("Authorization", $"Bearer {apiKey}");
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            generatedText = www.downloadHandler.text;
            Debug.Log("Generated Text: " + generatedText);

            // Use the generated text in your game.
        }
        else
        {
            Debug.LogError("OpenAI request failed: " + www.error);
        }
    }
}