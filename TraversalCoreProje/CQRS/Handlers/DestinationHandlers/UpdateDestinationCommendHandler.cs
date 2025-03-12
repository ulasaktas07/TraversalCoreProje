using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class UpdateDestinationCommendHandler
	{
		private readonly Context _context;

		public UpdateDestinationCommendHandler(Context context)
		{
			_context = context;
		}
		public void Handle(UpdateDestinationCommand command)
		{
			var destination = _context.Destinations.Find(command.Destinationid);
			destination.City = command.City;
			destination.DayNight = command.DayNight;
			destination.Price = command.price;
			_context.SaveChanges();
		}
	}
}
