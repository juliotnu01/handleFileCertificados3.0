using handleFileCertificados.Models;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace handleFileCertificados.Services
{
    public class ServiceExcel
    {
        public  void Excel(Root info)
        {
            var inputFileName = $@"{info.rutaexcel}";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzkxNzQwQDMxMzgyZTM0MmUzMGU0MjVUNStaOWVKZ1NWSWtHSTVSQkEwRzRUK0hHSm1YeTNPOVBIamxmeEE9;MzkxNzQxQDMxMzgyZTM0MmUzMEVjUExhdk9ZdmZjVFczNkhiRytYVUJZQ0dBL0pyNjVVSmVuL1gyWlYrK289;MzkxNzQyQDMxMzgyZTM0MmUzME41R2VYRmtubEdFYVA5ZEthNEdIbFZBKzlnN051QUdYdk1ydElRV3Nybm89;MzkxNzQzQDMxMzgyZTM0MmUzMFFXS2RzZmxmNzh4UkJURzIycEI2SktLbEFoUHJ0TmJLWFArbU02T3hMcjQ9;MzkxNzQ0QDMxMzgyZTM0MmUzMEZKcURySmJaUkE2TzRYRlVIR0xaSnU5Z29hc2txZkVXK0JwZUtvKzRwTGc9;MzkxNzQ1QDMxMzgyZTM0MmUzMGE0VEtTYlZadmU5ZDZIOGZQd2dSRTY3Tkhtb3NLNlNoaHdDZVMvczdjcUU9;MzkxNzQ2QDMxMzgyZTM0MmUzMFRtVkttYkRKRTNNQlJZYm9sVldMNVhHLzlxT0xPK2dBVkhFVE9oRlFoVUk9;MzkxNzQ3QDMxMzgyZTM0MmUzMEtvZkRhQ0RzNXlLNDU4QXBlTVhRbHkyalFEcFlUNGFkWjBIRmdISzZyaTA9;MzkxNzQ4QDMxMzgyZTM0MmUzMFFFWkF4UVNjQlBQR3Q2Yy93N0dCUW5BSjJ2cCtxdXJETkRRZHdvaE8xenc9;MzkxNzQ5QDMxMzgyZTM0MmUzMFBoY1o3YlNpT052d2NmRGhJMzRvU2pNSFRzbVVVQVNWNXExZnNNdEh3NkE9");
            //Creates a new instance for ExcelEngine
            ExcelEngine excelEngine = new ExcelEngine();
            //Load the file into stream
            FileStream inputStream = new FileStream(inputFileName, FileMode.Open);
            //Loads or open an existing workbook through Open method of IWorkbooks
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);

            //Modify your excel document 
            IWorksheet worksheet = workbook.Worksheets[1];
            worksheet.Range["C5"].Text = info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_razon_social + " " + info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_rfc;
            worksheet.Range["C6"].Text = info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_domiclio_fiscal_calle + " " + info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_domiclio_fiscal_numero;
            worksheet.Range["C7"].Text = info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_domiclio_fiscal_colonia;
            worksheet.Range["C8"].Text = info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_domiclio_fiscal_ciudad;
            worksheet.Range["C9"].Text = info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_domiclio_fiscal_estado;
            worksheet.Range["C10"].Text = info.has_recibo.has_cotizaicon.has_cliente.datos_fisicos_requeremientos_facturacion_domiclio_fiscal_cp;
            worksheet.Range["C12"].Text = info.has_recibo.has_cotizaicon.contacto;
            worksheet.Range["G12"].Text = info.has_recibo.has_cotizaicon.contacto_telefono;
            worksheet.Range["V5"].Text = info.has_recibo.created_at.ToString("yyyy-MM-dd");
            worksheet.Range["L6"].Text = info.has_intrumento.nombre;
            worksheet.Range["L11"].Text = info.has_intrumento.alcance;
            worksheet.Range["L7"].Text = info.identificacion;
            worksheet.Range["L9"].Text = info.marca;
            worksheet.Range["L10"].Text = info.modelo;
            worksheet.Range["L5"].Text = info.serie;

            //Set the version of the workbook
            workbook.Version = ExcelVersion.Excel2016;
            //Save the workbook in file system as XLSX format
            var outputFile = new FileStream($@"{info.rutaexcel}2", FileMode.Create);
            workbook.SaveAs(outputFile);
            workbook.Close();

        }
    }
}
