﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RokhMAUI.Framework.DTOs.PersonPost;
using RokhMAUI.Framework.Extensions;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Views;

namespace RokhMAUI.Presentation.ViewModels
{
	[QueryProperty("PersonPostsJson", "serializedPersonPosts")]
	[QueryProperty("Code", "code")]
	[QueryProperty("Mobile", "mobile")]

	public partial class PersonPostVM : ObservableObject
	{
		private readonly ErpRequest _erpRequest;

		[ObservableProperty]
		private string personPostsJson;

		[ObservableProperty]
		private string mobile;

		[ObservableProperty]
		private string code;

		[ObservableProperty]
		public PersonPostDto selectedPersonPost;

		[ObservableProperty]
		public List<PersonPostDto> personPosts;

		public PersonPostVM(ErpRequest erpRequest)
		{
			_erpRequest = erpRequest;
		}

		[RelayCommand]
		async void FinalLogin()
		{
			var dto = new Framework.DTOs.Auth.LoginDto
			{
				Mobile = mobile,
				VerifyCode = code,
				PersonPostId = selectedPersonPost.PersonPostId
			};
			var result = await _erpRequest.VerifyCode(dto);
			if (result.Success)
			{
				Shell.Current.GoToAsync(nameof(UserChats));
			}
			await App.Current.MainPage.DisplayAlert("Message", result.Message, "OK");
		}

		partial void OnPersonPostsJsonChanged(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				PersonPosts = value.FromJson<List<PersonPostDto>>();
			}
		}
	}
}