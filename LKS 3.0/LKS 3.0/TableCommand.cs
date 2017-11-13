using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_3._0
{
	class TableCommand
	{
		public int x, y;
		public string command;
		public TableCommand(int x, int y, string command)
		{
			this.x = x;
			this.y = y;
			this.command = command;
		}
	}
}
