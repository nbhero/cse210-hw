using System.Text.Json.Serialization;

class SimpleGoal : Goal {
	[JsonPropertyName("_isComplete")]
	private bool _isComplete;

	[JsonConstructor]
	public SimpleGoal(string name, string description, int points):base(name, description, points){

	}
	public void SetComplete(){
		_isComplete = true;
	}
	public override int RecordEvent(){
		_isComplete = true;
		return _isComplete?_points:0;
	}
	public override bool IsComplete(){
		return _isComplete;
	}
	public override string GetStringRepresentation()
	{
		string complete = _isComplete ? "X" : " ";
		return $"[{complete}]{base.GetDetailsString()} ";
	}
}