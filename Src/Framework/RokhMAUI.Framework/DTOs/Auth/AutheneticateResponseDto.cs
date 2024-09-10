using Core.Auth;
using RokhMAUI.Framework.DTOs.PersonPost;
using System.Text.Json.Serialization;

namespace RokhMAUI.Framework.DTOs.Auth
{
	public class AutheneticateResponseDto : RokhAuthenticationResponse
	{
		public AutheneticateResponseDto(bool success) : base(success)
		{
		}

		public bool loginWithOutPeriod { get; set; }
		public int periodId { get; set; }
		public string fullName { get; set; }
		public Guid? Profile { get; set; }
		public List<PersonPostDto> Items { get; set; }

		[JsonIgnore]
		public PersonPostDto PersonPost { get; set; }
		public bool NewUser { get; set; }

	}
}
