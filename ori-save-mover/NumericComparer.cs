using System.Collections; // required for NumericComparer : IComparer only

namespace ori_save_mover
{
	public class NumericComparer : IComparer
	{
		public int Compare(object? x, object? y)
		{
			if ((x is string X) && (y is string Y))
			{
				return StringLogicalComparer.Compare(X, Y);
			}
			return -1;
		}
	}
}