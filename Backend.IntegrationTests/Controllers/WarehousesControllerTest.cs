// using System.Threading.Tasks;
// using Backend.Controllers.Warehouses;
// using Backend.Features.Warehouses;
// using Microsoft.AspNetCore.Mvc;
// using Xunit;
//
// namespace Backend.IntegrationTests.Controllers
// {
//     public class WarehousesControllerTest
//     {
//         [Fact]
//         public async Task GetAllWarehousesOnSuccessReturns200()
//         {
//             // Arrange
//             var controller = new WarehousesController();
//
//             // Act
//             var result = await Task.FromResult(controller.GetAllWarehouses()) as OkObjectResult;
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(200, result.StatusCode);
//         }
//     }
// }
