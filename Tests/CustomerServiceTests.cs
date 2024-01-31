using ProvaPub.Repository;
using ProvaPub.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ProvaPub.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private TestDbContext _ctx;
        [TestInitialize]
        public void TestInitialize(TestDbContext ctx)
        {

            _ctx = ctx;
        }
        [TestMethod]
        public async Task CanPurchase_ValidCustomer_ReturnsTrue()
        {
            
            var customerService = new CustomerService(_ctx);

            
            var result = await customerService.CanPurchase(1, 50); 
            // customerId válido e valor de compra dentro das regras

            Assert.IsTrue(result);
            
        }
        
        [TestMethod]
        public async Task CanPurchase_CustomerDoesNotExist_ThrowsException()
        {
        
        var customerService = new CustomerService(_ctx);

        
        await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => customerService.CanPurchase(999, 50));
        }

    }
}
