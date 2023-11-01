using Godot;
using StateMachine;
using StateMachine.Resources;

[GlobalClass, Icon("res://addons/StateMachine/Icons/SM-C-000.svg")]
public partial class VariableRelationConditionRES : StateConditionRES
{
	public enum Relation {Equal, NotEqual, Less, Greater, LessEqual, GreaterEqual}
	public enum Variable {iVariable, jVariable}

	[Export] public Variable variable;
	[Export] public Relation relation;
	[Export] public int value;

	protected override Condition CreateCondition() => new VariableRelationCondition();
}

public partial class VariableRelationCondition : Condition
{
	private DemoStateMachine demoStateMachine;
	private int variableValue;

	protected new VariableRelationConditionRES OriginRES => (VariableRelationConditionRES)base.OriginRES;

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
			switch (OriginRES.variable)
			{
				case VariableRelationConditionRES.Variable.iVariable:
					variableValue = demoStateMachine.iVariable;
					break;

				case VariableRelationConditionRES.Variable.jVariable:
					variableValue = demoStateMachine.jVariable;
					break;
			}

			switch (OriginRES.relation)
			{
				case VariableRelationConditionRES.Relation.Equal:
					state = variableValue == OriginRES.value;
					break;

				case VariableRelationConditionRES.Relation.NotEqual:
					state = variableValue != OriginRES.value;
					break;

				case VariableRelationConditionRES.Relation.Less:
					state = variableValue < OriginRES.value;
					break;

				case VariableRelationConditionRES.Relation.Greater:
					state = variableValue > OriginRES.value;
					break;

				case VariableRelationConditionRES.Relation.LessEqual:
					state = variableValue <= OriginRES.value;
					break;

				case VariableRelationConditionRES.Relation.GreaterEqual:
					state = variableValue >= OriginRES.value;
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
