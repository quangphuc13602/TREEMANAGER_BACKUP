using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Services
{
    public interface ICayxanhRepository
    {
        List<CayXanhDetail> GetByOld(int old);
        List<CayXanhDetail> Getbyid(string id);
        List<CayxanhDuong> GetbyStreet(string street);
        List<CayxanhDuongPhuong> GetbyCommune(string commune);
        List<CayxanhVM> GetByStatus(string status);
        List<CayXanhNguoi> GetByPersonWork(string id);
        List<CayxanhLoai> GetByLoai(string tenloai, string loaire, string loaithan, string loaila);
        void Add(CayxanhVM cayxanhVM);
        bool Remove(string macay);
    }
}
