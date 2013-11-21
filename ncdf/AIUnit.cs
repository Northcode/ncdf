using System;

namespace ncdf
{
	class AIUnit : Unit
	{
		public virtual void Tick()
		{
			if(prg.randGen.Next(0,4) > 1)
			{
				int d = prg.randGen.Next(0,5);
				if(d == 0)
				{
					this.Move(UDirection.Up);
				}
				else if(d == 1)
				{
					this.Move(UDirection.Down);
				}
				else if(d == 2)
				{
					this.Move(UDirection.Left);
				}
				else if(d == 3)
				{
					this.Move(UDirection.Right);
				}
			}
		}
	}
}