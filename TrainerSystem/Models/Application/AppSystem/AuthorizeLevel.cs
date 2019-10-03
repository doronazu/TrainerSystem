using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace TrainerSystem.Models.Application.AppSystem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeLevel : AuthorizeAttribute
    {
        private ApplicationDbContext _context;

        public AuthorizeLevel()
        {
            _context = new ApplicationDbContext();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool isAuthorize = base.AuthorizeCore(httpContext);
            if (!isAuthorize)
            {
                return false;
            }

            var uid = httpContext.User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(u => u.Id == uid);

            if (user == null) return false;

            var url = httpContext.Request.Url;
            if (url == null) return false;
            if (!Settings.IsInRole(uid,RoleName.Admin) && (url.Segments[url.Segments.Length - 1].ToString() != user.TrainerId.ToString()))
                return false;

            return true;
        }
    }
}