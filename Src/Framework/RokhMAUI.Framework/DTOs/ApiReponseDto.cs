namespace RokhMAUI.Framework.DTOs
{
	public record ApiReponseDto(bool Success, string Message, bool hasPersonPost = false);
	public record ApiReponseDto<T>(bool Success, string Message, bool HasPersonPost = false, T Data = default);
}
