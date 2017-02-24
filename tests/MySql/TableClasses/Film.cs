﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Massive.Tests.MySql.TableClasses
{
	public class Film : DynamicModel
	{
		public Film() : this(true)
		{
		}


		public Film(bool includeSchema) :
			base(TestConstants.ReadTestConnectionStringName, includeSchema ? "sakila.film" : "film", "film_id")
		{
		}


		/// <summary>
		/// Hook, called when IsValid is called
		/// </summary>
		/// <param name="item">The item to validate.</param>
		public override void Validate(dynamic item)
		{
			// bogus validation: isn't valid if rental_duration > 5

			if(item.rental_duration > 5)
			{
				Errors.Add("rental_duration > 5");
			}
		}
	}
}
