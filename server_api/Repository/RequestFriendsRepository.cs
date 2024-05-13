﻿using Microsoft.EntityFrameworkCore;
using server_api.Data;
using server_api.Dto.GetDto;
using server_api.Interfaces;
using server_api.Models;

namespace server_api.Repository
{
    public class RequestFriendsRepository : IRequestFriends
    {
        private readonly ApiDbContext _context;

        public RequestFriendsRepository(ApiDbContext context)
        {
            _context = context;
        }


        public async Task<ICollection<GetRequestFriendsDto>> GetRequestFriendsAsync(int Id_User)
        {
            return await _context.RequestFriends
                .Where(r => r.IdUserIssuer == Id_User || r.Id_UserReceiver == Id_User)
                .Select(r => new GetRequestFriendsDto
                {
                    Id_RequestFriends = r.Id_RequestFriends,
                    IdUserIssuer = r.IdUserIssuer,
                    UserIssuerPseudo = r.UserIssuer.Pseudo,
                    Id_UserReceiver = r.Id_UserReceiver,
                    UserReceiverPseudo = r.UserReceiver.Pseudo,
                    Status = r.Status,
                    Date_of_request = r.Date_of_request
                })
                .ToListAsync();
        }

        public async Task<RequestFriends> GetRequestFriendByIdAsync(int IdUserIssuer, int IdUserReceiver)
        {
            return await _context.RequestFriends
                    .Where(r => (r.IdUserIssuer == IdUserIssuer && r.Id_UserReceiver == IdUserReceiver)
                        || (r.IdUserIssuer == IdUserReceiver && r.Id_UserReceiver == IdUserIssuer))
                        .FirstOrDefaultAsync();
        }


        public async Task AddRequestFriendAsync(RequestFriends requestFriends)
        {
            await _context.RequestFriends.AddAsync(requestFriends);
            await _context.SaveChangesAsync();
        }


        public async Task<RequestFriends> GetUserFriendRequestByIdAsync(int Id_User, int IdUserIssuer)
        {
            return await _context.RequestFriends
        .FirstOrDefaultAsync(r => (r.IdUserIssuer == IdUserIssuer && r.Id_UserReceiver == Id_User && r.Status == RequestStatus.Onhold));
        }



        public async Task UpdateStatusRequestFriendsAsync(RequestFriends friendRequest)
        {
            _context.Entry(friendRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}