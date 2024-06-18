﻿using AmourConnect.App.Services;
using AmourConnect.Domain.Dtos.GetDtos;
using AmourConnect.Domain.Dtos.SetDtos;
using AmourConnect.Domain.Dtos.AppLayerDtos;
using Microsoft.AspNetCore.Mvc;
using AmourConnect.API.Filters;
using AmourConnect.App.Interfaces.Controllers;
namespace AmourConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(AuthorizeUser))]
    public class MessageController : Controller
    {
        private readonly IMessageCase _messageCase;

        public MessageController(IMessageCase MessageCase)
        {
            _messageCase = MessageCase;
        }



        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] SetMessageDto setmessageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string token_session_user = CookieUtils.GetCookieUser(HttpContext);

            var result = await _messageCase.SendMessageAsync(token_session_user, setmessageDto);

            if (result.success)
            {
                return Ok(new ApiResponseDto { message = result.message, succes = true });
            }

            if (result.message == "There must be validation of the friend request to chat")
            {
                return Conflict(new ApiResponseDto { message = result.message, succes = false });
            }

            return BadRequest(new ApiResponseDto { message = result.message, succes = false });
        }



        [HttpGet("GetUserMessage/{Id_UserReceiver}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetMessageDto>))]
        public async Task<IActionResult> GetUserMessage([FromRoute] int Id_UserReceiver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string token_session_user = CookieUtils.GetCookieUser(HttpContext);

            var result = await _messageCase.GetUserMessagesAsync(token_session_user, Id_UserReceiver);

            if (result.success)
            {
                return Ok(result.messages);
            }

            if (result.message == "There must be validation of the friend request to chat")
            {
                return Conflict(new ApiResponseDto { message = result.message, succes = false });
            }

            return Conflict(new ApiResponseDto { message = result.message, succes = false });
        }
    }
}