using System;
using System.ComponentModel.DataAnnotations;
[Serializable]
public class ReturnForSigfoxModel
{
    [Key]
    public string downlinkData { get; set; }
}