﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract.Abstract_Uow
{
	public interface IGenericUowService<T>
	{
		void TInsert(T t);
		void TUpdate(T t);
		void TMultiUpdate(List<T> t);
		T TGetById(int id);
	}
}
