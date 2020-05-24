//  I certify that this assignment is entirely my own work, performed independently and without any help from the sources which are not allowed.
//  Mateusz Zalewski
//Oyster is a website with reviews of various holiday destinations.
namespace TravelAgencies.DataAccess
{
	class BSTNode
	{
		public string Review { get; set; }
		public string UserName { get; set; }
		public BSTNode Left { get; set; }
		public BSTNode Right { get; set; }
	}
	class OysterDatabase : IIterable<BSTNode>
	{
		public BSTNode Reviews { get; set; }

		public IIterator<BSTNode> GetIterator()
		{
			return new OysterIterator(Reviews);
		}
	}

	class OysterIterator : IIterator<BSTNode>
	{
		private int s; // type of node : 0-nothing, 1-left, 2-this, 3-right
		private OysterIterator it;
		private readonly BSTNode root; //t
		public BSTNode Current { get; private set; }
		public bool IsDone { get; private set; }

		public OysterIterator(BSTNode _t = null)
		{
			root = _t;
			s = 0;
			First();
		}

		public void First()
		{
			if (s == 0)
			{
				IsDone = false;
				it = null;
				if (root == null)
					s = 0; //no tree, no next
				else if (root.Left != null)
				{
					s = 1; //we are in the left subtree
					it = new OysterIterator(root.Left);
				}
				else
					s = 2;
			}
			if (s == 0)
			{
				IsDone = true;
				Current = null;
			}
		}

		public void Next()
		{
			if (s == 0)
			{
				IsDone = true;
				Current = null;
				return;
			}
			else if (s == 2)
			{
				if (root.Right == null)
					s = 0;
				else
				{
					s = 3;
					it = new OysterIterator(root.Right);
				}
				Current = root;
				return;
			}

			it.Next();
			var node = it.Current;
			if (node == null)
			{
				if (s == 1)
					s = 2;
				else // right node returned null
					s = 0;
				Next();
				node = Current;
			}
			Current = node;
			return;
		}
	}
}
