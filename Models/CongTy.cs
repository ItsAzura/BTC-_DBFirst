using System;
using System.Collections.Generic;

namespace BTC_DBFirst.Models;

public partial class CongTy
{
    public int CongTyId { get; set; }

    public string TenCongTy { get; set; } = null!;

    public virtual ICollection<PhongBan> PhongBans { get; set; } = new List<PhongBan>();
}
