using System.Text.Json.Serialization;

class EternalGoal : Goal {

	[JsonConstructor]
	public EternalGoal(string name, string description, int points):base(name, description, points){

	}
	public override int RecordEvent(){
		return _points;
	}
	public override bool IsComplete(){
		return false;
	}
	public override string GetStringRepresentation()
	{
		//I know this is unneccessary since IsComplete always returns false, but including for consistency
		string complete = IsComplete() ? "X" : " ";
		return $"[{complete}]{base.GetDetailsString()} ";
	}
}