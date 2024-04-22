using BTC_DBFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace BTC_DBFirst
{
    public static class ConsoleResult
    {
        public static void Show(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<CompanyDbdatabaseFirstContext>();

                var result = applicationDbContext.NhanViens.Where(nv => nv.PhongBanId == 3 && nv.GioiTinh == "Nam" && (nv.Age >= 30 && nv.Age <= 40)).ToList();

                Console.WriteLine("Result: ");

                result.ForEach(nv => Console.WriteLine($"NhanVien name: {nv.HoTen} - age: {nv.Age} - GioiTinh: {nv.GioiTinh} - PhongBan: {nv.PhongBanId}"));
            }
        }
    }
}
