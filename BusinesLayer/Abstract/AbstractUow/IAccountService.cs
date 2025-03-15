using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract.Abstract_Uow
{
	public interface IAccountService:IGenericUowService<Account>
	{
	}
}
