using System.Text.Json.Serialization;

namespace Foster.Framework;

/// <summary>
/// An Input Binding mapped to a Controller Binding
/// </summary>
public sealed class ControllerButtonBinding : Binding
{
	[JsonInclude] public Buttons Button;

	public ControllerButtonBinding() {}
	public ControllerButtonBinding(Buttons button) => Button = button;

	public override BindingState GetState(Input input, int device) => new(
		Pressed: input.Controllers[device].Pressed(Button),
		Released: input.Controllers[device].Pressed(Button),
		Down: input.Controllers[device].Down(Button),
		Value: input.Controllers[device].Down(Button) ? 1 : 0,
		ValueNoDeadzone: input.Controllers[device].Down(Button) ? 1 : 0,
		Timestamp: input.Controllers[device].Timestamp(Button)
	);
}