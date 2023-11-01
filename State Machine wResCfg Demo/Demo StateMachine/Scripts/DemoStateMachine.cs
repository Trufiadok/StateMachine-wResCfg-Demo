using Godot;

public partial class DemoStateMachine : Node
{
	SpinBox iValue;
	SpinBox jValue;

    public int iVariable
	{
		get
		{
			if (iValue != null)
			{
				return (int)iValue.Value;
			}
			return 0;
		}

		set
		{
			if (iValue != null)
			{
				iValue.Value = (double)value;
			}
		}
	}	
    public int jVariable
	{
		get
		{
			if (jValue != null)
			{
				return (int)jValue.Value;
			}
			return 0;
		}

		set
		{
			if (jValue != null)
			{
				jValue.Value = (double)value;
			}
		}
	}

	ColorRect aStateLamp;
	ColorRect bStateLamp;
	ColorRect cStateLamp;
	ColorRect dStateLamp;

	public bool aLamp
	{
		get
		{
			if (aStateLamp != null)
			{
				return aStateLamp.Color == new Color(0, 1, 0, 1) ? true : false;
			}
			return false;
		}

		set
		{
			if (aStateLamp != null)
			{
				aStateLamp.Color = value ? new Color(0, 1, 0, 1) : new Color(1, 0, 0, 1);
			}
		}
	}
	public bool bLamp
	{
		get
		{
			if (bStateLamp != null)
			{
				return bStateLamp.Color == new Color(0, 1, 0, 1) ? true : false;
			}
			return false;
		}

		set
		{
			if (bStateLamp != null)
			{
				bStateLamp.Color = value ? new Color(0, 1, 0, 1) : new Color(1, 0, 0, 1);
			}
		}
	}
	public bool cLamp
	{
		get
		{
			if (cStateLamp != null)
			{
				return cStateLamp.Color == new Color(0, 1, 0, 1) ? true : false;
			}
			return false;
		}

		set
		{
			if (cStateLamp != null)
			{
				cStateLamp.Color = value ? new Color(0, 1, 0, 1) : new Color(1, 0, 0, 1);
			}
		}
	}
	public bool dLamp
	{
		get
		{
			if (dStateLamp != null)
			{
				return dStateLamp.Color == new Color(0, 1, 0, 1) ? true : false;
			}
			return false;
		}

		set
		{
			if (dStateLamp != null)
			{
				dStateLamp.Color = value ? new Color(0, 1, 0, 1) : new Color(1, 0, 0, 1);
			}
		}
	}

	public bool AtoDbutton { get; private set; }
	public bool AtoBbutton { get; private set; }
	public bool BtoAbutton { get; private set; }
	public bool BtoCbutton { get; private set; }

	public void ClearAtoDbutton()
	{
		AtoDbutton = false;
	}
	public void ClearAtoBbutton()
	{
		AtoBbutton = false;
	}
	public void ClearBtoAbutton()
	{
		BtoAbutton = false;
	}
	public void ClearBtoCbutton()
	{
		BtoCbutton = false;
	}

	public override void _EnterTree()
	{
		iValue = FindNode<SpinBox>("iValue", true, false);
		jValue = FindNode<SpinBox>("jValue", true, false);

		aStateLamp = FindNode<ColorRect>("aStatus", true, false);
		bStateLamp = FindNode<ColorRect>("bStatus", true, false);
		cStateLamp = FindNode<ColorRect>("cStatus", true, false);
		dStateLamp = FindNode<ColorRect>("dStatus", true, false);
	}

    // Called when the node enters the scene tree for the first time.
    // public override void _Ready()
	// {

	// }
	
	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public override void _Process(double delta)
	// {
	// }

	public void AtoB_OnButtonPressed()
	{
		AtoBbutton = true;
	}
	
	public void AtoD_OnButtonPressed()
	{
		AtoDbutton = true;
	}	

	public void BtoA_OnButtonPressed()
	{
		BtoAbutton = true;
	}	

	public void BtoC_OnButtonPressed()
	{
		BtoCbutton = true;
	}

	public T FindNode<T>(string nodeName, bool recursive = true, bool owned = true) where T : class
	{
		T nodeObject;

		nodeObject = GetTree().Root.FindChild(nodeName, recursive, owned) as T;

		return nodeObject;
	}
}
