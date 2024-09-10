using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RokhMAUI.Framework.DTOs.Auth
{
	public record LoginDto
	{
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonPostId { get; set; }
    }
 
    
}
