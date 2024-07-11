using System.Threading.Tasks;
using UberClone.Core.Entities;

namespace UberClone.Core.Interfaces
{
    public interface IPaymentService
    {
        Task ProcessPaymentAsync(PaymentDetails paymentDetails);
        Task AddPaymentMethodAsync(int userId, string paymentMethod);
    }
}
