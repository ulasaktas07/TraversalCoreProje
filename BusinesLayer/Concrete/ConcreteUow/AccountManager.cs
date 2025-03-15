using BusinesLayer.Abstract.Abstract_Uow;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete.ConcreteUow
{
	public class AccountManager : IAccountService
	{
		private readonly IAccountDal _accountDal;
		private readonly IUowDal _unitOfWork;

		public AccountManager(IAccountDal accountDal, IUowDal unitOfWork)
		{
			_accountDal = accountDal;
			_unitOfWork = unitOfWork;
		}

		public Account TGetById(int id)
		{
			return _accountDal.GetById(id);
		}

		public void TInsert(Account t)
		{
			_accountDal.Insert(t);
			_unitOfWork.Save();
		}

		public void TMultiUpdate(List<Account> t)
		{
			_accountDal.MultiUpdate(t);
			_unitOfWork.Save();
		}

		public void TUpdate(Account t)
		{
			_accountDal.Update(t);
			_unitOfWork.Save();
		}
	}
}
