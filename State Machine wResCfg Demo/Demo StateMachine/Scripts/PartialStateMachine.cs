using Godot;

namespace StateMachine
{
	public partial class StateMachine : Node
	{
		public DemoStateMachine demoStateMachine { get; private set; }

		public void InitDemoStateMachine()
		{
            if (demoStateMachine == null)
  			    demoStateMachine = GetTree().Root.FindChild("DemoStateMachine", true, false) as DemoStateMachine;
		}
	}
}