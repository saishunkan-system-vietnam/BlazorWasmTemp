﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm.Shared
{
	public class Users
	{
		public string UserId { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public DateTime BirthDt { get; set; }
		public string Phone { get; set; }
		public DateTime UsUpdateDtTm { get; set; }
		public bool DelFlg { get; set; }
	}
}
