using System;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models.Client.Dtos
{
	public class CreateEmployee
	{
		[StringLength(1000)]
		[Required]
		public string Name { get; set; }
	}
}

