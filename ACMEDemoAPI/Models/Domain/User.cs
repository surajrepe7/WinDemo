namespace WinDemoAPI.Models.Domain
{
	public class User
	{
		public int UserId { get; set; }
		public string Firstname { get; set; }=string.Empty;
		public string Lastname { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
		public string? Email { get; set; }
		public string? Password { get; set; }
		public string? CPassword { get; set; }
		public int Gender { get; set; }
		public string Address1 { get; set; }= string.Empty;
		public string? Address2 { get; set; }
		public string? Pincode { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Zipcode { get; set; }


	}
}
