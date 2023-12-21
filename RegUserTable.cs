using System;

/* В данной таблице указываютя параметры элемента в базе
данных для регистарции и входа пользователя */

namespace foodsharing.Tables
{
	public class RegUserTable
	{
		public Guid UserId { get; set; }
		public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

