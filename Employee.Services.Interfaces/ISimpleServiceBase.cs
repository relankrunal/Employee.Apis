using System;
namespace Employee.Services.Interfaces
{
	public interface ISimpleServiceBase
	{
		public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }
    }
}

