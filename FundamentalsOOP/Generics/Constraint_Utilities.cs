using System;

namespace Generics
{
    // where T : IComparable
    // where T : Product (class e subclass)
    // where T : struct (value type)
    // where T : class (reference type)
    // whete T : new() (object that has a default constructor)

    public class Constraint_Utilities<T> where T : IComparable, new()
    {
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();
        }
    }

    public class DiscountCalculator<T> where T : Product //T = Product ou Book
    {
        public float Calculate(T product)
        {
            return product.Price;
        }
    }

    public class Nullable<T> where T : struct
    {// esta classe tem a capacidade de permitir que um tipo de valor seja null

        private object _value;

        public Nullable()
        {

        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }

    }
}
