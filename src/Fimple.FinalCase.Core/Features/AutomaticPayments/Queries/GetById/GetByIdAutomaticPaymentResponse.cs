using Fimple.FinalCase.Core.Enums;
using Fimple.FinalCase.Core.Utilities.Responses;

namespace Fimple.FinalCase.Core.Features.AutomaticPayments.Queries.GetById;

public class GetByIdAutomaticPaymentResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public AutomaticPaymentStatus Status { get; set; }
}