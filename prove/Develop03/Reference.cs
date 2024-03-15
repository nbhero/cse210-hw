using System;

class Reference
{
    public string _reference {get; set;}
    private string _book {get; set;}
    private string _chapter {get; set;}
    private string _verse {get; set;}

    public Reference(string reference){
        _reference = reference;
    }
    public string getDisplayText(){
        return $"Scripture Reference: {this._reference}";
    }

}