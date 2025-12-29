using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.QRCode
{
    public interface IQRCodeService
    {
        string GenerateQrBase64(string value);
    }
}
