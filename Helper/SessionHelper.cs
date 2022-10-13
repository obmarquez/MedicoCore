﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MedicoCore.Helper
{
    public class SessionHelper
    {
        public static string GetValue(IPrincipal User, string Property)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(Property);
            return r == null ? "" : r.Value;
        }

        public static string GetNameIdentifier(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return r == null ? "" : r.Value;
        }

        public static string GetName(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name);
            return r == null ? "" : r.Value;
        }

        public static string GetNameActor(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Actor);
            return r == null ? "" : r.Value;
        }

        public static string GetNameRol(IPrincipal User)
        {
            var r = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Role);
            return r == null ? "" : r.Value;
        }
    }
}
