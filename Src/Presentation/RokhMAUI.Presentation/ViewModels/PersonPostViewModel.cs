using CommunityToolkit.Mvvm.ComponentModel;
using RokhMAUI.Framework.DTOs.PersonPost;
using System.Text.Json;

namespace RokhMAUI.Presentation.ViewModels
{
	[QueryProperty("PersonPostsJson", "serializedPersonPosts")]
	public partial class PersonPostViewModel : ObservableObject
	{
		[ObservableProperty]
		private string personPostsJson;

		[ObservableProperty]
		public PersonPostDto selectedPersonPost;

		[ObservableProperty]
		public List<PersonPostDto> PersonPosts;

		partial void OnPersonPostsJsonChanged(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				// Deserialize the JSON string back into a List<PersonPost>
				PersonPosts = JsonSerializer.Deserialize<List<PersonPostDto>>(value);
			}
		}
	}
}
