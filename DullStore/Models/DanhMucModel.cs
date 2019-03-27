using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.Models
{
    public class DanhMucModel
    {
        public List<SanPhamModel> ListNike { get; set; }

        public List<SanPhamModel> ListDas { get; set; }

        public List<SanPhamModel> ListCroc { get; set; }

        public List<SanPhamModel> ListCon { get; set; }

        public List<SanPhamModel> ListVan { get; set; }

        public List<SanPhamModel> D1 { get; set; }
        public List<SanPhamModel> D2 { get; set; }
        public List<SanPhamModel> D3 { get; set; }

        public DanhMucModel()
        {
            ListNike = new List<SanPhamModel>();
            ListNike.Add(new SanPhamModel("/Content/Image/940x564q80.jpg"));
            ListNike.Add(new SanPhamModel("/Content/Image/Q2940jordanshoes_9571.jpg"));
            ListNike.Add(new SanPhamModel("/Content/Image/Q3697jordanshoes_12174.jpg"));

            ListDas = new List<SanPhamModel>();
            ListDas.Add(new SanPhamModel("/Content/Image/adidas-d-rose-6-red.jpg"));
            ListDas.Add(new SanPhamModel("/Content/Image/adidas-originals-superstar-veno-1.jpg"));

            ListCroc = new List<SanPhamModel>();
            ListCroc.Add(new SanPhamModel("/Content/Image/a7705e6e423e5d42a4dac4866b82fbd9.jpg"));

            ListVan = new List<SanPhamModel>();
            ListVan.Add(new SanPhamModel("/Content/Image/vans-old-skool.jpg"));

            ListCon = new List<SanPhamModel>();
            ListCon.Add(new SanPhamModel("/Content/Image/121186-1.jpg"));
            ListCon.Add(new SanPhamModel("/Content/Image/converse-chuck-2-shoes-7.jpg"));

            D1 = new List<SanPhamModel>();
            D1.Add(new SanPhamModel("/Content/Image/940x564q80.jpg"));
            D1.Add(new SanPhamModel("/Content/Image/Q2940jordanshoes_9571.jpg"));
            D1.Add(new SanPhamModel("/Content/Image/Q3697jordanshoes_12174.jpg"));

            D2 = new List<SanPhamModel>();
            D2.Add(new SanPhamModel("/Content/Image/adidas-d-rose-6-red.jpg"));
            D2.Add(new SanPhamModel("/Content/Image/adidas-originals-superstar-veno-1.jpg"));
            D2.Add(new SanPhamModel("/Content/Image/a7705e6e423e5d42a4dac4866b82fbd9.jpg"));

            D3 = new List<SanPhamModel>();
            D3.Add(new SanPhamModel("/Content/Image/vans-old-skool.jpg"));
            D3.Add(new SanPhamModel("/Content/Image/121186-1.jpg"));
            D3.Add(new SanPhamModel("/Content/Image/converse-chuck-2-shoes-7.jpg"));
        }
    }
}