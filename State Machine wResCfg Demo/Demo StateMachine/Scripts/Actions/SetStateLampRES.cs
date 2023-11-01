using Godot;
using StateMachine;
using StateMachine.Resources;

[GlobalClass, Icon("res://addons/StateMachine/Icons/SM-A-000.svg")]
public partial class SetStateLampRES : StateActionRES
{
	public enum StateLamp {A, B, C, D}

	[Export] public StateLamp lamp;

	protected override StateAction CreateAction() => new SetStateLamp();
}

public partial class SetStateLamp : StateAction
{
	private DemoStateMachine demoStateMachine;

	protected new SetStateLampRES OriginRES => (SetStateLampRES)base.OriginRES;

	public override void Awake(StateMachine.StateMachine stateMachine)
	{
		stateMachine.InitDemoStateMachine();
		demoStateMachine = stateMachine.demoStateMachine;
	}
	
	public override void OnUpdate()
	{
	}
	
	public override void OnStateEnter()
	{
		if (demoStateMachine != null)
		{
			switch (OriginRES.lamp)
			{
				case SetStateLampRES.StateLamp.A:
					demoStateMachine.aLamp = true;
					break;

				case SetStateLampRES.StateLamp.B:
					demoStateMachine.bLamp = true;
					break;

				case SetStateLampRES.StateLamp.C:
					demoStateMachine.cLamp = true;
					break;

				case SetStateLampRES.StateLamp.D:
					demoStateMachine.dLamp = true;
					break;
			}
		}
	}
	
	public override void OnStateExit()
	{
		if (demoStateMachine != null)
		{
			switch (OriginRES.lamp)
			{
				case SetStateLampRES.StateLamp.A:
					demoStateMachine.aLamp = false;
					break;

				case SetStateLampRES.StateLamp.B:
					demoStateMachine.bLamp = false;
					break;

				case SetStateLampRES.StateLamp.C:
					demoStateMachine.cLamp = false;
					break;

				case SetStateLampRES.StateLamp.D:
					demoStateMachine.dLamp = false;
					break;
			}
		}
	}
}
