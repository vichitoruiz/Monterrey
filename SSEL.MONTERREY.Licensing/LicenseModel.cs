using System;
﻿using System;
namespace SSEL.MONTERREY.Licensing;

public class LicenseModel
{
    public string Company { get; set; } = "SSEL MONTERREY";
    public string LicensedTo { get; set; } = "";
    public string LicenseKey { get; set; } = "";
    public DateTime ExpirationDate { get; set; }
    public string HardwareId { get; set; } = "";
}
