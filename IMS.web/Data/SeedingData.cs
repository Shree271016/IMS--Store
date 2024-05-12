using Microsoft.AspNetCore.Identity;

namespace IMS.web.Data
{
    public class SeedingData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            //roll manager ko lagi service banako
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
           // array banaera rolles ma 5 wota type define gareko
            string[] Roles = { "SUPERADMIN", "ADMIN", "COUNTER", "STORE","PUBLIC" };
           //rollname ma roles ani type string ho 5 wota ko lagi 
            foreach (string roleName in Roles)
            {
                //role name check garxa yadi xaen vhaane vitra jane 1 no ko roll rolename
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    //asp identityRole vanne table ma add garxa role name lai 
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }



        }  
    }
}
