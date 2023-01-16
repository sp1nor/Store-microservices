using Sale.API.DTO;
using Sale.API.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Sale.API.Extensions;

namespace Sale.API.Features
{
    public class SaleFeature : ISaleFeature
    {
        private readonly HttpClient _client;

        public SaleFeature(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public static bool isProductQuantityLessThenHaveSalePoint(Shared.Models.Sale sale, SalesPoint salesPoints)
        {
            foreach (var salesData in sale.SalesData)
            {
                foreach (var providedProducts in salesPoints.ProvidedProducts)
                {
                    if (salesData.ProductId == providedProducts.ProductId)
                    {
                        if (salesData.ProductQuantity > providedProducts.ProductQuantity)
                            return false;
                    }
                }       
            }

            return true;
        }

        public static void ChangeProductQuantituInSalePoint(Shared.Models.Sale sale, SalesPoint salesPoints)
        {
            foreach (var salesData in sale.SalesData)
            {
                foreach (var providedProducts in salesPoints.ProvidedProducts)
                {
                    if (salesData.ProductId == providedProducts.ProductId)
                    {
                        providedProducts.ProductQuantity -= salesData.ProductQuantity;                      
                    }
                }
            }
        }

        public async Task<Shared.Models.Sale> CalculateTotalAmount(Shared.Models.Sale sale)
        {
            var SalesData = sale.SalesData;
            foreach (var saleData in SalesData)
            {
                try
                {
                    var response = await _client.GetAsync($"/gateway/product/{saleData.ProductId}");
                    var product = await HttpClientExtensions.ReadContentAs<ProductDTO>(response);
                    sale.TotalAmount += saleData.ProductQuantity * product.Price;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return sale;
        }
    }
}
