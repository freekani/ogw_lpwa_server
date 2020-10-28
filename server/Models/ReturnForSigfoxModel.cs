using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

[Serializable]
public class ReturnForSigfoxModel
{
    [Key]
    //[JsonIgnore]
    public string deviceId{get;set;}
    [Key]
    public string downlinkData { get; set; }
}