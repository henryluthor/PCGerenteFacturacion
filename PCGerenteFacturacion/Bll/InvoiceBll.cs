using PCGerenteFacturacion.DBModels;
using PCGerenteFacturacion.Models;
using PCGerenteFacturacion.Repository;

namespace PCGerenteFacturacion.Bll
{
    public class InvoiceBll
    {
        PcgerentetestContext DBContext;

        public InvoiceBll(PcgerentetestContext _context)
        {  
            DBContext = _context; 
        }

        public GenericResponse<bool> InsertInvoice(InvoiceHeadModel model)
        {
            DBContext.Database.BeginTransaction();

            try
            {
                InvoiceRepository invoiceRepository = new InvoiceRepository();

                InvoiceHead invoiceHead = new InvoiceHead
                {
                    TaxTwelve = model.TaxTwelve,
                    TaxZero = model.TaxZero,
                    Total = model.Total
                };

                InvoiceHead invoiceHeadReturned = invoiceRepository.InsertInvoiceHead(DBContext, invoiceHead);

                //DBContext.Database.CommitTransaction(); //talves tengo que aplicar esta linea antes de seguir, chequear en pruebas

                foreach(InvoiceDetailModel product in model.Products)
                {
                    InvoiceDetail invoiceDetail = new InvoiceDetail
                    {
                        ProductName = product.ProductName,
                        Quantity = product.Quantity,
                        Price = product.Price,
                        IdInvoiceHead = invoiceHeadReturned.IdInvoiceHead
                    };

                    invoiceRepository.InsertInvoiceDetail(DBContext, invoiceDetail);
                }

                DBContext.Database.CommitTransaction();

                return new GenericResponse<bool>
                {
                    StatusCode = 200,
                    Data = true,
                    Message = "Factura generada exitosamente."
                };
            }
            catch
            {
                DBContext.Database.RollbackTransaction();

                return new GenericResponse<bool>
                {
                    StatusCode = 500,
                    Data = false,
                    Message = "Ocurrio un error."
                };
            }
        }
    }
}
