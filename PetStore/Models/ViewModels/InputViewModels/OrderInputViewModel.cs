using FluentValidation;

namespace PetStore.Models.ViewModels.InputViewModels
{
	/// <summary>
	/// View model used on user's order form.
	/// </summary>
	public class OrderInputViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string CreditCardNumber { get; set; }

		/// <summary>
		/// Id of a product that has been ordered.
		/// </summary>
		public int ProductId { get; set; }
	}

	public class OrderInputViewModelValidator : AbstractValidator<OrderInputViewModel>
	{
		public OrderInputViewModelValidator()
		{
			RuleFor(m => m.FirstName).NotEmpty().WithMessage("First Name is required.");
			RuleFor(m => m.LastName).NotEmpty().WithMessage("Last Name is required.");
			RuleFor(m => m.PhoneNumber).NotEmpty().WithMessage("Phone is required.");
			RuleFor(m => m.Email).NotEmpty().EmailAddress().WithMessage("Email is required.");
			RuleFor(m => m.CreditCardNumber).NotEmpty().CreditCard().WithMessage("Credit card number is required and must contain 16 characters.");
		}
	}
}
