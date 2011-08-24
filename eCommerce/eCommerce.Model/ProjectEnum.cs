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
    }
}
