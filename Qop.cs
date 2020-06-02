using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DigestAuthCalc
{
	[Serializable]
	public enum Qop
	{
		[Display(Name="(none)")] None,
		[Display(Name = "auth")] Auth,
		[Display(Name = "auth-int")] AuthInt
	}
}
