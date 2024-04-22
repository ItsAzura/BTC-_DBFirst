using System;
using System.Collections.Generic;

namespace BTC_DBFirst.Models;

public partial class PhongBan
{
    public int PhongBanId { get; set; }

    public string TenPhongBan { get; set; } = null!;

    public int CongTyId { get; set; }

    public virtual CongTy CongTy { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
