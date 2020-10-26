using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarListAppForEmiratesAuction.Models
{
    public class CarViewModel
    {
        public class Error
        {
        }

        public class UaeTime
        {
            public string en { get; set; }
            public string ar { get; set; }
        }

        public class AuctionInfo
        {
            public int bids { get; set; }
            public int endDate { get; set; }
            public string endDateEn { get; set; }
            public string endDateAr { get; set; }
            public string currencyEn { get; set; }
            public string currencyAr { get; set; }
            public int currentPrice { get; set; }
            public int minIncrement { get; set; }
            public int lot { get; set; }
            public int priority { get; set; }
            public int VATPercent { get; set; }
            public int itemAuctionType { get; set; }
            public int isModified { get; set; }
            public int itemid { get; set; }
            public int iCarId { get; set; }
            public string iVinNumber { get; set; }
        }

        public class Car
        {
            public int carID { get; set; }
            public string image { get; set; }
            public int year { get; set; }
            public string makeEn { get; set; }
            public string makeAr { get; set; }
            public string modelEn { get; set; }
            public string modelAr { get; set; }
            public string bodyEn { get; set; }
            public string bodyAr { get; set; }
            public AuctionInfo AuctionInfo { get; set; }
        }

        public class Root
        {
            public string alertEn { get; set; }
            public string alertAr { get; set; }
            public Error Error { get; set; }
            public int RefreshInterval { get; set; }
            public string Ticks { get; set; }
            public int count { get; set; }
            public int endDate { get; set; }
            public string sortOption { get; set; }
            public string sortDirection { get; set; }
            public UaeTime uaeTime { get; set; }
            public int updateList { get; set; }
            public int minYear { get; set; }
            public int maxYear { get; set; }
            public int minPrice { get; set; }
            public int maxPrice { get; set; }
            public int page { get; set; }
            public int totalPage { get; set; }
            public int itemPerPage { get; set; }
            public List<Car> Cars { get; set; }
        }


    }
}
