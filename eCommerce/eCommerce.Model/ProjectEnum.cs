namespace eCommerce.Model
{
    public class ProjectEnum
    {
        public enum Payment
        {
            Paypay = 1,
            NganLuong = 2,
            Tradition = 3
        }

        public enum OrderState
        {
            New = 1,
            Processing = 2,
            Finish = 3
        }

        public enum Role
        {
            SuperAdmin = 1,
            SaleManage = 2,
            FoodManage = 3,
            CustommerManage = 4
        }

        public static string PrintRole(int role)
        {
            string s = null;

            if (role == (int)ProjectEnum.Role.SuperAdmin)
            {
                s = "Super Administrator";
            }
            else if (role == (int)ProjectEnum.Role.SaleManage)
            {
                s = "Sale Manager";
            }
            else if (role == (int)Role.FoodManage)
            {
                s = "Food Manager";
            }
            else if (role == (int)Role.CustommerManage)
            {
                s = "Custommer Manager";
            }
            return s;
        }
    }
}
