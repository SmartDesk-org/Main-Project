using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ResourceFlow.Application.Interfaces.Services;
using ResourceFlow.Domain.Entities.Finance;

namespace ResourceFlow.Infrastructure.Services
{
    public class PdfService : IPdfService, IDocument
    {
        private Billing _bill;

        // Called by PaymentService
        public byte[] GeneratePdf(Billing bill)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            _bill = bill; // store data for Compose()
            return this.GeneratePdf();
        }

        // QuestPDF metadata
        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        // PDF layout definition
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(11));

                page.Content().Column(col =>
                {
                    /* ================= HEADER ================= */
                    col.Item().Row(row =>
                    {
                        row.RelativeItem().Column(c =>
                        {
                            c.Item().Text("INVOICE").FontSize(22).Bold();
                            c.Item().Text("SmartDesk").FontSize(12).Bold();
                            c.Item().Text("Subscription Billing");
                        });

                        row.ConstantItem(200).AlignRight().Column(c =>
                        {
                            c.Item().Text($"Invoice No: {_bill.InvoiceNumber}").Bold();
                            c.Item().Text($"Invoice Date: {_bill.BillingDate:dd/MM/yyyy}");
                            c.Item().Text($"Status: {_bill.PaymentStatus}");
                        });
                    });

                    col.Item().PaddingVertical(12).LineHorizontal(1);

                    /* ================= BILL TO ================= */
                    col.Item().Text("BILL TO").Bold().FontSize(12);

                    col.Item().Border(1).Padding(10).Column(c =>
                    {
                        c.Item().Text(_bill.CompanyName ?? "N/A").Bold();
                        c.Item().Text(_bill.CompanyMail ?? "N/A");
                        c.Item().Text($"Company ID: {_bill.CompanyId}");
                    });

                    col.Item().PaddingVertical(15);

                    /* ================= SUBSCRIPTION DETAILS ================= */
                    col.Item().Text("SUBSCRIPTION DETAILS").Bold().FontSize(12);

                    col.Item().Border(1).Padding(10).Column(c =>
                    {
                        c.Item().Text($"Subscription: {_bill.SubscriptionName}");
                        c.Item().Text($"Start Date: {_bill.SubscriptionStartDate:dd-MM-yyyy}");
                        c.Item().Text($"End Date: {_bill.SubscriptionEndDate:dd-MM-yyyy}");
                        c.Item().Text($"Payment Method: {_bill.PaymentMethod}");
                    });

                    col.Item().PaddingVertical(15);

                    /* ================= AMOUNT SUMMARY ================= */
                    col.Item().Text("PAYMENT SUMMARY").Bold().FontSize(12);

                    col.Item().Border(1).Padding(10).Column(c =>
                    {
                        c.Item().Row(r =>
                        {
                            r.RelativeItem().Text("Subtotal");
                            r.ConstantItem(100).AlignRight().Text($"₹ {_bill.SubTotal}");
                        });

                        c.Item().Row(r =>
                        {
                            r.RelativeItem().Text("Tax");
                            r.ConstantItem(100).AlignRight().Text($"₹ {_bill.TaxAmount}");
                        });

                        c.Item().Row(r =>
                        {
                            r.RelativeItem().Text("Discount");
                            r.ConstantItem(100).AlignRight().Text($"₹ {_bill.Discount}");
                        });

                        c.Item().PaddingVertical(6).LineHorizontal(1);

                        c.Item().Row(r =>
                        {
                            r.RelativeItem().Text("TOTAL AMOUNT").Bold();
                            r.ConstantItem(100)
                                .AlignRight()
                                .Text($"₹ {_bill.TotalAmount}")
                                .Bold()
                                .FontSize(13);
                        });
                    });

                    col.Item().PaddingVertical(20);

                    /* ================= TRANSACTION INFO ================= */
                    col.Item().Text("TRANSACTION DETAILS").Bold().FontSize(12);

                    col.Item().Border(1).Padding(10).Column(c =>
                    {
                        c.Item().Text($"Transaction ID: {_bill.TransactionId ?? "N/A"}");
                        c.Item().Text($"Payment Status: {_bill.PaymentStatus}");
                        c.Item().Text($"Payment Method: {_bill.PaymentMethod}");
                    });

                    col.Item().PaddingVertical(25);

                    /* ================= FOOTER ================= */
                    col.Item().AlignCenter().Column(c =>
                    {
                        c.Item().Text("Thank you for choosing SmartDesk").Bold();
                        c.Item().Text("This is a system generated invoice.").FontSize(9);
                    });
                });
            });
        }

    }
}
