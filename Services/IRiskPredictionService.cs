using System.Threading.Tasks;
using Craciun_Adriana_Lab5.Models;

namespace Craciun_Adriana_Lab5.Services
{
    public interface IRiskPredictionService
    {
        Task<string> PredictRiskAsync(RiskInput input);
    }
}
