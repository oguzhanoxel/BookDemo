namespace Entities.Exceptions;

public class PriceOutOfRangeBadRequestException : BadRequestException
{
	public PriceOutOfRangeBadRequestException() : base("Price is out of the acceptable range.")
	{
		
	}
}
