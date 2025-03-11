using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage ="Lütfen bir kullanıcı adı giriniz")]
		public string username { get; set; }

		[Required(ErrorMessage = "Lütfen parola  giriniz")]
		public string password { get; set; }
	}
}
