using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_3._0
{
	class TableCommand
	{
		public int row, coll;
		public string command;
		public TableCommand(int row, int coll, string command)
		{
			this.row = row; 
			this.coll = coll;
			this.command = command;
		}
		public static bool FoundCommand(TableCommand cm,string com)
		{
			if(cm.command == com)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
