using System;

namespace ncdf
{
	class Unit : Entity
	{
		protected internal int lx,ly;

		public delegate void UnitMove(UDirection direction);

		UnitMove mUp;
		UnitMove mDown;
		UnitMove mLeft;
		UnitMove mRight;

		public Unit()
		{
			mUp = MoveUp;
			mDown = MoveDown;
			mLeft = MoveLeft;
			mRight = MoveRight;

			ascii = 'U';
		}

		public void SetLastPos(int x, int y)
        {
            this.lx = x;
            this.ly = y;
        }

        public void Move(UDirection direction)
        {
        	switch (direction)
        	{
        		case UDirection.Up:
        			mUp(direction);
        			break;
    			case UDirection.Down:
    				mDown(direction);
    				break;
				case UDirection.Left:
					mLeft(direction);
					break;
				case UDirection.Right:
					mRight(direction);
					break;
        	}
        }

        public void MoveUp(UDirection direction)
        {
        	if(MovementCheckY(y - 1))
            {
                lx = x;
                ly = y;
                y = y - 1;
            }
        }

        public void MoveDown(UDirection direction)
        {
        	if(MovementCheckY(y + 1))
            {
                lx = x;
                ly = y;
                y = y + 1;
            }
        }

        public void MoveLeft(UDirection direction)
        {
        	if(MovementCheckX(x - 1))
            {
                lx = x;
                ly = y;
                x = x - 1;
            }
        }

        public void MoveRight(UDirection direction)
        {
        	if(MovementCheckX(x + 1))
            {
                lx = x;
                ly = y;
                x = x + 1;
            }
        }

        private bool MovementCheckY(int p)
        {
            return p >= 0 && p < tiles.height && tiles.get(x,p).IsWalkAble;
        }

        private bool MovementCheckX(int p)
        {
            return p >= 0 && p < tiles.width && tiles.get(p,y).IsWalkAble;
        }

        public override void Output() {
            if (tiles.get(lx, ly) != null) { tiles.get(lx, ly).Output(); }
            base.Output();
        }
	}

	public enum UDirection
	{
		Up,
		Down,
		Left,
		Right
	}
}