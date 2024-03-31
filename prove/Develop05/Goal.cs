using System.Text.Json.Serialization;

abstract class Goal
{
    [JsonPropertyName("_shortName")]
    protected string _shortName { get; }

    [JsonPropertyName("_description")]
    protected string _description { get; }

    [JsonPropertyName("_points")]
    protected int _points { get; }

    [JsonConstructor]
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
	// Protected getters for private properties
    public string GetShortName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }
    public abstract string GetStringRepresentation();
}