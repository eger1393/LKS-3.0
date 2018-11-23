﻿using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Abstract
{
	public interface IPrepodRepository : IRepository<Prepod>
	{
		List<Prepod> GetItems();
	}
}
