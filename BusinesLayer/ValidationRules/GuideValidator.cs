﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.ValidationRules
{
	public class GuideValidator : AbstractValidator<Guide>
	{
		public GuideValidator()
		{
			RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen rehber adını giriniz");
			RuleFor(x=>x.Description).NotEmpty().WithMessage("Lütfen rehber açıklamasını giriniz");
			RuleFor(x=>x.Image).NotEmpty().WithMessage("Lütfen rehber görselini giriniz");
			RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Lütfen 30 karakteden daha kısa bir isim giriniz");
			RuleFor(x=>x.Name).MaximumLength(8).WithMessage("Lütfen 8 karakteden daha uzun bir isim giriniz");
		}
	}
}
