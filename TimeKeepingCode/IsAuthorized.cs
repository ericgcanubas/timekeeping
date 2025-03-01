using System;

namespace TimeKeepingCode
{
    public static class IsAuthorized
    {
        public static bool IsHaveUserAccess(Roles role,UserRoles userRole) 
        {
            var userRoles = TimeKeepingDataCode.Biometrics.UserRoles.GetAllUserRoles(Program.BiometricsConnection, Program.User.Id);
            for (int i = 0; i < userRoles.Count; i++)
            {
                if (userRoles[i].RoleId == Convert.ToInt32(role)) 
                {
                    switch (userRole)
                    {
                        case UserRoles.CanCreate:
                            return userRoles[i].CanCreate;
                        case UserRoles.CanDelete:
                            return userRoles[i].CanDelete;
                        case UserRoles.CanGenerateReport:
                            return userRoles[i].CanGenerateReport;
                        case UserRoles.CanPost:
                            return userRoles[i].CanPost;
                        case UserRoles.CanUnpost:
                            return userRoles[i].CanUnPost;
                        case UserRoles.CanUpdate:
                            return userRoles[i].CanUpdate;
                        case UserRoles.CanView:
                            return userRoles[i].CanView;
                    }
                }
            }

            return false;
        }
    }
}
