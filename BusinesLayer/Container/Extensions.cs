﻿using BusinesLayer.Abstract;
using BusinesLayer.Abstract.Abstract_Uow;
using BusinesLayer.Concrete;
using BusinesLayer.Concrete.ConcreteUow;
using BusinesLayer.ValidationRules;
using BusinesLayer.ValidationRules.AnnouncementValidationRules;
using BusinesLayer.ValidationRules.ContactUs;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entity_Framework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<ICommentSevice, CommentManager>();
			services.AddScoped<ICommentDal, EfCommentDal>();

			services.AddScoped<IDestinationService, DestinationManager>();
			services.AddScoped<IDestinationDal, EfDestinationDal>();

			services.AddScoped<IAppUserService, AppUserManager>();
			services.AddScoped<IAppUserDal, EfAppUserDal>();

			services.AddScoped<IReservationService, ReservationManager>();
			services.AddScoped<IReservationDal, EfReservationDal>();

			services.AddScoped<IGuideService, GuideManager>();
			services.AddScoped<IGuideDal, EfGuideDal>();

			services.AddScoped<IExcelService, ExcelManager>();

			services.AddScoped<IPdfService, PdfManager>();

			services.AddScoped<IContactUsService, ContactUsManager>();
			services.AddScoped<IContactUsDal, EfContactUsDal>();

			services.AddScoped<IAnnouncementService, AnnouncementManager>();
			services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

			services.AddScoped<IAccountService, AccountManager>();
			services.AddScoped<IAccountDal, EfAccountDal>();

			services.AddScoped<IUowDal, UowDal>();
		}
		public static void CustomerValidator(this IServiceCollection services)
		{
			services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
			services.AddTransient<IValidator<AnnouncementUpdateDto>, AnnouncementUpdateValidator>();
			services.AddTransient<IValidator<SendMessageDto>, SendContactUsValidator>();
		}
	}
}
