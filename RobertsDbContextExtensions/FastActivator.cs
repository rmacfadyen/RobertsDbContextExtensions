namespace RobertsDbContextExtensions
{
    internal class FastActivator<T>
    {
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }

    internal class FastActivator
    {
        public static Func<object> Instance(Type TypeOfT)
        {
            return Expression.Lambda<Func<object>>(Expression.New(TypeOfT)).Compile();
        }
    }
}
