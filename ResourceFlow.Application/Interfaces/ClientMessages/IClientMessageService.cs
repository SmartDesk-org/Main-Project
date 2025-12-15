using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.ClientMessages;
using ResourceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.ClientMessages
{
    public interface IClientMessageService
    {
        Task<Response<IEnumerable<ClientMessage>>> GetAllAsync();
        Task<Response<ClientMessage>> CreateAsync(NewClientMessageDto msg);

        Task<Response<ClientMessage>> ToggleReadAsync(int id);
        Task<Response<ClientMessage>> ToggleImportantAsync(int id);
        Task<Response<bool>> DeleteAsync(int id);

    }
}
