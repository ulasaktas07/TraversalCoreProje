using BusinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer.Concrete
{
	public class TestimonialManager:ITestimonialService
	{
		ITestimonialDal _tesmonialDal;

		public TestimonialManager(ITestimonialDal tesmonialDal)
		{
			_tesmonialDal = tesmonialDal;
		}

		public void TAdd(Testimonial t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Testimonial t)
		{
			throw new NotImplementedException();
		}

		public Testimonial TGetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Testimonial> TGetList()
		{
			return _tesmonialDal.GetList();
		}

		public void TUpdate(Testimonial t)
		{
			throw new NotImplementedException();
		}
	}
}
