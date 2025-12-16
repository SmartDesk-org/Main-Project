using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Employees
{
    public class BulkUploadResponse
    {
        public int TotalRecords { get; set; }
        public int SuccessfulRecords { get; set; }
        public int FailedRecords { get; set; }
        public int ChunkSize { get; set; }
        public int TotalChunks { get; set; }
        public List<ImportErrorDto> Errors { get; set; } = new();
    }

}
