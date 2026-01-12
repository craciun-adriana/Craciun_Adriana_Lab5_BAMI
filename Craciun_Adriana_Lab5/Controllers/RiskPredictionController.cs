using Microsoft.AspNetCore.Mvc;
using Craciun_Adriana_Lab5.Models;
using Craciun_Adriana_Lab5.Services;
using System.Threading.Tasks;

namespace Craciun_Adriana_Lab5.Controllers
{
    public class RiskPredictionController : Controller
    {
        private readonly IRiskPredictionService _riskService;
        public RiskPredictionController(IRiskPredictionService riskService)
        {
            _riskService = riskService;
        }
        // GET: /RiskPrediction/Index
        [HttpGet]
        public IActionResult Index()
        {
            var model = new RiskPredictionViewModel();
            return View(model);
        }
        // POST: /RiskPrediction/Index
        [HttpPost]
        public async Task<IActionResult> Index(RiskPredictionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var input = new RiskInput
            {
                InspectionType = model.InspectionType,
                ViolationDescription = model.ViolationDescription
            };
            // apelăm Web API-ul
            var prediction = await _riskService.PredictRiskAsync(input);
            model.PredictedRisk = prediction;
            return View(model);
        }
    }
}

