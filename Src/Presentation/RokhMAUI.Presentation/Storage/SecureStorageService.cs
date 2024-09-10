using RokhMAUI.Framework.Configuration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokhMAUI.Presentation.Storage
{
	public class SecureStorageService : ISecureStorageService
	{
		public Task<string?> GetValueAsync(string key)
		{
			return SecureStorage.GetAsync(key);
		}

		public Task SetValueAsync(string key, string value)
		{
			return SecureStorage.SetAsync(key, value);
		}

		public bool RemoveAsync(string key)
		{
			return SecureStorage.Remove(key);
		}
	}
}
