namespace RokhMAUI.Framework.DTOs.Auth
{
	public record LoginDto
	{
		public string Mobile { get; set; }
		public string? VerifyCode { get; set; }
		public int PersonPostId { get; set; }
	}

	public record MobileAuthDto(bool Success, string Message, bool NewUser = false);
}
