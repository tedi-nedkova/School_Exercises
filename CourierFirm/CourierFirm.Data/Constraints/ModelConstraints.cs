namespace CourierFirm.Data.Constraints
{
    public static class ModelConstraints
    {
        public static class CustomerConstraints
        {
            public const int FirstNameMaxLength = 100;
            public const int LastNameMaxLength = 100;
            public const int EmailMaxLength = 90;
            public const int PhoneMaxLength = 15;
        }

        public static class CourierConstraints
        {
            public const int NameMaxLength = 100;
        }

        public static class PackageConstraints
        {
            public const int TrackingNumberMaxLength = 50;
            public const int WeightInKgMin = 1;
            public const int WeightInKgMax = 1000;
        }

        public static class DeliveryRouteConstraints
        {
            public const int LocationMaxLength = 200;
        }

        public static class OfficeConstraints
        {
            public const int LocationMaxLength = 200;
        }

        public static class VehicleConstraints
        {
            public const int PlateNumberMaxLength = 50;
            public const int ModelMaxLength = 70;
            public const int TypeMaxLength = 30;
        }
    }
}
