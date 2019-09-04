using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RetailStore.Data;
using RetailStore.Models;
using RetailStore.Services;
using RetailStore.Utils;

namespace RetailStore.Controllers
{
    public class StockHistoryController : Controller
    {
        private readonly IProductStockService _productStockService;

        public StockHistoryController(IProductStockService productStockService)
        {
            _productStockService = productStockService;
        }

        [HttpPost]
        public IActionResult Post(CreateStockViewModel createStockViewModel)
        {
            if (Request.IsAjaxRequest())
            {
                _productStockService.CreateStock(createStockViewModel);
                return Ok(createStockViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }
    }
}