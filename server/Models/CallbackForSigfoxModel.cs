using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
[Serializable]
public class CallbackForSigfoxModel
{
    [JsonIgnore]
    public string DeviceId { get; set; }
    [Key]
    public string Data { get; set; }
}