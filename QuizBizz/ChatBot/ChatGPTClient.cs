using System;
using RestSharp;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

public class ChatGPTClient
{
    private readonly string _apiKey;
    private readonly RestClient _client;

    // Constructor that takes the API key as a parameter
    public ChatGPTClient(string apiKey)
    {
        _apiKey = apiKey;
        // Initialize the RestClient with the ChatGPT API endpoint
        _client = new RestClient("https://api.openai.com/v1/engines/text-davinci-003/completions");
    }
    // Method to send a message to the ChatGPT API and return the response
    // It takes a message as input, creates a POST request to the ChatGPT API with the appropriate headers and JSON body, and returns the response from the API.
    public string SendMessage(string message)
    {
        // Check for empty input
        if (string.IsNullOrWhiteSpace(message))
        {
            return "Sorry, I didn't receive any input. Please try again!";
        }
        try
        {
            // Create a new POST request
            var request = new RestRequest("", Method.Post);

            // Set the Content-Type header
            request.AddHeader("Content-Type", "application/json");
            // Set the Authorization header with the API key
            request.AddHeader("Authorization", $"Bearer {_apiKey}");

            // Create the request body with the message and other parameters
            var requestBody = new
            {
                //potrebno je staviti novi kupljen model
                prompt = message,
                max_tokens = 100,
                n = 1,
                stop = (string?)null,
                temperature = 0.7,
            };
            // Add the JSON body to the request
            request.AddJsonBody(JsonConvert.SerializeObject(requestBody));

            // Execute the request and receive the response
            var response = _client.Execute(request);
            // Deserialize the response JSON content

            Console.WriteLine(response.Content); //ovde je greska
            
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content ?? string.Empty);
            // Extract and return the chatbot's response text
           
            // Check if jsonResponse and choices array are not null before accessing elements
            if (jsonResponse != null && jsonResponse.choices != null && jsonResponse.choices.Count > 0)
            {
                // Extract and return the chatbot's response text
                return jsonResponse.choices[0]?.text?.ToString()?.Trim() ?? string.Empty;
            }
            else
            {
                // Handle the case where jsonResponse or choices array is null
                return string.Empty;
            }


        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur during the API request
            Console.WriteLine($"Error: {ex.Message}");
            return "Sorry, there was an error processing your request. Please try again later.";
        }
    }

}
