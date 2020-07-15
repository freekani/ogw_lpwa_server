using System;
using System.ComponentModel.DataAnnotations;
[Serializable]
public class CallbackForSigfoxModel
{
    [Key]
    public string DeviceId { get; set; }
    [Key]
    public string Data { get; set; }
}