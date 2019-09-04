using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RetailStore.Data;
using RetailStore.Domain;
using RetailStore.Models;

namespace RetailStore.Services
{
    public interface IProductStockService
    {
        void CreateStock(CreateStockViewModel viewModel);
    }

    public class ProductStockService : IProductStockService
    {
        private ApplicationDbContext _context;

        public ProductStockService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateStock(CreateStockViewModel viewModel)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                CreateStockHistory(viewModel);
                var cost = CalculateWeightedAverageCost(viewModel.ProductId);
                UpdateProductCostAndQuantity(cost, viewModel.QtyPurchased, viewModel.ProductId);
                transaction.Commit();
            }
        }

        private void UpdateProductCostAndQuantity(double cost, double qtyPurchased, int productId)
        {
            var product = _context.Products.Find(productId);
            product.Quantity += qtyPurchased;
            product.AverageUnitCost = cost;
            _context.Update(product);
            _context.SaveChanges();
        }

        private double CalculateWeightedAverageCost(int productId)
        {
            return _context.StockHistories.Where(x => x.ProductId == productId).Average(x => x.UnitCost);
        }

        private void CreateStockHistory(CreateStockViewModel viewModel)
        {
            var stockHistory = new StockHistory()
            {
                ProductId = viewModel.ProductId,
                VendorId = viewModel.VendorId,
                Quantity = viewModel.QtyPurchased,
                Date = DateTime.Now,
                UnitCost = viewModel.UnitCost
            };

            _context.StockHistories.Add(stockHistory);
            _context.SaveChanges();
        }
    }
}
