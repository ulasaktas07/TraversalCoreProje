﻿using BusinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
	public class AppUserManager : IAppUserService
	{
		IAppUserDal _appUserDal;

		public AppUserManager(IAppUserDal appUserDal)
		{
			_appUserDal = appUserDal;
		}

		public void TAdd(AppUser t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(AppUser t)
		{
			_appUserDal.Delete(t);
		}

		public AppUser TGetById(int id)
		{
			return _appUserDal.GetByID(id);
		}

		public List<AppUser> TGetList()
		{
			return _appUserDal.GetList();
		}

		public void TUpdate(AppUser t)
		{
			throw new NotImplementedException();
		}
	}
}
