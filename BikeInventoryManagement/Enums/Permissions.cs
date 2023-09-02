namespace BikeInventoryManagement.Enums
{
    public static class Permissions
    {
        public enum Permission
        {
            Admin,
            Manager,
            DataEntry,
            Viewer
        }

        public static List<string> PermissionsToStringList()
        {
            var list = Enum.GetValues(typeof(Permission));
            List<string> ret = new List<string>();

            foreach(Permission perm in list)
            {
                ret.Add(perm.ToString());
            }

            return ret;
        }
    }
}
