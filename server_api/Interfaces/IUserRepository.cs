﻿using server_api.Dto.AppLayerDto;
using server_api.Dto.GetDto;
using server_api.Models;

namespace server_api.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<GetUserDto>> GetUsersToMatchAsync(User dataUserNowConnect);
        Task<int?> GetUserIdWithGoogleIdAsync(string EmailGoogle, string userIdGoogle);
        Task<int?> CreateUserAsync(string userIdGoogle, string EmailGoogle, DateTime? date_of_birth, string sex, string Pseudo, string city);
        Task<ALSessionUserDto> UpdateSessionUserAsync(int Id_User);
        Task<bool> GetUserByPseudoAsync(string Pseudo);
        Task<bool> UpdateUserAsync(int Id_User, User user);
        Task<User> GetUserByIdUserAsync(int Id_User);
        Task<User> GetUserWithCookieAsync(string token_session_user);
    }
}