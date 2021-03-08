using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using handleFileCertificados.Interfaces;
using handleFileCertificados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace handleFileCertificados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionController : ControllerBase
    {
        private readonly IAsignacionRepository _asignacionRepository;
        private const string bucketName = "elasticbeanstalk-us-west-2-573465137969";
        private const string keyName = "testing.xlsx";
        private const string filePath = "";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
        private readonly IAmazonS3 _s3Client;

        public AsignacionController(IAsignacionRepository asignacionRepository)
        {
            _asignacionRepository = asignacionRepository;
            _s3Client = new AmazonS3Client(bucketRegion);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _asignacionRepository.Get();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _asignacionRepository.GetById(id);
            return Ok(data);
        }

        [HttpPost("Json")]
        public async Task<IActionResult> InserJson(Root rootobject)
        {
            //Excel(rootobject);
            ObteinFile();
            Asignacion asig = new Asignacion() { Rutaexcel = rootobject.rutaexcel};
            await _asignacionRepository.Insert(asig);
            return Ok(rootobject);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Asignacion asig)
        {
                      
            await _asignacionRepository.Insert(asig);
            return Ok(asig);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Asignacion asig, int id)
        {
            asig.Idruta = (uint)id;
            await _asignacionRepository.Put(asig);
            return Ok(asig);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _asignacionRepository.Delete(id);
            return Ok(data);
        }

        public async void Excel(Root info)
        {
            var inputFileName = @"C:\Users\juliot\Documents\Libro1.xlsx";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzkxNzQwQDMxMzgyZTM0MmUzMGU0MjVUNStaOWVKZ1NWSWtHSTVSQkEwRzRUK0hHSm1YeTNPOVBIamxmeEE9;MzkxNzQxQDMxMzgyZTM0MmUzMEVjUExhdk9ZdmZjVFczNkhiRytYVUJZQ0dBL0pyNjVVSmVuL1gyWlYrK289;MzkxNzQyQDMxMzgyZTM0MmUzME41R2VYRmtubEdFYVA5ZEthNEdIbFZBKzlnN051QUdYdk1ydElRV3Nybm89;MzkxNzQzQDMxMzgyZTM0MmUzMFFXS2RzZmxmNzh4UkJURzIycEI2SktLbEFoUHJ0TmJLWFArbU02T3hMcjQ9;MzkxNzQ0QDMxMzgyZTM0MmUzMEZKcURySmJaUkE2TzRYRlVIR0xaSnU5Z29hc2txZkVXK0JwZUtvKzRwTGc9;MzkxNzQ1QDMxMzgyZTM0MmUzMGE0VEtTYlZadmU5ZDZIOGZQd2dSRTY3Tkhtb3NLNlNoaHdDZVMvczdjcUU9;MzkxNzQ2QDMxMzgyZTM0MmUzMFRtVkttYkRKRTNNQlJZYm9sVldMNVhHLzlxT0xPK2dBVkhFVE9oRlFoVUk9;MzkxNzQ3QDMxMzgyZTM0MmUzMEtvZkRhQ0RzNXlLNDU4QXBlTVhRbHkyalFEcFlUNGFkWjBIRmdISzZyaTA9;MzkxNzQ4QDMxMzgyZTM0MmUzMFFFWkF4UVNjQlBQR3Q2Yy93N0dCUW5BSjJ2cCtxdXJETkRRZHdvaE8xenc9;MzkxNzQ5QDMxMzgyZTM0MmUzMFBoY1o3YlNpT052d2NmRGhJMzRvU2pNSFRzbVVVQVNWNXExZnNNdEh3NkE9");
            //Creates a new instance for ExcelEngine

            
            ExcelEngine excelEngine = new ExcelEngine();
            //Load the file into stream
            FileStream inputStream = new FileStream(inputFileName, FileMode.Open);
            //Loads or open an existing workbook through Open method of IWorkbooks
            IWorkbook workbook = excelEngine.Excel.Workbooks.Open(inputStream);

            //Modify your excel document 
            IWorksheet worksheet = workbook.Worksheets[0];

            worksheet.Range["A5"].Text = "tESSTIN";
            worksheet.Range["B5"].Text = "dEBUG";
            /*
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
            worksheet.Range["L8"].Text = info.serie;
            worksheet.Range["L5"].Text = info.informe_id;
            */

            //Set the version of the workbook
            workbook.Version = ExcelVersion.Excel2016;
            //Save the workbook in file system as XLSX format
            var outputFile = new FileStream(@"C:\Users\juliot\Documents\Libro2.xlsx", FileMode.Create);
            var file = new MemoryStream();
            workbook.SaveAs(outputFile);
            workbook.SaveAs(file);
            AmazonUpload(file);
            workbook.Close();
            outputFile.Dispose();
            inputStream.Dispose();


            

        }

        private  void ObteinFile()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://elasticbeanstalk-us-west-2-573465137969.s3-us-west-2.amazonaws.com/testing.xlsx", @"C:\Users\juliot\Documents\descargadodeAWS.xlsx");
            }
        }


        private async void UploadFile(FileStream outputFile)
        {
            

            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);

                //Option1
                await fileTransferUtility.UploadAsync(filePath, bucketName);

                //Option2 with IO
                using (var filetoUpload = outputFile)
                {
                    await fileTransferUtility.UploadAsync(filetoUpload,bucketName,keyName);
                }
                //option3 Advace
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = bucketName,
                    FilePath = filePath,
                    StorageClass = S3StorageClass.StandardInfrequentAccess,
                    PartSize = 6291456,//6MB
                    Key = keyName,
                    CannedACL = S3CannedACL.PublicRead
                };
                fileTransferUtilityRequest.Metadata.Add("param1","Value1");
                await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);
            }
            catch(AmazonS3Exception e)
            {
                var msg = e.Message;
            }catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void AmazonUpload(MemoryStream outputFile)
        {
            var fileTransferUtility = new TransferUtility(_s3Client);
            using (var filetoUpload = outputFile)
            {
                await fileTransferUtility.UploadAsync(filetoUpload, bucketName, keyName);
            }
        }

        
    }

}
