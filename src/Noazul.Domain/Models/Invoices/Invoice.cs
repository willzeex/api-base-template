using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Noazul.Domain.Models.Invoices;

public class FinancialRelease : Entity, IAggregateRoot
{
    public DateTime ReferenceDate { get; private set; }
    public decimal Amount => Invoices.Sum(i => i.Value);
    public IEnumerable<Invoice> Invoices { get; set; }
}

public class Invoice : Entity, IAggregateRoot
{
    public string Description { get; private set; }
    public string BarCode { get; private set; }
    public int InstallmentNumber { get; private set; }
    public decimal Value { get; private set; }
    public PaymentType PaymentType { get; private set; }
    public DateTime DueDate { get; private set; }
    public bool Recurrent { get; private set; }
    public InvoiceStatus InvoiceStatus { get; private set; }
    public virtual Guid CategoryId { get; private set; }
    public virtual Category Category { get; private set; }
}

public enum PaymentType
{
    Cash,
    CreditCard,
    BankSlip,
    Pix,
    DebitCard
}

public enum InvoiceStatus
{
    WaitingForPayment,
    PaidOut,
    LatePayment
}