using System;
using System.Collections.Generic;

namespace RokhMAUI.Framework.DTOs.PersonPost
{
	public class PersonPostDto
	{
		public int PersonPostId { get; set; }
		public Guid PostId { get; set; }
		public int TenantId { get; set; }
		//برای نمایش پست تعریف شده
		public string PostName { get; set; }
		public List<int> PersonnelIds { get; set; }

		//برای Apiهای Get تعریف شده
		public int PersonnelGetId { get; set; }
		public DateTime CreatedDate { get; set; }

		//برای نمایش پست و نام شخص در GetAllPersonPosts
		public string PersonPost { get; set; }

		public string PostTitle { get; set; }
	}

	public class AssignPersonPostDto
	{
		public Guid PostId { get; set; }
		public int TenantId { get; set; }
		public int PersonnelId { get; set; }
	}
}
