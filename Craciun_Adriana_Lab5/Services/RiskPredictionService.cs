using Craciun_Adriana_Lab5.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Craciun_Adriana_Lab5.Services
{
        public class RiskPredictionService : IRiskPredictionService
        {
            private readonly HttpClient _httpClient;
            public RiskPredictionService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }
            public async Task<string> PredictRiskAsync(RiskInput input)
            {
                // POST către /predict
                var response = await _httpClient.PostAsJsonAsync("/predict", input);
                response.EnsureSuccessStatusCode();
                // Structura exactă a răspunsului depinde de API.
                // De obicei, Model Builder generează un JSON de forma:
                // { "Prediction": "Moderate Risk", ... }
                var result = await response.Content.ReadFromJsonAsync<RiskApiResponse>();
                return result?.Prediction;
            }
            // clasă internă pentru maparea răspunsului
            private class RiskApiResponse
            { 
                public string Prediction { get; set; }
            }
        }
}
