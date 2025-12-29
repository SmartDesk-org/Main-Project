using QRCoder;
using ResourceFlow.Application.Interfaces.QRCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Infrastructure.Services.QRCode
{
    public class QRCodeService:IQRCodeService
    {

        public string GenerateQrBase64(string value)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);

            var bytes = qrCode.GetGraphic(20);
            return Convert.ToBase64String(bytes);
        }
    }
}
