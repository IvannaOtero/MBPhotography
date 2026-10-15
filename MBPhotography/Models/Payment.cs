using System;
using MBPhotography.Enums;

namespace MBPhotography.Models;

public class Payment : AuditableEntity
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public decimal TotalPrice { get; set; }
    public decimal DepositAmount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal RemainingBalance { get; set; }
    public string PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string TransactionId { get; set; }
}
