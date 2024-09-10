namespace RokhMAUI.Framework.Configuration.Interface
{
	public interface ISecureStorageService
	{
		Task<string> GetValueAsync(string key);
		Task SetValueAsync(string key, string value);
		bool RemoveAsync(string key);
	}
}
