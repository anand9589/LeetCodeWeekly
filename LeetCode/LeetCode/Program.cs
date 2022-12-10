using December22;
using Common;

var head = Utilities.BuildTreeNode(new int?[] { 2, null, 0, null, 4, null, 3, null, 1 });
Solution solution = new Solution();
var p =solution.MaxAncestorDiff(head);

