using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class OrderService
    {
        public interface IPaymentMethod
        {
            Task ProcessPayment(decimal paymentValue);
        }

        public class PixPayment : IPaymentMethod
        {
            public async Task ProcessPayment(decimal paymentValue)
            {
                // Lógica de pagamento Pix
            }
        }

        public class CreditCardPayment : IPaymentMethod
        {
            public async Task ProcessPayment(decimal paymentValue)
            {
                // Lógica de pagamento com cartão de crédito
            }
        }
        public class BitcoinPayment : IPaymentMethod
        {
            public async Task ProcessPayment(decimal paymentValue)
            {
                // Lógica de pagamento com bitcoin
            }
        }

        public class PayPalPayment : IPaymentMethod
        {
            public async Task ProcessPayment(decimal paymentValue)
            {
                // Lógica de pagamento PayPal
            }

        }

        private readonly Dictionary<string, IPaymentMethod> paymentMethods;

        public OrderService()
        {
            paymentMethods = new Dictionary<string, IPaymentMethod>
        {
            { "pix", new PixPayment() },
            { "creditcard", new CreditCardPayment() },
            { "paypal", new PayPalPayment() },
            { "bitcoin", new BitcoinPayment() }
        };
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            Order newOrder = new Order
            {
                Value = paymentValue,
              
            };

            if (paymentMethods.TryGetValue(paymentMethod, out var paymentMethodInstance))
            {
                try
                {
                    // Simula o processamento do pagamento
                    await paymentMethodInstance.ProcessPayment(paymentValue);

                    // Atualiza a mensagem indicando que o pagamento foi bem-sucedido
                    newOrder.Message = "Pagamento bem-sucedido!";
                }
                catch (Exception ex)
                {
                    // Se houver uma exceção, atualiza a mensagem indicando falha no pagamento
                    newOrder.Message = $"Falha no pagamento: {ex.Message}";
                }
            }
            else
            {
                // Atualiza a mensagem indicando que o método de pagamento não é válido
                newOrder.Message = "Método de pagamento inválido!";
            }

            return await Task.FromResult(new Order()
            {
                Value = paymentValue,
                Message = newOrder.Message
            }) ;
        }
    }
}