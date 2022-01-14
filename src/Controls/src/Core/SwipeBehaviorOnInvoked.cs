namespace Microsoft.Maui.Controls
{
	/// <include file="../../docs/Microsoft.Maui.Controls/SwipeBehaviorOnInvoked.xml" path="Type[@FullName='Microsoft.Maui.Controls.SwipeBehaviorOnInvoked']/Docs" />
	public enum SwipeBehaviorOnInvoked
	{
		/// <include file="../../docs/Microsoft.Maui.Controls/SwipeBehaviorOnInvoked.xml" path="//Member[@MemberName='Auto']/Docs" />
		Auto,       // In Reveal mode, the SwipeView closes after an item is invoked. In Execute mode, the SwipeView remains open.
		/// <include file="../../docs/Microsoft.Maui.Controls/SwipeBehaviorOnInvoked.xml" path="//Member[@MemberName='Close']/Docs" />
		Close,      // The SwipeView closes after an item is invoked.
		/// <include file="../../docs/Microsoft.Maui.Controls/SwipeBehaviorOnInvoked.xml" path="//Member[@MemberName='RemainOpen']/Docs" />
		RemainOpen  // The SwipeView remains open after an item is invoked.
	}
}