using AutoMapper;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.DTOs.ClientMessages;
using ResourceFlow.Application.Interfaces.ClientMessages;
using ResourceFlow.Application.Interfaces.Repositories;
using ResourceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.ClientMessages
{
    public class ClientMessagesService : IClientMessageService
    {
        private readonly IGenericRepository<ClientMessage> _messageRepo;
        private readonly IMapper _mapper;
        public ClientMessagesService(IGenericRepository<ClientMessage> messageRepo,IMapper mapper)
        {
            _messageRepo = messageRepo;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ClientMessage>>> GetAllAsync()
        {
            var messages = await _messageRepo.GetAllAsync();

            return new Response<IEnumerable<ClientMessage>>(
                (int)HttpStatusCode.OK,
                "Messages fetched successfully",
                messages
            );
        }

        public async Task<Response<ClientMessage>> CreateAsync(NewClientMessageDto dto)
        {
           
            var msg = _mapper.Map<ClientMessage>(dto);

            if (msg == null)
                return new Response<ClientMessage>(
                    (int)HttpStatusCode.BadRequest,
                    "Invalid message data"
                );

            msg.IsRead = false;
            msg.IsImportant = false;

            var saved = await _messageRepo.AddAsync(msg);

            return new Response<ClientMessage>(
                (int)HttpStatusCode.Created,
                "Message submitted successfully , Our team will contact you soon",
                saved
            );
        }

        public async Task<Response<ClientMessage>> ToggleReadAsync(int id)
        {
            var message = await _messageRepo.GetByIdAsync(id);

            if (message == null)
                return new Response<ClientMessage>(
                    (int)HttpStatusCode.NotFound,
                    "Message not found"
                );

           

            await _messageRepo.UpdateAsync(message);

            return new Response<ClientMessage>(
                (int)HttpStatusCode.OK,
                "Read status updated",
                message
            );
        }

        public async Task<Response<ClientMessage>> ToggleImportantAsync(int id)
        {
            var message = await _messageRepo.GetByIdAsync(id);

            if (message == null)
                return new Response<ClientMessage>(
                    (int)HttpStatusCode.NotFound,
                    "Message not found"
                );

         

            await _messageRepo.UpdateAsync(message);

            return new Response<ClientMessage>(
                (int)HttpStatusCode.OK,
                "Important status updated",
                message
            );
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            var message = await _messageRepo.GetByIdAsync(id);

            if (message == null)
                return new Response<bool>(
                    (int)HttpStatusCode.NotFound,
                    "Message not found"
                );

            await _messageRepo.DeleteAsync(message);

            return new Response<bool>(
                (int)HttpStatusCode.OK,
                "Message deleted successfully",
                true
            );
        }


    }
}
