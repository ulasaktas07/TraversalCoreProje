﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
	public interface IExcelService
	{
		byte[] ExcelList<T>(List<T> t) where T : class;
	}
}
