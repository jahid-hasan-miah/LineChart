using LineChart.Context;
using LineChart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LineChart.Controllers
{
    public class ChartController : Controller
    {
        private readonly ILogger<ChartController> _logger;
        private readonly CustomDbContext _customDb;
        public ChartController(ILogger<ChartController> logger,CustomDbContext customDb)
        {
            _logger = logger;
            _customDb = customDb;
        }

        public IActionResult Index()
        {
            List<DataPoint> DataSeries1 = new List<DataPoint>();
            List<DataPoint> DataSeries2 = new List<DataPoint>();
            var Data = _customDb.Products.ToList();

            foreach (var product in Data)
            {
                if (product.Date.Year < DateTime.Today.Year)
                {
                    DataSeries1.Add(new DataPoint(product.Name, product.Price));
                }
                else
                {
                    DataSeries2.Add(new DataPoint(product.Name, product.Price));
                }

            }
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(DataSeries1);
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(DataSeries2);
            return View();
        }
    }
}
