using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Abstract
{
	public interface ICommentSevice:IGenericService<Comment>
	{
		List<Comment> TGetDestinationById(int id);
		List<Comment> TGetListCommentWithDestination();
	}
}
