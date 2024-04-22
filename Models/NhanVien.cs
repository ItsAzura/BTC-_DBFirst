using System;
using System.Collections.Generic;

namespace BTC_DBFirst.Models;

public partial class NhanVien
{
    public int NhanVienId { get; set; }

    public string HoTen { get; set; } = null!;

    public int? Age { get; set; }

    public string? GioiTinh { get; set; }

    public int PhongBanId { get; set; }

    public virtual PhongBan PhongBan { get; set; } = null!;
}
