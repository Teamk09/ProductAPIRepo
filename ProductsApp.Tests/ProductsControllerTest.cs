using Microsoft.AspNetCore.Mvc;
using ProductsApp.Controllers;
using ProductsApp.Models;

namespace ProductsApp.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var controller = new ProductsController();

            var result = controller.GetAllProducts().ToArray();

            Assert.AreEqual(3, result.Length);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var controller = new ProductsController();

            var result = controller.GetProduct(1) as OkObjectResult;

            Assert.IsNotNull(result);
            var product = result.Value as Product;
            Assert.IsNotNull(product);
            Assert.AreEqual("Tomato Soup", product.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new ProductsController();

            var result = controller.GetProduct(999);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
