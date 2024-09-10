using Etraab.CC.Framework.Cache.Models;
namespace RokhMAUI.Framework.DTOs.Auth.Rcc
{
    public class AgentLoginDto
	{
		public string Tenant { get; set; }
		public string Agent { get; set; }
		public string UUID { get; set; }
		public string Extension { get; set; }
		public string? VirtualExtension { get; set; }
		public string Server { get; set; }
		public string WebrtcBaseUrl { get; set; }
		public string SipServer { get; set; }
		public string Authorization { get; set; }
		public bool Webrtc { get; set; }
		public bool spv { get; set; }
		public string Token { get; set; }
		public string RefreshToken { get; set; }
		public string Rp_Token { get; set; }
		public List<EndpointCacheData> Endpoints { get; set; }
		public string StunServer { get; set; }
		public List<EnAccessTabs> AccessTabs { get; set; }
		public List<EnAccessSetting> AccessSettings { get; set; }
	}

	public class AgentEndpointDto
	{
		public string Name { get; set; }
		public string DefaultExtension { get; set; }
		public string UUID { get; set; }
		public bool BlanketRecording { get; set; }
		public bool NailedUp { get; set; }
		public bool AutoAccept { get; set; }
		public string DefaultCampaign { get; set; }

		public bool IsVoice { get; set; }
	}
}
