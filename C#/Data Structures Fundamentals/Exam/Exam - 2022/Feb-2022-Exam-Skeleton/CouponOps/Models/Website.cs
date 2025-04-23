namespace CouponOps.Models
{
    using System.Collections.Generic;

    public class Website
    {
        private HashSet<Coupon> _coupons;

        public Website(string domain, int usersCount)
        {
            this.Domain = domain;
            this.UsersCount = usersCount;
            this._coupons = new HashSet<Coupon>();
        }

        public string Domain { get; set; }
        public int UsersCount { get; set; }

        public HashSet<Coupon> Coupons { get { return this._coupons; } }

        public void AddCoupon(Coupon coupon)
        {
            this._coupons.Add(coupon);
        }

        public void RemoveCoupon(Coupon coupon)
        {
            this._coupons.Remove(coupon);
        }
    }
}
