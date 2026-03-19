using Microsoft.EntityFrameworkCore;
using PetProject2026.Context;
using PetProject2026.DTOs.DTOHotel;
using PetProject2026.DTOs.DTORoom;
using PetProject2026.Models;
using PetProject2026.Services.Interfaces;
using System.Net.WebSockets;

namespace PetProject2026.Services.Implementations
{
    public class ImplsHotelService : IHotelService
    {
        private readonly BookingContext bookingContext;
        public ImplsHotelService( BookingContext _bookingcontext)
        {
            bookingContext = _bookingcontext;

        }
        public async Task<List<HotelDTO>> getAllHotel()
        {
            var hotel = await bookingContext.hotel.Select(h => new HotelDTO
            {
                hName = h.hotelName,
                startLv = h.starLevel,
                address = h.address,
                description = h.desciption
            }).ToListAsync();
            
            return hotel;
        }

        public async Task<HotelDTO> getHotelById(int id)
        {
            var hotel = await bookingContext.hotel.FindAsync(id);
            if (hotel == null) { throw new Exception("Cannot find Hotel"); }
            return new HotelDTO
            {
                hName = hotel.hotelName,
                startLv = hotel.starLevel,
                address = hotel.address,
                description = hotel.desciption
            };

        }
        public async Task<HotelDTO> createHotel(CreateHotelDTO request)
        {
            var hotel = new Hotel
            {
                hotelName = request.hName,
                starLevel = request.startLv,
                address = request.address,
                desciption = request.description
            };
             await bookingContext.hotel.AddAsync(hotel);
            await bookingContext.SaveChangesAsync();
            return new HotelDTO
            {
                hName = hotel.hotelName,
                startLv = hotel.starLevel,
                address = hotel.address,
                description = hotel.desciption
            };
        }
        public async Task<UpdateHotelDTO> updateHotelById(int id, UpdateHotelDTO request)
        {
            var hotel = await bookingContext.hotel.FindAsync(id);
            if (hotel == null) { throw new Exception("hotel not found"); }
            hotel.hotelName = request.hName;
            hotel.starLevel = request.startLv;
            hotel.address = request.address;
            hotel.desciption = request.description;
            await bookingContext.SaveChangesAsync();
            return new UpdateHotelDTO
            {
                hName = hotel.hotelName,
                startLv = hotel.starLevel,
                address = hotel.address,
                description = hotel.desciption
            };

        }
        public async Task deleteHotelById(int id)
        {
            var hotel = await bookingContext.hotel.FindAsync(id);
            if (hotel == null) { throw new Exception("hotel not found"); }
            bookingContext.hotel.Remove(hotel);
            await bookingContext.SaveChangesAsync();
        }

        

        
    }
}
