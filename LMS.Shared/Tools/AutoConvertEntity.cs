namespace LMS.Shared.Tools {
    public static class AutoConvertEntity {

        public static EntityTo Convert<EntityFrom, EntityTo>(EntityFrom from, EntityTo to) {

            if (from == null || to == null)
                throw new Exception("From/To entity is null.");

            var fromProperties = from.GetType().GetProperties();

            foreach(var fromProperty in fromProperties) {

                var value = fromProperty.GetValue(from);
                var toProperty = to.GetType().GetProperty(fromProperty.Name);

                if (toProperty != null)
                    toProperty.SetValue(to, value);

            }

            return to;

        }

    }
}
