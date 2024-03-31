using System.Text.Json.Serialization;

class ChecklistGoal : Goal {
	[JsonPropertyName("_amountComplete")]
	private int _amountComplete;
	[JsonPropertyName("_target")]
	private int _target;
	[JsonPropertyName("_bonus")]
	private int _bonus;

	[JsonConstructor]
	public ChecklistGoal(string name, string description, int points, int target, int bonus):base(name, description, points){
		_target = target;
		_bonus = bonus;
	}
	// Protected getters for private properties
	public void SetAmountComplete(int amountComplete) {
		_amountComplete = amountComplete;
	}
    public int GetAmountComplete() => _amountComplete;
    public int GetTarget() => _target;
    public int GetBonus() => _bonus;
	public override int RecordEvent(){
		_amountComplete++;
		if(_amountComplete >= _target){
			return _bonus+_points;
		}
		return _points;
	}
	public override bool IsComplete(){
		if(this._amountComplete >= this._target){
			return true;
		}
		return false;
	}
	public new string GetDetailsString()
	{
		return $"{base.GetDetailsString()} - Complete {_amountComplete}/{_target}";
	}

	public override string GetStringRepresentation()
	{
		string complete = IsComplete() ? "X" : " ";
		return $"[{complete}]{base.GetDetailsString()} - {_amountComplete}/{_target}";
	}
}