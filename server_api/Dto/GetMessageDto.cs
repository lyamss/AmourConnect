﻿namespace server_api.Dto
{
    public class GetMessageDto
    {
        public int Id_Message { get; set; }
        public string message_content { get; set; }
        public DateTime Date_of_request { get; set; }
        public int IdUserIssuer { get; set; }
        public int Id_UserReceiver { get; set; }
        public string UserReceiverPseudo { get; set; }
        public string UserIssuerPseudo { get; set; }
        public string UserReceiverSex { get; set; }
        public string UserIssuerSex { get; set; }
        public byte[]? UserReceiverProfile_picture { get; set; }
        public byte[]? UserIssuerProfile_picture { get; set; }
    }
}