using System;
using System.ComponentModel.DataAnnotations;
[Serializable]
public class CallbackForSigfoxModel
{
    [NonSerialized]
    public string DeviceId;
    [Key]
    public string Data { get; set; }
}