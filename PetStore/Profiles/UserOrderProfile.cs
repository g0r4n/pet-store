using AutoMapper;
using PetStore.Models.DomainModels;
using PetStore.Models.ViewModels.InputViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Profiles
{
	public class UserOrderProfile : Profile
	{
		/// <summary>
		/// Used for mapping order details to user domain model.
		/// </summary>
		public UserOrderProfile()
		{
			CreateMap<OrderInputViewModel, User>();
		}
	}
}
