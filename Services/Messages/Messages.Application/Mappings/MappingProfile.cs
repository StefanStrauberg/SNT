using AutoMapper;
using Messages.Application.DTOs;
using Messages.Domain;

namespace Messages.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMessageDto, Message>();
            CreateMap<UpdateMessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}