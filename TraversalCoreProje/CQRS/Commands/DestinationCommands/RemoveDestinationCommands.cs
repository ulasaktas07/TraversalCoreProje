namespace TraversalCoreProje.CQRS.Commands.DestinationCommands
{
	public class RemoveDestinationCommands
	{
		public RemoveDestinationCommands(int ıd)
		{
			Id = ıd;
		}

		public int Id { get; set; }
	}
}
