using Entities.Models;
using System.Reflection;
using System.Text;

namespace Repositories.EFCore.Extentions;

public static class OrderQueryBuilder
{
	public static String CreateOrderQuery<T>(String orderByQueryString)
	{
		var orderParams = orderByQueryString.Trim().Split(',');

		var propertInfos = typeof(T)
			.GetProperties(BindingFlags.Public | BindingFlags.Instance);

		var orderQueryBuilder = new StringBuilder();

		foreach (var param in orderParams)
		{
			if (string.IsNullOrEmpty(param)) continue;

			var propertyFromQueryName = param.Split(' ')[0];

			var objectProperty = propertInfos.FirstOrDefault(x => x.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

			if (objectProperty is null) continue;

			var direction = param.EndsWith(" desc") ? "descending" : "ascending";

			orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
		}

		var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

		return orderQuery;
	}
}
