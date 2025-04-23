namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Website> _websites;
        private Dictionary<string, Coupon> _coupons;

        public CouponOperations()
        {
            this._websites = new Dictionary<string, Website>();
            this._coupons = new Dictionary<string, Coupon>();
        }

        public void RegisterSite(Website website)
        {
            if (this._websites.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            this._websites[website.Domain] = website;
        }

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this._websites.ContainsKey(website.Domain) || this._websites[website.Domain].Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            this._coupons[coupon.Code] = coupon;
            this._websites[website.Domain].AddCoupon(coupon);
            coupon.Website = website;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!this._websites.ContainsKey(domain))
            {
                throw new ArgumentException();
            }

            Website website = this._websites[domain];

            foreach (var coupon in website.Coupons)
            {
                this._coupons.Remove(coupon.Code);
                coupon.Website = null;
            }

            website.Coupons.Clear();
            this._websites.Remove(domain);

            return website;
        }

        public Coupon RemoveCoupon(string code)
        {
            //TODO tuk cuponite moje da ne e unikalen a da sa nqkolko, za nqkolko saita!!!
            if (!this._coupons.ContainsKey(code))
            {
                throw new ArgumentException();
            }

            Coupon coupon = this._coupons[code];

            foreach (var website in this._websites.Values)
            {
                if (website.Coupons.Contains(coupon))
                {
                    website.RemoveCoupon(coupon);
                }
            }

            this._coupons.Remove(code);

            return coupon;
        }

        public bool Exist(Website website)
        {
            if (!this._websites.ContainsKey(website.Domain))
            {
                return false;
            }

            return true;
        }

        public bool Exist(Coupon coupon)
        {
            if (!this._coupons.ContainsKey(coupon.Code))
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Website> GetSites()
        {
            return new List<Website>(this._websites.Values);
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            List<Coupon> result = new List<Coupon>();

            if (!this._websites.ContainsKey(website.Domain))
            {
                throw new ArgumentException();
            }

            foreach (var coupon in this._websites[website.Domain].Coupons)
            {
                if (coupon.Website.Equals(website))
                {
                    result.Add(coupon);
                }
            }

            return result;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this._websites.ContainsKey(website.Domain) || 
                !this._coupons.ContainsKey(coupon.Code) ||
                !this._websites[website.Domain].Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            this._websites[website.Domain].RemoveCoupon(coupon);
            this._coupons.Remove(website.Domain);
            coupon.Website = null;

        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return new List<Coupon>(this._coupons.Values
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage));
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
            return new List<Website>(this._websites.Values
                .OrderBy(w => w.UsersCount)
                .ThenByDescending (w => w.Coupons.Count));
        }
    }
}
