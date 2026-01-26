using Booking_Hotel.Domain.Interfaces;
using Booking_Hotel.Domain.Entites;
using Booking_Hotel.Infrastructure.Repositories;
using Booking_Hotel.Application.DTOs;
using AutoMapper;
using System.Linq.Expressions;

namespace Booking_Hotel.Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if(room == null)
            {
                throw new KeyNotFoundException($"Room with id {id} not found");
            }

            return room;
        }

        public async Task<IReadOnlyList<Room>> GetAllAsync()
        {
            return await _roomRepository.GetAllAsync();
        }
        
        public async Task<Room> AddRoomAsync(RoomCreateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var room = _mapper.Map<Room>(dto);
            room.Status = Status.Available;

            return await _roomRepository.AddRoomAsync(room);
        }

        public async Task UpdateRoomAsync(int id, RoomUpdateDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var room = await _roomRepository.GetByIdAsync(id);

            if(room == null)
            {
                throw new KeyNotFoundException($"Room with id {id} not found");
            }
            _mapper.Map(dto, room);

            await _roomRepository.UpdateRoomAsync(room);
        }
        
        public async Task DeleteRoomAsync(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);

            if(room==null)
            {
                throw new KeyNotFoundException($"Room with id {id} not found.");
            }

            await _roomRepository.DeleteRoomAsync(id);
        }
    }
}
