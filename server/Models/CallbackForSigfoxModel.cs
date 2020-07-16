using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
[Serializable]
public class CallbackForSigfoxModel
{
    //[Key]
    //public string DeviceId ="";
    [Key]
    public string Data { get; set; }
}