using PCGerenteFacturacion.DBModels;
using PCGerenteFacturacion.Models;

namespace PCGerenteFacturacion.Repository
{
    public class InvoiceRepository
    {
        public InvoiceHeadModel InsertInvoice(PcgerentetestContext context, InvoiceHead invoiceHead, List<InvoiceDetail> invoiceDetails)
        {
            context.InvoiceHeads.Add(invoiceHead);
            InvoiceHeadModel invoiceHeadModel = new InvoiceHeadModel();
            invoiceHeadModel.IdInvoiceHead = invoiceHead.IdInvoiceHead;
            invoiceHeadModel.TaxTwelve = (float)invoiceHead.TaxTwelve;
            invoiceHeadModel.TaxZero = (float)invoiceHead.TaxZero;
            invoiceHeadModel.Total = (float)invoiceHead.Total;

            foreach(InvoiceDetail invoiceDetail in invoiceDetails)
            {
                context.InvoiceDetails.Add(invoiceDetail);
                InvoiceDetailModel invoiceDetailModel = new InvoiceDetailModel();
                invoiceDetailModel.ProductName = invoiceDetail.ProductName;
                invoiceDetailModel.Quantity = invoiceDetail.Quantity;
                invoiceDetailModel.Price = (float)invoiceDetail.Price;

                invoiceHeadModel.Products.Add(invoiceDetailModel);
            }


            context.SaveChanges();
            return invoiceHeadModel;
        }

        public InvoiceHead InsertInvoiceHead(PcgerentetestContext context, InvoiceHead invoiceHead)
        {
            context.InvoiceHeads.Add(invoiceHead);
            context.SaveChanges();
            return invoiceHead;
        }

        public InvoiceDetail InsertInvoiceDetail(PcgerentetestContext context, InvoiceDetail invoiceDetail)
        {
            context.InvoiceDetails.Add(invoiceDetail);
            context.SaveChanges();
            return invoiceDetail;
        }
    }
}
