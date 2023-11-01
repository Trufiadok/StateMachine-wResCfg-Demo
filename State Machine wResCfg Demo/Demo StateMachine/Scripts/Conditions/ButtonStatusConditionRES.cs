using Godot;
using StateMachine;
using StateMachine.Resources;

[GlobalClass, Icon("res://addons/StateMachine/Icons/SM-C-000.svg")]
public partial class ButtonStatusConditionRES : StateConditionRES
{
	public enum Button {AtoD, AtoB, BtoA, BtoC}

	[Export] public Button button;

	protected override Condition CreateCondition() => new ButtonStatusCondition();
}

public partial class ButtonStatusCondition : Condition
{
	private DemoStateMachine demoStateMachine;

	protected new ButtonStatusConditionRES OriginRES => (ButtonStatusConditionRES)base.OriginRES;

	public override void Awake(StateMachine.StateMachine stateMachine)
	{
		stateMachine.InitDemoStateMachine();
		demoStateMachine = stateMachine.demoStateMachine;
	}
	
	protected override bool Statement()
	{
		bool state = false;

		if (demoStateMachine != null)
		{
			switch (OriginRES.button)
			{
				case ButtonStatusConditionRES.Button.AtoB:
					state = demoStateMachine.AtoBbutton;
					if (state)
						demoStateMachine.ClearAtoBbutton();
					break;

				case ButtonStatusConditionRES.Button.AtoD:
					state = demoStateMachine.AtoDbutton;
					if (state)
						demoStateMachine.ClearAtoDbutton();
					break;

				case ButtonStatusConditionRES.Button.BtoA:
					state = demoStateMachine.BtoAbutton;
					if (state)
						demoStateMachine.ClearBtoAbutton();
					break;

				case ButtonStatusConditionRES.Button.BtoC:
					state = demoStateMachine.BtoCbutton;
					if (state)
						demoStateMachine.ClearBtoCbutton();
					break;
			}
		}

		return state;
	}
	
	public override void OnStateEnter()
	{
	}
	
	public override void OnStateExit()
	{
	}
}
