namespace Craciun_Adriana_Lab5.Models
{
    public class RiskPredictionViewModel
    {
        public string InspectionType { get; set; }
        public string ViolationDescription { get; set; }
        // rezultat întors de API
        public string PredictedRisk { get; set; }
    }
}
